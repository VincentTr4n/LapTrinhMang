﻿namespace AsynchronousSocket
{
	partial class frmDetail
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
			this.components = new System.ComponentModel.Container();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.myUserBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.phoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.myUserBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.AutoGenerateColumns = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.phoneDataGridViewTextBoxColumn,
            this.totalDataGridViewTextBoxColumn});
			this.dataGridView1.DataSource = this.myUserBindingSource;
			this.dataGridView1.Location = new System.Drawing.Point(12, 32);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(295, 162);
			this.dataGridView1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "List user";
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Location = new System.Drawing.Point(232, 200);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "Back";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// myUserBindingSource
			// 
			this.myUserBindingSource.DataSource = typeof(AsynchronousSocket.MyUser);
			// 
			// phoneDataGridViewTextBoxColumn
			// 
			this.phoneDataGridViewTextBoxColumn.DataPropertyName = "Phone";
			this.phoneDataGridViewTextBoxColumn.HeaderText = "Phone";
			this.phoneDataGridViewTextBoxColumn.Name = "phoneDataGridViewTextBoxColumn";
			this.phoneDataGridViewTextBoxColumn.Width = 150;
			// 
			// totalDataGridViewTextBoxColumn
			// 
			this.totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
			this.totalDataGridViewTextBoxColumn.HeaderText = "Total";
			this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
			// 
			// frmDetail
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(320, 232);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dataGridView1);
			this.Name = "frmDetail";
			this.Text = "frmDetail";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.myUserBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGridViewTextBoxColumn phoneDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
		private System.Windows.Forms.BindingSource myUserBindingSource;
	}
}