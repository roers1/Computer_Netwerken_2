using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailKit.Net.Imap;

namespace Course_4_Email_Tool
{
	public partial class Settings : Form
	{
		private readonly ImapClient _ic;
		private readonly EmailConfiguration _emailConfiguration;
		public Settings(ImapClient ic, EmailConfiguration ec)
		{
			InitializeComponent();
			_ic = ic;
			_emailConfiguration = ec;

			textBox_DisplayName.Text = "Ruben van Oers"; //_emailConfiguration.DisplayName;
			textBox_IMAP_Host.Text = _emailConfiguration.ImapServer;
			textBox_IMAP_Port.Text = _emailConfiguration.ImapPort.ToString();
			textBox_SMTP_Host.Text = "smtp.gmail.com"; //_emailConfiguration.SmtpServer;
			textBox_SMTP_Port.Text = 587.ToString(); //_emailConfiguration.SmtpPort.ToString();
		}

		private void button_save_Click(object sender, EventArgs e)
		{
			_emailConfiguration.DisplayName = textBox_DisplayName.Text;
			_emailConfiguration.ImapServer = textBox_IMAP_Host.Text;
			_emailConfiguration.ImapPort = Int32.Parse(textBox_IMAP_Port.Text);
			_emailConfiguration.SmtpServer = textBox_SMTP_Host.Text;
			_emailConfiguration.SmtpPort = Int32.Parse(textBox_SMTP_Port.Text);

			Inbox();
		}

		private void button_back_Click(object sender, EventArgs e)
		{
			Inbox();
		}

		private void Inbox()
		{
			Form inbox = new Inbox(_ic, _emailConfiguration);
			inbox.Show();
			inbox.Location = this.Location;
			inbox.StartPosition = FormStartPosition.Manual;
			inbox.Show();
			this.Close();
		}
	}
}
