using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CM = System.Configuration.ConfigurationManager;//ConfigurationManager alias import

namespace HotelApp.MenuForms
{
    public partial class Guest : Form
    {
        DataTable dtGuests;

        int currentRecord = 0;

        private int currentGuestID;

        private int firstGuestID;

        private int lastGuestID;

        private int? previousGuestID;

        private int? nextGuestID;


        public Guest()
        {
            InitializeComponent();
        }

        #region [Retrieves]

        private void LoadGuests()
        {
            // Create sql query string to get guests details 
            string sqlGuests = "SELECT GuestID, FirstName + ' ' + LastName AS FullName FROM Guest ORDER BY FullName";

            // execute query and save result to a datarow
            dtGuests = DataAccess.GetData(sqlGuests);

            UIUtilities.BindListControl(cboChooseGuest, "GuestID", "FullName", dtGuests, true, "");

        }

        private void LoadGuestDetails()
        {
            string sqlGuestDetails = $"SELECT GuestID, FirstName, LastName, CivicNumber, StreetName, City, Province, PhoneNumber, Email, IsVip FROM Guest WHERE " +
                                       $"GuestID = {currentGuestID}";
            DataTable dtGuestDetails = DataAccess.GetData(sqlGuestDetails);
            
            // populate form details
            cboChooseGuest.SelectedValue = currentGuestID; 

            //if (dtGuestDetails.Rows.Count > 0)
            //{
            DataRow selectedGuest = dtGuestDetails.Rows[0];

                txtFirstName.Text = selectedGuest["FirstName"].ToString();
                txtLastName.Text = selectedGuest["LastName"].ToString();
                txtCivicNumber.Text = selectedGuest["CivicNumber"].ToString();
                txtStreetName.Text = selectedGuest["StreetName"].ToString();
                txtCity.Text = selectedGuest["City"].ToString();
                txtProvince.Text = selectedGuest["Province"].ToString();
                txtPhone.Text = selectedGuest["PhoneNumber"].ToString();
                txtEmail.Text = selectedGuest["Email"].ToString();
                chkVip.Checked = Convert.ToBoolean(selectedGuest["IsVip"]);
            //}


            SetFirstLastPrevNextValues();

            btnModify.Enabled = true;
        }


        private void Setup()
        {

            SetCurrentGuestIDAsFirstGuest();
            LoadGuestDetails();

            // set textboxes to read only
            SetTextBoxesReadOnly(true);
        }
        #endregion


        /// <summary>
        /// Sets the values for the first, next, previous, and last agent ID, as well as
        /// the current position and total agents, based on the currentAgentID
        /// </summary>
        private void SetFirstLastPrevNextValues()
        {
            // create sql query that will return a dataset with the previous, next, first, last, current position, total guests
            string sqlFirstLastGuestIDQuery = $@"SELECT PreviousGuestID, NextGuestID, FirstGuestID, LastGuestID, CurrentPosition
                                                FROM
                                                (SELECT GuestID AS CurrentGuestID,
	                                                   LAG(GuestID) OVER (ORDER BY FirstName ASC) AS PreviousGuestID,
	                                                   LEAD(GuestID) OVER (ORDER BY FirstName ASC) AS NextGuestID,
	                                                   (SELECT TOP(1) GuestID FROM Guest ORDER BY FirstName ASC) AS FirstGuestID,
	                                                   (SELECT TOP(1) GuestID FROM Guest ORDER BY FirstName DESC) AS LastGuestID,
	                                                   ROW_NUMBER() OVER (ORDER BY FirstName ASC) AS CurrentPosition
                                                FROM Guest) AS temp_table
                                                WHERE CurrentGuestID = {currentGuestID};
";

            // execute query and save results to a DataROw
            DataRow resultRow = DataAccess.GetData(sqlFirstLastGuestIDQuery).Rows[0];

            // set value of guest ID form variables
            firstGuestID = Convert.ToInt32(resultRow["FirstGuestID"]);
            lastGuestID = Convert.ToInt32(resultRow["LastGuestID"]);
            currentGuestID = Convert.ToInt32(resultRow["CurrentPosition"]);

            previousGuestID = resultRow["PreviousGuestID"] != DBNull.Value ?
                Convert.ToInt32(resultRow["PreviousGuestID"]) : (int?)null;
            nextGuestID = resultRow["NextGuestID"] != DBNull.Value ?
                Convert.ToInt32(resultRow["NextGuestID"]) : (int?)null;

            // set button states based on these values
            HandlePrevNextFirstLastButtonStates();
        }


