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
using MailKit;
using MailKit.Net.Imap;
using MailKit.Security;

namespace Course_4_Email_Tool
{
	public partial class Inbox : Form
	{
		private readonly ImapClient _ic;
		private readonly EmailConfiguration _emailConfiguration;
		private int mailsToShow;

		public Inbox(ImapClient ic, EmailConfiguration ec)
		{
			InitializeComponent();
			_ic = ic;
			_emailConfiguration = ec;

			Label_LoggedInAs.Text = ec.ImapUsername;

			ic.Inbox.Open(FolderAccess.ReadOnly);

			mailsToShow = ic.Inbox.Count > 10 ? 10 : ic.Inbox.Count();

			try
			{
				var dt = new DataTable("Inbox");
				dt.Columns.Add("Subject", typeof(string));
				dt.Columns.Add("Sender", typeof(string));
				dt.Columns.Add("Body", typeof(string));
				dt.Columns.Add("Date", typeof(string));

				dataGridView1.DataSource = dt;

				for (int i = 0; i < mailsToShow; i++)
				{
					var message = ic.Inbox.GetMessage(i);
					dt.Rows.Add(new object[]
					{
						message.Subject, message.From, message.HtmlBody, message.Date.ToLocalTime()
					});
				}
			}
			catch (Exception ex)
			{
				Console.Write(ex.Message);
			}
			
		}

		private void button_settings_Click(object sender, EventArgs e)
		{
			Form settings = new Settings(_ic, _emailConfiguration);
			settings.Show();
			settings.Location = this.Location;
			settings.StartPosition = FormStartPosition.Manual;
			settings.Show();
			this.Close();
		}

		private void button_sent_Click(object sender, EventArgs e)
		{
			Form write = new Write(_ic, _emailConfiguration);
			write.Show();
			write.Location = this.Location;
			write.StartPosition = FormStartPosition.Manual;
			write.Show();
		}

		private void button_refresh_Click(object sender, EventArgs e)
		{
		}
	}
}