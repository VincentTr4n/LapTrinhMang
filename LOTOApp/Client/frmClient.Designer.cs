namespace Client
{
	partial class frmClient
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
			this.txIpAddress = new System.Windows.Forms.TextBox();
			this.txPort = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btCon = new System.Windows.Forms.Button();
			this.btDis = new System.Windows.Forms.Button();
			this.lstContent = new System.Windows.Forms.ListBox();
			this.txMess = new System.Windows.Forms.TextBox();
			this.btSend = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(51, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "IP Server";
			// 
			// txIpAddress
			// 
			this.txIpAddress.Location = new System.Drawing.Point(69, 12);
			this.txIpAddress.Name = "txIpAddress";
			this.txIpAddress.Size = new System.Drawing.Size(142, 20);
			this.txIpAddress.TabIndex = 1;
			// 
			// txPort
			// 
			this.txPort.Location = new System.Drawing.Point(254, 12);
			this.txPort.Name = "txPort";
			this.txPort.Size = new System.Drawing.Size(64, 20);
			this.txPort.TabIndex = 3;
			this.txPort.Text = "9090";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(222, 15);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(26, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Port";
			// 
			// btCon
			// 
			this.btCon.Location = new System.Drawing.Point(324, 10);
			this.btCon.Name = "btCon";
			this.btCon.Size = new System.Drawing.Size(75, 23);
			this.btCon.TabIndex = 4;
			this.btCon.Text = "Connect";
			this.btCon.UseVisualStyleBackColor = true;
			this.btCon.Click += new System.EventHandler(this.btCon_Click);
			// 
			// btDis
			// 
			this.btDis.Location = new System.Drawing.Point(405, 10);
			this.btDis.Name = "btDis";
			this.btDis.Size = new System.Drawing.Size(75, 23);
			this.btDis.TabIndex = 5;
			this.btDis.Text = "Disconnect";
			this.btDis.UseVisualStyleBackColor = true;
			this.btDis.Click += new System.EventHandler(this.btDis_Click);
			// 
			// lstContent
			// 
			this.lstContent.FormattingEnabled = true;
			this.lstContent.Location = new System.Drawing.Point(15, 41);
			this.lstContent.Name = "lstContent";
			this.lstContent.Size = new System.Drawing.Size(465, 238);
			this.lstContent.TabIndex = 6;
			// 
			// txMess
			// 
			this.txMess.Location = new System.Drawing.Point(15, 285);
			this.txMess.Multiline = true;
			this.txMess.Name = "txMess";
			this.txMess.Size = new System.Drawing.Size(396, 39);
			this.txMess.TabIndex = 7;
			// 
			// btSend
			// 
			this.btSend.Location = new System.Drawing.Point(417, 285);
			this.btSend.Name = "btSend";
			this.btSend.Size = new System.Drawing.Size(63, 23);
			this.btSend.TabIndex = 8;
			this.btSend.Text = "Send";
			this.btSend.UseVisualStyleBackColor = true;
			this.btSend.Click += new System.EventHandler(this.btSend_Click);
			// 
			// frmClient
			// 
			this.AcceptButton = this.btSend;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(490, 335);
			this.Controls.Add(this.btSend);
			this.Controls.Add(this.txMess);
			this.Controls.Add(this.lstContent);
			this.Controls.Add(this.btDis);
			this.Controls.Add(this.btCon);
			this.Controls.Add(this.txPort);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txIpAddress);
			this.Controls.Add(this.label1);
			this.Name = "frmClient";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txIpAddress;
		private System.Windows.Forms.TextBox txPort;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btCon;
		private System.Windows.Forms.Button btDis;
		private System.Windows.Forms.ListBox lstContent;
		private System.Windows.Forms.TextBox txMess;
		private System.Windows.Forms.Button btSend;
	}
}

