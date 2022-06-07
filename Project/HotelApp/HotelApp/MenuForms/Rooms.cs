using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HotelApp
{
    public partial class Rooms : Form
    {
        int? hotelID;
        int lastSelectedRoomID;

        public Rooms()
        {
            InitializeComponent();
        }

        public Rooms(int incomingHotelID)
        {
            InitializeComponent();
            hotelID = incomingHotelID;
        }

        #region Event Handlers
        private void Rooms_Load(object sender, EventArgs e)
        {
            try
            {
                SetupBrowse();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        


        private void cboHotel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LoadRoomInformationIntoDGV((int)cboHotel.SelectedValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                SetAddButtonState();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void HandleCellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // load values into combobox and text box up above

                int? roomTypeID = dgvRooms.SelectedCells[0].OwningRow.Cells["RoomTypeID"].Value as int?;
                string description = dgvRooms.SelectedCells[0].OwningRow.Cells["RoomTypeDescription"].Value.ToString();
                int? roomID = dgvRooms.SelectedCells[0].OwningRow.Cells["RoomID"].Value as int?;

                lastSelectedRoomID = roomID.Value;
                cboRoomType.SelectedValue = roomTypeID;
                txtDescription.Text = description;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void cboRoomType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                // check if blank row is selected. If so, return out of method
                if (cboRoomType.SelectedValue == DBNull.Value)
                {
                    return;
                }

                // get room type description
                int roomTypeID = Convert.ToInt32(cboRoomType.SelectedValue);

                
                

                string sqlRoomDescription =
                    $"SELECT RoomTypeDescription FROM RoomType WHERE RoomTypeID = {roomTypeID}";

                string roomDescription = DataAccess.ExecuteScalar(sqlRoomDescription).ToString();

                txtDescription.Text = roomDescription;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                // set buttons to modify state
                SetModifyButtonState();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void btnCancelDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // determine if this is a Cancel or Delete

                if (btnCancelDelete.Text.ToLower() == "cancel")
                {
                    // reset form to browse state
                    SetupBrowse();
                }
                else if (btnCancelDelete.Text.ToLower() == "delete")
                {
                    DeleteRoom();
                }
                else
                {
                    throw new Exception("Cannot determine type of CancelDelete press");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

       

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                // determine if this is a modify or an add
                if (dgvRooms.SelectedCells.Count == 0)
                {
                    // this is an add
                    AddNewRoom();
                }
                else
                {
                    // this is a modify
                    ModifyRoomType();
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        #endregion

        #region Load Information

        /// <summary>
        /// Reloads values from the Database and sets the form
        /// to Browse mode 
        /// </summary>
        private void SetupBrowse()
        {
            LoadHotelDropdown();

            LoadRoomTypeDropdown();

            // if local hotelID is set, set to that hotel
            if (hotelID.HasValue)
            {
                cboHotel.SelectedValue = hotelID.Value;
                LoadRoomInformationIntoDGV((int)cboHotel.SelectedValue);
                cboHotel.Enabled = false;
            }

            SetBrowseButtonState();
        }

        /// <summary>
        /// Loads all the related rooms for the given hotelID into the 
        /// DGV for Rooms
        /// </summary>
        /// <param name="selectedValue"></param>
        private void LoadRoomInformationIntoDGV(int hotelID)
        {
            // create sql query that returns room information
            // for the given hotelID
            string sqlRoomQuery =
                $@"SELECT RoomID, Room.RoomTypeID, RoomTypeName, RoomTypeDescription 
FROM Room INNER JOIN RoomType ON Room.RoomTypeID = RoomType.RoomTypeID
WHERE HotelID = {hotelID}".Replace(Environment.NewLine, " ");

            // save results to a datatable
            DataTable roomsResult = DataAccess.GetData(sqlRoomQuery);

            // assign result to dgv
            dgvRooms.DataSource = roomsResult;

            // hide roomTypeID column
            dgvRooms.Columns["RoomTypeID"].Visible = false;

            
        }

        /// <summary>
        /// Load the Current Hotels from the Database into the Dropdown
        /// </summary>
        private void LoadHotelDropdown()
        {
            // create sql query that will return the HotelID and HotelName
            string sqlHotelDropdownQuery =
                "SELECT HotelID, HotelName FROM Hotel ORDER BY HotelName ASC";

            // save results to a datatable
            DataTable dt = DataAccess.GetData(sqlHotelDropdownQuery);

            // use UIUtility to bind datatable to dropdown box
            UIUtilities.BindListControl(cboHotel, "HotelID", "HotelName", dt, true);
        }

        /// <summary>
        /// Load Room Type dropdown
        /// </summary>       
        private void LoadRoomTypeDropdown()
        {
            // create sql query to load room types into dropdown
            string sqlRoomTypes =
                "SELECT RoomTypeID, RoomTypeName FROM RoomType ORDER BY RoomTypeName ASC";

            // save result to datatable
            DataTable roomTypeResults = DataAccess.GetData(sqlRoomTypes);

            // bind to dropdown with a blank
            UIUtilities.BindListControl(cboRoomType, "RoomTypeID", "RoomTypeName", roomTypeResults, true);

        }

        /// <summary>
        /// Sets the Enabled state for the CRUD buttons to Browsing mode
        /// </summary>
        private void SetBrowseButtonState()
        {
            // set button states for browsing
            btnAdd.Enabled = true;
            btnModify.Enabled = true;
            btnConfirm.Enabled = false;
            btnCancelDelete.Enabled = true;
            btnCancelDelete.Text = "Delete";

            dgvRooms.ReadOnly = false;
            dgvRooms.Enabled = true;

            cboHotel.Enabled = false;
            cboRoomType.Enabled = false;

            txtDescription.Text = "";
        }

        /// <summary>
        /// Sets the Enabled state for the CRUD buttons to Add mode
        /// </summary>
        private void SetAddButtonState()
        {
            // set button states for browsing
            btnAdd.Enabled = false;
            btnModify.Enabled = false;
            btnConfirm.Enabled = true;
            btnCancelDelete.Enabled = true;
            btnCancelDelete.Text = "Cancel";

            dgvRooms.ReadOnly = true;
            dgvRooms.ClearSelection();
            dgvRooms.Enabled = false;

            cboHotel.Enabled = false;
            cboRoomType.Enabled = true;

            cboRoomType.SelectedValue = DBNull.Value;
        }

        /// <summary>
        /// Sets the Enabled state for the CRUD buttons to Add mode
        /// </summary>
        private void SetModifyButtonState()
        {
            // set button states for browsing
            btnAdd.Enabled = false;
            btnModify.Enabled = false;
            btnConfirm.Enabled = true;
            btnCancelDelete.Enabled = true;
            btnCancelDelete.Text = "Cancel";

            dgvRooms.ReadOnly = true;
            // disable dgv so it cannot be selected again
            dgvRooms.Enabled = false;
            

            cboHotel.Enabled = false;
            cboRoomType.Enabled = true;
        }

        #endregion

        #region Create, Update, and Delete Information

        /// <summary>
        /// Delete's the current room, as long as there are no current bookings for the room
        /// </summary>
        private void DeleteRoom()
        {
            // if no row is selected, show message and return
            if(dgvRooms.SelectedCells.Count == 0)
            {
                throw new Exception("Please select a room to delete");
            }

            // get room ID for selected room
            int? roomID = dgvRooms.SelectedCells[0].OwningRow.Cells["RoomID"].Value as int?;

            // null check
            if (!roomID.HasValue)
            {
                throw new Exception("Unable to retrieve RoomID for the selected room");
            }

            // check if any bookings have this room
            // create sql query string to get num of bookings with this roomID
            string sqlBookingsWithRoom =
                $"SELECT COUNT(*) FROM Booking WHERE RoomID = {roomID.Value}";

            // execute query and save result to an int
            int? bookingsWithThisRoom = DataAccess.ExecuteScalar(sqlBookingsWithRoom) as int?;

            // null check
            if (!bookingsWithThisRoom.HasValue)
            {
                throw new Exception("Unable to find if this room has any associated bookings before deleting");
            }

            // tell user that if there are bookings attached to this room, remove them before deleting this room
            if(bookingsWithThisRoom.Value > 0)
            {
                MessageBox.Show("Cannot delete this room. Please remove any bookings for this room and try again", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // create sql query to delete room
            string sqlDeleteRoom =
                $"DELETE FROM Room WHERE RoomID = {roomID}";

            // execute command and save rows affected
            int rowsDeleted = DataAccess.ExecuteNonQuery(sqlDeleteRoom);

            // display message to user indicating status of delete
            if(rowsDeleted == 0)
            {
                MessageBox.Show("Something went wrong, and the room was not deleted");
            }
            else
            {
                MessageBox.Show("Room " + roomID
                    + " was deleted successfully!");
            }

            // go back to initial browse state
            SetupBrowse();
        }

        /// <summary>
        /// Creates a new room from the Room type selected
        /// </summary>
        private void AddNewRoom()
        {
            // if no room type selected, return out of method
            if(cboRoomType.SelectedValue == DBNull.Value)
            {
                MessageBox.Show("Please select a room type to create a new room");
                return;
            }

            // get information into variables
            // we already have the hotelID
            int roomTypeID = Convert.ToInt32(cboRoomType.SelectedValue);

            // create sql insert statement
            string sqlInsertRoom =
                $"INSERT INTO Room (HotelID, RoomTypeID) VALUES ({hotelID}, {roomTypeID})";

            // execute and save rows affected
            int? rowsAffected = DataAccess.ExecuteNonQuery(sqlInsertRoom);

            if(rowsAffected.HasValue || rowsAffected.Value > 0)
            {
                MessageBox.Show("You have successfully created a new room!");
                UIUtilities.DisplayInStatusStrip(1, "Successfully created a new room.");
            }

            SetupBrowse();

            
        }

        private void ModifyRoomType()
        {
            // if no room type selected, show message and return
            if(cboRoomType.SelectedValue == DBNull.Value)
            {
                MessageBox.Show("Please select a new room type");
                return;
            }

            // create sql statement that will update the current room based
            // on the roomID in lastSelectedRoomID

            int selectedRoomType = Convert.ToInt32(cboRoomType.SelectedValue);

            // get selected roomID
            int? roomID = dgvRooms.SelectedCells[0].OwningRow.Cells["RoomID"].Value as int?;

            // null check
            if (!roomID.HasValue)
            {
                throw new Exception("Unable to find the RoomID for the desired modification.");
            }

            string sqlModifyRoom =
                $"UPDATE Room SET RoomTypeID = {selectedRoomType} WHERE RoomID = {roomID.Value}";

            // execute modify, and save rows affected to an int
            int rowsAffected = DataAccess.ExecuteNonQuery(sqlModifyRoom);

            // show message is update was successful
            if(rowsAffected == 1)
            {
                MessageBox.Show("Room record successfully updated!");
                UIUtilities.DisplayInStatusStrip(1, "Successfully modified a room.");
            }

            SetupBrowse();
        }

        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }
    }

}
