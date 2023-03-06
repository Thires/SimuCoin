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
            this.loginButton = new System.Windows.Forms.Button();
            this.signoutButton = new System.Windows.Forms.Button();
            this.currentCoinsLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.userNameTB = new System.Windows.Forms.TextBox();
            this.passwordTB = new System.Windows.Forms.TextBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.iconPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // loginButton
            // 
            this.loginButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.loginButton.Location = new System.Drawing.Point(8, 107);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(86, 24);
            this.loginButton.TabIndex = 1;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // signoutButton
            // 
            this.signoutButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.signoutButton.Location = new System.Drawing.Point(215, 107);
            this.signoutButton.Name = "signoutButton";
            this.signoutButton.Size = new System.Drawing.Size(86, 24);
            this.signoutButton.TabIndex = 3;
            this.signoutButton.Text = "Signout";
            this.signoutButton.UseVisualStyleBackColor = true;
            this.signoutButton.Click += new System.EventHandler(this.signoutButton_Click);
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
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 0;
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.BackColor = System.Drawing.Color.Transparent;
            this.timeLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.timeLabel.ForeColor = System.Drawing.Color.White;
            this.timeLabel.Location = new System.Drawing.Point(8, 9);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(206, 16);
            this.timeLabel.TabIndex = 11;
            this.timeLabel.Text = "Next Subscription Bonus in:";
            // 
            // userNameTB
            // 
            this.userNameTB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.userNameTB.Location = new System.Drawing.Point(8, 77);
            this.userNameTB.Name = "userNameTB";
            this.userNameTB.Size = new System.Drawing.Size(130, 23);
            this.userNameTB.TabIndex = 13;
            // 
            // passwordTB
            // 
            this.passwordTB.Location = new System.Drawing.Point(171, 78);
            this.passwordTB.Name = "passwordTB";
            this.passwordTB.PasswordChar = '*';
            this.passwordTB.Size = new System.Drawing.Size(130, 23);
            this.passwordTB.TabIndex = 15;
            this.passwordTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passwordTB_KeyDown);
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
            this.Controls.Add(this.passwordTB);
            this.Controls.Add(this.userNameTB);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.currentCoinsLabel);
            this.Controls.Add(this.signoutButton);
            this.Controls.Add(this.loginButton);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SimuCoins";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button loginButton;
        private Button signoutButton;
        private Label currentCoinsLabel;
        private Label label2;
        private Label timeLabel;
        private TextBox userNameTB;
        private TextBox passwordTB;
        private Label statusLabel;
        private Label usernameLabel;
        private Label passwordLabel;
        private PictureBox iconPictureBox;
    } 
}