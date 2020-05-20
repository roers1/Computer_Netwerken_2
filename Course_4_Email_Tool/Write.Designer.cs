namespace Course_4_Email_Tool
{
	partial class Write
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Label_LoggedInAs = new System.Windows.Forms.Label();
			this.Label_LoggedUser = new System.Windows.Forms.Label();
			this.label_from = new System.Windows.Forms.Label();
			this.label_To = new System.Windows.Forms.Label();
			this.label_subject = new System.Windows.Forms.Label();
			this.button_send = new System.Windows.Forms.Button();
			this.textBox_from = new System.Windows.Forms.TextBox();
			this.textBox_to = new System.Windows.Forms.TextBox();
			this.textBox_subject = new System.Windows.Forms.TextBox();
			this.label_message = new System.Windows.Forms.Label();
			this.label_attachment = new System.Windows.Forms.Label();
			this.textBox_attachment = new System.Windows.Forms.TextBox();
			this.button_AddAttachment = new System.Windows.Forms.Button();
			this.label_status = new System.Windows.Forms.Label();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.textBox_message = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// Label_LoggedInAs
			// 
			this.Label_LoggedInAs.AutoSize = true;
			this.Label_LoggedInAs.Location = new System.Drawing.Point(90, 9);
			this.Label_LoggedInAs.Name = "Label_LoggedInAs";
			this.Label_LoggedInAs.Size = new System.Drawing.Size(35, 13);
			this.Label_LoggedInAs.TabIndex = 3;
			this.Label_LoggedInAs.Text = "NULL";
			// 
			// Label_LoggedUser
			// 
			this.Label_LoggedUser.AutoSize = true;
			this.Label_LoggedUser.Location = new System.Drawing.Point(12, 9);
			this.Label_LoggedUser.Name = "Label_LoggedUser";
			this.Label_LoggedUser.Size = new System.Drawing.Size(71, 13);
			this.Label_LoggedUser.TabIndex = 2;
			this.Label_LoggedUser.Text = "Logged in as:";
			// 
			// label_from
			// 
			this.label_from.AutoSize = true;
			this.label_from.Location = new System.Drawing.Point(90, 40);
			this.label_from.Name = "label_from";
			this.label_from.Size = new System.Drawing.Size(33, 13);
			this.label_from.TabIndex = 4;
			this.label_from.Text = "From:";
			// 
			// label_To
			// 
			this.label_To.AutoSize = true;
			this.label_To.Location = new System.Drawing.Point(90, 66);
			this.label_To.Name = "label_To";
			this.label_To.Size = new System.Drawing.Size(23, 13);
			this.label_To.TabIndex = 5;
			this.label_To.Text = "To:";
			// 
			// label_subject
			// 
			this.label_subject.AutoSize = true;
			this.label_subject.Location = new System.Drawing.Point(90, 92);
			this.label_subject.Name = "label_subject";
			this.label_subject.Size = new System.Drawing.Size(46, 13);
			this.label_subject.TabIndex = 6;
			this.label_subject.Text = "Subject:";
			// 
			// button_send
			// 
			this.button_send.Location = new System.Drawing.Point(15, 37);
			this.button_send.Name = "button_send";
			this.button_send.Size = new System.Drawing.Size(75, 68);
			this.button_send.TabIndex = 7;
			this.button_send.Text = "Send";
			this.button_send.UseVisualStyleBackColor = true;
			this.button_send.Click += new System.EventHandler(this.button_send_Click);
			// 
			// textBox_from
			// 
			this.textBox_from.Enabled = false;
			this.textBox_from.Location = new System.Drawing.Point(142, 37);
			this.textBox_from.Name = "textBox_from";
			this.textBox_from.Size = new System.Drawing.Size(355, 20);
			this.textBox_from.TabIndex = 8;
			// 
			// textBox_to
			// 
			this.textBox_to.Location = new System.Drawing.Point(142, 63);
			this.textBox_to.Name = "textBox_to";
			this.textBox_to.Size = new System.Drawing.Size(355, 20);
			this.textBox_to.TabIndex = 9;
			// 
			// textBox_subject
			// 
			this.textBox_subject.Location = new System.Drawing.Point(142, 89);
			this.textBox_subject.Name = "textBox_subject";
			this.textBox_subject.Size = new System.Drawing.Size(355, 20);
			this.textBox_subject.TabIndex = 10;
			// 
			// label_message
			// 
			this.label_message.AutoSize = true;
			this.label_message.Location = new System.Drawing.Point(90, 130);
			this.label_message.Name = "label_message";
			this.label_message.Size = new System.Drawing.Size(53, 13);
			this.label_message.TabIndex = 12;
			this.label_message.Text = "Message:";
			// 
			// label_attachment
			// 
			this.label_attachment.AutoSize = true;
			this.label_attachment.Location = new System.Drawing.Point(503, 37);
			this.label_attachment.Name = "label_attachment";
			this.label_attachment.Size = new System.Drawing.Size(64, 13);
			this.label_attachment.TabIndex = 13;
			this.label_attachment.Text = "Attachment:";
			// 
			// textBox_attachment
			// 
			this.textBox_attachment.Enabled = false;
			this.textBox_attachment.Location = new System.Drawing.Point(573, 37);
			this.textBox_attachment.Name = "textBox_attachment";
			this.textBox_attachment.Size = new System.Drawing.Size(215, 20);
			this.textBox_attachment.TabIndex = 14;
			// 
			// button_AddAttachment
			// 
			this.button_AddAttachment.Location = new System.Drawing.Point(713, 66);
			this.button_AddAttachment.Name = "button_AddAttachment";
			this.button_AddAttachment.Size = new System.Drawing.Size(75, 23);
			this.button_AddAttachment.TabIndex = 15;
			this.button_AddAttachment.Text = "Add";
			this.button_AddAttachment.UseVisualStyleBackColor = true;
			this.button_AddAttachment.Click += new System.EventHandler(this.button_AddAttachment_Click);
			// 
			// label_status
			// 
			this.label_status.AutoSize = true;
			this.label_status.Location = new System.Drawing.Point(420, 411);
			this.label_status.Name = "label_status";
			this.label_status.Size = new System.Drawing.Size(0, 13);
			this.label_status.TabIndex = 16;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// textBox_message
			// 
			this.textBox_message.Location = new System.Drawing.Point(142, 130);
			this.textBox_message.Multiline = true;
			this.textBox_message.Name = "textBox_message";
			this.textBox_message.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_message.Size = new System.Drawing.Size(638, 267);
			this.textBox_message.TabIndex = 17;
			// 
			// Write
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.textBox_message);
			this.Controls.Add(this.label_status);
			this.Controls.Add(this.button_AddAttachment);
			this.Controls.Add(this.textBox_attachment);
			this.Controls.Add(this.label_attachment);
			this.Controls.Add(this.label_message);
			this.Controls.Add(this.textBox_subject);
			this.Controls.Add(this.textBox_to);
			this.Controls.Add(this.textBox_from);
			this.Controls.Add(this.button_send);
			this.Controls.Add(this.label_subject);
			this.Controls.Add(this.label_To);
			this.Controls.Add(this.label_from);
			this.Controls.Add(this.Label_LoggedInAs);
			this.Controls.Add(this.Label_LoggedUser);
			this.Name = "Write";
			this.Text = "Write";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label Label_LoggedInAs;
		private System.Windows.Forms.Label Label_LoggedUser;
		private System.Windows.Forms.Label label_from;
		private System.Windows.Forms.Label label_To;
		private System.Windows.Forms.Label label_subject;
		private System.Windows.Forms.Button button_send;
		private System.Windows.Forms.TextBox textBox_from;
		private System.Windows.Forms.TextBox textBox_to;
		private System.Windows.Forms.TextBox textBox_subject;
		private System.Windows.Forms.Label label_message;
		private System.Windows.Forms.Label label_attachment;
		private System.Windows.Forms.TextBox textBox_attachment;
		private System.Windows.Forms.Button button_AddAttachment;
		private System.Windows.Forms.Label label_status;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.TextBox textBox_message;
	}
}