using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Client
{
	public partial class frmClient : Form
	{
		byte[] buffer = new byte[1024];
		Socket client;
		static string phone = "";
		public frmClient()
		{
			InitializeComponent();
			CheckForIllegalCrossThreadCalls = false;
			txIpAddress.Text = IPAddress.Loopback.ToString();
		}
		void Connect()
		{
			client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			try
			{
				IPEndPoint iep = new IPEndPoint(IPAddress.Parse(txIpAddress.Text), int.Parse(txPort.Text));
				client.BeginConnect(iep, new AsyncCallback(ConnectCallBack), client);
				client.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), client);
				//client.Connect(iep);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void ConnectCallBack(IAsyncResult ar)
		{
			Socket socket = (Socket)ar.AsyncState;
			socket.EndConnect(ar);
			SendData("[.]");
		}

		private void btCon_Click(object sender, EventArgs e)
		{
			frmPhone frm = new frmPhone();
			if (frm.ShowDialog() == DialogResult.OK)
			{
				phone = frm.txPhone;
				Connect();
				lstContent.Items.Clear();
			}
		}

		private void ReceiveCallBack(IAsyncResult ar)
		{
			try
			{
				Socket socket = (Socket)ar.AsyncState;
				if(socket.Connected)
				{
					int rec = socket.EndReceive(ar);

					string res = Encoding.ASCII.GetString(buffer, 0, rec);
					lstContent.Items.Add("Server : " + res);

					socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), socket);
				}
			}
			catch(SocketException ex)
			{
				MessageBox.Show(ex.ToString());
			}
			
		}

		private void btSend_Click(object sender, EventArgs e)
		{
			SendData(phone+" "+txMess.Text);
			lstContent.Items.Add("Me: " + txMess.Text);
			txMess.Text = null;
		}

		private void SendCallBack(IAsyncResult ar)
		{
			Socket socket = (Socket)ar.AsyncState;
			socket.EndSend(ar);
		}

		void SendData(string content)
		{
			var data = Encoding.ASCII.GetBytes(content);
			client.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallBack), client);
		}

		private void btDis_Click(object sender, EventArgs e)
		{
			client.Close();
		}
	}
}
