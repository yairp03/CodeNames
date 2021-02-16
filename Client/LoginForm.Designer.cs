
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
            this.username_textBox = new System.Windows.Forms.TextBox();
            this.password_textBox = new System.Windows.Forms.TextBox();
            this.username_label = new System.Windows.Forms.Label();
            this.password_label = new System.Windows.Forms.Label();
            this.signup_button = new System.Windows.Forms.Button();
            this.login_button = new System.Windows.Forms.Button();
            this.errorMessage_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // username_textBox
            // 
            this.username_textBox.Font = new System.Drawing.Font("Berlin Sans FB", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username_textBox.Location = new System.Drawing.Point(490, 124);
            this.username_textBox.Name = "username_textBox";
            this.username_textBox.Size = new System.Drawing.Size(154, 31);
            this.username_textBox.TabIndex = 0;
            // 
            // password_textBox
            // 
            this.password_textBox.Font = new System.Drawing.Font("Berlin Sans FB", 15.75F);
            this.password_textBox.Location = new System.Drawing.Point(490, 200);
            this.password_textBox.Name = "password_textBox";
            this.password_textBox.PasswordChar = '*';
            this.password_textBox.Size = new System.Drawing.Size(154, 31);
            this.password_textBox.TabIndex = 1;
            // 
            // username_label
            // 
            this.username_label.AutoSize = true;
            this.username_label.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username_label.Location = new System.Drawing.Point(566, 103);
            this.username_label.Name = "username_label";
            this.username_label.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.username_label.Size = new System.Drawing.Size(81, 18);
            this.username_label.TabIndex = 4;
            this.username_label.Text = "שם משתמש:";
            // 
            // password_label
            // 
            this.password_label.AutoSize = true;
            this.password_label.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password_label.Location = new System.Drawing.Point(598, 179);
            this.password_label.Name = "password_label";
            this.password_label.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.password_label.Size = new System.Drawing.Size(49, 18);
            this.password_label.TabIndex = 5;
            this.password_label.Text = "סיסמא:";
            // 
            // signup_button
            // 
            this.signup_button.AutoSize = true;
            this.signup_button.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signup_button.Location = new System.Drawing.Point(569, 292);
            this.signup_button.Name = "signup_button";
            this.signup_button.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.signup_button.Size = new System.Drawing.Size(75, 30);
            this.signup_button.TabIndex = 2;
            this.signup_button.Text = "הירשם";
            this.signup_button.UseVisualStyleBackColor = true;
            this.signup_button.Click += new System.EventHandler(this.Signup);
            // 
            // login_button
            // 
            this.login_button.AutoSize = true;
            this.login_button.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_button.Location = new System.Drawing.Point(488, 292);
            this.login_button.Name = "login_button";
            this.login_button.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.login_button.Size = new System.Drawing.Size(75, 30);
            this.login_button.TabIndex = 3;
            this.login_button.Text = "התחבר";
            this.login_button.UseVisualStyleBackColor = true;
            this.login_button.Click += new System.EventHandler(this.Login);
            // 
            // errorMessage_label
            // 
            this.errorMessage_label.AutoSize = true;
            this.errorMessage_label.Font = new System.Drawing.Font("Berlin Sans FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorMessage_label.ForeColor = System.Drawing.Color.Red;
            this.errorMessage_label.Location = new System.Drawing.Point(490, 234);
            this.errorMessage_label.Name = "errorMessage_label";
            this.errorMessage_label.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.errorMessage_label.Size = new System.Drawing.Size(0, 21);
            this.errorMessage_label.TabIndex = 6;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.errorMessage_label);
            this.Controls.Add(this.login_button);
            this.Controls.Add(this.signup_button);
            this.Controls.Add(this.password_label);
            this.Controls.Add(this.username_label);
            this.Controls.Add(this.password_textBox);
            this.Controls.Add(this.username_textBox);
            this.Name = "LoginForm";
            this.Text = "התחברות";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox username_textBox;
        private System.Windows.Forms.TextBox password_textBox;
        private System.Windows.Forms.Label username_label;
        private System.Windows.Forms.Label password_label;
        private System.Windows.Forms.Button signup_button;
        private System.Windows.Forms.Button login_button;
        private System.Windows.Forms.Label errorMessage_label;
    }
}

