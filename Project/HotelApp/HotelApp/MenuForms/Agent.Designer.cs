namespace HotelApp.MenuForms
{
    partial class Agent
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
            this.lblAgentProfile = new System.Windows.Forms.Label();
            this.lblCurrentAgent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblAgentProfile
            // 
            this.lblAgentProfile.AutoSize = true;
            this.lblAgentProfile.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblAgentProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgentProfile.Location = new System.Drawing.Point(202, 44);
            this.lblAgentProfile.Name = "lblAgentProfile";
            this.lblAgentProfile.Size = new System.Drawing.Size(350, 63);
            this.lblAgentProfile.TabIndex = 0;
            this.lblAgentProfile.Text = "Agent Profile";
            // 
            // lblCurrentAgent
            // 
            this.lblCurrentAgent.AutoSize = true;
            this.lblCurrentAgent.Location = new System.Drawing.Point(210, 131);
            this.lblCurrentAgent.Name = "lblCurrentAgent";
            this.lblCurrentAgent.Size = new System.Drawing.Size(156, 13);
            this.lblCurrentAgent.TabIndex = 1;
            this.lblCurrentAgent.Text = "Currently viewing Agent\'s profile";
            // 
            // Agent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblCurrentAgent);
            this.Controls.Add(this.lblAgentProfile);
            this.Name = "Agent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agent";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAgentProfile;
        private System.Windows.Forms.Label lblCurrentAgent;
    }
}