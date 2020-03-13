﻿using System;
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
            typeMiles = oneHundredFifty.Text;
        }

        private void Stop(object sender, EventArgs e)
        {
            managerThumbtack.StopBot();
        }

        private async void Start(object sender, EventArgs e)
        {
            await Task.Run(() => managerThumbtack.StartBot(typeMiles));
            
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