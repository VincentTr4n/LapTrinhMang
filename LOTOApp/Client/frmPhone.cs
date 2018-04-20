using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
	public partial class frmPhone : Form
	{
		public string txPhone { get; set; }
		public frmPhone()
		{
			InitializeComponent();
			textBox1.KeyPress += (o, e) => { if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b') e.Handled = true; };
			this.FormClosing += (o, e) => {
				if (string.IsNullOrEmpty(textBox1.Text) && textBox1.Text.Length < 10)
				{
					MessageBox.Show("Please enter phone number");
					e.Cancel = true;
				}
				else txPhone = textBox1.Text;
			};
		}
	}
}
