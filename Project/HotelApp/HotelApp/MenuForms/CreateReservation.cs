using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HotelApp.MenuForms
{
    public partial class CreateReservation : Form
    {
        int selectedGuestID;
        int selectedHotelID;
        int selectedRoomTypeID;
        int selectedRoomID;
        string currentAgentUserName;
        int selectedAgentID;
        int currentGuestID;
        int currentHotelID;
        int currentRoomTypeID;
        int currentRoomID;
        int currentBookingID;
        string currentArrival;
        string currentDeparture;
        
        //Retrieves the username that was used to login. Functions using a chain
        //of child/parent forms and passing in data from the login form to here.
        public CreateReservation(BookingManager form)
        {
            InitializeComponent();
            currentAgentUserName = form.currentAgent;
        }

        //Retrieves the ID's that were passed in by the booking manager form and assigns it to variables.
        public CreateReservation(int guestID, int hotelID, int roomTypeID, int roomID, int agentID, string arrival, string departure)
        {
            InitializeComponent();
            currentGuestID = guestID;
            currentHotelID = hotelID;
            currentRoomTypeID = roomTypeID;
            currentRoomID = roomID;
            currentArrival = arrival;
            currentDeparture = departure;
            selectedAgentID = agentID;
        }

        #region LoadData
        /// <summary>
        /// Loads the hotels into the hotel combo box.
        /// </summary>
        private void LoadHotels()
        {
            string sqlHotels = "SELECT HotelID, HotelName FROM Hotel ORDER BY HotelName ASC;";

            DataTable dtHotels = DataAccess.GetData(sqlHotels);

            UIUtilities.BindListControl(cmbHotel, "HotelID", "HotelName", dtHotels, true, "----Select a hotel----");
        }

        /// <summary>
        /// Loads the registered guests into the combo box.
        /// </summary>
        private void LoadGuests()
        {
            string sqlGuests = "SELECT GuestID, (FirstName + ', ' + LastName) AS FullName FROM Guest ORDER BY FullName;";

            DataTable dtGuests = DataAccess.GetData(sqlGuests);

            UIUtilities.BindListControl(cmbGuests, "GuestID", "FullName", dtGuests, true, "----Select a Guest----");
        }

        /// <summary>
        /// Loads available room types into the combo box based on which hotel was picked
        /// </summary>
        private void LoadRoomTypes()
        {
            string sqlRoomTypes = $@"SELECT Room.RoomTypeID, (RoomTypeName + ' - ' + RoomTypeDescription) AS RoomDesc 
                                FROM RoomType
                                INNER JOIN Room ON RoomType.RoomTypeID = Room.RoomTypeID
                                WHERE HotelID = {selectedHotelID}
                                ORDER BY RoomTypeDescription; ";

            DataTable dtRoomTypes = DataAccess.GetData(sqlRoomTypes);

            UIUtilities.BindListControl(cmbRoomTypes, "RoomTypeID", "RoomDesc", dtRoomTypes, true, "----Select a RoomType----");
        }

        /// <summary>
        /// Load available rooms based on which room type was picked.
        /// </summary>
        private void LoadRooms()
        {
            string sqlAvailableRooms = $"SELECT RoomID, ('Room #' + CONVERT(VARCHAR(10), RoomID)) AS RoomNumber FROM Room WHERE RoomTypeID = {selectedRoomTypeID};";

            DataTable dtAvailableRooms = DataAccess.GetData(sqlAvailableRooms);

            UIUtilities.BindListControl(cmbRoomNumber, "RoomID", "RoomNumber", dtAvailableRooms, true, "----Select a Room----");
        }

        /// <summary>
        /// Loads the booking based on selection made in booking manager
        /// </summary>
        private void LoadBooking()
        {
            string sqlBooking = $"SELECT BookingID, ArrivalDate, DepartureDate FROM Booking WHERE AgentID = {selectedAgentID} AND RoomID = {currentRoomID} AND GuestID = {currentGuestID};";

            DataTable dtBooking = DataAccess.GetData(sqlBooking);

            DataRow booking = dtBooking.Rows[0];

            dteArrival.Text  = booking["ArrivalDate"].ToString();
            dteDeparture.Text = booking["DepartureDate"].ToString();
            currentBookingID = (int)booking["BookingID"];

        }

        /// <summary>
        /// Checks to see if a username was passed in. If username is empty 
        /// means agent must be taken from booking manager otherwise assign logged in
        /// agent.
        /// </summary>
        private void LoadAgent()
        {
            if(currentAgentUserName == null)
            {
                string sqlSelectedAgent = $@"SELECT 
                                    AgentID,
                                    (FirstName + ', ' + LastName) AS FullName,
                                    Company,
                                    Phone,
                                    Email
                                    FROM Agent
                                    WHERE AgentID = {selectedAgentID};";


                DataTable dtAgent = DataAccess.GetData(sqlSelectedAgent);

                DataRow values = dtAgent.Rows[0];

                txtAgentName.Text = values["FullName"].ToString();
                txtAgentEmail.Text = values["Email"].ToString();
                txtAgentPhone.Text = values["Phone"].ToString();
                txtCompany.Text = values["Company"].ToString();

                selectedAgentID = (int)values["AgentID"];

            }
            else
            {
                string sqlCurrentAgent = $@"SELECT 
                    AgentID,
                    (FirstName + ', ' + LastName) AS FullName,
                    Company,
                    Phone,
                    Email
                    FROM Agent
                    WHERE UserName = '{currentAgentUserName}'";

                DataTable dtAgent = DataAccess.GetData(sqlCurrentAgent);

                DataRow values = dtAgent.Rows[0];

                txtAgentName.Text = values["FullName"].ToString();
                txtAgentEmail.Text = values["Email"].ToString();
                txtAgentPhone.Text = values["Phone"].ToString();
                txtCompany.Text = values["Company"].ToString();

                selectedAgentID = (int)values["AgentID"];
            }

            
        }

        /// <summary>
        /// Loads the hotels details into textboxes baed on which hotel is selected.
        /// </summary>
        private void LoadHotelDetails()
        {
            string sqlHotelDetails = $@"SELECT 
            (CivicNumber + ' ' + StreetName + ' ' + City + ', ' + Province) AS [Location],
            PhoneNumber,
            AmentityName
            FROM Hotel 
            INNER JOIN AmentitiesHotel 
	            ON Hotel.HotelID = AmentitiesHotel.HotelID
            INNER JOIN Amentities
	            ON AmentitiesHotel.AmentityID = Amentities.AmentityID
            WHERE Hotel.HotelID = {selectedHotelID};";

            DataTable dtHotelDetails = DataAccess.GetData(sqlHotelDetails);

            DataRow values = dtHotelDetails.Rows[0];

            txtLocation.Text = values["Location"].ToString();
            txtPhoneHotel.Text = values["PhoneNumber"].ToString();
            txtAmentities.Text = values["AmentityName"].ToString();
        }

        /// <summary>
        /// Loads the guest details for the selected guest
        /// </summary>
        private void LoadGuestDetails()
        {
            string sqlGuestDetails = $@"SELECT 
                                    Email,
                                    PhoneNumber
                                    FROM Guest
                                    WHERE GuestID = {selectedGuestID};";


            DataTable dtGuestDetails = DataAccess.GetData(sqlGuestDetails);

            DataRow Values = dtGuestDetails.Rows[0];

            txtGuestEmail.Text = Values["Email"].ToString();
            txtPhoneGuest.Text = Values["PhoneNumber"].ToString();
        }

        #endregion

        
        /// <summary>
        /// When form loads load dara into combo boxes. If booking is pre-existing allow for modification/deletion of 
        /// pre existing fields otherwise start a fresh form with create function.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateReservation_Load(object sender, EventArgs e)
        {
            if(isExistingBooking())
            {
                LoadHotels();
                LoadGuests();
                LoadAgent();
                LoadFromBookingManager();

                EnableFieldEdit(false);
                btnCreateBooking.Text = "Modify";
                btnDelete.Enabled = false;
                cmbGuests.Visible = false;
                return;
            }
            LoadHotels();
            LoadGuests();
            LoadAgent();
            txtGuestName.Visible = false;
            EnableFieldEdit(true);
            btnDelete.Text = "Reset";
            cmbRoomTypes.Enabled = false;
            cmbRoomNumber.Enabled = false;
        }
        /// <summary>
        /// Get values from the booking manager and assign them to selected variables. 
        /// Then load details for each table into their fields calling the created methods and assinging selected value on combo boxes.
        /// </summary>
        private void LoadFromBookingManager()
        {
            selectedGuestID = currentGuestID;
            selectedHotelID = currentHotelID;
            selectedRoomID = currentRoomID;
            selectedRoomTypeID = currentRoomTypeID;

            cmbGuests.SelectedValue = currentGuestID;
            cmbHotel.SelectedValue = currentHotelID;


            LoadGuestDetails();
            LoadHotelDetails();
            LoadRoomTypes();
            LoadRooms();


            cmbRoomTypes.SelectedValue = currentRoomTypeID;
            cmbRoomNumber.SelectedValue = currentRoomID;
            LoadBooking();

            cmbGuests.Visible = false;
        }

        /// <summary>
        /// Tracks which hotel was selected in the fropdown and loads the related paramaters.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbHotel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cmbHotel.SelectedIndex == 0)
                {
                    return;
                }

                selectedHotelID = (int)cmbHotel.SelectedValue;

                LoadHotelDetails();
                LoadRoomTypes();
                cmbRoomTypes.SelectedIndex = 0;
                cmbRoomTypes.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), default, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Keeps tracks of which room type was selected and sets the value accordingly.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbRoomTypes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cmbRoomTypes.SelectedIndex == 0)
                {
                    cmbRoomNumber.Enabled = false;
                    cmbRoomNumber.SelectedValue = DBNull.Value;
                    return;
                }

                cmbRoomNumber.Enabled = true;

                selectedRoomTypeID = (int)cmbRoomTypes.SelectedValue;

                LoadRooms();

                cmbRoomNumber.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), default, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Changes the guest details based on which guest is selected in the dropdown.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbGuests_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cmbGuests.SelectedIndex == 0)
                {
                    txtGuestEmail.Text = "";
                    txtPhoneGuest.Text = "";
                    return;
                }

                selectedGuestID = (int)cmbGuests.SelectedValue;

                LoadGuestDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), default, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// keeps track of the selected room, avoids null.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbRoomNumber_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cmbRoomNumber.SelectedValue == DBNull.Value)
                {
                    return;
                }
                selectedRoomID = (int)cmbRoomNumber.SelectedValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), default, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Enables the editing fields on first click and changes button text. Allows modifying existing
        /// records and adding new ones by calling methods.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateBooking_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateModifyOrCreate())
                {
                    if (btnCreateBooking.Text == "Modify")
                    {
                        EnableFieldEdit(true);
                        btnCreateBooking.Text = "Save";
                        btnDelete.Text = "Cancel";
                        btnDelete.Enabled = true;
                        return;
                    }
                    else if (btnCreateBooking.Text == "Save")
                    {
                        UpdateBooking();
                        return;
                    }
                    AddBooking();
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), default, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Button can cancel pending modifications, reset the form when creating new reservations or delete bookings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnDelete.Text == "Cancel")
                {
                    if (isExistingBooking())
                    {
                        //this resets the form back to the values obtained from the booking manager.
                        LoadFromBookingManager();
                        EnableFieldEdit(false);
                        btnCreateBooking.Text = "Modify";
                        btnDelete.Enabled = false;
                        return;
                    }
                }
                else if (btnDelete.Text == "Reset")
                {
                    cmbGuests.SelectedValue = DBNull.Value;
                    cmbHotel.SelectedValue = DBNull.Value;
                    cmbRoomNumber.SelectedValue = DBNull.Value;
                    cmbRoomTypes.SelectedValue = DBNull.Value;
                    dteArrival.Text = DateTime.Now.ToString();
                    dteDeparture.Text = DateTime.Now.ToString();

                    cmbRoomTypes.Enabled = false;
                    cmbRoomNumber.Enabled = false;
                }
                else
                {
                    DialogResult result = MessageBox.Show("Are you sure you wish to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.Yes)
                    {
                        DeleteBooking();
                    }
                    else
                    {
                        MessageBox.Show("Booking was not deleted.", "Canceled Delete");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), default, MessageBoxIcon.Error);
            }

        }
        /// <summary>
        /// Adds a booking to the database based on user selection and gives user a notification on success/failure.
        /// </summary>
        private void AddBooking()
        {
            string sqlCreateBooking = $@"INSERT INTO Booking (AgentID, RoomID, GuestID, ArrivalDate, DepartureDate)
                                        VALUES
                                        ({selectedAgentID}, {cmbRoomNumber.SelectedValue}, {cmbGuests.SelectedValue}, '{Convert.ToDateTime(dteArrival.Text)}', '{Convert.ToDateTime(dteDeparture.Text)}'); ";

            int rowsAffected = DataAccess.ExecuteNonQuery(sqlCreateBooking);

            if (rowsAffected == 1)
            {
                MessageBox.Show("Booking has been created!", "Success");
            }
            else
            {
                MessageBox.Show("Booking Failed!", "Failure");
            }
        }

        /// <summary>
        /// Updates the existing booking that was selected in booking manager and notifies user with a message of success/failure.
        /// </summary>
        private void UpdateBooking()
        {
            string sqlModify = $"UPDATE Booking SET RoomID = {cmbRoomNumber.SelectedValue}, ArrivalDate = '{Convert.ToDateTime(dteArrival.Text)}', DepartureDate = '{Convert.ToDateTime(dteDeparture.Text)}' WHERE BookingID = {currentBookingID};";

            int rowsAffected = DataAccess.ExecuteNonQuery(sqlModify);

            if (rowsAffected == 1)
            {
                MessageBox.Show("Booking has been updated", "Success");
            }
            else
            {
                MessageBox.Show("Failed to update booking", "Failure");
            }
        }

        /// <summary>
        ///Deletes the existing booking that was selected in booking manager and notifies user with a message of success/failure.
        /// </summary>
        private void DeleteBooking()
        {
            string sqlDelete = $"DELETE FROM Booking WHERE BookingID = {currentBookingID};";

            int rowsAffected = DataAccess.ExecuteNonQuery(sqlDelete);

            if(rowsAffected == 1)
            {
                MessageBox.Show("Booking was successfully deleted! This form will now close...", "Delete Successful");
                this.Close();
            }
            else
            {
                MessageBox.Show("Booking failed to delete!", "Error");
                return;
            }
        }

        /// <summary>
        /// Checks to make sure not of the required values are null and returns a bool based on pass or fail.
        /// </summary>
        /// <returns></returns>
        private bool ValidateModifyOrCreate()
        {
            if(cmbHotel.SelectedValue == DBNull.Value || cmbRoomNumber.SelectedValue == DBNull.Value || cmbRoomTypes.SelectedValue == DBNull.Value)
            {
                MessageBox.Show("You must make a selection for all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
            
            
        }
        /// <summary>
        /// Enable/Disable user's ability to edit fields based on passed in bool state.
        /// </summary>
        /// <param name="state"></param>
        private void EnableFieldEdit(bool state)
        {
            if (state == false)
            {
                cmbHotel.Visible = state;
                cmbRoomNumber.Visible = state;
                cmbRoomTypes.Visible = state;
                dteArrival.Visible = state;
                dteDeparture.Visible = state;
                txtGuestName.Text = cmbGuests.Text;
                txtHotel.Text = cmbHotel.Text;
                txtRoomNumber.Text = cmbRoomNumber.Text;
                txtRoomType.Text = cmbRoomTypes.Text;
                txtArrival.Text = dteArrival.Text;
                txtDeparture.Text = dteDeparture.Text;
                txtGuestName.Visible = true;
                txtHotel.Visible = true;
                txtRoomNumber.Visible = true;
                txtRoomType.Visible = true;
                txtArrival.Visible = true;
                txtDeparture.Visible = true;
            }
            else
            {
                cmbHotel.Visible = state;
                cmbRoomNumber.Visible = state;
                cmbRoomTypes.Visible = state;
                dteArrival.Visible = state;
                dteDeparture.Visible = state;
                txtHotel.Visible = false;
                txtRoomNumber.Visible = false;
                txtRoomType.Visible = false;
                txtArrival.Visible = false;
                txtDeparture.Visible = false;
            }

        }

        /// <summary>
        /// Checks to see if user is trying to pull existing info from
        /// booking manager or trying to start a new booking.
        /// </summary>
        /// <returns></returns>
        private bool isExistingBooking()
        {
            return (currentGuestID != 0 && currentHotelID != 0 && currentRoomTypeID != 0 && currentRoomID != 0);
        }

        
    }
}