        /// <summary>
        /// Executes a scalar query to find the first guest ID
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void SetCurrentGuestIDAsFirstGuest()
        {
            // create sql query that will return the first guest ID as a result
            string sqlGuestIDQuery =
                "SELECT TOP(1) GuestID FROM Guest ORDER BY FirstName ASC ;";
            // execute query, and save result to int agentID
            firstGuestID = int.Parse(DataAccess.ExecuteScalar(sqlGuestIDQuery).ToString());

            // set currentGuestID as firstGuestID
            currentGuestID = firstGuestID;

        }

        /// <summary>
        /// The job of this method is to set the tool strip status label’s Text property to the msg that was passed in.
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="c"></param>
        private void SetToolStrip(string msg, bool c)
        {
            toolStripStatusLabel1.Text = msg;

            if (c == false)
            {
                toolStripStatusLabel1.ForeColor = Color.Red;
            }
            else
            {
                toolStripStatusLabel1.ForeColor = Color.Black;
            }
        }

        private void Guest_Load(object sender, EventArgs e)
        {
            try
            {
                SetToolStrip("Ready...", true);

                LoadGuests();
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, exception.GetType().ToString());
            }
        }


        #region [UI Helpers]

        /// <summary>
        /// Helps manage the enable state of our navigation buttons
        /// </summary>
        private void NavigationButtonManagement()
        {
            //Handle Previous
            if (currentRecord > 1)
            {
                btnPrevious.Enabled = true;
            }
            else
            {
                btnPrevious.Enabled = false;
            }

            //Handle the Next Button
            if (currentRecord < cboChooseGuest.Items.Count - 1)
            {
                btnNext.Enabled = true;
            }
            else
            {
                btnNext.Enabled = false;
            }
        }

        /// <summary>
        /// Disables the error provider for all the textboxes
        /// </summary>
        private void DisableAllErrorMessages()
        {
            errorProvider1.SetError(txtFirstName, "");
            errorProvider1.SetError(txtLastName, "");
            errorProvider1.SetError(txtCivicNumber, "");
            errorProvider1.SetError(txtStreetName, "");
            errorProvider1.SetError(txtCity, "");
            errorProvider1.SetError(txtProvince, "");
            errorProvider1.SetError(txtEmail, "");
            errorProvider1.SetError(txtPhone, "");
        }

