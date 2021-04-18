
namespace CodeNames
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Welcome_Label = new System.Windows.Forms.Label();
            this.Logout_Button = new System.Windows.Forms.Button();
            this.DeleteUser_Button = new System.Windows.Forms.Button();
            this.MaxPlayers_NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CreateLobby_Button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Lobbies_Panel = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ReloadLobbies_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MaxPlayers_NumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // Welcome_Label
            // 
            this.Welcome_Label.AutoSize = true;
            this.Welcome_Label.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Welcome_Label.ForeColor = System.Drawing.Color.LimeGreen;
            this.Welcome_Label.Location = new System.Drawing.Point(570, 9);
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
            this.Logout_Button.Location = new System.Drawing.Point(713, 410);
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
            // MaxPlayers_NumericUpDown
            // 
            this.MaxPlayers_NumericUpDown.Location = new System.Drawing.Point(501, 184);
            this.MaxPlayers_NumericUpDown.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.MaxPlayers_NumericUpDown.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.MaxPlayers_NumericUpDown.Name = "MaxPlayers_NumericUpDown";
            this.MaxPlayers_NumericUpDown.Size = new System.Drawing.Size(74, 20);
            this.MaxPlayers_NumericUpDown.TabIndex = 2;
            this.MaxPlayers_NumericUpDown.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(581, 182);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(179, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "מספר שחקנים מקסימלי:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(581, 109);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(85, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "צור משחק:";
            // 
            // CreateLobby_Button
            // 
            this.CreateLobby_Button.AutoSize = true;
            this.CreateLobby_Button.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateLobby_Button.Location = new System.Drawing.Point(581, 269);
            this.CreateLobby_Button.Name = "CreateLobby_Button";
            this.CreateLobby_Button.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CreateLobby_Button.Size = new System.Drawing.Size(75, 28);
            this.CreateLobby_Button.TabIndex = 5;
            this.CreateLobby_Button.Text = "צור";
            this.CreateLobby_Button.UseVisualStyleBackColor = true;
            this.CreateLobby_Button.Click += new System.EventHandler(this.CreateLobby_Button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(190, 60);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(122, 22);
            this.label3.TabIndex = 6;
            this.label3.Text = "הצטרף למשחק:";
            // 
            // Lobbies_Panel
            // 
            this.Lobbies_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lobbies_Panel.Location = new System.Drawing.Point(50, 153);
            this.Lobbies_Panel.Name = "Lobbies_Panel";
            this.Lobbies_Panel.Size = new System.Drawing.Size(396, 232);
            this.Lobbies_Panel.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(68, 128);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(49, 22);
            this.label6.TabIndex = 8;
            this.label6.Text = "host";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(200, 128);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(77, 22);
            this.label7.TabIndex = 9;
            this.label7.Text = "players";
            // 
            // ReloadLobbies_Button
            // 
            this.ReloadLobbies_Button.AutoSize = true;
            this.ReloadLobbies_Button.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReloadLobbies_Button.Location = new System.Drawing.Point(371, 122);
            this.ReloadLobbies_Button.Name = "ReloadLobbies_Button";
            this.ReloadLobbies_Button.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ReloadLobbies_Button.Size = new System.Drawing.Size(75, 28);
            this.ReloadLobbies_Button.TabIndex = 11;
            this.ReloadLobbies_Button.Text = "Reload";
            this.ReloadLobbies_Button.UseVisualStyleBackColor = true;
            this.ReloadLobbies_Button.Click += new System.EventHandler(this.ReloadLobbies_Button_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ReloadLobbies_Button);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Lobbies_Panel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CreateLobby_Button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MaxPlayers_NumericUpDown);
            this.Controls.Add(this.DeleteUser_Button);
            this.Controls.Add(this.Logout_Button);
            this.Controls.Add(this.Welcome_Label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "חלון ראשי";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.MaxPlayers_NumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Welcome_Label;
        private System.Windows.Forms.Button Logout_Button;
        private System.Windows.Forms.Button DeleteUser_Button;
        private System.Windows.Forms.NumericUpDown MaxPlayers_NumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CreateLobby_Button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel Lobbies_Panel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button ReloadLobbies_Button;
    }
}