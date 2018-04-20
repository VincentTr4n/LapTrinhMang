using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;


namespace AsynchronousSocket
{
	public partial class frmServer : Form
	{
		byte[] buffer = new byte[1 << 10];
		static List<MyUser> mlist = new List<MyUser>();
		Socket server;

		public frmServer()
		{
			InitializeComponent();
			CheckForIllegalCrossThreadCalls = false;
			mlist.AddRange(JsonConvert.DeserializeObject<MyUser[]>(System.IO.File.ReadAllText("Data.txt")));
			FormClosing += (o, e) => {
				System.IO.File.WriteAllText("Data.txt","");
				var content = JsonConvert.SerializeObject(mlist);
				System.IO.File.WriteAllText("Data.txt",content);
			};
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
						data.Trim();
						var temp = data.Split(' ');
						if (temp[0] == "[.]")
						{
							sendData(client, "Accepted!");
						}
						else if (temp[1].ToLower() == "dk")
						{
							if (PhoneContains(temp[0])==null)
							{
								MyUser user = new MyUser() { Phone = temp[0],Total=20 };
								mlist.Add(user);
								sendData(client, "Register is successfully!");
								lstContent.Items.Add(temp[0] + " : " + "Register is successfully!");
							}
						}
						else
						{
							var user = PhoneContains(temp[0]);
							if (user != null)
							{
								if (temp[1].ToLower() == "loto")
								{
									lstContent.Items.Add(temp[0] + " : " + data.Substring(temp[0].Length));
									if (temp.Length == 2) sendData(client, "Syntax error");
									else
									{
										int n = int.Parse(temp[2]);
										if (n < 1) sendData(client, "Syntax error");
										else
										{
											if (n > user.Total) sendData(client, "Not enough money because You have " + user.Total + "$ , please add more money!");
											else
											{
												Random rnd = new Random();
												string res = "";
												for (int i = 0; i < n; i++) res += rnd.Next(0, 99) + " ";
												sendData(client,"You have "+n+" number is : " + res);
												user.Total -= n;
											}
										}
									}
								}
								else if (temp[1].ToLower() == "add")
								{
									if (temp.Length == 2) sendData(client, "Syntax error");
									else
									{
										int m = int.Parse(temp[2]);
										if (m < 0) sendData(client, "Syntax error");
										else
										{
											user.Total += m;
											sendData(client, "Add successfully!");
											lstContent.Items.Add(temp[0] + " : " + data.Substring(temp[0].Length));
										}
									}
								}
								else if (temp[1].ToLower() == "check")
								{
									sendData(client, "You have : "+user.Total+"$");
									lstContent.Items.Add(temp[0] + " : " +temp[1]);
								}
								else sendData(client, "Syntax error");
							}
							else sendData(client, "Phone number not exist!, Please send 'DK' to register!");
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
			server.BeginAccept(new AsyncCallback(AcceptCallBack), null);
		}

		private void SendCallback(IAsyncResult ar)
		{
			Socket socket = (Socket)ar.AsyncState;
			socket.EndSend(ar);
		}
		private MyUser PhoneContains(string phone)
		{
			foreach (var item in mlist)
			{
				if (phone == item.Phone) return item;
			}
			return null;
		}

		private void btnShow_Click(object sender, EventArgs e)
		{
			frmDetail frm = new frmDetail(mlist);
			frm.ShowDialog();
		}
	}
}
