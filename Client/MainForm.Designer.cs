
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
            this.Welcome_Label = new System.Windows.Forms.Label();
            this.Logout_Button = new System.Windows.Forms.Button();
            this.DeleteUser_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Welcome_Label
            // 
            this.Welcome_Label.AutoSize = true;
            this.Welcome_Label.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Welcome_Label.ForeColor = System.Drawing.Color.LimeGreen;
            this.Welcome_Label.Location = new System.Drawing.Point(539, 93);
            this.Welcome_Label.Name = "Welcome_Label";
            this.Welcome_Label.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Welcome_Label.Size = new System.Drawing.Size(80, 22);
            this.Welcome_Label.TabIndex = 0;
            this.Welcome_Label.Text = "ברוך הבא!";
            // 
            // Logout_Button
            // 
            this.Logout_Button.AutoSize = true;
            this.Logout_Button.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Logout_Button.Location = new System.Drawing.Point(540, 140);
            this.Logout_Button.Name = "Logout_Button";
            this.Logout_Button.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Logout_Button.Size = new System.Drawing.Size(75, 28);
            this.Logout_Button.TabIndex = 0;
            this.Logout_Button.Text = "התנתק";
            this.Logout_Button.UseVisualStyleBackColor = true;
            this.Logout_Button.Click += new System.EventHandler(this.Logout_Button_Click);
            // 
            // DeleteUser_Button
            // 
            this.DeleteUser_Button.AutoSize = true;
            this.DeleteUser_Button.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteUser_Button.Location = new System.Drawing.Point(12, 410);
            this.DeleteUser_Button.Name = "DeleteUser_Button";
            this.DeleteUser_Button.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DeleteUser_Button.Size = new System.Drawing.Size(96, 28);
            this.DeleteUser_Button.TabIndex = 1;
            this.DeleteUser_Button.Text = "מחק משתמש";
            this.DeleteUser_Button.UseVisualStyleBackColor = true;
            this.DeleteUser_Button.Click += new System.EventHandler(this.DeleteUser_Button_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DeleteUser_Button);
            this.Controls.Add(this.Logout_Button);
            this.Controls.Add(this.Welcome_Label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "חלון ראשי";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Welcome_Label;
        private System.Windows.Forms.Button Logout_Button;
        private System.Windows.Forms.Button DeleteUser_Button;
    }
}