using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientCaro
{
    public partial class Form1 : Form
    {
        // Network component
        private SocketClientHelper client;
        private byte[] buffer;

        // Chess component
        private ChessHelper chessHelper;
        private Graphics graphics;

        private bool CanMakeCell = true;
        private string Player2;
        private bool connected = false;
        private int currentRun = 0;

        
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            buffer = new byte[1 << 12];

            graphics = pnBoard.CreateGraphics();

            chessHelper = new ChessHelper();
            chessHelper.graphics = graphics;

        }

        private void pnBoard_Paint(object sender, PaintEventArgs e)
        {
            chessHelper.PaintCell();
            chessHelper.PaintBoard();
        }


        bool firstTime = true;
        private void pnBoard_MouseClick(object sender, MouseEventArgs e)
        {
            if (!chessHelper.isReady) return;
            if (CanMakeCell)
            {
                if(chessHelper.MakeCell(e.X, e.Y))
                {
                    string data = "play:" + e.X + ":" + e.Y + ":" + Player2;
                    //MessageBox.Show(e.X + "-" + e.Y);
                    //MessageBox.Show(txUserName.Text + " -> " + Player2);
                    //if (firstTime)
                    //{
                    //    chessHelper.SetNewCell(e.X, e.Y);
                    //    firstTime = false;
                    //    graphics.Clear(pnBoard.BackColor);
                    //    chessHelper.PaintBoard();
                    //}
                    client.SendData(data);
                    CanMakeCell = false;
                }
            }
            //chessHelper.MakeCell(e.X, e.Y);
            //string data = "Tôi đã nhấn " + e.X + ":" + e.Y;
            //client.SendData(data);

            if (chessHelper.GameChecker()) chessHelper.EndGame();
            
        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txUserName.Text))
            {
                MessageBox.Show("Enter your user name pls!!");
                return;
            }
            try
            {
                client = new SocketClientHelper(txUserName.Text, int.Parse(txPort.Text));
                client.Connect();
                client.socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), client.socket);
                btConnect.Text = (btConnect.Text == "Connect") ? "Disconnect" : "Connect";
                connected = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ReceiveCallBack(IAsyncResult ar)
        {
            try
            {
                Socket socket = (Socket)ar.AsyncState;
                int recevied = socket.EndReceive(ar);
                string data = Encoding.ASCII.GetString(buffer, 0, recevied);

                var tmp = data.Split(':');
                if (tmp[0] == "list")
                {
                    var mlist = tmp[1].Split('\n');
                    lstUser.Items.Clear();
                    foreach (var item in mlist)
                    {
                        lstUser.Items.Add(item.Trim());
                    }
                }
                else if (tmp[0] == "request")
                {
                    Player2 = tmp[1].Trim();
                    graphics.Clear(pnBoard.BackColor);

                    currentRun = 1;
                    chessHelper.PlayerVsPlayer(1);
                    firstTime = false;
                }
                else if (tmp[0] == "accept")
                {
                    Player2 = tmp[1].Trim();
                   // MessageBox.Show("accept : "+Player2);
                    
                }
                else if (tmp[0] == "play")
                {
                    int X = int.Parse(tmp[1]);
                    int Y = int.Parse(tmp[2]);

                    if (!CanMakeCell)
                    {
                        if(chessHelper.MakeCell(X, Y))
                        {
                            //string content = "play:" + X + ":" + Y+":"+Player2;
                            
                            //client.SendData(content);
                            CanMakeCell = true;
                        }
                    }
                    if (chessHelper.GameChecker())
                    {
                        if(currentRun == chessHelper.EndGame())
                            MessageBox.Show(txUserName.Text + " is winner");
                        else MessageBox.Show(Player2 + " is winner");
                    }
                }



                buffer = new byte[1 << 12];
                client.socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), client.socket);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btPvP_Click(object sender, EventArgs e)
        {
            if (!connected)
            {
                MessageBox.Show("Please connect to server and chose a rival");
                return;
            }
            if (lstUser.SelectedItem.ToString().Trim().Equals(txUserName.Text))
            {
                MessageBox.Show("Please chose a rival");
                return;
            }

            string name = lstUser.SelectedItem.ToString().Split('|')[0];
            string request = "make_pair:" +name;
            Player2 = name + "";
            client.SendData(request);

            graphics.Clear(pnBoard.BackColor);

            chessHelper.PlayerVsPlayer(1);
            currentRun = 1;
        }
    }
}
