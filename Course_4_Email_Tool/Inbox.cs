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

namespace Course_4_Email_Tool
{
	public partial class Inbox : Form
	{
		private readonly ImapClient _ic;
		private readonly EmailConfiguration _emailConfiguration;

		public Inbox(ImapClient ic, EmailConfiguration ec)
		{
			InitializeComponent();
			_ic = ic;
			_emailConfiguration = ec;

			Label_LoggedInAs.Text = ec.ImapUsername;
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
			Form write = new Write(_ic,_emailConfiguration);
			write.Show();
			write.Location = this.Location;
			write.StartPosition = FormStartPosition.Manual;
			write.Show();
		}
	}
}