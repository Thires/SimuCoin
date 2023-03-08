using System.Windows.Forms;

namespace SimuCoin
{
    partial class mainForm
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
            this.LoginButton = new System.Windows.Forms.Button();
            this.SignoutButton = new System.Windows.Forms.Button();
            this.currentCoinsLabel = new System.Windows.Forms.Label();
            this.timeLeftLabel = new System.Windows.Forms.Label();
            this.UserNameTB = new System.Windows.Forms.TextBox();
            this.PasswordTB = new System.Windows.Forms.TextBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.iconPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // LoginButton
            // 
            this.LoginButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LoginButton.Location = new System.Drawing.Point(8, 107);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(86, 24);
            this.LoginButton.TabIndex = 1;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // SignoutButton
            // 
            this.SignoutButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SignoutButton.Location = new System.Drawing.Point(215, 107);
            this.SignoutButton.Name = "SignoutButton";
            this.SignoutButton.Size = new System.Drawing.Size(86, 24);
            this.SignoutButton.TabIndex = 3;
            this.SignoutButton.Text = "Signout";
            this.SignoutButton.UseVisualStyleBackColor = true;
            this.SignoutButton.Click += new System.EventHandler(this.SignoutButton_Click);
            // 
            // currentCoinsLabel
            // 
            this.currentCoinsLabel.AutoSize = true;
            this.currentCoinsLabel.BackColor = System.Drawing.Color.Transparent;
            this.currentCoinsLabel.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.currentCoinsLabel.ForeColor = System.Drawing.Color.White;
            this.currentCoinsLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.currentCoinsLabel.Location = new System.Drawing.Point(64, 26);
            this.currentCoinsLabel.Name = "currentCoinsLabel";
            this.currentCoinsLabel.Size = new System.Drawing.Size(108, 25);
            this.currentCoinsLabel.TabIndex = 7;
            this.currentCoinsLabel.Text = "You have";
            // 
            // timeLeftLabel
            // 
            this.timeLeftLabel.AutoSize = true;
            this.timeLeftLabel.BackColor = System.Drawing.Color.Transparent;
            this.timeLeftLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.timeLeftLabel.ForeColor = System.Drawing.Color.White;
            this.timeLeftLabel.Location = new System.Drawing.Point(8, 9);
            this.timeLeftLabel.Name = "timeLeftLabel";
            this.timeLeftLabel.Size = new System.Drawing.Size(201, 16);
            this.timeLeftLabel.TabIndex = 11;
            this.timeLeftLabel.Text = "Next Subscription Bonus in";
            // 
            // UserNameTB
            // 
            this.UserNameTB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.UserNameTB.Location = new System.Drawing.Point(8, 77);
            this.UserNameTB.Name = "UserNameTB";
            this.UserNameTB.Size = new System.Drawing.Size(130, 23);
            this.UserNameTB.TabIndex = 13;
            this.UserNameTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserNameTB_KeyDown);
            // 
            // PasswordTB
            // 
            this.PasswordTB.Location = new System.Drawing.Point(171, 78);
            this.PasswordTB.Name = "PasswordTB";
            this.PasswordTB.PasswordChar = '*';
            this.PasswordTB.Size = new System.Drawing.Size(130, 23);
            this.PasswordTB.TabIndex = 15;
            this.PasswordTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PasswordTB_KeyDown);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.BackColor = System.Drawing.Color.Transparent;
            this.statusLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.statusLabel.ForeColor = System.Drawing.Color.White;
            this.statusLabel.Location = new System.Drawing.Point(8, 136);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(54, 16);
            this.statusLabel.TabIndex = 17;
            this.statusLabel.Text = "Status";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.BackColor = System.Drawing.Color.Transparent;
            this.usernameLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.usernameLabel.ForeColor = System.Drawing.Color.White;
            this.usernameLabel.Location = new System.Drawing.Point(8, 58);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(130, 16);
            this.usernameLabel.TabIndex = 19;
            this.usernameLabel.Text = "Play.net Account";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.BackColor = System.Drawing.Color.Transparent;
            this.passwordLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.passwordLabel.ForeColor = System.Drawing.Color.White;
            this.passwordLabel.Location = new System.Drawing.Point(171, 59);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(77, 16);
            this.passwordLabel.TabIndex = 21;
            this.passwordLabel.Text = "Password";
            // 
            // iconPictureBox
            // 
            this.iconPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.iconPictureBox.Image = global::SimuCoin.Properties.Resources.sc_icon_28_w;
            this.iconPictureBox.Location = new System.Drawing.Point(172, 28);
            this.iconPictureBox.Name = "iconPictureBox";
            this.iconPictureBox.Size = new System.Drawing.Size(23, 23);
            this.iconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconPictureBox.TabIndex = 20;
            this.iconPictureBox.TabStop = false;
            this.iconPictureBox.Visible = false;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SimuCoin.Properties.Resources.footer_bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(307, 162);
            this.Controls.Add(this.iconPictureBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.PasswordTB);
            this.Controls.Add(this.UserNameTB);
            this.Controls.Add(this.timeLeftLabel);
            this.Controls.Add(this.currentCoinsLabel);
            this.Controls.Add(this.SignoutButton);
            this.Controls.Add(this.LoginButton);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SimuCoins";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button LoginButton;
        private Button SignoutButton;
        private Label currentCoinsLabel;
        private Label timeLeftLabel;
        private TextBox UserNameTB;
        private TextBox PasswordTB;
        private Label statusLabel;
        private Label usernameLabel;
        private Label passwordLabel;
        private PictureBox iconPictureBox;
    } 
}