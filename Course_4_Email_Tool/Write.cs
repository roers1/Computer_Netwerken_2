using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailKit.Net.Imap;


namespace Course_4_Email_Tool
{
	public partial class Write : Form
	{
		private readonly ImapClient _ic;
		private SmtpClient _sc;
		private readonly EmailConfiguration _emailConfiguration;

		public Write(ImapClient ic, EmailConfiguration ec)
		{
			InitializeComponent();
			_ic = ic;
			_emailConfiguration = ec;

			Label_LoggedInAs.Text = ec.ImapUsername;
			textBox_from.Text = ec.ImapUsername;
		}

		private void button_send_Click(object sender, EventArgs e)
		{
			label_status.Text = "Sending mail...";
			try
			{
				MailMessage mail = new MailMessage();
				_sc = new SmtpClient(_emailConfiguration.SmtpServer);
				mail.From = new MailAddress(_emailConfiguration.SmtpUsername, _emailConfiguration.DisplayName);
				mail.To.Add(new MailAddress(textBox_to.Text));
				mail.Subject = textBox_subject.Text;
				mail.Body = textBox_message.Text;

				if (textBox_attachment.Text != "")
				{
					System.Net.Mail.Attachment attachment;
					attachment = new System.Net.Mail.Attachment(textBox_attachment.Text);
					mail.Attachments.Add(attachment);
				}

				_sc.Port = _emailConfiguration.SmtpPort;
				_sc.Credentials = new System.Net.NetworkCredential(_emailConfiguration.SmtpUsername,
					_emailConfiguration.SmtpPassword);
				_sc.EnableSsl = true;
				_sc.Send(mail);
				this.Close();
			}
			catch (Exception ex)
			{
				label_status.Text = ex.Message;
			}
		}

		private void button_AddAttachment_Click(object sender, EventArgs e)
		{
			openFileDialog1.ShowDialog();
			textBox_attachment.Text = openFileDialog1.FileName;
		}
	}
}