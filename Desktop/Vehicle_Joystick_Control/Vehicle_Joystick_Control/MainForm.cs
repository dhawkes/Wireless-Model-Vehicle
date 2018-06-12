using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace Vehicle_Joystick_Control
{
    public partial class MainForm : Form
    {
        // Control variables
        Gamepad joystick;
        UdpClient client;
        UdpClient goListener;
        IPEndPoint ip = new IPEndPoint(IPAddress.Parse("192.168.1.44"), 2380);
        IPEndPoint goIp = new IPEndPoint(IPAddress.Parse("192.168.1.44"), 2390);

        // Drawing variables
        Pen pen;
        Brush brush1, brush2;

        public MainForm()
        {
            // Initialize graphic components
            InitializeComponent();

            // Initialize game components
            client = new UdpClient();
            joystick = new Gamepad(1);

            // Initialize graphics components
            pen = new Pen(Color.Black);
            brush1 = new SolidBrush(Color.Blue);
            brush2 = new SolidBrush(Color.Red);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Update the joystick state, if connected
            try
            {
                joystick.LoadState();
            }
            catch
            {
                this.Text = "Joystick - DISCONNECTED";
                return;
            }

            // Update the display
            this.Text = "Joystick - Connected";
            leftStickPB.Refresh();
            rightStickPB.Refresh();
            buttonsTB.Text = joystick.Buttons();

            // Send controller data
            byte left = (byte)(100 * (joystick.Thumbsticks.Left.Y + 1));
            byte right = (byte)(100 * (joystick.Thumbsticks.Right.X + 1));
            client.SendAsync(new byte[] {left, right}, 2, ip);
        }

        private void leftStickPB_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            g.DrawEllipse(pen, g.ClipBounds);
            float lx = (g.ClipBounds.Width / 2.0f) - 4f + (g.ClipBounds.Width / 2.0f) * ((float)joystick.Thumbsticks.Left.X);
            float ly = (g.ClipBounds.Height / 2.0f) - 4f + (g.ClipBounds.Height / 2.0f) * (-(float)joystick.Thumbsticks.Left.Y);
            g.FillEllipse(brush1, lx, ly, 8.0f, 8.0f);
        }

        private void rightStickPB_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            g.DrawEllipse(pen, g.ClipBounds);
            float lx = (g.ClipBounds.Width / 2.0f) - 4f + (g.ClipBounds.Width / 2.0f) * ((float)joystick.Thumbsticks.Right.X);
            float ly = (g.ClipBounds.Height / 2.0f) - 4f + (g.ClipBounds.Height / 2.0f) * (-(float)joystick.Thumbsticks.Right.Y);
            g.FillEllipse(brush2, lx, ly, 8.0f, 8.0f);
        }

        private void goBT_Click(object sender, EventArgs e)
        {
            client.SendAsync(Encoding.ASCII.GetBytes("GO!"), 3, goIp);
        }
    }
}
