using System.Windows.Forms;

namespace SimuCoin
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
            LoginButton = new Button();
            SignoutButton = new Button();
            currentCoinsLabel = new Label();
            timeLeftLabel = new Label();
            PasswordTB = new TextBox();
            statusLabel = new Label();
            usernameLabel = new Label();
            passwordLabel = new Label();
            iconPictureBox = new PictureBox();
            UserNameCB = new ComboBox();
            exclamationLabel = new Label();
            RemoveButton = new Button();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox).BeginInit();
            SuspendLayout();
            // 
            // LoginButton
            // 
            LoginButton.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            LoginButton.Location = new Point(241, 105);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(97, 24);
            LoginButton.TabIndex = 3;
            LoginButton.Text = "Login";
            LoginButton.UseVisualStyleBackColor = true;
            LoginButton.Click += LoginButton_Click;
            // 
            // SignoutButton
            // 
            SignoutButton.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            SignoutButton.Location = new Point(9, 105);
            SignoutButton.Name = "SignoutButton";
            SignoutButton.Size = new Size(97, 24);
            SignoutButton.TabIndex = 4;
            SignoutButton.Text = "Signout";
            SignoutButton.UseVisualStyleBackColor = true;
            SignoutButton.Click += SignoutButton_Click;
            // 
            // currentCoinsLabel
            // 
            currentCoinsLabel.AutoSize = true;
            currentCoinsLabel.BackColor = Color.Transparent;
            currentCoinsLabel.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            currentCoinsLabel.ForeColor = Color.White;
            currentCoinsLabel.ImageAlign = ContentAlignment.MiddleRight;
            currentCoinsLabel.Location = new Point(72, 26);
            currentCoinsLabel.Name = "currentCoinsLabel";
            currentCoinsLabel.Size = new Size(107, 25);
            currentCoinsLabel.TabIndex = 7;
            currentCoinsLabel.Text = "You Have";
            // 
            // timeLeftLabel
            // 
            timeLeftLabel.AutoSize = true;
            timeLeftLabel.BackColor = Color.Transparent;
            timeLeftLabel.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            timeLeftLabel.ForeColor = Color.White;
            timeLeftLabel.Location = new Point(9, 9);
            timeLeftLabel.Name = "timeLeftLabel";
            timeLeftLabel.Size = new Size(191, 16);
            timeLeftLabel.TabIndex = 8;
            timeLeftLabel.Text = "Next Subscription Bonus in";
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
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.BackColor = Color.Transparent;
            statusLabel.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            statusLabel.ForeColor = Color.White;
            statusLabel.Location = new Point(9, 136);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(50, 16);
            statusLabel.TabIndex = 6;
            statusLabel.Text = "Status";
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
            usernameLabel.TabIndex = 19;
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
            passwordLabel.TabIndex = 21;
            passwordLabel.Text = "Password";
            // 
            // iconPictureBox
            // 
            iconPictureBox.BackColor = Color.Transparent;
            iconPictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            iconPictureBox.Image = Properties.Resources.icon;
            iconPictureBox.Location = new Point(192, 30);
            iconPictureBox.Name = "iconPictureBox";
            iconPictureBox.Size = new Size(16, 16);
            iconPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            iconPictureBox.TabIndex = 20;
            iconPictureBox.TabStop = false;
            iconPictureBox.Visible = false;
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
            // exclamationLabel
            // 
            exclamationLabel.AutoSize = true;
            exclamationLabel.BackColor = Color.Transparent;
            exclamationLabel.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point);
            exclamationLabel.ForeColor = Color.White;
            exclamationLabel.Location = new Point(206, 22);
            exclamationLabel.Name = "exclamationLabel";
            exclamationLabel.Size = new Size(20, 29);
            exclamationLabel.TabIndex = 23;
            exclamationLabel.Text = "!";
            exclamationLabel.Visible = false;
            // 
            // RemoveButton
            // 
            RemoveButton.Location = new Point(124, 105);
            RemoveButton.Name = "RemoveButton";
            RemoveButton.Size = new Size(97, 24);
            RemoveButton.TabIndex = 5;
            RemoveButton.Text = "Remove";
            RemoveButton.UseVisualStyleBackColor = true;
            RemoveButton.Click += RemoveButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImage = Properties.Resources.background;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(345, 162);
            Controls.Add(RemoveButton);
            Controls.Add(exclamationLabel);
            Controls.Add(UserNameCB);
            Controls.Add(iconPictureBox);
            Controls.Add(passwordLabel);
            Controls.Add(usernameLabel);
            Controls.Add(statusLabel);
            Controls.Add(PasswordTB);
            Controls.Add(timeLeftLabel);
            Controls.Add(currentCoinsLabel);
            Controls.Add(SignoutButton);
            Controls.Add(LoginButton);
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
            KeyDown += MainForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)iconPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button LoginButton;
        private Button SignoutButton;
        private Label currentCoinsLabel;
        private Label timeLeftLabel;
        private TextBox PasswordTB;
        private Label statusLabel;
        private Label usernameLabel;
        private Label passwordLabel;
        private PictureBox iconPictureBox;
        private ComboBox UserNameCB;
        private Label exclamationLabel;
        private Button RemoveButton;
    }
}