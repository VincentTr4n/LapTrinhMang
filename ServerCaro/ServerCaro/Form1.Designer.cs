namespace ServerCaro
{
	partial class Form1
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
			this.label1 = new System.Windows.Forms.Label();
			this.txIPHost = new System.Windows.Forms.TextBox();
			this.txPort = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.listUser = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(51, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "IP Host";
			// 
			// txIPHost
			// 
			this.txIPHost.Enabled = false;
			this.txIPHost.Location = new System.Drawing.Point(69, 6);
			this.txIPHost.Name = "txIPHost";
			this.txIPHost.Size = new System.Drawing.Size(175, 22);
			this.txIPHost.TabIndex = 1;
			// 
			// txPort
			// 
			this.txPort.Enabled = false;
			this.txPort.Location = new System.Drawing.Point(295, 6);
			this.txPort.Name = "txPort";
			this.txPort.Size = new System.Drawing.Size(110, 22);
			this.txPort.TabIndex = 3;
			this.txPort.Text = "9090";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(257, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Port";
			// 
			// listUser
			// 
			this.listUser.FormattingEnabled = true;
			this.listUser.ItemHeight = 16;
			this.listUser.Location = new System.Drawing.Point(13, 45);
			this.listUser.Name = "listUser";
			this.listUser.Size = new System.Drawing.Size(392, 276);
			this.listUser.TabIndex = 4;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(420, 342);
			this.Controls.Add(this.listUser);
			this.Controls.Add(this.txPort);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txIPHost);
			this.Controls.Add(this.label1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txIPHost;
		private System.Windows.Forms.TextBox txPort;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListBox listUser;
	}
}

