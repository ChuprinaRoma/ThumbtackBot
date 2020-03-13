using System.Windows.Forms;

namespace ThumbtackBot
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 210);
            this.Text = "Thumbtack";

            startBtn = new Button();
            startBtn.Text = "Start bot";
            startBtn.Location = new System.Drawing.Point(65, 20);

            stopBtn = new Button();
            stopBtn.Text = "Stop bot";
            stopBtn.Location = new System.Drawing.Point(65, 50);

            five = new RadioButton();
            five.Text = "5 Miles";
            five.Location = new System.Drawing.Point(65, 100);

            twentyFive = new RadioButton();
            twentyFive.Text = "25 Miles";
            twentyFive.Location = new System.Drawing.Point(65, 120);

            fifty = new RadioButton();
            fifty.Text = "50 Miles";
            fifty.Location = new System.Drawing.Point(65, 140);

            oneHundred = new RadioButton();
            oneHundred.Text = "100 Miles";
            oneHundred.Location = new System.Drawing.Point(65, 160);

            oneHundredFifty = new RadioButton();
            oneHundredFifty.Text = "150 Miles";
            oneHundredFifty.Location = new System.Drawing.Point(65, 180);
            oneHundredFifty.Checked = true;

            Controls.Add(startBtn);
            Controls.Add(stopBtn);
            Controls.Add(five);
            Controls.Add(twentyFive);
            Controls.Add(fifty);
            Controls.Add(oneHundred);
            Controls.Add(oneHundredFifty);
        }

        #endregion

        public Button startBtn = null;
        public Button stopBtn = null;
        public RadioButton five = null;
        public RadioButton twentyFive = null;
        public RadioButton fifty = null;
        public RadioButton oneHundred = null;
        public RadioButton oneHundredFifty = null;
    }
}

