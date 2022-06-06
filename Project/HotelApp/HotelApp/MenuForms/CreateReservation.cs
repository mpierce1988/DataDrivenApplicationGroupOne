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
        string currentArrival;
        string currentDeparture;
        
        public CreateReservation(BookingManager form)
        {
            InitializeComponent();
            currentAgentUserName = form.currentAgent;
        }

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
        private void LoadHotels()
        {
            string sqlHotels = "SELECT HotelID, HotelName FROM Hotel ORDER BY HotelName ASC;";

            DataTable dtHotels = DataAccess.GetData(sqlHotels);

            UIUtilities.BindListControl(cmbHotel, "HotelID", "HotelName", dtHotels, true, "----Select a hotel----");
        }

        private void LoadGuests()
        {
            string sqlGuests = "SELECT GuestID, (FirstName + ', ' + LastName) AS FullName FROM Guest ORDER BY FullName;";

            DataTable dtGuests = DataAccess.GetData(sqlGuests);

            UIUtilities.BindListControl(cmbGuests, "GuestID", "FullName", dtGuests, true, "----Select a Guest----");
        }

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

        private void LoadRooms()
        {
            string sqlAvailableRooms = $"SELECT RoomID, ('Room #' + CONVERT(VARCHAR(10), RoomID)) AS RoomNumber FROM Room WHERE RoomTypeID = {selectedRoomTypeID};";

            DataTable dtAvailableRooms = DataAccess.GetData(sqlAvailableRooms);

            UIUtilities.BindListControl(cmbRoomNumber, "RoomID", "RoomNumber", dtAvailableRooms, true, "----Select a Room----");
        }

        private void LoadBooking()
        {
            string sqlBooking = $"SELECT ArrivalDate, DepartureDate FROM Booking WHERE AgentID = {selectedAgentID} AND RoomID = {currentRoomID} AND GuestID = {currentGuestID};";

            DataTable dtBooking = DataAccess.GetData(sqlBooking);

            DataRow booking = dtBooking.Rows[0];

            dteArrival.Text  = booking["ArrivalDate"].ToString();
            dteDeparture.Text = booking["DepartureDate"].ToString();
        }

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
        private void CreateReservation_Load(object sender, EventArgs e)
        {
            if(currentGuestID != 0 && currentHotelID != 0 && currentRoomTypeID != 0 && currentRoomID != 0)
            {
                LoadHotels();
                LoadGuests();
                LoadAgent();
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
                return;
            }
            LoadHotels();
            LoadGuests();
            LoadAgent();
        }

        private void cmbHotel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(cmbHotel.SelectedIndex == 0)
            {
                return;
            }

                selectedHotelID = (int)cmbHotel.SelectedValue;

                LoadHotelDetails();
                LoadRoomTypes();
        }

        private void cmbRoomTypes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if( cmbRoomTypes.SelectedIndex == 0)
            {
                cmbRoomNumber.Enabled = false;
                return;
            }

            cmbRoomNumber.Enabled = true;

            selectedRoomTypeID = (int)cmbRoomTypes.SelectedValue;

            LoadRooms();
        }

        private void cmbGuests_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(cmbGuests.SelectedIndex == 0)
            {
                txtGuestEmail.Text = "";
                txtPhoneGuest.Text = "";
                return;
            }

            selectedGuestID = (int)cmbGuests.SelectedValue;

            LoadGuestDetails();
        }

        private void cmbRoomNumber_SelectionChangeCommitted(object sender, EventArgs e)
        {
            selectedRoomID = (int)cmbRoomNumber.SelectedValue;
        }

        private void btnCreateBooking_Click(object sender, EventArgs e)
        {

        }
    }
}
