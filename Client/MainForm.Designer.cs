
namespace Client
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
            this.welcome_label = new System.Windows.Forms.Label();
            this.logout_button = new System.Windows.Forms.Button();
            this.deleteUser_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // welcome_label
            // 
            this.welcome_label.AutoSize = true;
            this.welcome_label.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcome_label.ForeColor = System.Drawing.Color.LimeGreen;
            this.welcome_label.Location = new System.Drawing.Point(539, 93);
            this.welcome_label.Name = "welcome_label";
            this.welcome_label.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.welcome_label.Size = new System.Drawing.Size(80, 22);
            this.welcome_label.TabIndex = 0;
            this.welcome_label.Text = "ברוך הבא!";
            // 
            // logout_button
            // 
            this.logout_button.AutoSize = true;
            this.logout_button.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logout_button.Location = new System.Drawing.Point(540, 140);
            this.logout_button.Name = "logout_button";
            this.logout_button.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.logout_button.Size = new System.Drawing.Size(75, 28);
            this.logout_button.TabIndex = 0;
            this.logout_button.Text = "התנתק";
            this.logout_button.UseVisualStyleBackColor = true;
            this.logout_button.Click += new System.EventHandler(this.Logout);
            // 
            // deleteUser_button
            // 
            this.deleteUser_button.AutoSize = true;
            this.deleteUser_button.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteUser_button.Location = new System.Drawing.Point(12, 410);
            this.deleteUser_button.Name = "deleteUser_button";
            this.deleteUser_button.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.deleteUser_button.Size = new System.Drawing.Size(96, 28);
            this.deleteUser_button.TabIndex = 1;
            this.deleteUser_button.Text = "מחק משתמש";
            this.deleteUser_button.UseVisualStyleBackColor = true;
            this.deleteUser_button.Click += new System.EventHandler(this.DeleteUser);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.deleteUser_button);
            this.Controls.Add(this.logout_button);
            this.Controls.Add(this.welcome_label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "חלון ראשי";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label welcome_label;
        private System.Windows.Forms.Button logout_button;
        private System.Windows.Forms.Button deleteUser_button;
    }
}