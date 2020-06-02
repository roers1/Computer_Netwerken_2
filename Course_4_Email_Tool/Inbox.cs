using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit.Security;
using MimeKit;

namespace Course_4_Email_Tool
{
	public partial class Inbox : Form
	{
		private readonly ImapClient _ic;
		private readonly EmailConfiguration _emailConfiguration;
		private int mailsToShow;
		private DataTable dt;
		private DataTable attachmentDataTable;
		private UniqueId currentMail;

		public Inbox(ImapClient ic, EmailConfiguration ec)
		{
			InitializeComponent();
			_ic = ic;
			_emailConfiguration = ec;

			Label_LoggedInAs.Text = ec.ImapUsername;

			_ic.Inbox.Open(FolderAccess.ReadOnly);

			mailsToShow = _ic.Inbox.Count > 10 ? 10 : ic.Inbox.Count();

			try
			{
				dt = new DataTable("Inbox");
				dt.Columns.Add("Subject", typeof(string));
				dt.Columns.Add("Sender", typeof(string));
				dt.Columns.Add("Date", typeof(string));
				dt.Columns.Add("Id", typeof(string));

				dataGridView1.DataSource = dt;

				for (int i = 0; i < mailsToShow; i++)
				{
					var message = _ic.Inbox.GetMessage(i);
					dt.Rows.Add(new object[]
					{
						message.Subject, message.From, message.Date.ToLocalTime(), message.MessageId
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
			if (!_ic.Inbox.IsOpen)
			{
				_ic.Inbox.Open(FolderAccess.ReadOnly);
			}

			mailsToShow = _ic.Inbox.Count > 10 ? 10 : _ic.Inbox.Count();

			try
			{
				dt = new DataTable("Inbox");
				dt.Columns.Add("Subject", typeof(string));
				dt.Columns.Add("Sender", typeof(string));
				dt.Columns.Add("Date", typeof(string));
				dt.Columns.Add("Id", typeof(string));

				dataGridView1.DataSource = dt;

				for (int i = 0; i < mailsToShow; i++)
				{
					var message = _ic.Inbox.GetMessage(i);
					dt.Rows.Add(new object[]
					{
						message.Subject, message.From, message.Date.ToLocalTime(), message.MessageId
					});
				}
			}
			catch (Exception ex)
			{
				Console.Write(ex.Message);
			}
		}

		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= dt.Rows.Count || e.RowIndex < 0) return;

			var uids = _ic.Inbox.Search(SearchQuery.HeaderContains("Message-Id",
				dt.Rows[e.RowIndex]["Id"].ToString()));
			currentMail = uids[0];
			var message = _ic.Inbox.GetMessage(currentMail);
			webBrowser1.DocumentText = message.HtmlBody ?? message.TextBody;

			attachmentDataTable = new DataTable();
			attachmentDataTable.Columns.Add("FileName", typeof(string));
			dataGridView2.DataSource = attachmentDataTable;


			foreach (MimeEntity attachment in message.Attachments)
			{
				var fileName = attachment.ContentDisposition?.FileName ?? attachment.ContentType.Name;
				attachmentDataTable.Rows.Add(new object[] {fileName});
			}
		}

		private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			var fbd = new FolderBrowserDialog();
			DialogResult result = fbd.ShowDialog();

			if (result != DialogResult.OK || string.IsNullOrWhiteSpace(fbd.SelectedPath)) return;


			var message = _ic.Inbox.GetMessage(currentMail);
			var attachmentName = attachmentDataTable.Rows[e.RowIndex]["FileName"].ToString();

			label_download_status.Text = $"downloading {attachmentName}";

			foreach (MimeEntity attachment in message.Attachments.Where(attachment =>
				attachment.ContentDisposition?.FileName == attachmentName ||
				attachment.ContentType.Name == attachmentName))
			{
				using (var stream = File.Create(fbd.SelectedPath + $"/{attachmentName}"))
				{
					if (attachment is MessagePart)
					{
						var rfc822 = (MessagePart) attachment;

						rfc822.Message.WriteTo(stream);
					}
					else
					{
						var part = (MimePart) attachment;

						part.Content.DecodeTo(stream);
					}
				}
			}

			label_download_status.Text = "Succesfully downloaded!";
		}
	}
}