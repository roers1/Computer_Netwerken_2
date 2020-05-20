namespace Course_4_Email_Tool
{
	partial class Login
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
			this.Label_Email = new System.Windows.Forms.Label();
			this.Label_Password = new System.Windows.Forms.Label();
			this.textBox_Email = new System.Windows.Forms.TextBox();
			this.textBox_Password = new System.Windows.Forms.TextBox();
			this.Label_Host = new System.Windows.Forms.Label();
			this.textBox_Host = new System.Windows.Forms.TextBox();
			this.btn_Login = new System.Windows.Forms.Button();
			this.textBox_Port = new System.Windows.Forms.TextBox();
			this.label_Port = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// Label_Email
			// 
			this.Label_Email.AutoSize = true;
			this.Label_Email.Location = new System.Drawing.Point(239, 158);
			this.Label_Email.Name = "Label_Email";
			this.Label_Email.Size = new System.Drawing.Size(35, 13);
			this.Label_Email.TabIndex = 0;
			this.Label_Email.Text = "Email:";
			// 
			// Label_Password
			// 
			this.Label_Password.AutoSize = true;
			this.Label_Password.Location = new System.Drawing.Point(239, 191);
			this.Label_Password.Name = "Label_Password";
			this.Label_Password.Size = new System.Drawing.Size(56, 13);
			this.Label_Password.TabIndex = 1;
			this.Label_Password.Text = "Password:";
			// 
			// textBox_Email
			// 
			this.textBox_Email.Location = new System.Drawing.Point(299, 158);
			this.textBox_Email.Name = "textBox_Email";
			this.textBox_Email.Size = new System.Drawing.Size(100, 20);
			this.textBox_Email.TabIndex = 2;
			this.textBox_Email.Text = "rubenvanoers1998@gmail.com";
			// 
			// textBox_Password
			// 
			this.textBox_Password.Location = new System.Drawing.Point(299, 188);
			this.textBox_Password.Name = "textBox_Password";
			this.textBox_Password.PasswordChar = '*';
			this.textBox_Password.Size = new System.Drawing.Size(100, 20);
			this.textBox_Password.TabIndex = 3;
			this.textBox_Password.Text = "LK#8991R%";
			// 
			// Label_Host
			// 
			this.Label_Host.AutoSize = true;
			this.Label_Host.Location = new System.Drawing.Point(239, 222);
			this.Label_Host.Name = "Label_Host";
			this.Label_Host.Size = new System.Drawing.Size(32, 13);
			this.Label_Host.TabIndex = 4;
			this.Label_Host.Text = "Host:";
			// 
			// textBox_Host
			// 
			this.textBox_Host.Location = new System.Drawing.Point(299, 219);
			this.textBox_Host.Name = "textBox_Host";
			this.textBox_Host.Size = new System.Drawing.Size(100, 20);
			this.textBox_Host.TabIndex = 5;
			this.textBox_Host.Text = "imap.gmail.com";
			// 
			// btn_Login
			// 
			this.btn_Login.Location = new System.Drawing.Point(324, 278);
			this.btn_Login.Name = "btn_Login";
			this.btn_Login.Size = new System.Drawing.Size(75, 23);
			this.btn_Login.TabIndex = 6;
			this.btn_Login.Text = "Login";
			this.btn_Login.UseVisualStyleBackColor = true;
			this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
			// 
			// textBox_Port
			// 
			this.textBox_Port.Location = new System.Drawing.Point(299, 252);
			this.textBox_Port.Name = "textBox_Port";
			this.textBox_Port.Size = new System.Drawing.Size(100, 20);
			this.textBox_Port.TabIndex = 7;
			this.textBox_Port.Text = "993";
			// 
			// label_Port
			// 
			this.label_Port.AutoSize = true;
			this.label_Port.Location = new System.Drawing.Point(242, 255);
			this.label_Port.Name = "label_Port";
			this.label_Port.Size = new System.Drawing.Size(29, 13);
			this.label_Port.TabIndex = 8;
			this.label_Port.Text = "Port:";
			// 
			// Login
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.label_Port);
			this.Controls.Add(this.textBox_Port);
			this.Controls.Add(this.btn_Login);
			this.Controls.Add(this.textBox_Host);
			this.Controls.Add(this.Label_Host);
			this.Controls.Add(this.textBox_Password);
			this.Controls.Add(this.textBox_Email);
			this.Controls.Add(this.Label_Password);
			this.Controls.Add(this.Label_Email);
			this.Name = "Login";
			this.Text = "Login";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label Label_Email;
		private System.Windows.Forms.Label Label_Password;
		private System.Windows.Forms.TextBox textBox_Email;
		private System.Windows.Forms.TextBox textBox_Password;
		private System.Windows.Forms.Label Label_Host;
		private System.Windows.Forms.TextBox textBox_Host;
		private System.Windows.Forms.Button btn_Login;
		private System.Windows.Forms.TextBox textBox_Port;
		private System.Windows.Forms.Label label_Port;
	}
}