        private void Navigation_Handler(object sender, EventArgs e)
        {
            try
            {
                //cast sender as button
                Button b = (Button)sender;

                switch (b.Name)
                {
                    case "btnFirst":
                        currentGuestID = firstGuestID;
                        break;
                    case "btnLast":
                        currentGuestID = lastGuestID;
                        break;
                    case "btnPrevious":
                        if (previousGuestID != null) currentGuestID = previousGuestID.Value;
                        break;
                    case "btnNext":
                        if (nextGuestID != null) currentGuestID = nextGuestID.Value;
                        break;
                }

                LoadGuestDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
}


        /// <summary>
        /// Set all of the Nav Buttons' Enabled state to the given bool
        /// </summary>
        /// <param name="v"></param>
        private void SetNavButtonsEnabledState(bool v)
        {
            btnNext.Enabled = v;
            btnPrevious.Enabled = v;
            btnFirst.Enabled = v;
            btnLast.Enabled = v;
        }

        /// <summary>
        /// Sets the ReadOnly status of all the TextBoxes.
        /// </summary>
        /// <param name="state"></param>
        private void SetTextBoxesReadOnly(bool state)
        {
            txtCity.ReadOnly = state;
            txtCivicNumber.ReadOnly = state;
            txtStreetName.ReadOnly = state;
            txtPhone.ReadOnly = state;
            txtEmail.ReadOnly = state;
            txtFirstName.ReadOnly = state;
            txtLastName.ReadOnly = state;
            txtProvince.ReadOnly = state;
        }

        /// <summary>
        /// Sets the Enabled state of the Previous and Next buttons 
        /// based on the value (or lack of value) in previousAgentID and nextAgentID
        /// </summary>
        private void HandlePrevNextFirstLastButtonStates()
        {

            // enable first and last buttons
            btnFirst.Enabled = true;
            btnLast.Enabled = true;

            if (previousGuestID == null)
            {
                btnPrevious.Enabled = false;
            }
            else
            {
                btnPrevious.Enabled = true;
            }

            if (nextGuestID == null)
            {
                btnNext.Enabled = false;
            }
            else
            {
                btnNext.Enabled = true;
            }
        }

        #endregion

        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            
            try
            {
                SetToolStrip("", true);

                if (cboChooseGuest.SelectedIndex <= 0)
                {
                    SetToolStrip("You must select a guest.", false);
                }
                else
                {
                    currentRecord = cboChooseGuest.SelectedIndex;
                    currentGuestID = Convert.ToInt32(cboChooseGuest.SelectedValue);

                    NavigationButtonManagement();
                    LoadGuestDetails();
                }
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

                // set combo box to blank row
                //cboChooseGuest.SelectedValue = DBNull.Value;

                // clear text fields
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtCivicNumber.Text = "";
                txtEmail.Text = "";
                txtPhone.Text = "";
                txtStreetName.Text = "";
                txtCity.Text = "";
                txtProvince.Text = "";
                chkVip.Checked = false;

                // disable navigation buttons
                SetNavButtonsEnabledState(false);

                // disable modify button
                btnModify.Enabled = false;

                // disable dropdown
                //cboChooseGuest.Visible = false;

                // set combo box to blank
                //cboChooseGuest.SelectedValue = DBNull.Value;

                // enable txtFirstName and LastName
                txtFirstName.Enabled = true;
                txtFirstName.Visible = true;

                txtLastName.Enabled = true;
                txtLastName.Visible = true;

                // enable save and cancel button
                btnSave.Enabled = true;
                btnCancel.Enabled = true;

                // enable text fields to be edited
                SetTextBoxesReadOnly(false); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {

                // enable nav buttons
                SetNavButtonsEnabledState(true);

                SetTextBoxesReadOnly(false); 

                // enable modify button
                btnModify.Enabled = true;

                //// cancel out any left over text in txtUsername
                //txtFirstName.Text = "";
                //txtLastName.Text = "";

                DisableAllErrorMessages(); 
                Setup();
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
                // enable textboxes to be edited
                SetTextBoxesReadOnly(false);

                // enable save and cancel button
                btnSave.Enabled = true;
                btnCancel.Enabled = true;

                // disable dropdown
                //cboChooseGuest.Enabled = false;

                // disable new button
                btnAdd.Enabled = false;

                // disable modify button
                btnModify.Enabled = false;

                // disable navigation buttons
                SetNavButtonsEnabledState(false);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }


        #region Save/UpdateInformation
        /// <summary>
        /// Saves the entered information as a new guest in the database
        /// </summary>        
        private void SaveNewGuest()
        {
            // validate form first. 
            if (!ValidateChildren(ValidationConstraints.Enabled))
            {
                MessageBox.Show("Some of your form data is invalid. Please fix the invalid data and try again",
                    "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // save information into variables
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string civicNumber = txtCivicNumber.Text.Trim();
            string streetName = txtStreetName.Text.Trim();
            string city = txtCity.Text.Trim();
            string province = txtProvince.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();

            int vipNumber = 0; 

            if (chkVip.Checked)
            {
                vipNumber = 1;
            }


            // construct sql insert non-query
            string sqlInsertGuestNonQuery =
                $@"INSERT INTO Guest (FirstName, LastName, CivicNumber, StreetName, City, Province, PhoneNumber, Email, IsVip)
                        VALUES
                        ('{firstName}', '{lastName}', '{civicNumber}', '{streetName}', '{city}', '{province}', '{phone}', '{email}', {vipNumber});";

            // execute statement, saving num of rows affected as an int
            int? rowsAffected = DataAccess.ExecuteNonQuery(sqlInsertGuestNonQuery);

            if (!rowsAffected.HasValue || rowsAffected.Value == 0)
            {
                throw new Exception("Inserting of new guest record failed.");
            }

            // get new GuestID from new record
            string sqlNewGuestID =
                $"SELECT GuestID FROM Guest WHERE FirstName = '{firstName}';";
            int newGuestID = Convert.ToInt32(DataAccess.ExecuteScalar(sqlNewGuestID));


            // show message box saying agent was successfully saved
            MessageBox.Show("Guest Profile for " + firstName + " was successfully created!", "New Guest Profile Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // rerun setup to reset form with new agent record in the dropdown
            Setup();
        }

        /// <summary>
        /// Updates the record for the guest selected in the combo box
        /// </summary>
        private void UpdateGuestRecord()
        {
            // validate form first
            if (!ValidateChildren(ValidationConstraints.Enabled))
            {
                MessageBox.Show("Some of your form data is invalid. Please fix the invalid data and try again",
                    "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // save relevant information to variables
            int? selectedGuestID = cboChooseGuest.SelectedValue as int?;

            string updatedFirstName = txtFirstName.Text.Trim();
            string updatedLastName = txtLastName.Text.Trim();
            string updatedCivicNumber = txtCivicNumber.Text.Trim();
            string updateStreetName = txtStreetName.Text.Trim();
            string updateCity = txtCity.Text.Trim();
            string updateProvince = txtProvince.Text.Trim();
            string updatedPhone = txtPhone.Text.Trim();
            string updatedEmail = txtEmail.Text.Trim();

            // create update sql statement
            string sqlUpdateGuest =
                $@"UPDATE Guest SET FirstName = '{updatedFirstName}', LastName = '{updatedLastName}', CivicNumber = '{updatedCivicNumber}',
                                                  StreetName = '{updateStreetName}', City = '{updateCity}', Province = '{updateProvince}', 
                                                  Phone = '{updatedPhone}', Email = '{updatedEmail}' WHERE AgentID = {selectedGuestID} ;";

            int rowsUpdated = DataAccess.ExecuteNonQuery(sqlUpdateGuest);

            // throw error if no rows were affected
            if (rowsUpdated == 0)
            {
                throw new Exception("Something went wrong, the record was not modified");
            }

            // display message saying update was successful
            MessageBox.Show("Guest information for " + cboChooseGuest.SelectedValue.ToString() + " was successfully updated.");

            // run setup to put back to browse state
            Setup();

        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                cboChooseGuest.Visible = true; 

                // determine if this is an insert or an update
                if (cboChooseGuest.SelectedValue == DBNull.Value)
                {
                    // this is an insert
                    SaveNewGuest();
                }
                else
                {
                    // this is an update
                    UpdateGuestRecord();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }


        #region Validation

        private void NotEmptyValidation(object sender, CancelEventArgs e)
        {
            try
            {
                TextBox textBox = sender as TextBox;

                // if textBox is null, something other than a textbox as called this method
                if (textBox == null)
                {
                    throw new ArgumentException("A non-textbox has called the NotEmptyValidation method");
                }

                string errorMsg = "";

                if (textBox.Text.Trim() == "")
                {
                    errorMsg = "This field is required";
                    e.Cancel = true;
                }

                errorProvider1.SetError(textBox, errorMsg);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        #endregion

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // save information into variable
                int guestId = Convert.ToInt32(cboChooseGuest.SelectedValue);
                string deleteQuery =
                    $"DELETE FROM Guest WHERE GuestID = {guestId}";

                int rowsAffected = DataAccess.ExecuteNonQuery(deleteQuery);

                if (rowsAffected == 1)
                {
                    MessageBox.Show("Guest was successfully deleted! This form will now close...", "Delete Successful");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Guest failed to delete!", "Error");
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }
    }
}
