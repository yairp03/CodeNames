
namespace Client
{
    partial class LoginForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.LoginErrorMessage_Label = new System.Windows.Forms.Label();
            this.SignupErrorMessage_Label = new System.Windows.Forms.Label();
            this.Signup_Button = new System.Windows.Forms.Button();
            this.SignupPassword_Label = new System.Windows.Forms.Label();
            this.SignupUsername_Label = new System.Windows.Forms.Label();
            this.SignupPassword_TextBox = new System.Windows.Forms.TextBox();
            this.SignupUsername_TextBox = new System.Windows.Forms.TextBox();
            this.SwitchMethod_Button = new System.Windows.Forms.Button();
            this.CredentialsVerify_Panel = new System.Windows.Forms.Panel();
            this.PasswordLegalChars_Label = new System.Windows.Forms.Label();
            this.UsernameLegalLength_Label = new System.Windows.Forms.Label();
            this.PasswordLegalLength_Label = new System.Windows.Forms.Label();
            this.PasswordVerifyLabel_Label = new System.Windows.Forms.Label();
            this.UsernameLegalChars_Label = new System.Windows.Forms.Label();
            this.UsernameVerifyLabel_Label = new System.Windows.Forms.Label();
            this.LoginSignup_Panel = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LoginUsername_TextBox = new System.Windows.Forms.TextBox();
            this.LoginPassword_TextBox = new System.Windows.Forms.TextBox();
            this.LoginUsername_Label = new System.Windows.Forms.Label();
            this.Login_Button = new System.Windows.Forms.Button();
            this.LoginPassword_Label = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ConnectionFailed_Label = new System.Windows.Forms.Label();
            this.ReloadConnect_Timer = new System.Windows.Forms.Timer(this.components);
            this.CredentialsVerify_Panel.SuspendLayout();
            this.LoginSignup_Panel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LoginErrorMessage_Label
            // 
            this.LoginErrorMessage_Label.AutoSize = true;
            this.LoginErrorMessage_Label.Font = new System.Drawing.Font("Berlin Sans FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginErrorMessage_Label.ForeColor = System.Drawing.Color.Red;
            this.LoginErrorMessage_Label.Location = new System.Drawing.Point(19, 85);
            this.LoginErrorMessage_Label.Name = "LoginErrorMessage_Label";
            this.LoginErrorMessage_Label.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LoginErrorMessage_Label.Size = new System.Drawing.Size(0, 21);
            this.LoginErrorMessage_Label.TabIndex = 6;
            // 
            // SignupErrorMessage_Label
            // 
            this.SignupErrorMessage_Label.AutoSize = true;
            this.SignupErrorMessage_Label.Font = new System.Drawing.Font("Berlin Sans FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignupErrorMessage_Label.ForeColor = System.Drawing.Color.Red;
            this.SignupErrorMessage_Label.Location = new System.Drawing.Point(19, 85);
            this.SignupErrorMessage_Label.Name = "SignupErrorMessage_Label";
            this.SignupErrorMessage_Label.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SignupErrorMessage_Label.Size = new System.Drawing.Size(0, 21);
            this.SignupErrorMessage_Label.TabIndex = 12;
            // 
            // Signup_Button
            // 
            this.Signup_Button.AutoSize = true;
            this.Signup_Button.Enabled = false;
            this.Signup_Button.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Signup_Button.Location = new System.Drawing.Point(19, 186);
            this.Signup_Button.Name = "Signup_Button";
            this.Signup_Button.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Signup_Button.Size = new System.Drawing.Size(75, 30);
            this.Signup_Button.TabIndex = 6;
            this.Signup_Button.Text = "הירשם";
            this.Signup_Button.UseVisualStyleBackColor = true;
            this.Signup_Button.Click += new System.EventHandler(this.Signup_Button_Click);
            // 
            // SignupPassword_Label
            // 
            this.SignupPassword_Label.AutoSize = true;
            this.SignupPassword_Label.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignupPassword_Label.Location = new System.Drawing.Point(127, 106);
            this.SignupPassword_Label.Name = "SignupPassword_Label";
            this.SignupPassword_Label.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SignupPassword_Label.Size = new System.Drawing.Size(49, 18);
            this.SignupPassword_Label.TabIndex = 11;
            this.SignupPassword_Label.Text = "סיסמא:";
            // 
            // SignupUsername_Label
            // 
            this.SignupUsername_Label.AutoSize = true;
            this.SignupUsername_Label.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignupUsername_Label.Location = new System.Drawing.Point(95, 30);
            this.SignupUsername_Label.Name = "SignupUsername_Label";
            this.SignupUsername_Label.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SignupUsername_Label.Size = new System.Drawing.Size(81, 18);
            this.SignupUsername_Label.TabIndex = 10;
            this.SignupUsername_Label.Text = "שם משתמש:";
            // 
            // SignupPassword_TextBox
            // 
            this.SignupPassword_TextBox.Enabled = false;
            this.SignupPassword_TextBox.Font = new System.Drawing.Font("Berlin Sans FB", 15.75F);
            this.SignupPassword_TextBox.Location = new System.Drawing.Point(19, 127);
            this.SignupPassword_TextBox.MaxLength = 16;
            this.SignupPassword_TextBox.Name = "SignupPassword_TextBox";
            this.SignupPassword_TextBox.PasswordChar = '*';
            this.SignupPassword_TextBox.Size = new System.Drawing.Size(154, 31);
            this.SignupPassword_TextBox.TabIndex = 5;
            this.SignupPassword_TextBox.TextChanged += new System.EventHandler(this.SignupPassword_TextBox_TextChanged);
            // 
            // SignupUsername_TextBox
            // 
            this.SignupUsername_TextBox.Enabled = false;
            this.SignupUsername_TextBox.Font = new System.Drawing.Font("Berlin Sans FB", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignupUsername_TextBox.Location = new System.Drawing.Point(19, 51);
            this.SignupUsername_TextBox.MaxLength = 20;
            this.SignupUsername_TextBox.Name = "SignupUsername_TextBox";
            this.SignupUsername_TextBox.Size = new System.Drawing.Size(154, 31);
            this.SignupUsername_TextBox.TabIndex = 4;
            this.SignupUsername_TextBox.TextChanged += new System.EventHandler(this.SignupUsername_TextBox_TextChanged);
            // 
            // SwitchMethod_Button
            // 
            this.SwitchMethod_Button.AutoSize = true;
            this.SwitchMethod_Button.Font = new System.Drawing.Font("Berlin Sans FB", 15.75F);
            this.SwitchMethod_Button.Location = new System.Drawing.Point(446, 109);
            this.SwitchMethod_Button.Name = "SwitchMethod_Button";
            this.SwitchMethod_Button.Size = new System.Drawing.Size(33, 33);
            this.SwitchMethod_Button.TabIndex = 3;
            this.SwitchMethod_Button.Text = "<";
            this.SwitchMethod_Button.UseVisualStyleBackColor = true;
            this.SwitchMethod_Button.Click += new System.EventHandler(this.SwitchMethod_Button_Click);
            // 
            // CredentialsVerify_Panel
            // 
            this.CredentialsVerify_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CredentialsVerify_Panel.Controls.Add(this.PasswordLegalChars_Label);
            this.CredentialsVerify_Panel.Controls.Add(this.UsernameLegalLength_Label);
            this.CredentialsVerify_Panel.Controls.Add(this.PasswordLegalLength_Label);
            this.CredentialsVerify_Panel.Controls.Add(this.PasswordVerifyLabel_Label);
            this.CredentialsVerify_Panel.Controls.Add(this.UsernameLegalChars_Label);
            this.CredentialsVerify_Panel.Controls.Add(this.UsernameVerifyLabel_Label);
            this.CredentialsVerify_Panel.Enabled = false;
            this.CredentialsVerify_Panel.Location = new System.Drawing.Point(16, 18);
            this.CredentialsVerify_Panel.Name = "CredentialsVerify_Panel";
            this.CredentialsVerify_Panel.Size = new System.Drawing.Size(151, 152);
            this.CredentialsVerify_Panel.TabIndex = 14;
            // 
            // PasswordLegalChars_Label
            // 
            this.PasswordLegalChars_Label.AutoSize = true;
            this.PasswordLegalChars_Label.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.PasswordLegalChars_Label.Location = new System.Drawing.Point(60, 97);
            this.PasswordLegalChars_Label.Name = "PasswordLegalChars_Label";
            this.PasswordLegalChars_Label.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PasswordLegalChars_Label.Size = new System.Drawing.Size(87, 18);
            this.PasswordLegalChars_Label.TabIndex = 20;
            this.PasswordLegalChars_Label.Text = "・ תווים חוקיים";
            // 
            // UsernameLegalLength_Label
            // 
            this.UsernameLegalLength_Label.AutoSize = true;
            this.UsernameLegalLength_Label.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.UsernameLegalLength_Label.Location = new System.Drawing.Point(61, 52);
            this.UsernameLegalLength_Label.Name = "UsernameLegalLength_Label";
            this.UsernameLegalLength_Label.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.UsernameLegalLength_Label.Size = new System.Drawing.Size(86, 18);
            this.UsernameLegalLength_Label.TabIndex = 19;
            this.UsernameLegalLength_Label.Text = "・ 3-20 תווים";
            // 
            // PasswordLegalLength_Label
            // 
            this.PasswordLegalLength_Label.AutoSize = true;
            this.PasswordLegalLength_Label.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.PasswordLegalLength_Label.Location = new System.Drawing.Point(63, 115);
            this.PasswordLegalLength_Label.Name = "PasswordLegalLength_Label";
            this.PasswordLegalLength_Label.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PasswordLegalLength_Label.Size = new System.Drawing.Size(86, 18);
            this.PasswordLegalLength_Label.TabIndex = 18;
            this.PasswordLegalLength_Label.Text = "・ 5-16 תווים";
            // 
            // PasswordVerifyLabel_Label
            // 
            this.PasswordVerifyLabel_Label.AutoSize = true;
            this.PasswordVerifyLabel_Label.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordVerifyLabel_Label.Location = new System.Drawing.Point(95, 76);
            this.PasswordVerifyLabel_Label.Name = "PasswordVerifyLabel_Label";
            this.PasswordVerifyLabel_Label.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PasswordVerifyLabel_Label.Size = new System.Drawing.Size(53, 18);
            this.PasswordVerifyLabel_Label.TabIndex = 17;
            this.PasswordVerifyLabel_Label.Text = "סיסמא:";
            // 
            // UsernameLegalChars_Label
            // 
            this.UsernameLegalChars_Label.AutoSize = true;
            this.UsernameLegalChars_Label.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.UsernameLegalChars_Label.Location = new System.Drawing.Point(61, 34);
            this.UsernameLegalChars_Label.Name = "UsernameLegalChars_Label";
            this.UsernameLegalChars_Label.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.UsernameLegalChars_Label.Size = new System.Drawing.Size(87, 18);
            this.UsernameLegalChars_Label.TabIndex = 16;
            this.UsernameLegalChars_Label.Text = "・ תווים חוקיים";
            // 
            // UsernameVerifyLabel_Label
            // 
            this.UsernameVerifyLabel_Label.AutoSize = true;
            this.UsernameVerifyLabel_Label.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameVerifyLabel_Label.Location = new System.Drawing.Point(63, 16);
            this.UsernameVerifyLabel_Label.Name = "UsernameVerifyLabel_Label";
            this.UsernameVerifyLabel_Label.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.UsernameVerifyLabel_Label.Size = new System.Drawing.Size(85, 18);
            this.UsernameVerifyLabel_Label.TabIndex = 15;
            this.UsernameVerifyLabel_Label.Text = "שם משתמש:";
            // 
            // LoginSignup_Panel
            // 
            this.LoginSignup_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LoginSignup_Panel.Controls.Add(this.SwitchMethod_Button);
            this.LoginSignup_Panel.Controls.Add(this.CredentialsVerify_Panel);
            this.LoginSignup_Panel.Controls.Add(this.panel2);
            this.LoginSignup_Panel.Controls.Add(this.panel3);
            this.LoginSignup_Panel.Enabled = false;
            this.LoginSignup_Panel.Location = new System.Drawing.Point(34, 137);
            this.LoginSignup_Panel.Name = "LoginSignup_Panel";
            this.LoginSignup_Panel.Size = new System.Drawing.Size(731, 275);
            this.LoginSignup_Panel.TabIndex = 15;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.LoginUsername_TextBox);
            this.panel3.Controls.Add(this.LoginPassword_TextBox);
            this.panel3.Controls.Add(this.LoginUsername_Label);
            this.panel3.Controls.Add(this.LoginErrorMessage_Label);
            this.panel3.Controls.Add(this.Login_Button);
            this.panel3.Controls.Add(this.LoginPassword_Label);
            this.panel3.Location = new System.Drawing.Point(518, 18);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(190, 237);
            this.panel3.TabIndex = 12;
            // 
            // LoginUsername_TextBox
            // 
            this.LoginUsername_TextBox.Font = new System.Drawing.Font("Berlin Sans FB", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginUsername_TextBox.Location = new System.Drawing.Point(19, 51);
            this.LoginUsername_TextBox.MaxLength = 20;
            this.LoginUsername_TextBox.Name = "LoginUsername_TextBox";
            this.LoginUsername_TextBox.Size = new System.Drawing.Size(154, 31);
            this.LoginUsername_TextBox.TabIndex = 0;
            this.LoginUsername_TextBox.TextChanged += new System.EventHandler(this.LoginUsername_TextBox_TextChanged);
            // 
            // LoginPassword_TextBox
            // 
            this.LoginPassword_TextBox.Font = new System.Drawing.Font("Berlin Sans FB", 15.75F);
            this.LoginPassword_TextBox.Location = new System.Drawing.Point(19, 127);
            this.LoginPassword_TextBox.MaxLength = 16;
            this.LoginPassword_TextBox.Name = "LoginPassword_TextBox";
            this.LoginPassword_TextBox.PasswordChar = '*';
            this.LoginPassword_TextBox.Size = new System.Drawing.Size(154, 31);
            this.LoginPassword_TextBox.TabIndex = 1;
            this.LoginPassword_TextBox.TextChanged += new System.EventHandler(this.LoginPassword_TextBox_TextChanged);
            // 
            // LoginUsername_Label
            // 
            this.LoginUsername_Label.AutoSize = true;
            this.LoginUsername_Label.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginUsername_Label.Location = new System.Drawing.Point(95, 30);
            this.LoginUsername_Label.Name = "LoginUsername_Label";
            this.LoginUsername_Label.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LoginUsername_Label.Size = new System.Drawing.Size(81, 18);
            this.LoginUsername_Label.TabIndex = 10;
            this.LoginUsername_Label.Text = "שם משתמש:";
            // 
            // Login_Button
            // 
            this.Login_Button.AutoSize = true;
            this.Login_Button.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login_Button.Location = new System.Drawing.Point(19, 186);
            this.Login_Button.Name = "Login_Button";
            this.Login_Button.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Login_Button.Size = new System.Drawing.Size(75, 30);
            this.Login_Button.TabIndex = 2;
            this.Login_Button.Text = "התחבר";
            this.Login_Button.UseVisualStyleBackColor = true;
            this.Login_Button.Click += new System.EventHandler(this.Login_Button_Click);
            // 
            // LoginPassword_Label
            // 
            this.LoginPassword_Label.AutoSize = true;
            this.LoginPassword_Label.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginPassword_Label.Location = new System.Drawing.Point(127, 106);
            this.LoginPassword_Label.Name = "LoginPassword_Label";
            this.LoginPassword_Label.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LoginPassword_Label.Size = new System.Drawing.Size(49, 18);
            this.LoginPassword_Label.TabIndex = 11;
            this.LoginPassword_Label.Text = "סיסמא:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.SignupUsername_TextBox);
            this.panel2.Controls.Add(this.SignupPassword_TextBox);
            this.panel2.Controls.Add(this.SignupErrorMessage_Label);
            this.panel2.Controls.Add(this.SignupUsername_Label);
            this.panel2.Controls.Add(this.Signup_Button);
            this.panel2.Controls.Add(this.SignupPassword_Label);
            this.panel2.Location = new System.Drawing.Point(199, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 237);
            this.panel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(249, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(301, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // ConnectionFailed_Label
            // 
            this.ConnectionFailed_Label.AutoSize = true;
            this.ConnectionFailed_Label.ForeColor = System.Drawing.Color.Red;
            this.ConnectionFailed_Label.Location = new System.Drawing.Point(365, 115);
            this.ConnectionFailed_Label.Name = "ConnectionFailed_Label";
            this.ConnectionFailed_Label.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ConnectionFailed_Label.Size = new System.Drawing.Size(188, 13);
            this.ConnectionFailed_Label.TabIndex = 17;
            this.ConnectionFailed_Label.Text = "התחברות לשרת נכשלה. מנסה שוב...";
            this.ConnectionFailed_Label.Visible = false;
            // 
            // ReloadConnect_Timer
            // 
            this.ReloadConnect_Timer.Interval = 3000;
            this.ReloadConnect_Timer.Tick += new System.EventHandler(this.ReloadConnect_Timer_Tick);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ConnectionFailed_Label);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LoginSignup_Panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.Text = "התחברות";
            this.CredentialsVerify_Panel.ResumeLayout(false);
            this.CredentialsVerify_Panel.PerformLayout();
            this.LoginSignup_Panel.ResumeLayout(false);
            this.LoginSignup_Panel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LoginErrorMessage_Label;
        private System.Windows.Forms.Label SignupErrorMessage_Label;
        private System.Windows.Forms.Button Signup_Button;
        private System.Windows.Forms.Label SignupPassword_Label;
        private System.Windows.Forms.Label SignupUsername_Label;
        private System.Windows.Forms.TextBox SignupPassword_TextBox;
        private System.Windows.Forms.TextBox SignupUsername_TextBox;
        private System.Windows.Forms.Button SwitchMethod_Button;
        private System.Windows.Forms.Panel CredentialsVerify_Panel;
        private System.Windows.Forms.Label PasswordLegalChars_Label;
        private System.Windows.Forms.Label UsernameLegalLength_Label;
        private System.Windows.Forms.Label PasswordLegalLength_Label;
        private System.Windows.Forms.Label PasswordVerifyLabel_Label;
        private System.Windows.Forms.Label UsernameLegalChars_Label;
        private System.Windows.Forms.Label UsernameVerifyLabel_Label;
        private System.Windows.Forms.Panel LoginSignup_Panel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox LoginUsername_TextBox;
        private System.Windows.Forms.TextBox LoginPassword_TextBox;
        private System.Windows.Forms.Label LoginUsername_Label;
        private System.Windows.Forms.Button Login_Button;
        private System.Windows.Forms.Label LoginPassword_Label;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label ConnectionFailed_Label;
        private System.Windows.Forms.Timer ReloadConnect_Timer;
    }
}

