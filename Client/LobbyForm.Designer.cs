
namespace Client
{
    partial class LobbyForm
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
            this.Logout_Button = new System.Windows.Forms.Button();
            this.Players_Panel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.PlayersAmount_Label = new System.Windows.Forms.Label();
            this.StartGame_Button = new System.Windows.Forms.Button();
            this.OnlyAdmin_Label = new System.Windows.Forms.Label();
            this.PlayersListReload_Timer = new System.Windows.Forms.Timer(this.components);
            this.NotEnoughPlayers_Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Logout_Button
            // 
            this.Logout_Button.AutoSize = true;
            this.Logout_Button.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Logout_Button.Location = new System.Drawing.Point(12, 410);
            this.Logout_Button.Name = "Logout_Button";
            this.Logout_Button.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Logout_Button.Size = new System.Drawing.Size(75, 28);
            this.Logout_Button.TabIndex = 1;
            this.Logout_Button.Text = "יציאה";
            this.Logout_Button.UseVisualStyleBackColor = true;
            this.Logout_Button.Click += new System.EventHandler(this.Logout_Button_Click);
            // 
            // Players_Panel
            // 
            this.Players_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Players_Panel.Location = new System.Drawing.Point(107, 102);
            this.Players_Panel.Name = "Players_Panel";
            this.Players_Panel.Size = new System.Drawing.Size(200, 293);
            this.Players_Panel.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(251, 86);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "משתתפים:";
            // 
            // PlayersAmount_Label
            // 
            this.PlayersAmount_Label.AutoSize = true;
            this.PlayersAmount_Label.Location = new System.Drawing.Point(107, 86);
            this.PlayersAmount_Label.Name = "PlayersAmount_Label";
            this.PlayersAmount_Label.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PlayersAmount_Label.Size = new System.Drawing.Size(0, 13);
            this.PlayersAmount_Label.TabIndex = 4;
            // 
            // StartGame_Button
            // 
            this.StartGame_Button.AutoSize = true;
            this.StartGame_Button.Enabled = false;
            this.StartGame_Button.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartGame_Button.Location = new System.Drawing.Point(513, 314);
            this.StartGame_Button.Name = "StartGame_Button";
            this.StartGame_Button.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartGame_Button.Size = new System.Drawing.Size(93, 28);
            this.StartGame_Button.TabIndex = 5;
            this.StartGame_Button.Text = "התחל משחק";
            this.StartGame_Button.UseVisualStyleBackColor = true;
            // 
            // OnlyAdmin_Label
            // 
            this.OnlyAdmin_Label.AutoSize = true;
            this.OnlyAdmin_Label.ForeColor = System.Drawing.Color.Red;
            this.OnlyAdmin_Label.Location = new System.Drawing.Point(458, 345);
            this.OnlyAdmin_Label.Name = "OnlyAdmin_Label";
            this.OnlyAdmin_Label.Size = new System.Drawing.Size(207, 13);
            this.OnlyAdmin_Label.TabIndex = 6;
            this.OnlyAdmin_Label.Text = "רק מנהל החדר יכול להתחיל את המשחק";
            // 
            // PlayersListReload_Timer
            // 
            this.PlayersListReload_Timer.Enabled = true;
            this.PlayersListReload_Timer.Interval = 1000;
            this.PlayersListReload_Timer.Tick += new System.EventHandler(this.PlayersListReload_Timer_Tick);
            // 
            // NotEnoughPlayers_Label
            // 
            this.NotEnoughPlayers_Label.AutoSize = true;
            this.NotEnoughPlayers_Label.ForeColor = System.Drawing.Color.Red;
            this.NotEnoughPlayers_Label.Location = new System.Drawing.Point(510, 298);
            this.NotEnoughPlayers_Label.Name = "NotEnoughPlayers_Label";
            this.NotEnoughPlayers_Label.Size = new System.Drawing.Size(104, 13);
            this.NotEnoughPlayers_Label.TabIndex = 7;
            this.NotEnoughPlayers_Label.Text = "אין מספיק שחקנים";
            // 
            // LobbyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.NotEnoughPlayers_Label);
            this.Controls.Add(this.OnlyAdmin_Label);
            this.Controls.Add(this.StartGame_Button);
            this.Controls.Add(this.PlayersAmount_Label);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Players_Panel);
            this.Controls.Add(this.Logout_Button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LobbyForm";
            this.Text = "LobbyForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LobbyForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Logout_Button;
        private System.Windows.Forms.Panel Players_Panel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label PlayersAmount_Label;
        private System.Windows.Forms.Button StartGame_Button;
        private System.Windows.Forms.Label OnlyAdmin_Label;
        private System.Windows.Forms.Timer PlayersListReload_Timer;
        private System.Windows.Forms.Label NotEnoughPlayers_Label;
    }
}