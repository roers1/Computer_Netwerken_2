using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Security;
using Org.BouncyCastle.Utilities;

namespace Course_4_Email_Tool
{
	public partial class Login : Form
	{
		private readonly ImapClient _ic;
		private readonly EmailConfiguration _emailConfiguration;
		public Login()
		{
			InitializeComponent();
			_ic = new ImapClient();
			_emailConfiguration = new EmailConfiguration();
		}

		public Login(ImapClient ic, EmailConfiguration ec)
		{
			InitializeComponent();
			_ic = ic;
			_emailConfiguration = ec;
		}

		private void btn_Login_Click(object sender, EventArgs e)
		{
			_emailConfiguration.ImapServer = textBox_Host.Text;
			_emailConfiguration.ImapUsername = textBox_Email.Text;
			_emailConfiguration.ImapPassword = textBox_Password.Text;
			_emailConfiguration.SmtpUsername = textBox_Email.Text;
			_emailConfiguration.SmtpPassword = textBox_Password.Text;
			_emailConfiguration.ImapPort = Int32.Parse(textBox_Port.Text);

			_ic.Connect(_emailConfiguration.ImapServer,_emailConfiguration.ImapPort, SecureSocketOptions.SslOnConnect);
			_ic.Authenticate(_emailConfiguration.ImapUsername,_emailConfiguration.ImapPassword);

			Form inbox = new Inbox(_ic,_emailConfiguration);
			inbox.Show();
			inbox.Location = this.Location;
			inbox.StartPosition = FormStartPosition.Manual;
			inbox.Show();
			this.Close();
		}
	}
}
