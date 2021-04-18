
namespace Client
{
    partial class GameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.RedPlayers_Panel = new System.Windows.Forms.Panel();
            this.BluePlayers_Panel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CurrTurn_Label = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CurrWord_TextBox = new System.Windows.Forms.TextBox();
            this.CurrWord_Label = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.CurrAmount_NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.CurrAmount_Label = new System.Windows.Forms.Label();
            this.GameUpdates_Timer = new System.Windows.Forms.Timer(this.components);
            this.ExitLobby_Button = new System.Windows.Forms.Button();
            this.SendWord_Button = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ChosenWord_Label = new System.Windows.Forms.Label();
            this.GuessWord_Button = new System.Windows.Forms.Button();
            this.GuessWord_Panel = new System.Windows.Forms.Panel();
            this.Game_Panel = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CurrAmount_NumericUpDown)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.GuessWord_Panel.SuspendLayout();
            this.Game_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // RedPlayers_Panel
            // 
            this.RedPlayers_Panel.BackColor = System.Drawing.Color.MistyRose;
            this.RedPlayers_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RedPlayers_Panel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.RedPlayers_Panel.Location = new System.Drawing.Point(27, 13);
            this.RedPlayers_Panel.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.RedPlayers_Panel.Name = "RedPlayers_Panel";
            this.RedPlayers_Panel.Size = new System.Drawing.Size(133, 329);
            this.RedPlayers_Panel.TabIndex = 3;
            // 
            // BluePlayers_Panel
            // 
            this.BluePlayers_Panel.BackColor = System.Drawing.Color.Lavender;
            this.BluePlayers_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BluePlayers_Panel.Location = new System.Drawing.Point(788, 13);
            this.BluePlayers_Panel.Margin = new System.Windows.Forms.Padding(3, 3, 30, 3);
            this.BluePlayers_Panel.Name = "BluePlayers_Panel";
            this.BluePlayers_Panel.Size = new System.Drawing.Size(133, 329);
            this.BluePlayers_Panel.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CurrTurn_Label);
            this.groupBox1.Location = new System.Drawing.Point(642, 406);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(142, 40);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "תור";
            // 
            // CurrTurn_Label
            // 
            this.CurrTurn_Label.AutoSize = true;
            this.CurrTurn_Label.Location = new System.Drawing.Point(51, 16);
            this.CurrTurn_Label.Name = "CurrTurn_Label";
            this.CurrTurn_Label.Size = new System.Drawing.Size(0, 13);
            this.CurrTurn_Label.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CurrWord_TextBox);
            this.groupBox2.Controls.Add(this.CurrWord_Label);
            this.groupBox2.Location = new System.Drawing.Point(409, 406);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(142, 40);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "מילה";
            // 
            // CurrWord_TextBox
            // 
            this.CurrWord_TextBox.Location = new System.Drawing.Point(6, 13);
            this.CurrWord_TextBox.Name = "CurrWord_TextBox";
            this.CurrWord_TextBox.Size = new System.Drawing.Size(123, 20);
            this.CurrWord_TextBox.TabIndex = 32;
            this.CurrWord_TextBox.Visible = false;
            // 
            // CurrWord_Label
            // 
            this.CurrWord_Label.AutoSize = true;
            this.CurrWord_Label.Location = new System.Drawing.Point(31, 16);
            this.CurrWord_Label.Name = "CurrWord_Label";
            this.CurrWord_Label.Size = new System.Drawing.Size(0, 13);
            this.CurrWord_Label.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.CurrAmount_NumericUpDown);
            this.groupBox3.Controls.Add(this.CurrAmount_Label);
            this.groupBox3.Location = new System.Drawing.Point(164, 406);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox3.Size = new System.Drawing.Size(142, 40);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "כמות";
            // 
            // CurrAmount_NumericUpDown
            // 
            this.CurrAmount_NumericUpDown.Location = new System.Drawing.Point(6, 13);
            this.CurrAmount_NumericUpDown.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.CurrAmount_NumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CurrAmount_NumericUpDown.Name = "CurrAmount_NumericUpDown";
            this.CurrAmount_NumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.CurrAmount_NumericUpDown.TabIndex = 32;
            this.CurrAmount_NumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CurrAmount_NumericUpDown.Visible = false;
            // 
            // CurrAmount_Label
            // 
            this.CurrAmount_Label.AutoSize = true;
            this.CurrAmount_Label.Location = new System.Drawing.Point(58, 16);
            this.CurrAmount_Label.Name = "CurrAmount_Label";
            this.CurrAmount_Label.Size = new System.Drawing.Size(0, 13);
            this.CurrAmount_Label.TabIndex = 0;
            // 
            // GameUpdates_Timer
            // 
            this.GameUpdates_Timer.Enabled = true;
            this.GameUpdates_Timer.Interval = 1000;
            this.GameUpdates_Timer.Tick += new System.EventHandler(this.GameUpdates_Timer_Tick);
            // 
            // ExitLobby_Button
            // 
            this.ExitLobby_Button.AutoSize = true;
            this.ExitLobby_Button.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitLobby_Button.Location = new System.Drawing.Point(12, 12);
            this.ExitLobby_Button.Name = "ExitLobby_Button";
            this.ExitLobby_Button.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ExitLobby_Button.Size = new System.Drawing.Size(75, 28);
            this.ExitLobby_Button.TabIndex = 32;
            this.ExitLobby_Button.Text = "יציאה";
            this.ExitLobby_Button.UseVisualStyleBackColor = true;
            this.ExitLobby_Button.Click += new System.EventHandler(this.ExitLobby_Button_Click);
            // 
            // SendWord_Button
            // 
            this.SendWord_Button.AutoSize = true;
            this.SendWord_Button.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendWord_Button.Location = new System.Drawing.Point(37, 412);
            this.SendWord_Button.Name = "SendWord_Button";
            this.SendWord_Button.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SendWord_Button.Size = new System.Drawing.Size(75, 28);
            this.SendWord_Button.TabIndex = 33;
            this.SendWord_Button.Text = "שלח";
            this.SendWord_Button.UseVisualStyleBackColor = true;
            this.SendWord_Button.Visible = false;
            this.SendWord_Button.Click += new System.EventHandler(this.SendWord_Button_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ChosenWord_Label);
            this.groupBox4.Location = new System.Drawing.Point(91, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox4.Size = new System.Drawing.Size(142, 40);
            this.groupBox4.TabIndex = 31;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "ניחוש";
            // 
            // ChosenWord_Label
            // 
            this.ChosenWord_Label.AutoSize = true;
            this.ChosenWord_Label.Location = new System.Drawing.Point(51, 16);
            this.ChosenWord_Label.Name = "ChosenWord_Label";
            this.ChosenWord_Label.Size = new System.Drawing.Size(0, 13);
            this.ChosenWord_Label.TabIndex = 0;
            // 
            // GuessWord_Button
            // 
            this.GuessWord_Button.AutoSize = true;
            this.GuessWord_Button.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GuessWord_Button.Location = new System.Drawing.Point(10, 14);
            this.GuessWord_Button.Name = "GuessWord_Button";
            this.GuessWord_Button.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.GuessWord_Button.Size = new System.Drawing.Size(75, 28);
            this.GuessWord_Button.TabIndex = 34;
            this.GuessWord_Button.Text = "שלח";
            this.GuessWord_Button.UseVisualStyleBackColor = true;
            this.GuessWord_Button.Visible = false;
            this.GuessWord_Button.Click += new System.EventHandler(this.GuessWord_Button_Click);
            // 
            // GuessWord_Panel
            // 
            this.GuessWord_Panel.Controls.Add(this.groupBox4);
            this.GuessWord_Panel.Controls.Add(this.GuessWord_Button);
            this.GuessWord_Panel.Location = new System.Drawing.Point(352, 348);
            this.GuessWord_Panel.Name = "GuessWord_Panel";
            this.GuessWord_Panel.Size = new System.Drawing.Size(243, 53);
            this.GuessWord_Panel.TabIndex = 35;
            this.GuessWord_Panel.Visible = false;
            // 
            // Game_Panel
            // 
            this.Game_Panel.Controls.Add(this.GuessWord_Panel);
            this.Game_Panel.Controls.Add(this.RedPlayers_Panel);
            this.Game_Panel.Controls.Add(this.SendWord_Button);
            this.Game_Panel.Controls.Add(this.BluePlayers_Panel);
            this.Game_Panel.Controls.Add(this.groupBox1);
            this.Game_Panel.Controls.Add(this.groupBox3);
            this.Game_Panel.Controls.Add(this.groupBox2);
            this.Game_Panel.Location = new System.Drawing.Point(12, 46);
            this.Game_Panel.Name = "Game_Panel";
            this.Game_Panel.Size = new System.Drawing.Size(948, 462);
            this.Game_Panel.TabIndex = 36;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 520);
            this.Controls.Add(this.ExitLobby_Button);
            this.Controls.Add(this.Game_Panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GameForm";
            this.Text = "משחק";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameForm_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CurrAmount_NumericUpDown)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.GuessWord_Panel.ResumeLayout(false);
            this.GuessWord_Panel.PerformLayout();
            this.Game_Panel.ResumeLayout(false);
            this.Game_Panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel RedPlayers_Panel;
        private System.Windows.Forms.Panel BluePlayers_Panel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label CurrTurn_Label;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox CurrWord_TextBox;
        private System.Windows.Forms.Label CurrWord_Label;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown CurrAmount_NumericUpDown;
        private System.Windows.Forms.Label CurrAmount_Label;
        private System.Windows.Forms.Timer GameUpdates_Timer;
        private System.Windows.Forms.Button ExitLobby_Button;
        private System.Windows.Forms.Button SendWord_Button;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label ChosenWord_Label;
        private System.Windows.Forms.Button GuessWord_Button;
        private System.Windows.Forms.Panel GuessWord_Panel;
        private System.Windows.Forms.Panel Game_Panel;
    }
}