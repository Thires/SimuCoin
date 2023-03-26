﻿using System.Windows.Forms;

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
            this.LoginButton = new System.Windows.Forms.Button();
            this.SignoutButton = new System.Windows.Forms.Button();
            this.currentCoinsLabel = new System.Windows.Forms.Label();
            this.timeLeftLabel = new System.Windows.Forms.Label();
            this.PasswordTB = new System.Windows.Forms.TextBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.iconPictureBox = new System.Windows.Forms.PictureBox();
            this.UserNameCB = new System.Windows.Forms.ComboBox();
            this.exclamationLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // LoginButton
            // 
            this.LoginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LoginButton.Location = new System.Drawing.Point(241, 105);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(97, 24);
            this.LoginButton.TabIndex = 3;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // SignoutButton
            // 
            this.SignoutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SignoutButton.Location = new System.Drawing.Point(9, 105);
            this.SignoutButton.Name = "SignoutButton";
            this.SignoutButton.Size = new System.Drawing.Size(97, 24);
            this.SignoutButton.TabIndex = 4;
            this.SignoutButton.Text = "Signout";
            this.SignoutButton.UseVisualStyleBackColor = true;
            this.SignoutButton.Click += new System.EventHandler(this.SignoutButton_Click);
            // 
            // currentCoinsLabel
            // 
            this.currentCoinsLabel.AutoSize = true;
            this.currentCoinsLabel.BackColor = System.Drawing.Color.Transparent;
            this.currentCoinsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.currentCoinsLabel.ForeColor = System.Drawing.Color.White;
            this.currentCoinsLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.currentCoinsLabel.Location = new System.Drawing.Point(72, 26);
            this.currentCoinsLabel.Name = "currentCoinsLabel";
            this.currentCoinsLabel.Size = new System.Drawing.Size(107, 25);
            this.currentCoinsLabel.TabIndex = 7;
            this.currentCoinsLabel.Text = "You Have";
            // 
            // timeLeftLabel
            // 
            this.timeLeftLabel.AutoSize = true;
            this.timeLeftLabel.BackColor = System.Drawing.Color.Transparent;
            this.timeLeftLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.timeLeftLabel.ForeColor = System.Drawing.Color.White;
            this.timeLeftLabel.Location = new System.Drawing.Point(9, 9);
            this.timeLeftLabel.Name = "timeLeftLabel";
            this.timeLeftLabel.Size = new System.Drawing.Size(191, 16);
            this.timeLeftLabel.TabIndex = 11;
            this.timeLeftLabel.Text = "Next Subscription Bonus in";
            // 
            // PasswordTB
            // 
            this.PasswordTB.Location = new System.Drawing.Point(192, 78);
            this.PasswordTB.Name = "PasswordTB";
            this.PasswordTB.PasswordChar = '*';
            this.PasswordTB.Size = new System.Drawing.Size(146, 22);
            this.PasswordTB.TabIndex = 2;
            this.PasswordTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PasswordTB_KeyDown);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.BackColor = System.Drawing.Color.Transparent;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.statusLabel.ForeColor = System.Drawing.Color.White;
            this.statusLabel.Location = new System.Drawing.Point(9, 136);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(50, 16);
            this.statusLabel.TabIndex = 17;
            this.statusLabel.Text = "Status";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.BackColor = System.Drawing.Color.Transparent;
            this.usernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.usernameLabel.ForeColor = System.Drawing.Color.White;
            this.usernameLabel.Location = new System.Drawing.Point(9, 58);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(122, 16);
            this.usernameLabel.TabIndex = 19;
            this.usernameLabel.Text = "Play.net Account";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.BackColor = System.Drawing.Color.Transparent;
            this.passwordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.passwordLabel.ForeColor = System.Drawing.Color.White;
            this.passwordLabel.Location = new System.Drawing.Point(192, 58);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(75, 16);
            this.passwordLabel.TabIndex = 21;
            this.passwordLabel.Text = "Password";
            // 
            // iconPictureBox
            // 
            this.iconPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.iconPictureBox.Image = global::SimuCoin.Properties.Resources.icon;
            this.iconPictureBox.Location = new System.Drawing.Point(192, 30);
            this.iconPictureBox.Name = "iconPictureBox";
            this.iconPictureBox.Size = new System.Drawing.Size(16, 16);
            this.iconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconPictureBox.TabIndex = 20;
            this.iconPictureBox.TabStop = false;
            this.iconPictureBox.Visible = false;
            // 
            // UserNameCB
            // 
            this.UserNameCB.FormattingEnabled = true;
            this.UserNameCB.Location = new System.Drawing.Point(9, 77);
            this.UserNameCB.Name = "UserNameCB";
            this.UserNameCB.Size = new System.Drawing.Size(146, 24);
            this.UserNameCB.TabIndex = 1;
            this.UserNameCB.SelectedIndexChanged += new System.EventHandler(this.UserNameCB_SelectedIndexChanged);
            this.UserNameCB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserNameCB_KeyDown);
            // 
            // exclamationLabel
            // 
            this.exclamationLabel.AutoSize = true;
            this.exclamationLabel.BackColor = System.Drawing.Color.Transparent;
            this.exclamationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.exclamationLabel.ForeColor = System.Drawing.Color.White;
            this.exclamationLabel.Location = new System.Drawing.Point(206, 22);
            this.exclamationLabel.Name = "exclamationLabel";
            this.exclamationLabel.Size = new System.Drawing.Size(20, 29);
            this.exclamationLabel.TabIndex = 23;
            this.exclamationLabel.Text = "!";
            this.exclamationLabel.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SimuCoin.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(345, 162);
            this.Controls.Add(this.exclamationLabel);
            this.Controls.Add(this.UserNameCB);
            this.Controls.Add(this.iconPictureBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.PasswordTB);
            this.Controls.Add(this.timeLeftLabel);
            this.Controls.Add(this.currentCoinsLabel);
            this.Controls.Add(this.SignoutButton);
            this.Controls.Add(this.LoginButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
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
        private TextBox PasswordTB;
        private Label statusLabel;
        private Label usernameLabel;
        private Label passwordLabel;
        private PictureBox iconPictureBox;
        private ComboBox UserNameCB;
        private Label exclamationLabel;
    } 
}