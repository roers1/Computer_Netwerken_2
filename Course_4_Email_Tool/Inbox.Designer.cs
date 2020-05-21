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
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Subject = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Sender = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.webBrowser1 = new System.Windows.Forms.WebBrowser();
			this.button_refresh = new System.Windows.Forms.Button();
			this.dataGridView2 = new System.Windows.Forms.DataGridView();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.label_download_status = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
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
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Subject,
            this.Sender,
            this.Date});
			this.dataGridView1.Location = new System.Drawing.Point(97, 46);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(344, 116);
			this.dataGridView1.TabIndex = 4;
			this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
			// 
			// Subject
			// 
			this.Subject.DataPropertyName = "Subject";
			this.Subject.HeaderText = "Subject";
			this.Subject.Name = "Subject";
			// 
			// Sender
			// 
			this.Sender.DataPropertyName = "Sender";
			this.Sender.HeaderText = "Sender";
			this.Sender.Name = "Sender";
			// 
			// Date
			// 
			this.Date.DataPropertyName = "Date";
			this.Date.HeaderText = "Date";
			this.Date.Name = "Date";
			// 
			// webBrowser1
			// 
			this.webBrowser1.Location = new System.Drawing.Point(16, 175);
			this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowser1.Name = "webBrowser1";
			this.webBrowser1.Size = new System.Drawing.Size(772, 263);
			this.webBrowser1.TabIndex = 5;
			// 
			// button_refresh
			// 
			this.button_refresh.Location = new System.Drawing.Point(16, 116);
			this.button_refresh.Name = "button_refresh";
			this.button_refresh.Size = new System.Drawing.Size(75, 23);
			this.button_refresh.TabIndex = 6;
			this.button_refresh.Text = "Refresh";
			this.button_refresh.UseVisualStyleBackColor = true;
			this.button_refresh.Click += new System.EventHandler(this.button_refresh_Click);
			// 
			// dataGridView2
			// 
			this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView2.Location = new System.Drawing.Point(548, 46);
			this.dataGridView2.Name = "dataGridView2";
			this.dataGridView2.Size = new System.Drawing.Size(143, 116);
			this.dataGridView2.TabIndex = 7;
			this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// label_download_status
			// 
			this.label_download_status.AutoSize = true;
			this.label_download_status.Location = new System.Drawing.Point(548, 27);
			this.label_download_status.Name = "label_download_status";
			this.label_download_status.Size = new System.Drawing.Size(13, 13);
			this.label_download_status.TabIndex = 8;
			this.label_download_status.Text = "  ";
			// 
			// Inbox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.label_download_status);
			this.Controls.Add(this.dataGridView2);
			this.Controls.Add(this.button_refresh);
			this.Controls.Add(this.webBrowser1);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.button_sent);
			this.Controls.Add(this.button_settings);
			this.Controls.Add(this.Label_LoggedInAs);
			this.Controls.Add(this.Label_LoggedUser);
			this.Name = "Inbox";
			this.Text = "Inbox";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label Label_LoggedUser;
		private System.Windows.Forms.Label Label_LoggedInAs;
		private System.Windows.Forms.Button button_settings;
		private System.Windows.Forms.Button button_sent;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Subject;
		private System.Windows.Forms.DataGridViewTextBoxColumn Sender;
		private System.Windows.Forms.DataGridViewTextBoxColumn Date;
		private System.Windows.Forms.WebBrowser webBrowser1;
		private System.Windows.Forms.Button button_refresh;
		private System.Windows.Forms.DataGridView dataGridView2;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Label label_download_status;
	}
}