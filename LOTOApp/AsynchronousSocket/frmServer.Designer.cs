namespace AsynchronousSocket
{
	partial class frmServer
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
			this.txIPServer = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txPort = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txIPClient = new System.Windows.Forms.TextBox();
			this.lstContent = new System.Windows.Forms.ListBox();
			this.btnShow = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txIPServer
			// 
			this.txIPServer.Enabled = false;
			this.txIPServer.Location = new System.Drawing.Point(76, 12);
			this.txIPServer.Name = "txIPServer";
			this.txIPServer.Size = new System.Drawing.Size(165, 20);
			this.txIPServer.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "IP Address";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(254, 15);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(26, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Port";
			// 
			// txPort
			// 
			this.txPort.Location = new System.Drawing.Point(286, 12);
			this.txPort.Name = "txPort";
			this.txPort.Size = new System.Drawing.Size(88, 20);
			this.txPort.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 41);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(46, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "IP Client";
			// 
			// txIPClient
			// 
			this.txIPClient.Location = new System.Drawing.Point(76, 38);
			this.txIPClient.Name = "txIPClient";
			this.txIPClient.Size = new System.Drawing.Size(165, 20);
			this.txIPClient.TabIndex = 4;
			// 
			// lstContent
			// 
			this.lstContent.FormattingEnabled = true;
			this.lstContent.Location = new System.Drawing.Point(15, 66);
			this.lstContent.Name = "lstContent";
			this.lstContent.Size = new System.Drawing.Size(442, 225);
			this.lstContent.TabIndex = 6;
			// 
			// btnShow
			// 
			this.btnShow.Location = new System.Drawing.Point(15, 297);
			this.btnShow.Name = "btnShow";
			this.btnShow.Size = new System.Drawing.Size(75, 24);
			this.btnShow.TabIndex = 7;
			this.btnShow.Text = "Show List";
			this.btnShow.UseVisualStyleBackColor = true;
			this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
			// 
			// frmServer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(465, 328);
			this.Controls.Add(this.btnShow);
			this.Controls.Add(this.lstContent);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txIPClient);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txPort);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txIPServer);
			this.Name = "frmServer";
			this.Text = "Server";
			this.Load += new System.EventHandler(this.frmServer_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txIPServer;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txPort;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txIPClient;
		private System.Windows.Forms.ListBox lstContent;
		private System.Windows.Forms.Button btnShow;
	}
}

