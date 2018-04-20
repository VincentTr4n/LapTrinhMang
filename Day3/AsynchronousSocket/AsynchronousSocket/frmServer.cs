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


namespace AsynchronousSocket
{
	public partial class frmServer : Form
	{
		byte[] buffer = new byte[1 << 10];
		Socket server;

		public frmServer()
		{
			InitializeComponent();
			CheckForIllegalCrossThreadCalls = false;
		}

		private void frmServer_Load(object sender, EventArgs e)
		{
			SetupServer();
		}
		void SetupServer()
		{
			server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			IPEndPoint ipe = new IPEndPoint(IPAddress.Any, 9090);
			txIPServer.Text = IPAddress.Any + "";
			txPort.Text = 9090+"";

			server.Bind(ipe);
			server.Listen(10);

			server.BeginAccept(new AsyncCallback(AcceptCallBack), null);			// Bắt đầu lắng nghe kết nối
		}

		private void AcceptCallBack(IAsyncResult ar)
		{
			var client = server.EndAccept(ar);
			txIPClient.Text = client.RemoteEndPoint+"";

			client.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), client);            // Bắt đầu nhận dữ liệu từ client đã kết nối
		}

		private void ReceiveCallBack(IAsyncResult ar)
		{
			Socket client = ar.AsyncState as Socket;
			try
			{
				if (client.Connected)
				{
					int rec;
					try
					{
						rec = client.EndReceive(ar);
					}
					catch (SocketException ex)
					{
						MessageBox.Show(ex.ToString());
						return;
					}

					if (rec > 0)
					{
						string data = Encoding.ASCII.GetString(buffer, 0, rec);
						var temp = data.Split(':');
						if (temp[0] == "sum")
						{
							int a = int.Parse(temp[1].Split(' ')[0]);
							int b = int.Parse(temp[1].Split(' ')[0]);

							sendData(client, (a + b).ToString());
						}
						else if (temp[0] == "[.]")
						{
							sendData(client, "Accepted!");
						}
						else
						{
							var info = client.RemoteEndPoint as IPEndPoint;
							lstContent.Items.Add(info.Address + " : " + data);
							sendData(client,"Received!");
						}
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			client.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), client);
		}

		private void sendData(Socket socket, string content)
		{
			byte[] data = Encoding.ASCII.GetBytes(content);
			socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);
		}

		private void SendCallback(IAsyncResult ar)
		{
			Socket socket = (Socket)ar.AsyncState;
			socket.EndSend(ar);
		}
	}
}
