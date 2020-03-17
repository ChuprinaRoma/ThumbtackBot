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
            this.ClientSize = new System.Drawing.Size(400, 210);
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
            fifty.Checked = true;

            oneHundred = new RadioButton();
            oneHundred.Text = "100 Miles";
            oneHundred.Location = new System.Drawing.Point(65, 160);

            oneHundredFifty = new RadioButton();
            oneHundredFifty.Text = "150 Miles";
            oneHundredFifty.Location = new System.Drawing.Point(65, 180);

            loginL = new Label();
            loginL.Text = "Login";
            loginL.Location = new System.Drawing.Point(190, 20);

            loginT = new TextBox();
            loginT.PlaceholderText = "Enter login";
            loginT.Text = "";
            loginT.Location = new System.Drawing.Point(190, 43);

            passwordL = new Label();
            passwordL.Text = "Password";
            passwordL.Location = new System.Drawing.Point(190, 80);

            passwordT = new TextBox();
            passwordT.PlaceholderText = "Enter password";
            passwordT.Text = "";
            passwordT.Location = new System.Drawing.Point(190, 103);

            messageT = new TextBox();
            messageT.PlaceholderText = "Enter password";
            messageT.Text = "We can do free estimate!";
            messageT.Location = new System.Drawing.Point(190, 136);
            messageT.Height = 70;
            messageT.Width = 150;
            messageT.Multiline = true;

            estimateT = new TextBox();
            estimateT.PlaceholderText = "$";
            estimateT.Text = "1";
            estimateT.Location = new System.Drawing.Point(300, 103);
            estimateT.Width = 20;
            estimateT.KeyPress += textBox1_KeyPress;

            estimateL = new Label();
            estimateL.Text = "$";
            estimateL.Location = new System.Drawing.Point(320, 106);

            Controls.Add(startBtn);
            Controls.Add(stopBtn);
            Controls.Add(five);
            Controls.Add(twentyFive);
            Controls.Add(fifty);
            Controls.Add(oneHundred);
            Controls.Add(oneHundredFifty);
            Controls.Add(loginL);
            Controls.Add(passwordL);
            Controls.Add(loginT);
            Controls.Add(passwordT);
            Controls.Add(messageT);
            Controls.Add(estimateT);
            Controls.Add(estimateL);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        #endregion

        public Button startBtn = null;
        public Button stopBtn = null;
        public RadioButton five = null;
        public RadioButton twentyFive = null;
        public RadioButton fifty = null;
        public RadioButton oneHundred = null;
        public RadioButton oneHundredFifty = null;
        public Label loginL = null;
        public Label passwordL = null;
        public TextBox loginT = null;
        public TextBox passwordT = null;
        public TextBox messageT = null;
        public TextBox estimateT = null;
        public Label estimateL = null;
    }
}

