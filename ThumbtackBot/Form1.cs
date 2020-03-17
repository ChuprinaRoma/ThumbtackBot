using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThumbtackBot.Service;

namespace ThumbtackBot
{
    public partial class Form1 : Form
    {
        private ManagerThumbtack managerThumbtack = null;
        private string typeMiles { get; set; }

        public Form1()
        {
            InitializeComponent();
            managerThumbtack = new ManagerThumbtack();
            five.CheckedChanged += CheckedMiles;
            twentyFive.CheckedChanged += CheckedMiles;
            fifty.CheckedChanged += CheckedMiles;
            oneHundred.CheckedChanged += CheckedMiles;
            oneHundredFifty.CheckedChanged += CheckedMiles;
            startBtn.Click += Start;
            stopBtn.Click += Stop;
            typeMiles = fifty.Text;
        }

        private void Stop(object sender, EventArgs e)
        {
            managerThumbtack.StopBot();
        }

        private async void Start(object sender, EventArgs e)
        {
            if (DateTime.Now.Year == 2020 && DateTime.Now.Month == 3 && DateTime.Now.Day <= 31)
            {
                await Task.Run(() => managerThumbtack.StartBot(typeMiles, loginT.Text, passwordT.Text, messageT.Text, estimateT.Text));
            }
        }

        private void CheckedMiles(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if(radioButton.Checked)
            {
                typeMiles = radioButton.Text;
            }
        }
    }
}