using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AsynchronousSocket
{
	public partial class frmDetail : Form
	{
		public frmDetail(List<MyUser> data)
		{
			InitializeComponent();
			myUserBindingSource.DataSource = data;
		}
	}
}
