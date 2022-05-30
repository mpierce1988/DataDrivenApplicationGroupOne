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
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.grpMaintenance.SuspendLayout();
            this.grpBookings.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMaintenance
            // 
            this.grpMaintenance.Controls.Add(this.btnGuest);
            this.grpMaintenance.Controls.Add(this.btnAgent);
            this.grpMaintenance.Controls.Add(this.btnHotel);
            this.grpMaintenance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMaintenance.Location = new System.Drawing.Point(44, 30);
            this.grpMaintenance.Name = "grpMaintenance";
            this.grpMaintenance.Size = new System.Drawing.Size(296, 448);
            this.grpMaintenance.TabIndex = 5;
            this.grpMaintenance.TabStop = false;
            this.grpMaintenance.Text = "Maintenance";
            // 
            // btnGuest
            // 
            this.btnGuest.Location = new System.Drawing.Point(36, 297);
            this.btnGuest.Name = "btnGuest";
            this.btnGuest.Size = new System.Drawing.Size(226, 60);
            this.btnGuest.TabIndex = 2;
            this.btnGuest.Tag = "Guest";
            this.btnGuest.Text = "Edit/Add Guests";
            this.btnGuest.UseVisualStyleBackColor = true;
            this.btnGuest.Click += new System.EventHandler(this.HandleButtonClick);
            // 
            // btnAgent
            // 
            this.btnAgent.Location = new System.Drawing.Point(36, 194);
            this.btnAgent.Name = "btnAgent";
            this.btnAgent.Size = new System.Drawing.Size(226, 60);
            this.btnAgent.TabIndex = 1;
            this.btnAgent.Tag = "Agent";
            this.btnAgent.Text = "Edit/Add Agents";
            this.btnAgent.UseVisualStyleBackColor = true;
            this.btnAgent.Click += new System.EventHandler(this.HandleButtonClick);
            // 
            // btnHotel
            // 
            this.btnHotel.Location = new System.Drawing.Point(36, 91);
            this.btnHotel.Name = "btnHotel";
            this.btnHotel.Size = new System.Drawing.Size(226, 60);
            this.btnHotel.TabIndex = 0;
            this.btnHotel.Tag = "Hotel";
            this.btnHotel.Text = "Edit/Add Hotels";
            this.btnHotel.UseVisualStyleBackColor = true;
            this.btnHotel.Click += new System.EventHandler(this.HandleButtonClick);
            // 
            // grpBookings
            // 
            this.grpBookings.Controls.Add(this.button2);
            this.grpBookings.Controls.Add(this.button3);
            this.grpBookings.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBookings.Location = new System.Drawing.Point(449, 30);
            this.grpBookings.Name = "grpBookings";
            this.grpBookings.Size = new System.Drawing.Size(296, 448);
            this.grpBookings.TabIndex = 6;
            this.grpBookings.TabStop = false;
            this.grpBookings.Text = "Bookings";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(36, 194);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(226, 60);
            this.button2.TabIndex = 1;
            this.button2.Tag = "CancelBooking";
            this.button2.Text = "Cancel Booking";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.HandleButtonClick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(36, 91);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(226, 60);
            this.button3.TabIndex = 0;
            this.button3.Tag = "AvailBooking";
            this.button3.Text = "View Available Bookings";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.HandleButtonClick);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grpBookings);
            this.Controls.Add(this.grpMaintenance);
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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}