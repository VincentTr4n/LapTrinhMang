using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
	public partial class frmSend : Form
	{
		Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		string txtSendFile;
		public frmSend(Socket socket,string fileName)
		{
			InitializeComponent();
			client = socket;
			txtSendFile = fileName;
		}

		private void frmSend_Load(object sender, EventArgs e)
		{
			FileStream fs = null;

			client.NoDelay = true;

			bool bSendOk = true;

			label1.Text = "Sending file \"" + txtSendFile + "\"";

			Application.DoEvents();

			try
			{
				FileInfo fi = new FileInfo(txtSendFile);
				ulong fileSize = (ulong)fi.Length;

				progressBar1.Minimum = 0;
				progressBar1.Maximum = 1000;
				Application.DoEvents();

				byte[] buf = new byte[32 * 1024];
				MemoryStream ms = new MemoryStream(buf);
				BinaryWriter bw = new BinaryWriter(ms);
				bw.Write(fileSize);
				bw.Close();
				ms.Close();

				fs = File.OpenRead(txtSendFile);

				int ns = client.Send(buf, sizeof(ulong), SocketFlags.None);
				ulong pos = 0;

				Thread.Sleep(1000);
				while (pos < fileSize)
				{
					int nr = fs.Read(buf, 0, buf.Length);
					if (nr <= 0)
					{
						break;
					}

					pos += (ulong)nr;
					ns = client.Send(buf, nr, SocketFlags.None);

					Thread.Sleep(1000);
					progressBar1.Value = (int)(((double)progressBar1.Maximum * (double)pos) / (double)fileSize + 0.5);
					Application.DoEvents();
				}

			}
			catch (Exception ex)
			{
				bSendOk = false;
				MessageBox.Show(ex.Message, "File Sending Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}



			if (fs != null)
			{
				try { fs.Close(); }
				catch (Exception) { }
			}

			if (bSendOk)
			{
				MessageBox.Show("Send complete !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
				this.Close();
			}
		}
	}
}
