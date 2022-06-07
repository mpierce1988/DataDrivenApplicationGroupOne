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
        public string currentAgent;

        public BookingManager(MainForm form)
        {
            InitializeComponent();
            currentAgent = form.currentAgent;
        }

        private void AvailableBookings_Load(object sender, EventArgs e)
        {
            LoadHotels();
        }

        #region Load Data

        /// <summary>
        /// Loads sql query table hotel into the cmbHotel combo box
        /// </summary>
        private void LoadHotels()
        {
            string sqlHotel = "SELECT HotelID, HotelName FROM Hotel ORDER BY HotelName ASC;";

            DataTable dtHotel = DataAccess.GetData(sqlHotel);

            UIUtilities.BindListControl(cmbHotel, "HotelID", "HotelName", dtHotel, true, "----Select a hotel----");
        }

        /// <summary>
        /// Retrieves info from Hotel, Room, Booking, Agent, Guest tables and loads it into the data grid view 
        /// based on the hotel that was selected in the cmbHotel combo box.
        /// </summary>
        private void LoadBookingDetails()
        {
            string sqlBookingDetails = $@"SELECT 
                                Guest.GuestID,
                                Hotel.HotelID,
                                Room.RoomID,
                                Room.RoomTypeID,
                                Booking.AgentID,
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

            //Hiding the ID's that I pulled so the user cannot see them.
            dgvBookings.Columns["GuestID"].Visible = false;
            dgvBookings.Columns["HotelID"].Visible = false;
            dgvBookings.Columns["RoomID"].Visible = false;
            dgvBookings.Columns["RoomTypeID"].Visible = false;
            dgvBookings.Columns["AgentID"].Visible = false;



            cmbHotel.SelectedValue = currentHotelID;
        }


        /// <summary>
        /// Loads the next and previous hotelID's as well as the row cound into variables.
        /// </summary>
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

            hotelCount = Convert.ToInt32(selectedRow["RowNumber"]);

        }

        /// <summary>
        /// Retrieves and passed ID's from dgv into reservation form. used on modify button click and cell double click.
        /// </summary>
        private void ModifySelectedRecord()
        {
            if (dgvBookings.CurrentRow == null)
            {
                MessageBox.Show("You must first select a booking to modify from the list.", "No selection", default, MessageBoxIcon.Error);
                return;
            }

            //Retrieving ID's required to keep track of booking details to pre load the reservation form when modifying.
            DataGridViewRow currentRow = dgvBookings.CurrentRow;

            if (currentRow.Cells.Count == 0)
            {
                MessageBox.Show("Please select a valid booking.", "Invalid selection", default, MessageBoxIcon.Error);
                return;
            }
            int currentGuestID = (int)currentRow.Cells["GuestID"].Value;
            int currentHotelID = (int)currentRow.Cells["HotelID"].Value;
            int currentRoomTypeID = (int)currentRow.Cells["RoomTypeID"].Value;
            int currentRoomID = (int)currentRow.Cells["RoomID"].Value;
            int currentAgentID = (int)currentRow.Cells["AgentID"].Value;
            string currentArrival = currentRow.Cells["Arrival"].Value.ToString();
            string currentDeparture = currentRow.Cells["Departure"].Value.ToString();

            //passing data into reservation form.
            CreateReservation currentReservation = new CreateReservation(currentGuestID, currentHotelID, currentRoomTypeID, currentRoomID, currentAgentID, currentArrival, currentDeparture);

            currentReservation.ShowDialog();

            LoadBookingDetails();
        }

        #endregion

        #region Event Handler
        private void cmbHotel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                //If the currentHotelID is not equal to null convert into a an int otherwise set the value to 0.
                currentHotelID = cmbHotel.SelectedValue != null
                    ? Convert.ToInt32(cmbHotel.SelectedValue)
                    : 0;

                if (currentHotelID == 0)
                {
                    return;
                }
                else
                {
                    //if a value was assigned to the variable currentHotelID go ahead and load booking details.
                    LoadBookingDetails();
                }
                LoadNavigation();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), default, MessageBoxIcon.Error);
            }
            
        }

        /// <summary>
        /// Loads the first hotel in the list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFirst_Click(object sender, EventArgs e)
        {
            try
            {
                cmbHotel.SelectedIndex = 1;
                currentHotelID = (int)cmbHotel.SelectedValue;
                LoadNavigation();
                LoadBookingDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), default, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Loads the last hotel in the list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLast_Click(object sender, EventArgs e)
        {
            try
            {
                cmbHotel.SelectedIndex = cmbHotel.Items.Count - 1;
                currentHotelID = (int)cmbHotel.SelectedValue;
                LoadNavigation();
                LoadBookingDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), default, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Loads the previous hotel in the list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                //Prevents error if user clicks previous button before selecting a hotel from the list.
                if (currentHotelID == -1)
                {
                    cmbHotel.SelectedIndex = 1;
                    currentHotelID = (int)cmbHotel.SelectedValue;
                    LoadBookingDetails();
                    return;
                }

                LoadNavigation();

                //If the previous hotelID is null display a message and stop it from loading.
                if (previousHotelID == null)
                {
                    MessageBox.Show("First hotel is currently being displayed");
                    return;
                }
                currentHotelID = previousHotelID.Value;
                LoadBookingDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), default, MessageBoxIcon.Error);

            }


        }

        /// <summary>
        /// Loads the next hotel in the list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                //Prevents error if user clicks next button before selecting a hotel from the list.
                if (currentHotelID == -1)
                {
                    cmbHotel.SelectedIndex = cmbHotel.Items.Count - 1;
                    currentHotelID = (int)cmbHotel.SelectedValue;
                    LoadBookingDetails();
                    return;
                }

                LoadNavigation();

                //If the enxt hotelID is null display a message and stop it form loading.
                if (nextHotelID == null)
                {
                    MessageBox.Show("Last hotel is currently being displayed");
                    return;
                }
                currentHotelID = nextHotelID.Value;
                LoadBookingDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), default, MessageBoxIcon.Error);

            }

        }

        private void dgvBookings_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ModifySelectedRecord();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), default, MessageBoxIcon.Error);

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //Load reservation form without any data.
                CreateReservation createReservation = new CreateReservation(this);
                createReservation.ShowDialog();
                
                LoadBookingDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), default, MessageBoxIcon.Error);

            }

        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                ModifySelectedRecord();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), default, MessageBoxIcon.Error);

            }
        }

        #endregion

    }
}
