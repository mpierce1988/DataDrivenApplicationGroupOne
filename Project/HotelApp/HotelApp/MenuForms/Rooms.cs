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
                LoadHotelDropdown();

                // if local hotelID is set, set to that hotel
                if (hotelID.HasValue)
                {
                    cboHotel.SelectedValue = hotelID.Value;
                    LoadRoomInformationIntoDGV((int)cboHotel.SelectedValue);
                }
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



        #endregion

        #region Load Information

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
                $@"SELECT RoomID, RoomTypeName, RoomTypeDescription 
FROM Room INNER JOIN RoomType ON Room.RoomTypeID = RoomType.RoomTypeID
WHERE HotelID = {hotelID}".Replace(Environment.NewLine, " ");

            // save results to a datatable
            DataTable roomsResult = DataAccess.GetData(sqlRoomQuery);

            // assign result to dgv
            dgvRooms.DataSource = roomsResult;

            // create new column for Room Type drop down box
            DataGridViewColumn comboBoxColumn = new DataGridViewComboBoxColumn();
            comboBoxColumn.Name = "RoomTypeColumn";
            comboBoxColumn.Width = 100;
            comboBoxColumn.HeaderText = "Room Type";
            // add to dgv
            dgvRooms.Columns.Add(comboBoxColumn);

            // loop through rows in dgv and add room type combo box

            foreach (DataGridViewRow item in collection)
            {

            }
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


        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // add row to dgv
                dgvRooms.AllowUserToAddRows = true;
                // make datagrid editable
                dgvRooms.ReadOnly = false;

                // set all rows except last row to read only
                foreach (DataGridViewRow record in dgvRooms.Rows)
                {
                    if(record.Cells["RoomID"].ToString() != "")
                    {
                        record.ReadOnly = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }
    }


}
