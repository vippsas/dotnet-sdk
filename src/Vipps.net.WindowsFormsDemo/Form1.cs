using System;
using System.Windows.Forms;

namespace Vipps.net.WindowsFormsDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var pollingUrl = await CheckoutSessionCreator.CreateSession();
            label1.Text = pollingUrl;
        }

        private void label1_Click(object sender, EventArgs e) { }
    }
}
