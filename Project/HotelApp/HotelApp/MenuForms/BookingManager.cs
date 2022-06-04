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
    public partial class BookingManager : Form
    {
        int currentHotelID = -1;
        int? nextHotelID;
        int? previousHotelID;
        int hotelCount;
        public BookingManager()
        {
            InitializeComponent();
        }

        private void AvailableBookings_Load(object sender, EventArgs e)
        {
            LoadHotels();
        }



        private void LoadHotels()
        {
            string sqlHotel = "SELECT HotelID, HotelName FROM Hotel ORDER BY HotelName ASC;";

            DataTable dtHotel = DataAccess.GetData(sqlHotel);

            UIUtilities.BindListControl(cmbHotel, "HotelID", "HotelName", dtHotel, true, "----Select a hotel----");
        }

        private void LoadBookingDetails()
        {
            string sqlBookingDetails = $@"SELECT 
                        HotelName AS [Hotel Name], 
                        (Hotel.City + ', ' + Hotel.Province) AS [Location],
                        Hotel.PhoneNumber AS [Hotel Phone],
                        ArrivalDate AS Arrival,
                        DepartureDate AS Departure,
                        (Guest.FirstName + ', ' + Guest.LastName) AS [Booked by],
                        Guest.PhoneNumber AS [Guest Phone],
                        Guest.Email AS [Guest Email],
                        (Agent.FirstName + ', ' + Agent.LastName) AS [Booking Agent],
                        Agent.Phone AS [Agent Phone],
                        Agent.Email AS [Agent Email]
                        FROM Hotel 
                        INNER JOIN Room ON Hotel.HotelID = Room.HotelID 
                        INNER JOIN Booking ON Room.RoomID = Booking.RoomID 
                        INNER JOIN Agent ON Agent.AgentID = Booking.AgentID 
                        INNER JOIN Guest ON Guest.GuestID = Booking.GuestID
                        WHERE Hotel.HotelID = {currentHotelID}
                        ORDER BY ArrivalDate , DepartureDate DESC;";

            DataTable dtBookingDetails = DataAccess.GetData(sqlBookingDetails);

            dgvBookings.DataSource = dtBookingDetails;

            cmbHotel.SelectedValue = currentHotelID;
        }


        private void LoadFirstHotelID()
        {
            cmbHotel.SelectedIndex = 1;
            currentHotelID = Convert.ToInt32(cmbHotel.SelectedValue);
            LoadBookingDetails();
        }

        private void LoadLastHotelID()
        {
            cmbHotel.SelectedIndex = cmbHotel.Items.Count - 1;
            currentHotelID = Convert.ToInt32(cmbHotel.SelectedValue);
            LoadBookingDetails();
        }


        private void LoadNavigation()
        {
            string sqlNavigation = $@"SELECT nav.NextHotelID, nav.PreviousHotelID, nav.RowNumber
                                    FROM
                                    (
                                    SELECT 
                                    HotelID,
                                    HotelName,
                                    LEAD(HotelID) OVER(ORDER BY HotelName) AS NextHotelID,
                                    LAG(HotelID) OVER(ORDER BY HotelName) AS PreviousHotelID,
                                    ROW_NUMBER() OVER(ORDER BY HotelName) AS 'RowNumber'
                                    FROM Hotel
                                    ) AS nav
                                    WHERE HotelID = {currentHotelID}
                                    ORDER BY HotelName;";

            DataTable dtNavigation = DataAccess.GetData(sqlNavigation);

            DataRow selectedRow = dtNavigation.Rows[0];

            nextHotelID = selectedRow["NextHotelID"] != DBNull.Value
                ? Convert.ToInt32(selectedRow["NextHotelID"])
                : (int?)null;

            previousHotelID = selectedRow["PreviousHotelID"] != DBNull.Value
                ? Convert.ToInt32(selectedRow["PreviousHotelID"])
                :(int?)null;

            currentHotelID = Convert.ToInt32(selectedRow["RowNumber"]);
        }

        private void cmbHotel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            currentHotelID = cmbHotel.SelectedValue != null 
                ? Convert.ToInt32(cmbHotel.SelectedValue) 
                : 0;

            if(currentHotelID == 0)
            {
                return;
            }
            else
            {
                LoadBookingDetails();
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            LoadFirstHotelID();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            LoadLastHotelID();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if(currentHotelID == -1)
            {
                LoadLastHotelID();
                return;
            }

            LoadNavigation();

            if (previousHotelID == null)
            {
                MessageBox.Show("Last hotel is currently being displayed");
                return;
            }
            currentHotelID = (int)previousHotelID;
            LoadBookingDetails();
            
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentHotelID == -1)
            {
                LoadFirstHotelID();
                return;
            }

            LoadNavigation();

            if (nextHotelID == null)
            {
                MessageBox.Show("First hotel is currently being displayed");
                return;
            }
            currentHotelID = (int)nextHotelID;
            LoadBookingDetails();

        }
    }
}
