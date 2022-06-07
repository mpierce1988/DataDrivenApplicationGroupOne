namespace HotelApp.MenuForms
{
    partial class CreateReservation
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
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dteArrival = new System.Windows.Forms.DateTimePicker();
            this.dteDeparture = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCreateBooking = new System.Windows.Forms.Button();
            this.txtGuestEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbGuests = new System.Windows.Forms.ComboBox();
            this.grpGuestDetails = new System.Windows.Forms.GroupBox();
            this.txtGuestName = new System.Windows.Forms.TextBox();
            this.txtPhoneGuest = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.grpHotelDetails = new System.Windows.Forms.GroupBox();
            this.txtHotel = new System.Windows.Forms.TextBox();
            this.txtAmentities = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPhoneHotel = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbHotel = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.grpRoomDetails = new System.Windows.Forms.GroupBox();
            this.txtRoomNumber = new System.Windows.Forms.TextBox();
            this.txtRoomType = new System.Windows.Forms.TextBox();
            this.cmbRoomNumber = new System.Windows.Forms.ComboBox();
            this.cmbRoomTypes = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.grpAgent = new System.Windows.Forms.GroupBox();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtAgentName = new System.Windows.Forms.TextBox();
            this.txtAgentPhone = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtAgentEmail = new System.Windows.Forms.TextBox();
            this.txtArrival = new System.Windows.Forms.TextBox();
            this.txtDeparture = new System.Windows.Forms.TextBox();
            this.grpGuestDetails.SuspendLayout();
            this.grpHotelDetails.SuspendLayout();
            this.grpRoomDetails.SuspendLayout();
            this.grpAgent.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(329, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(441, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hotel Reservation Form";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(132, 833);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 20);
            this.label7.TabIndex = 8;
            this.label7.Text = "Arrival Date*:";
            // 
            // dteArrival
            // 
            this.dteArrival.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteArrival.Location = new System.Drawing.Point(136, 858);
            this.dteArrival.Name = "dteArrival";
            this.dteArrival.Size = new System.Drawing.Size(368, 26);
            this.dteArrival.TabIndex = 11;
            // 
            // dteDeparture
            // 
            this.dteDeparture.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteDeparture.Location = new System.Drawing.Point(600, 858);
            this.dteDeparture.Name = "dteDeparture";
            this.dteDeparture.Size = new System.Drawing.Size(366, 26);
            this.dteDeparture.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(596, 833);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(146, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Departure Date*:";
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(322, 950);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(198, 74);
            this.btnDelete.TabIndex = 41;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCreateBooking
            // 
            this.btnCreateBooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateBooking.Location = new System.Drawing.Point(579, 950);
            this.btnCreateBooking.Name = "btnCreateBooking";
            this.btnCreateBooking.Size = new System.Drawing.Size(198, 74);
            this.btnCreateBooking.TabIndex = 42;
            this.btnCreateBooking.Text = "Create Booking";
            this.btnCreateBooking.UseVisualStyleBackColor = true;
            this.btnCreateBooking.Click += new System.EventHandler(this.btnCreateBooking_Click);
            // 
            // txtGuestEmail
            // 
            this.txtGuestEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGuestEmail.Location = new System.Drawing.Point(6, 142);
            this.txtGuestEmail.Name = "txtGuestEmail";
            this.txtGuestEmail.ReadOnly = true;
            this.txtGuestEmail.Size = new System.Drawing.Size(368, 26);
            this.txtGuestEmail.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(2, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Email:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Guest Name*:";
            // 
            // cmbGuests
            // 
            this.cmbGuests.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGuests.FormattingEnabled = true;
            this.cmbGuests.Location = new System.Drawing.Point(6, 63);
            this.cmbGuests.Name = "cmbGuests";
            this.cmbGuests.Size = new System.Drawing.Size(368, 28);
            this.cmbGuests.TabIndex = 20;
            this.cmbGuests.SelectionChangeCommitted += new System.EventHandler(this.cmbGuests_SelectionChangeCommitted);
            // 
            // grpGuestDetails
            // 
            this.grpGuestDetails.Controls.Add(this.txtGuestName);
            this.grpGuestDetails.Controls.Add(this.txtPhoneGuest);
            this.grpGuestDetails.Controls.Add(this.label9);
            this.grpGuestDetails.Controls.Add(this.cmbGuests);
            this.grpGuestDetails.Controls.Add(this.label3);
            this.grpGuestDetails.Controls.Add(this.label4);
            this.grpGuestDetails.Controls.Add(this.txtGuestEmail);
            this.grpGuestDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpGuestDetails.Location = new System.Drawing.Point(109, 75);
            this.grpGuestDetails.Name = "grpGuestDetails";
            this.grpGuestDetails.Size = new System.Drawing.Size(420, 266);
            this.grpGuestDetails.TabIndex = 43;
            this.grpGuestDetails.TabStop = false;
            this.grpGuestDetails.Text = "Guest Details";
            // 
            // txtGuestName
            // 
            this.txtGuestName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGuestName.Location = new System.Drawing.Point(5, 64);
            this.txtGuestName.Name = "txtGuestName";
            this.txtGuestName.ReadOnly = true;
            this.txtGuestName.Size = new System.Drawing.Size(368, 26);
            this.txtGuestName.TabIndex = 46;
            // 
            // txtPhoneGuest
            // 
            this.txtPhoneGuest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneGuest.Location = new System.Drawing.Point(6, 227);
            this.txtPhoneGuest.Name = "txtPhoneGuest";
            this.txtPhoneGuest.ReadOnly = true;
            this.txtPhoneGuest.Size = new System.Drawing.Size(367, 26);
            this.txtPhoneGuest.TabIndex = 45;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(2, 204);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 20);
            this.label9.TabIndex = 44;
            this.label9.Text = "Phone:";
            // 
            // grpHotelDetails
            // 
            this.grpHotelDetails.Controls.Add(this.txtHotel);
            this.grpHotelDetails.Controls.Add(this.txtAmentities);
            this.grpHotelDetails.Controls.Add(this.label8);
            this.grpHotelDetails.Controls.Add(this.txtPhoneHotel);
            this.grpHotelDetails.Controls.Add(this.label12);
            this.grpHotelDetails.Controls.Add(this.cmbHotel);
            this.grpHotelDetails.Controls.Add(this.label13);
            this.grpHotelDetails.Controls.Add(this.label14);
            this.grpHotelDetails.Controls.Add(this.txtLocation);
            this.grpHotelDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpHotelDetails.Location = new System.Drawing.Point(569, 75);
            this.grpHotelDetails.Name = "grpHotelDetails";
            this.grpHotelDetails.Size = new System.Drawing.Size(420, 430);
            this.grpHotelDetails.TabIndex = 46;
            this.grpHotelDetails.TabStop = false;
            this.grpHotelDetails.Text = "Hotel Details";
            // 
            // txtHotel
            // 
            this.txtHotel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHotel.Location = new System.Drawing.Point(9, 64);
            this.txtHotel.Name = "txtHotel";
            this.txtHotel.ReadOnly = true;
            this.txtHotel.Size = new System.Drawing.Size(368, 26);
            this.txtHotel.TabIndex = 47;
            // 
            // txtAmentities
            // 
            this.txtAmentities.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmentities.Location = new System.Drawing.Point(10, 354);
            this.txtAmentities.Name = "txtAmentities";
            this.txtAmentities.ReadOnly = true;
            this.txtAmentities.Size = new System.Drawing.Size(367, 26);
            this.txtAmentities.TabIndex = 49;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 331);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 20);
            this.label8.TabIndex = 48;
            this.label8.Text = "Amenities";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtPhoneHotel
            // 
            this.txtPhoneHotel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneHotel.Location = new System.Drawing.Point(10, 227);
            this.txtPhoneHotel.Name = "txtPhoneHotel";
            this.txtPhoneHotel.ReadOnly = true;
            this.txtPhoneHotel.Size = new System.Drawing.Size(367, 26);
            this.txtPhoneHotel.TabIndex = 45;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 204);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 20);
            this.label12.TabIndex = 44;
            this.label12.Text = "Phone:";
            // 
            // cmbHotel
            // 
            this.cmbHotel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbHotel.FormattingEnabled = true;
            this.cmbHotel.Location = new System.Drawing.Point(9, 63);
            this.cmbHotel.Name = "cmbHotel";
            this.cmbHotel.Size = new System.Drawing.Size(368, 28);
            this.cmbHotel.TabIndex = 20;
            this.cmbHotel.SelectionChangeCommitted += new System.EventHandler(this.cmbHotel_SelectionChangeCommitted);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 42);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 20);
            this.label13.TabIndex = 2;
            this.label13.Text = "Hotel*:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(5, 125);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(83, 20);
            this.label14.TabIndex = 4;
            this.label14.Text = "Location:";
            // 
            // txtLocation
            // 
            this.txtLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocation.Location = new System.Drawing.Point(9, 146);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.ReadOnly = true;
            this.txtLocation.Size = new System.Drawing.Size(368, 26);
            this.txtLocation.TabIndex = 5;
            // 
            // grpRoomDetails
            // 
            this.grpRoomDetails.Controls.Add(this.txtRoomNumber);
            this.grpRoomDetails.Controls.Add(this.txtRoomType);
            this.grpRoomDetails.Controls.Add(this.cmbRoomNumber);
            this.grpRoomDetails.Controls.Add(this.cmbRoomTypes);
            this.grpRoomDetails.Controls.Add(this.label10);
            this.grpRoomDetails.Controls.Add(this.label11);
            this.grpRoomDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpRoomDetails.Location = new System.Drawing.Point(109, 364);
            this.grpRoomDetails.Name = "grpRoomDetails";
            this.grpRoomDetails.Size = new System.Drawing.Size(420, 214);
            this.grpRoomDetails.TabIndex = 46;
            this.grpRoomDetails.TabStop = false;
            this.grpRoomDetails.Text = "Room Details";
            // 
            // txtRoomNumber
            // 
            this.txtRoomNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoomNumber.Location = new System.Drawing.Point(5, 145);
            this.txtRoomNumber.Name = "txtRoomNumber";
            this.txtRoomNumber.ReadOnly = true;
            this.txtRoomNumber.Size = new System.Drawing.Size(368, 26);
            this.txtRoomNumber.TabIndex = 51;
            // 
            // txtRoomType
            // 
            this.txtRoomType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoomType.Location = new System.Drawing.Point(7, 64);
            this.txtRoomType.Name = "txtRoomType";
            this.txtRoomType.ReadOnly = true;
            this.txtRoomType.Size = new System.Drawing.Size(368, 26);
            this.txtRoomType.TabIndex = 50;
            // 
            // cmbRoomNumber
            // 
            this.cmbRoomNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRoomNumber.FormattingEnabled = true;
            this.cmbRoomNumber.Location = new System.Drawing.Point(7, 144);
            this.cmbRoomNumber.Name = "cmbRoomNumber";
            this.cmbRoomNumber.Size = new System.Drawing.Size(362, 28);
            this.cmbRoomNumber.TabIndex = 46;
            this.cmbRoomNumber.SelectionChangeCommitted += new System.EventHandler(this.cmbRoomNumber_SelectionChangeCommitted);
            // 
            // cmbRoomTypes
            // 
            this.cmbRoomTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRoomTypes.FormattingEnabled = true;
            this.cmbRoomTypes.Location = new System.Drawing.Point(6, 63);
            this.cmbRoomTypes.Name = "cmbRoomTypes";
            this.cmbRoomTypes.Size = new System.Drawing.Size(368, 28);
            this.cmbRoomTypes.TabIndex = 20;
            this.cmbRoomTypes.SelectionChangeCommitted += new System.EventHandler(this.cmbRoomTypes_SelectionChangeCommitted);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 20);
            this.label10.TabIndex = 2;
            this.label10.Text = "Room Type*:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(2, 121);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(144, 20);
            this.label11.TabIndex = 4;
            this.label11.Text = "Rooms Number*:";
            // 
            // grpAgent
            // 
            this.grpAgent.Controls.Add(this.txtCompany);
            this.grpAgent.Controls.Add(this.label16);
            this.grpAgent.Controls.Add(this.txtAgentName);
            this.grpAgent.Controls.Add(this.txtAgentPhone);
            this.grpAgent.Controls.Add(this.label2);
            this.grpAgent.Controls.Add(this.label5);
            this.grpAgent.Controls.Add(this.label15);
            this.grpAgent.Controls.Add(this.txtAgentEmail);
            this.grpAgent.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpAgent.Location = new System.Drawing.Point(109, 584);
            this.grpAgent.Name = "grpAgent";
            this.grpAgent.Size = new System.Drawing.Size(880, 208);
            this.grpAgent.TabIndex = 46;
            this.grpAgent.TabStop = false;
            this.grpAgent.Text = "Agent";
            // 
            // txtCompany
            // 
            this.txtCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompany.Location = new System.Drawing.Point(470, 65);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.ReadOnly = true;
            this.txtCompany.Size = new System.Drawing.Size(368, 26);
            this.txtCompany.TabIndex = 48;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(468, 42);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(95, 20);
            this.label16.TabIndex = 47;
            this.label16.Text = "Company*:";
            // 
            // txtAgentName
            // 
            this.txtAgentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAgentName.Location = new System.Drawing.Point(5, 65);
            this.txtAgentName.Name = "txtAgentName";
            this.txtAgentName.ReadOnly = true;
            this.txtAgentName.Size = new System.Drawing.Size(368, 26);
            this.txtAgentName.TabIndex = 46;
            // 
            // txtAgentPhone
            // 
            this.txtAgentPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAgentPhone.Location = new System.Drawing.Point(472, 144);
            this.txtAgentPhone.Name = "txtAgentPhone";
            this.txtAgentPhone.ReadOnly = true;
            this.txtAgentPhone.Size = new System.Drawing.Size(367, 26);
            this.txtAgentPhone.TabIndex = 45;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(468, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 44;
            this.label2.Text = "Phone:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Agent Name*:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(2, 121);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(58, 20);
            this.label15.TabIndex = 4;
            this.label15.Text = "Email:";
            // 
            // txtAgentEmail
            // 
            this.txtAgentEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAgentEmail.Location = new System.Drawing.Point(6, 142);
            this.txtAgentEmail.Name = "txtAgentEmail";
            this.txtAgentEmail.ReadOnly = true;
            this.txtAgentEmail.Size = new System.Drawing.Size(368, 26);
            this.txtAgentEmail.TabIndex = 5;
            // 
            // txtArrival
            // 
            this.txtArrival.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArrival.Location = new System.Drawing.Point(136, 859);
            this.txtArrival.Name = "txtArrival";
            this.txtArrival.ReadOnly = true;
            this.txtArrival.Size = new System.Drawing.Size(368, 26);
            this.txtArrival.TabIndex = 49;
            // 
            // txtDeparture
            // 
            this.txtDeparture.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeparture.Location = new System.Drawing.Point(600, 859);
            this.txtDeparture.Name = "txtDeparture";
            this.txtDeparture.ReadOnly = true;
            this.txtDeparture.Size = new System.Drawing.Size(368, 26);
            this.txtDeparture.TabIndex = 50;
            // 
            // CreateReservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 1064);
            this.Controls.Add(this.txtDeparture);
            this.Controls.Add(this.txtArrival);
            this.Controls.Add(this.grpAgent);
            this.Controls.Add(this.grpRoomDetails);
            this.Controls.Add(this.grpHotelDetails);
            this.Controls.Add(this.grpGuestDetails);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCreateBooking);
            this.Controls.Add(this.dteDeparture);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dteArrival);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Name = "CreateReservation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hotel";
            this.Load += new System.EventHandler(this.CreateReservation_Load);
            this.grpGuestDetails.ResumeLayout(false);
            this.grpGuestDetails.PerformLayout();
            this.grpHotelDetails.ResumeLayout(false);
            this.grpHotelDetails.PerformLayout();
            this.grpRoomDetails.ResumeLayout(false);
            this.grpRoomDetails.PerformLayout();
            this.grpAgent.ResumeLayout(false);
            this.grpAgent.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dteArrival;
        private System.Windows.Forms.DateTimePicker dteDeparture;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCreateBooking;
        private System.Windows.Forms.TextBox txtGuestEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbGuests;
        private System.Windows.Forms.GroupBox grpGuestDetails;
        private System.Windows.Forms.TextBox txtPhoneGuest;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox grpHotelDetails;
        private System.Windows.Forms.TextBox txtAmentities;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPhoneHotel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbHotel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.GroupBox grpRoomDetails;
        private System.Windows.Forms.ComboBox cmbRoomTypes;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbRoomNumber;
        private System.Windows.Forms.GroupBox grpAgent;
        private System.Windows.Forms.TextBox txtAgentPhone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtAgentEmail;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtAgentName;
        private System.Windows.Forms.TextBox txtGuestName;
        private System.Windows.Forms.TextBox txtHotel;
        private System.Windows.Forms.TextBox txtRoomNumber;
        private System.Windows.Forms.TextBox txtRoomType;
        private System.Windows.Forms.TextBox txtArrival;
        private System.Windows.Forms.TextBox txtDeparture;
    }
}