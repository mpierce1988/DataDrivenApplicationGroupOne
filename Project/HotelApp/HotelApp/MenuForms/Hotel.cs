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
    public partial class Hotel : Form
    {

        // Fields to hold the values for Navigation buttons
        int firstHotelID;
        int lastHotelID;
        int currentHotelID;
        int currentPosition;
        int totalHotels;

        int? previousHotelID;
        int? nextHotelID;

        public Hotel()
        {
            InitializeComponent();
        }
        #region Event Handlers
        
        
        private void Hotel_Load(object sender, EventArgs e)
        {
            try
            {
                Setup();
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
                // if first blank row selected, do nothing
                if(cboHotel.SelectedValue == DBNull.Value)
                {
                    return;
                }

                // set currentHotelID to the selected hotel ID
                currentHotelID = Convert.ToInt32(cboHotel.SelectedValue);

                // load hotel details
                LoadHotelInformation();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        /// <summary>
        /// Handle button presses from the Navigation (First, Last, Previous, Next) Buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Navigation_Handler(object sender, EventArgs e)
        {
            try
            {
                // try to cast sender as button
                Button btn = sender as Button;

                // if sender is not a button, throw an error
                if(sender == null)
                {
                    throw new ArgumentException("Navigation_Handler was called by a non-Button");
                }

                // set currentHotelID based on which button was pressed
                switch (btn.Name)
                {
                    case "btnFirst":
                        currentHotelID = firstHotelID;
                        break;
                    case "btnPrevious":
                        currentHotelID = previousHotelID.Value;
                        break;
                    case "btnNext":
                        currentHotelID = nextHotelID.Value;
                        break;
                    case "btnLast":
                        currentHotelID = lastHotelID;
                        break;
                }

                // load hotel information
                LoadHotelInformation();

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
                // set button state to Add state
                SetButtonsState(ButtonState.Add);

                // clear form controls
                ClearFormFields();
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
                // determine if this button is current a delete or a cancel
                // cast sender as a button
                Button button = sender as Button;

                // check if value is null before proceeding
                if(button == null)
                {
                    throw new ArgumentException("A non-button has called the btnCancelDelete_Click method");
                }

                // respond differently if this is a cancel or a delete
                if(button.Text.ToLower() == "cancel")
                {
                    Setup();
                }
                else if(button.Text.ToLower() == "delete")
                {
                    MessageBox.Show("Delete functionality not implemented yet");
                    Setup();
                }
                else
                {
                    throw new ArgumentException("CancelDelete button has an invalid name");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // determine if this is a create or modify
                Button btn = sender as Button;

                // verify cast was successful
                if(btn == null)
                {
                    throw new ArgumentException("A non-button has called the btnSave_click method");
                }

                if(btn.Text.ToLower() == "save")
                {

                }
                else if(btn.Text.ToLower() == "create")
                {
                    // create hotel from the values entered in the form
                    CreateHotel();
                    // reload dropdown values so they include newly created hotel, and reload first
                    // hotel information
                    Setup();

                }
                else
                {
                    throw new ArgumentException("SaveCreate button has an invalid name while calling btnSave_click");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        

        /// <summary>
        /// Ensures the Hotel Fields are not empty
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValidateHotelField(object sender, CancelEventArgs e)
        {
            try
            {
                // case sender as text field
                TextBox textBox = sender as TextBox;

                // verify cast was successful
                if(textBox == null)
                {
                    throw new ArgumentException("A non-Textbox has called the ValidateHotelField method");
                }

                // if text is empty, display error and cancel validation
                if(textBox.Text == "")
                {
                    // set error provider to display error
                    errorProvider1.SetError(textBox, $"{textBox.Tag} field must not be blank");

                    // cancel validation
                    e.Cancel = true;
                }
                else
                {
                    // reset error provider
                    errorProvider1.SetError(textBox, "");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        #endregion

        #region UI Helpers

        /// <summary>
        ///  Resets/disables all error providers
        /// </summary>
        private void ClearAllErrorProviders()
        {
            errorProvider1.SetError(txtCity, "");
            errorProvider1.SetError(txtCivicNumber, "");
            errorProvider1.SetError(txtHotelName, "");
            errorProvider1.SetError(txtPhone, "");
            errorProvider1.SetError(txtProvince, "");
            errorProvider1.SetError(txtStreetName, "");
        }

        /// <summary>
        /// Clears all of the form Input fields
        /// </summary>
        private void ClearFormFields()
        {
            // clear form fields
            cboHotel.SelectedValue = DBNull.Value;

            txtCity.Text = "";
            txtCivicNumber.Text = "";
            txtHotelName.Text = "";
            txtPhone.Text = "";
            txtProvince.Text = "";
            txtStreetName.Text = "";

            chkBreakfast.Checked = false;
            chkParking.Checked = false;
            chkPool.Checked = false;
        }

        /// <summary>
        /// Enum to keep handle changing enabled/disabled state of buttons
        /// </summary>
        private enum ButtonState
        {
            Browse,
            Add,
            Modify,
            Delete
        }

        /// <summary>
        /// Sets the state of the nav buttons based on the current state of the app
        /// </summary>
        /// <param name="buttonState"></param>
        private void SetButtonsState(ButtonState buttonState)
        {
            void SetNavState(bool state)
            {
                btnPrevious.Enabled = state;
                btnNext.Enabled = state;
                btnFirst.Enabled = state;
                btnLast.Enabled = state;                
            }
            switch (buttonState)
            {
                case ButtonState.Browse:
                    SetNavState(true);

                    btnSave.Enabled = false;
                    btnSave.Text = "Save";

                    btnCancelDelete.Enabled = true;
                    btnCancelDelete.Text = "Delete";                    

                    btnAdd.Enabled = true;
                    btnModify.Enabled = true;
                    cboHotel.Enabled = true;
                    break;
                case ButtonState.Add:
                    // only enable Save and Cancel
                    // change save button text to "Create"
                    SetNavState(false);
                    cboHotel.SelectedValue = DBNull.Value;
                    cboHotel.Enabled = false;

                    btnSave.Enabled = true;
                    btnSave.Text = "Create";

                    btnCancelDelete.Enabled = true;

                    btnCancelDelete.Text = "Cancel";

                    btnAdd.Enabled = false;
                    btnModify.Enabled = false;
                    break;
                case ButtonState.Modify:
                    // Only enable save and cancel
                    // set save button text to "Save"
                    SetNavState(false);
                    cboHotel.SelectedValue = DBNull.Value;
                    cboHotel.Enabled = false;

                    btnSave.Enabled = true;
                    btnSave.Text = "Save";
                    btnCancelDelete.Enabled = true;

                    btnCancelDelete.Text = "Cancel";

                    btnAdd.Enabled = false;
                    btnModify.Enabled = false;

                    break;
                case ButtonState.Delete:
                    break;
                default:
                    break;
            }
        }


        /// <summary>
        /// Sets the form fields to display information from a DataRow containing a Hotel record
        /// </summary>
        /// <param name="selectedRecord"></param>
        /// <exception cref="Exception"></exception>
        private void DisplayHotelInformationFromRecord(DataRow selectedRecord)
        {
            // verify DataRow is valid
            if (selectedRecord == null || selectedRecord["HotelName"] == null)
            {
                throw new Exception("A null or incorrect hotel record was passed into the DisplayHotelInformation method");
            }

            // populate form fields with information
            cboHotel.SelectedValue = currentHotelID;

            txtHotelName.Text = selectedRecord["HotelName"].ToString();
            txtCivicNumber.Text = selectedRecord["CivicNumber"].ToString();
            txtStreetName.Text = selectedRecord["StreetName"].ToString();
            txtCity.Text = selectedRecord["City"].ToString();
            txtProvince.Text = selectedRecord["Province"].ToString();
            txtPhone.Text = selectedRecord["PhoneNumber"].ToString();
        }

        /// <summary>
        /// Sets the Checkboxes based on a DataTable of amenities for the given currentHotelID
        /// </summary>
        /// <param name="amenitiesResults"></param>
        private void SetCheckboxesFromAmenityResults(DataTable amenitiesResults)
        {
            // reset all the check boxes
            chkPool.Checked = false;
            chkParking.Checked = false;
            chkBreakfast.Checked = false;

            // for each row in the amenities results, check for an amenitity
            foreach (DataRow row in amenitiesResults.Rows)
            {
                int amenityID = Convert.ToInt32(row["AmentityID"]);

                switch (amenityID)
                {
                    case 1:
                        chkParking.Checked = true;
                        break;
                    case 2:
                        chkPool.Checked = true;
                        break;
                    case 3:
                        chkBreakfast.Checked = true;
                        break;
                }
            }
        }

        /// <summary>
        /// Enables or Disables the Previous and Next buttons depending on the values
        /// in previousHotelID and nextHotelID
        /// </summary>
        private void SetPrevNextButtonState()
        {
            btnPrevious.Enabled = previousHotelID == null ? false : true;
            btnNext.Enabled = nextHotelID == null ? false : true;
        }

        #endregion

        #region Modifying And Saving Information

        /// <summary>
        /// Create a new hotel entry out of the information entered in the form fields
        /// </summary>
        private void CreateHotel()
        {
            // validate fields
            if (!ValidateChildren(ValidationConstraints.Enabled))
            {
                MessageBox.Show("One or more fields are missing information. Please complete all fields and try again");
                Setup();
                return;
            }

            // save information to variables
            string hotelName = txtHotelName.Text.Trim();
            string civicNumber = txtCivicNumber.Text.Trim();
            string streetName = txtStreetName.Text.Trim();
            string city = txtCity.Text.Trim();
            string province = txtProvince.Text.Trim();
            string phoneNumber = txtPhone.Text.Trim();
            string pathToImage = "";

            bool hasPool = chkPool.Checked;
            bool hasBreakfast = chkBreakfast.Checked;
            bool hasParking = chkParking.Checked;

            // check to make sure a record with this information does not already exist
            string sqlDuplicateHotelCheck =
                $"SELECT COUNT(*) FROM Hotel WHERE HotelName = '{hotelName}' AND CivicNumber = '{civicNumber}' AND StreetName = '{streetName}' AND City = '{city}' AND Province = '{province}' AND PhoneNumber = '{phoneNumber}'";

            int? duplicateHotels = DataAccess.ExecuteScalar(sqlDuplicateHotelCheck) as int?;

            if (!duplicateHotels.HasValue)
            {
                MessageBox.Show("Cannot check for duplicate records. Aborting new record attempt.");
                return;
            }

            if(duplicateHotels.Value > 0)
            {
                MessageBox.Show("A hotel with these details already exists in the system.");
                return;
            }

            // create sql string to insert basic hotel info (without amenities)
            string sqlCreateHotel =
                $@"INSERT INTO Hotel (HotelName, CivicNumber, StreetName, City, Province, PhoneNumber, PathToPicture)
VALUES
('{hotelName}', '{civicNumber}', '{streetName}', '{city}', '{province}', '{phoneNumber}', '{pathToImage}')".Replace(Environment.NewLine, " ");

            // save results to int. use int? in case null value is returned
            int? rowsAffected = DataAccess.ExecuteNonQuery(sqlCreateHotel);

            // null or zero rows affected check
            if(!rowsAffected.HasValue || rowsAffected == 0)
            {
                throw new Exception("Insert of new Hotel record was unsuccessful");
            }

            // get HotelID for the newly created Hotel
            // create sql query to get hotelID
            string sqlHotelId =
                $"SELECT HotelID from Hotel WHERE HotelName = '{hotelName}' AND CivicNumber = '{civicNumber}' AND StreetName = '{streetName}' AND City = '{city}' AND Province = '{province}' AND PhoneNumber = '{phoneNumber}'";
            object result = DataAccess.ExecuteScalar(sqlHotelId);

            if(result == null || (int)result == 0)
            {
                throw new Exception("Unable to retrieve newly created HotelID");
            }

            int hotelId = (int)result;

            // add hotel amenities to hotel amenities table
            // add amenityID of each amenity for this hotel to a list of amenityIDs
            List<int> amenitiesToAdd = new List<int>();

            if (chkParking.Checked)
            {
                amenitiesToAdd.Add(1);
            }

            if (chkPool.Checked)
            {
                amenitiesToAdd.Add(2);
            }

            if (chkBreakfast.Checked)
            {
                amenitiesToAdd.Add(3);
            } 


            if(amenitiesToAdd.Count > 0)
            {
                // add each amentityID in the amenitiesToAdd list into the AmentitiesHotel table
                foreach (int amenityID in amenitiesToAdd)
                {
                   string sqlInsertAmentityStatement = $"INSERT INTO AmentitiesHotel (HotelID, AmentityID) VALUES ({hotelId}, {amenityID})";
                   int amentityRowsAffected = DataAccess.ExecuteNonQuery(sqlInsertAmentityStatement);
                    if (amentityRowsAffected == 0)
                    {
                        throw new Exception("Failed to insert amentity for this hotel");
                    }
                }
            }

            // Show message indicating successful creation of a new hotel
            MessageBox.Show($"{hotelName} was successfully added to the database");
        }

        #endregion

        #region Loading Information



        /// <summary>
        /// Load hotels from database into the dropdown, fetch the first hotel, and display it
        /// </summary>
        private void Setup()
        {
            // load hotels into dropdown
            LoadHotelsDropdown();
            // set current hotel ID to the ID of the first hotel, if sorted alphabetically
            currentHotelID = GetFirstHotelID();
            // load first hotel's information into fields
            LoadHotelInformation();
            // set button state to Browse state
            SetButtonsState(ButtonState.Browse);
        }


        /// <summary>
        /// Load the information for the hotel currentHotelID into the form fields
        /// </summary>
        private void LoadHotelInformation()
        {
            // create an sql query that will return the the hotel information
            string sqlHotelInformation =
                $"SELECT HotelName, CivicNumber, StreetName, City, Province, PhoneNumber, PathToPicture FROM Hotel WHERE HotelID = {currentHotelID};";


            // save results to a data row, since there should only be one record result
            DataRow selectedRecord = DataAccess.GetData(sqlHotelInformation).Rows[0];

            // display hotel information
            DisplayHotelInformationFromRecord(selectedRecord);

            // get amenities for the selected hotel. Save in a DataTable, as there could be multiple
            // create sql query
            string sqlAmenitiesQuery =
                $"SELECT * FROM AmentitiesHotel WHERE HotelID = {currentHotelID}";

            // save results as a datatable, as there could be multiple
            DataTable amenitiesResults = DataAccess.GetData(sqlAmenitiesQuery);

            // set radio buttons state
            SetCheckboxesFromAmenityResults(amenitiesResults);

            // set FirstPrevNextLast
            SetFirstPrevNextLastHotelID();
            // set nav button states
            SetPrevNextButtonState();

        }        

        /// <summary>
        /// Queries the database to set the first, previous, next, and last HotelID values
        /// </summary>
        private void SetFirstPrevNextLastHotelID()
        {
            // create sql subquery that returns the required values for the currentHotelID
            // returns first, prev, next, last hotel ID, as well as current row # and total hotels

            string sqlFirstPrevNextLastHotel =
                $@"SELECT * FROM
(SELECT HotelID AS CurrentHotelID,
HotelName,
LAG(HotelID) OVER (ORDER BY HotelName ASC) AS PreviousHotelID,
LEAD(HotelID) OVER (ORDER BY HotelName ASC) AS NextHotelID,
(SELECT TOP(1) HotelID FROM Hotel ORDER BY HotelName ASC) AS FirstHotelID,
(SELECT TOP(1) HotelID FROM Hotel ORDER BY HotelName DESC) AS LastHotelID,
ROW_NUMBER() OVER (ORDER BY HotelName ASC) AS CurrentPosition,
(SELECT COUNT(HotelID) FROM Hotel) AS TotalHotels
FROM Hotel) AS temp_table
WHERE CurrentHotelID = {currentHotelID}
";

            // save response as a data row
            DataRow resultRecord = DataAccess.GetData(sqlFirstPrevNextLastHotel).Rows[0];

            // assign results to global variables
            firstHotelID = Convert.ToInt32(resultRecord["FirstHotelID"]);
            lastHotelID = Convert.ToInt32(resultRecord["LastHotelID"]);
            currentPosition = Convert.ToInt32(resultRecord["CurrentPosition"]);

            if(resultRecord["PreviousHotelID"] == null || resultRecord["PreviousHotelID"] == DBNull.Value)
            {
                previousHotelID = (int?)null;
            }
            else
            {
                previousHotelID = Convert.ToInt32(resultRecord["PreviousHotelID"]);
            }

            if (resultRecord["NextHotelID"] == null || resultRecord["NextHotelID"] == DBNull.Value)
            {
                nextHotelID = (int?)null;
            }
            else
            {
                nextHotelID = Convert.ToInt32(resultRecord["NextHotelID"]);
            }

        }

        /// <summary>
        /// Loads Hotel names and ID values into the dropdown
        /// </summary>
        private void LoadHotelsDropdown()
        {
            // create query string
            string sqlHotelQuery =
                "SELECT HotelID, HotelName FROM Hotel ORDER BY HotelName ASC;";

            // query database and save results to datatable
            DataTable result = DataAccess.GetData(sqlHotelQuery);

            // populate combo box
            UIUtilities.BindListControl(cboHotel, "HotelID", "HotelName", result, true);
        }

        /// <summary>
        /// Get the first HotelID, if the Hotels are sorted alphabetically
        /// </summary>
        /// <returns></returns>
        private int GetFirstHotelID()
        {
            // create sql query that will return one result, the first hotel ID
            string sqlFirstHotelQuery =
                "SELECT TOP(1) HotelID FROM Hotel ORDER BY HotelName ASC";

            // execute query and save result as an object
            object result = DataAccess.ExecuteScalar(sqlFirstHotelQuery);

            // throw exception if no result found
            if (result == null || result == DBNull.Value)
            {
                throw new Exception("Database did not return a result for the first HotelID");
            }

            // convert result to int and return
            return Convert.ToInt32(result);
        }




        #endregion

        
    }
}
