namespace HotelApp
{
    partial class Home
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
            this.grpMaintenance = new System.Windows.Forms.GroupBox();
            this.btnGuest = new System.Windows.Forms.Button();
            this.btnAgent = new System.Windows.Forms.Button();
            this.btnHotel = new System.Windows.Forms.Button();
            this.grpBookings = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.grpMaintenance.SuspendLayout();
            this.grpBookings.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMaintenance
            // 
            this.grpMaintenance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(223)))), ((int)(((byte)(242)))));
            this.grpMaintenance.Controls.Add(this.btnGuest);
            this.grpMaintenance.Controls.Add(this.btnAgent);
            this.grpMaintenance.Controls.Add(this.btnHotel);
            this.grpMaintenance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMaintenance.Location = new System.Drawing.Point(38, 37);
            this.grpMaintenance.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpMaintenance.Name = "grpMaintenance";
            this.grpMaintenance.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpMaintenance.Size = new System.Drawing.Size(392, 396);
            this.grpMaintenance.TabIndex = 5;
            this.grpMaintenance.TabStop = false;
            this.grpMaintenance.Text = "Maintenance";
            // 
            // btnGuest
            // 
            this.btnGuest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(207)))), ((int)(((byte)(99)))));
            this.btnGuest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuest.Location = new System.Drawing.Point(43, 281);
            this.btnGuest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGuest.Name = "btnGuest";
            this.btnGuest.Size = new System.Drawing.Size(301, 74);
            this.btnGuest.TabIndex = 2;
            this.btnGuest.Tag = "Guest";
            this.btnGuest.Text = "Edit/Add Guests";
            this.btnGuest.UseVisualStyleBackColor = false;
            this.btnGuest.Click += new System.EventHandler(this.HandleButtonClick);
            // 
            // btnAgent
            // 
            this.btnAgent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(207)))), ((int)(((byte)(99)))));
            this.btnAgent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgent.Location = new System.Drawing.Point(43, 154);
            this.btnAgent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAgent.Name = "btnAgent";
            this.btnAgent.Size = new System.Drawing.Size(301, 74);
            this.btnAgent.TabIndex = 1;
            this.btnAgent.Tag = "Agent";
            this.btnAgent.Text = "Edit/Add Agents";
            this.btnAgent.UseVisualStyleBackColor = false;
            this.btnAgent.Click += new System.EventHandler(this.HandleButtonClick);
            // 
            // btnHotel
            // 
            this.btnHotel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(207)))), ((int)(((byte)(99)))));
            this.btnHotel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHotel.Location = new System.Drawing.Point(43, 27);
            this.btnHotel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnHotel.Name = "btnHotel";
            this.btnHotel.Size = new System.Drawing.Size(301, 74);
            this.btnHotel.TabIndex = 0;
            this.btnHotel.Tag = "Hotel";
            this.btnHotel.Text = "Edit/Add Hotels";
            this.btnHotel.UseVisualStyleBackColor = false;
            this.btnHotel.Click += new System.EventHandler(this.HandleButtonClick);
            // 
            // grpBookings
            // 
            this.grpBookings.Controls.Add(this.button3);
            this.grpBookings.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBookings.Location = new System.Drawing.Point(509, 37);
            this.grpBookings.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpBookings.Name = "grpBookings";
            this.grpBookings.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpBookings.Size = new System.Drawing.Size(395, 134);
            this.grpBookings.TabIndex = 6;
            this.grpBookings.TabStop = false;
            this.grpBookings.Text = "Bookings";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(118)))), ((int)(((byte)(217)))));
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(48, 27);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(301, 74);
            this.button3.TabIndex = 0;
            this.button3.Tag = "AvailBooking";
            this.button3.Text = "Booking Manager";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.HandleButtonClick);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.grpBookings);
            this.Controls.Add(this.grpMaintenance);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Home";
            this.Text = "Home";
            this.grpMaintenance.ResumeLayout(false);
            this.grpBookings.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMaintenance;
        private System.Windows.Forms.Button btnGuest;
        private System.Windows.Forms.Button btnAgent;
        private System.Windows.Forms.Button btnHotel;
        private System.Windows.Forms.GroupBox grpBookings;
        private System.Windows.Forms.Button button3;
    }
}