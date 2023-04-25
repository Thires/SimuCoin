namespace SimuCoins
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LoginBTN = new Button();
            ClearBTN = new Button();
            coinsLBL = new Label();
            timeLBL = new Label();
            PasswordTB = new TextBox();
            statusLBL = new Label();
            usernameLabel = new Label();
            passwordLabel = new Label();
            iconPIC = new PictureBox();
            UserNameCB = new ComboBox();
            exclamationLBL = new Label();
            RemoveBTN = new Button();
            ((System.ComponentModel.ISupportInitialize)iconPIC).BeginInit();
            SuspendLayout();
            // 
            // LoginBTN
            // 
            LoginBTN.FlatAppearance.BorderSize = 0;
            LoginBTN.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            LoginBTN.Location = new Point(241, 105);
            LoginBTN.Name = "LoginBTN";
            LoginBTN.Size = new Size(97, 24);
            LoginBTN.TabIndex = 3;
            LoginBTN.Text = "Login";
            LoginBTN.UseVisualStyleBackColor = true;
            LoginBTN.Click += LoginBTN_Click;
            // 
            // ClearBTN
            // 
            ClearBTN.FlatAppearance.BorderSize = 0;
            ClearBTN.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            ClearBTN.Location = new Point(9, 105);
            ClearBTN.Name = "ClearBTN";
            ClearBTN.Size = new Size(97, 24);
            ClearBTN.TabIndex = 4;
            ClearBTN.Text = "Clear";
            ClearBTN.UseVisualStyleBackColor = true;
            ClearBTN.Click += ClearBTN_Click;
            // 
            // coinsLBL
            // 
            coinsLBL.AutoSize = true;
            coinsLBL.BackColor = Color.Transparent;
            coinsLBL.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            coinsLBL.ForeColor = Color.White;
            coinsLBL.ImageAlign = ContentAlignment.MiddleRight;
            coinsLBL.Location = new Point(59, 25);
            coinsLBL.Name = "coinsLBL";
            coinsLBL.Size = new Size(107, 25);
            coinsLBL.TabIndex = 8;
            coinsLBL.Text = "You Have";
            // 
            // timeLBL
            // 
            timeLBL.AutoSize = true;
            timeLBL.BackColor = Color.Transparent;
            timeLBL.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            timeLBL.ForeColor = Color.White;
            timeLBL.Location = new Point(9, 9);
            timeLBL.Name = "timeLBL";
            timeLBL.Size = new Size(191, 16);
            timeLBL.TabIndex = 7;
            timeLBL.Text = "Next Subscription Bonus in";
            // 
            // PasswordTB
            // 
            PasswordTB.Location = new Point(192, 78);
            PasswordTB.Name = "PasswordTB";
            PasswordTB.PasswordChar = '*';
            PasswordTB.Size = new Size(146, 22);
            PasswordTB.TabIndex = 2;
            PasswordTB.KeyDown += PasswordTB_KeyDown;
            // 
            // statusLBL
            // 
            statusLBL.AutoSize = true;
            statusLBL.BackColor = Color.Transparent;
            statusLBL.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            statusLBL.ForeColor = Color.White;
            statusLBL.Location = new Point(9, 136);
            statusLBL.Name = "statusLBL";
            statusLBL.Size = new Size(50, 16);
            statusLBL.TabIndex = 6;
            statusLBL.Text = "Status";
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.BackColor = Color.Transparent;
            usernameLabel.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            usernameLabel.ForeColor = Color.White;
            usernameLabel.Location = new Point(9, 58);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(122, 16);
            usernameLabel.TabIndex = 10;
            usernameLabel.Text = "Play.net Account";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.BackColor = Color.Transparent;
            passwordLabel.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            passwordLabel.ForeColor = Color.White;
            passwordLabel.Location = new Point(192, 58);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(75, 16);
            passwordLabel.TabIndex = 11;
            passwordLabel.Text = "Password";
            // 
            // iconPIC
            // 
            iconPIC.BackColor = Color.Transparent;
            iconPIC.BackgroundImageLayout = ImageLayout.Stretch;
            iconPIC.Image = Properties.Resources.icon;
            iconPIC.Location = new Point(179, 29);
            iconPIC.Name = "iconPIC";
            iconPIC.Size = new Size(16, 16);
            iconPIC.SizeMode = PictureBoxSizeMode.StretchImage;
            iconPIC.TabIndex = 20;
            iconPIC.TabStop = false;
            iconPIC.Visible = false;
            // 
            // UserNameCB
            // 
            UserNameCB.FormattingEnabled = true;
            UserNameCB.Location = new Point(9, 77);
            UserNameCB.Name = "UserNameCB";
            UserNameCB.Size = new Size(146, 24);
            UserNameCB.TabIndex = 1;
            UserNameCB.SelectedIndexChanged += UserNameCB_SelectedIndexChanged;
            UserNameCB.KeyDown += UserNameCB_KeyDown;
            // 
            // exclamationLBL
            // 
            exclamationLBL.AutoSize = true;
            exclamationLBL.BackColor = Color.Transparent;
            exclamationLBL.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point);
            exclamationLBL.ForeColor = Color.White;
            exclamationLBL.Location = new Point(193, 21);
            exclamationLBL.Name = "exclamationLBL";
            exclamationLBL.Size = new Size(20, 29);
            exclamationLBL.TabIndex = 9;
            exclamationLBL.Text = "!";
            exclamationLBL.Visible = false;
            // 
            // RemoveBTN
            // 
            RemoveBTN.FlatAppearance.BorderSize = 0;
            RemoveBTN.Location = new Point(124, 105);
            RemoveBTN.Name = "RemoveBTN";
            RemoveBTN.Size = new Size(97, 24);
            RemoveBTN.TabIndex = 5;
            RemoveBTN.Text = "Remove";
            RemoveBTN.UseVisualStyleBackColor = true;
            RemoveBTN.Click += RemoveBTN_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImage = Properties.Resources.background;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(345, 162);
            Controls.Add(RemoveBTN);
            Controls.Add(exclamationLBL);
            Controls.Add(UserNameCB);
            Controls.Add(iconPIC);
            Controls.Add(passwordLabel);
            Controls.Add(usernameLabel);
            Controls.Add(statusLBL);
            Controls.Add(PasswordTB);
            Controls.Add(timeLBL);
            Controls.Add(coinsLBL);
            Controls.Add(ClearBTN);
            Controls.Add(LoginBTN);
            DoubleBuffered = true;
            Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SimuCoins";
            TopMost = true;
            FormClosing += MainForm_FormClosing;
            FormClosed += MainForm_FormClosed;
            KeyDown += MainForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)iconPIC).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button LoginBTN;
        private Button ClearBTN;
        private Label coinsLBL;
        private Label timeLBL;
        private TextBox PasswordTB;
        private Label statusLBL;
        private Label usernameLabel;
        private Label passwordLabel;
        private PictureBox iconPIC;
        private ComboBox UserNameCB;
        private Label exclamationLBL;
        private Button RemoveBTN;
    }
}