namespace Course_4_Email_Tool
{
	partial class Inbox
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
			this.Label_LoggedUser = new System.Windows.Forms.Label();
			this.Label_LoggedInAs = new System.Windows.Forms.Label();
			this.button_settings = new System.Windows.Forms.Button();
			this.button_sent = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// Label_LoggedUser
			// 
			this.Label_LoggedUser.AutoSize = true;
			this.Label_LoggedUser.Location = new System.Drawing.Point(13, 13);
			this.Label_LoggedUser.Name = "Label_LoggedUser";
			this.Label_LoggedUser.Size = new System.Drawing.Size(71, 13);
			this.Label_LoggedUser.TabIndex = 0;
			this.Label_LoggedUser.Text = "Logged in as:";
			// 
			// Label_LoggedInAs
			// 
			this.Label_LoggedInAs.AutoSize = true;
			this.Label_LoggedInAs.Location = new System.Drawing.Point(91, 13);
			this.Label_LoggedInAs.Name = "Label_LoggedInAs";
			this.Label_LoggedInAs.Size = new System.Drawing.Size(35, 13);
			this.Label_LoggedInAs.TabIndex = 1;
			this.Label_LoggedInAs.Text = "NULL";
			// 
			// button_settings
			// 
			this.button_settings.Location = new System.Drawing.Point(16, 46);
			this.button_settings.Name = "button_settings";
			this.button_settings.Size = new System.Drawing.Size(75, 23);
			this.button_settings.TabIndex = 2;
			this.button_settings.Text = "Settings";
			this.button_settings.UseVisualStyleBackColor = true;
			this.button_settings.Click += new System.EventHandler(this.button_settings_Click);
			// 
			// button_sent
			// 
			this.button_sent.Location = new System.Drawing.Point(16, 86);
			this.button_sent.Name = "button_sent";
			this.button_sent.Size = new System.Drawing.Size(75, 23);
			this.button_sent.TabIndex = 3;
			this.button_sent.Text = "Write Email";
			this.button_sent.UseVisualStyleBackColor = true;
			this.button_sent.Click += new System.EventHandler(this.button_sent_Click);
			// 
			// Inbox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.button_sent);
			this.Controls.Add(this.button_settings);
			this.Controls.Add(this.Label_LoggedInAs);
			this.Controls.Add(this.Label_LoggedUser);
			this.Name = "Inbox";
			this.Text = "Inbox";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label Label_LoggedUser;
		private System.Windows.Forms.Label Label_LoggedInAs;
		private System.Windows.Forms.Button button_settings;
		private System.Windows.Forms.Button button_sent;
	}
}