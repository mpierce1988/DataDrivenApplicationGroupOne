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
    public partial class Agent : Form
    {
        int firstAgentID;
        int lastAgentID;
        int currentAgentID;
        int currentPosition;
        int totalAgents;

        int? previousAgentID;
        int? nextAgentID;

        #region Constructor
        public Agent()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Handlers
        private void Agent_Load(object sender, EventArgs e)
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

        private void Navigation_Handler(object sender, EventArgs e)
        {
            try
            {
                // cast sender as button
                Button btn = sender as Button;

                // if sender is null, a non-button is calling this method. Throw an error
                if(btn == null)
                {
                    throw new ArgumentException("Navigation Handler called on a non-Button source");
                }


                // switch case to determine how to change desired agent ID
                int? desiredAgentID = null;
                switch (btn.Name)
                {
                    case "btnFirst":
                        desiredAgentID = firstAgentID;
                        break;
                    case "btnPrevious":
                        desiredAgentID = previousAgentID;
                        break;
                    case "btnNext":
                        desiredAgentID = nextAgentID;
                        break;
                    case "btnLast":
                        desiredAgentID = lastAgentID;
                        break;
                    default:
                        desiredAgentID = null;
                        break;
                }

                // if desired agent ID is null, an unexpected button called this method
                if(desiredAgentID == null)
                {
                    throw new ArgumentException("Button with unexpected name called Navigation Handler. Unexpected name: " + btn.Name);
                }

                // set current agent ID to desired agent ID, then load agent details
                currentAgentID = desiredAgentID.Value;
                LoadAgentDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void cboUsername_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if(cboUsername.SelectedValue == DBNull.Value)
                {
                    btnModify.Enabled = false;
                    return;
                }

                
                currentAgentID = (int)cboUsername.SelectedValue;
                LoadAgentDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        /// <summary>
        /// Modifies form controls in response to a request to add a new Agent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // set combo box to blank row
                cboUsername.SelectedValue = DBNull.Value;

                // clear text fields
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtCompany.Text = "";
                txtEmail.Text = "";
                txtPhone.Text = "";
                txtUsername.Text = "";
                txtPassword1.Text = "";
                txtPassword2.Text = "";

                // disable navigation buttons
                SetNavButtonsEnabledState(false);

                // disable modify button
                btnModify.Enabled = false;

                // disable dropdown
                cboUsername.Visible = false;

                // set combo box to blank
                cboUsername.SelectedValue = DBNull.Value;

                // enable txtUsername
                txtUsername.Enabled = true;
                txtUsername.Visible = true;

                // enable save and cancel button
                btnSave.Enabled = true;
                btnCancel.Enabled = true;

                // enable text fields to be edited
                SetTextBoxesReadOnly(false);

                // enable password fields
                SetPasswordFieldsEnabledState(true);


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

                // enable modify button
                btnModify.Enabled = true;

                // cancel out any left over text in txtUsername
                txtUsername.Text = "";

                // disable any error messages
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
                cboUsername.Enabled = false;

                // disable new button
                btnAdd.Enabled = false;

                // disable modify button
                btnModify.Enabled = false;

                // disable navigation buttons
                SetNavButtonsEnabledState(false);

                // if selected username matches currently logged in username, display password edit fields

                DataRowView dataRowView = (DataRowView)cboUsername.SelectedItem;
                string selectedUserName = dataRowView.Row["UserName"].ToString();

                if(selectedUserName == AuthenticationHelper.UserName)
                {
                    SetPasswordFieldsEnabledState(true);
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
                // determine if this is an insert or an update
                if(cboUsername.SelectedValue == DBNull.Value)
                {
                    // this is an insert
                    SaveNewAgent();
                }
                else
                {
                    // this is an update
                    UpdateAgentRecord();
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
        /// Enables or disables the password fields for entry
        /// </summary>
        /// <param name="activeState"></param>
        private void SetPasswordFieldsEnabledState(bool activeState)
        {
            txtPassword1.Visible = activeState;
            txtPassword1.Enabled = activeState;
            
            txtPassword2.Visible = activeState;
            txtPassword2.Enabled = activeState;

            lblPassword1.Visible = activeState;
            lblPassword2.Visible = activeState;
        }


        /// <summary>
        /// Sets the ReadOnly status of all the TextBoxes.
        /// </summary>
        /// <param name="state"></param>
        private void SetTextBoxesReadOnly(bool state)
        {
            txtUsername.ReadOnly = state;
            txtCompany.ReadOnly = state;
            txtEmail.ReadOnly = state;
            txtFirstName.ReadOnly = state;
            txtLastName.ReadOnly = state;
            txtPhone.ReadOnly = state;
        }


        /// <summary>
        /// Disables the error provider for all the textboxes
        /// </summary>
        private void DisableAllErrorMessages()
        {
            errorProvider1.SetError(txtUsername, "");
            errorProvider1.SetError(txtFirstName, "");
            errorProvider1.SetError(txtLastName, "");
            errorProvider1.SetError(txtCompany, "");
            errorProvider1.SetError(txtEmail, "");
            errorProvider1.SetError(txtPassword1, "");
            errorProvider1.SetError(txtPassword2, "");
            errorProvider1.SetError(txtPhone, "");
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

            if (previousAgentID == null)
            {
                btnPrevious.Enabled = false;
            }
            else
            {
                btnPrevious.Enabled = true;
            }

            if (nextAgentID == null)
            {
                btnNext.Enabled = false;
            }
            else
            {
                btnNext.Enabled = true;
            }
        }
        #endregion

        #region Load Information

        /// <summary>
        /// Loads Usernames and displays the first agent id
        /// </summary>
        private void Setup()
        {
            // enable username combobox
            cboUsername.Enabled = true;
            cboUsername.Visible = true;
            // disable and hide the txtUsername so it doesn't trigger validation on Modify form
            txtUsername.Enabled = false;
            txtUsername.Visible = false;

            LoadUsernames();
            SetCurrentAgentIDAsFirstAgent();
            LoadAgentDetails();
            SetPasswordFieldsEnabledState(false);

            // set password fields to display secret symbol (***)
            txtPassword1.UseSystemPasswordChar = true;
            txtPassword2.UseSystemPasswordChar = true;
            SetButtonsToBrowseState();

            // set textboxes to read only
            SetTextBoxesReadOnly(true);
        }


        /// <summary>
        /// Sets the bottom button's to the state required for browsing (not modifying or creating) user records
        /// </summary>
        private void SetButtonsToBrowseState()
        {
            // set initial button states
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnAdd.Enabled = true;
            btnModify.Enabled = true;
        }

        /// <summary>
        /// Executes a scalar query to find the first agent ID, sorted by AgentName ASC
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void SetCurrentAgentIDAsFirstAgent()
        {
            // create sql query that will return the first agent ID as a result
            string sqlAgentIDQuery =
                "SELECT TOP(1) AgentID FROM Agent ORDER BY UserName ASC ;";
            // execute query, and save result to int agentID
            firstAgentID = int.Parse(DataAccess.ExecuteScalar(sqlAgentIDQuery).ToString());

            // set currentAgentID as firstAgentID
            currentAgentID = firstAgentID;

        }

        /// <summary>
        /// Loads the details for the currentAgentID from the Agent table, and
        /// populates the form fields
        /// </summary>
        private void LoadAgentDetails()
        {
            // Create sql query string to get agent details for currentAgentID
            string sqlAgentDetailsQuery =
                $"SELECT FirstName, LastName, Company, Phone, Email, UserName FROM Agent WHERE AgentID = {currentAgentID};";

            // execute query and save result to a datarow
            DataTable dt = DataAccess.GetData(sqlAgentDetailsQuery);
            if (dt.Rows.Count == 0)
            {
                throw new ArgumentException("Load Agent sqlQuery for agent id " + currentAgentID + " returned zero results.");
            }
            DataRow agentRecord = dt.Rows[0];

            // populate form details
            cboUsername.SelectedValue = currentAgentID;

            txtFirstName.Text = agentRecord["FirstName"].ToString();
            txtLastName.Text = agentRecord["LastName"].ToString();
            txtCompany.Text = agentRecord["Company"].ToString();
            txtPhone.Text = agentRecord["Phone"].ToString();
            txtEmail.Text = agentRecord["Email"].ToString();

            // set first and last prev next values
            SetFirstLastPrevNextValues();

            // enable modify button
            btnModify.Enabled = true;
        }

        /// <summary>
        /// Sets the values for the first, next, previous, and last agent ID, as well as
        /// the current position and total agents, based on the currentAgentID
        /// </summary>
        private void SetFirstLastPrevNextValues()
        {
            // create sql query that will return a dataset with the previous, next, first, last, current position, total agents
            string sqlFirstLastAgentIDQuery =
                $@"SELECT PreviousAgentID, NextAgentID, FirstAgentID, LastAgentID, CurrentPosition, TotalAgents
FROM
(SELECT AgentID AS CurrentAgentID,
	   LAG(AgentID) OVER (ORDER BY UserName ASC) AS PreviousAgentID,
	   LEAD(AgentID) OVER (ORDER BY UserName ASC) AS NextAgentID,
	   (SELECT TOP(1) AgentID FROM Agent ORDER BY UserName ASC) AS FirstAgentID,
	   (SELECT TOP(1) AgentID FROM Agent ORDER BY UserName DESC) AS LastAgentID,
	   ROW_NUMBER() OVER (ORDER BY UserName ASC) AS CurrentPosition,
	   (SELECT COUNT(AgentID) FROM Agent) AS TotalAgents
FROM Agent) AS temp_table
WHERE CurrentAgentID = {currentAgentID};
";

            // execute query and save results to a DataROw
            DataRow resultRow = DataAccess.GetData(sqlFirstLastAgentIDQuery).Rows[0];

            // set value of agent ID form variables
            firstAgentID = Convert.ToInt32(resultRow["FirstAgentID"]);
            lastAgentID = Convert.ToInt32(resultRow["LastAgentID"]);
            currentPosition = Convert.ToInt32(resultRow["CurrentPosition"]);
            totalAgents = Convert.ToInt32(resultRow["TotalAgents"]);

            previousAgentID = resultRow["PreviousAgentID"] != DBNull.Value ?
                Convert.ToInt32(resultRow["PreviousAgentID"]) : (int?)null;
            nextAgentID = resultRow["NextAgentID"] != DBNull.Value ?
                Convert.ToInt32(resultRow["NextAgentID"]) : (int?)null;

            // set button states based on these values
            HandlePrevNextFirstLastButtonStates();
        }

        /// <summary>
        /// Loads all available usernames from the Agent table and 
        /// populates the cboUsername combo box
        /// </summary>
        private void LoadUsernames()
        {
            // create sql string to get dataset with AgentID and Agent Username
            string sqlAgentQuery =
                "SELECT AgentID, UserName FROM Agent ORDER BY UserName ASC;";
            // execute query and save result to dataset
            DataTable dtAgents = DataAccess.GetData(sqlAgentQuery);

            // bind to combo box using UIUtility method
            UIUtilities.BindListControl(cboUsername, "AgentID", "UserName",
                dtAgents, true);
        }

        #endregion

        #region Save/Update Information

        /// <summary>
        /// Updates the record for the agent selected in the combo box
        /// </summary>
        private void UpdateAgentRecord()
        {
            // validate form first
            if (!ValidateChildren(ValidationConstraints.Enabled))
            {
                MessageBox.Show("Some of your form data is invalid. Please fix the invalid data and try again",
                    "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // save relevant information to variables
            int? selectedAgentID = cboUsername.SelectedValue as int?;

            string updatedFirstName = txtFirstName.Text.Trim();
            string updatedLastName = txtLastName.Text.Trim();
            string updatedCompanyName = txtCompany.Text.Trim();
            string updatedPhone = txtPhone.Text.Trim();
            string updatedEmail = txtEmail.Text.Trim();

            // create update sql statement
            string sqlUpdateAgent =
                $@"UPDATE Agent SET FirstName = '{updatedFirstName}', LastName = '{updatedLastName}', Company = '{updatedCompanyName}', Phone = '{updatedPhone}', Email = '{updatedEmail}' WHERE AgentID = {selectedAgentID} ;";

            int rowsUpdated = DataAccess.ExecuteNonQuery(sqlUpdateAgent);

            // throw error if no rows were affected
            if(rowsUpdated == 0)
            {
                throw new Exception("Something went wrong, the record was not modified");
            }

            // display message saying update was successful
            MessageBox.Show("Agent information for " + cboUsername.SelectedValue.ToString() + " was successfully updated.");

            // run setup to put back to browse state
            Setup();           

        }


        /// <summary>
        /// Saves the entered information as a new agent in the database
        /// </summary>        
        private void SaveNewAgent()
        {
            // validate form first. This includes validating the userName is unique
            if (!ValidateChildren(ValidationConstraints.Enabled))
            {
                MessageBox.Show("Some of your form data is invalid. Please fix the invalid data and try again", 
                    "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // save information into variables
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string companyName = txtCompany.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();
            string userName = txtUsername.Text.Trim();
            string password = txtPassword1.Text;

            // construct sql insert non-query
            string sqlInsertAgentNonQuery =
                $@"INSERT INTO Agent (FirstName, LastName, Company, Phone, Email, UserName)
VALUES
('{firstName}', '{lastName}', '{companyName}', '{phone}', '{email}', '{userName}');";

            // execute statement, saving num of rows affected as an int
            int? rowsAffected = DataAccess.ExecuteNonQuery(sqlInsertAgentNonQuery);

            if(!rowsAffected.HasValue || rowsAffected.Value == 0)
            {
                throw new Exception("Inserting of new agent record failed.");
            }

            // get new AgentID from new record
            string sqlNewAgentID =
                $"SELECT AgentID FROM Agent WHERE UserName = '{userName}';";
            int newAgentID = Convert.ToInt32(DataAccess.ExecuteScalar(sqlNewAgentID));
           

            // insert password into password table
            // construct sql insert query
            string sqlInsertPassword =
                $"INSERT INTO Password (AgentID, Password) VALUES ({newAgentID}, '{password}')";

            int? passwordRowsAffected = DataAccess.ExecuteNonQuery(sqlInsertPassword);

            // if saving password failed, delete newly created agent record from Agent and 
            // throw error
            if(!passwordRowsAffected.HasValue || passwordRowsAffected.Value == 0)
            {
                // delete new agent record, as it has no associated password
                string sqlDeleteAgentRecord =
                    $"DELETE FROM Agent WHERE AgentID = {newAgentID}";
                int? deleteRowsAffected = DataAccess.ExecuteNonQuery(sqlDeleteAgentRecord);

                // throw error
                throw new Exception("Password was not saved to database. Agent record was not saved");
            }

            // show message box saying agent was successfully saved
            MessageBox.Show("Agent Profile for " + userName + " was successfully created!", "New Agent Profile Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // rerun setup to reset form with new agent record in the dropdown
            Setup();
        }

        #endregion

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

        private void ValidateUsernameField(object sender, CancelEventArgs e)
        {
            try
            {
                // validate field is not empty
                if (txtUsername.Text.Trim() == "")
                {
                    errorProvider1.SetError(txtUsername, "Please enter a username");
                    e.Cancel = true;
                    return;
                }

                // validate username is not already taken
                // write query that will return a result if the name is taken, and a null result if
                // it is not taken
                string sqlNameQuery =
                    $"SELECT AgentID FROM Agent WHERE UserName = '{txtUsername.Text.Trim()}';";

                // execute scalar and save result to an obj, which is nullable
                object result = DataAccess.ExecuteScalar(sqlNameQuery);

                // if result is null, then name is unique. if result has a value, then name is taken
                if (result != null)
                {
                    // name is already taken
                    errorProvider1.SetError(txtUsername, "This username is already taken.");
                    // flag validation as failed
                    e.Cancel = true;

                    return;
                }

                // by this point, there should be no errors for username. reset error provider
                errorProvider1.SetError(txtUsername, "");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void PasswordValidation(object sender, CancelEventArgs e)
        {
            try
            {
                string msg = "";
                // if one or both of the text boxes are empty, display an error on both
                if (txtPassword1.Text.Trim() == "" || txtPassword2.Text.Trim() == "")
                {
                    msg = "Please enter a password in both boxes";
                    e.Cancel = true;

                }
                // if the text boxes do not match, throw an error on both text boxes
                else if (txtPassword1.Text.Trim() != txtPassword2.Text.Trim())
                {
                    msg = "The passwords entered in both boxes must match";
                    e.Cancel = true;
                }

                // set error providers
                errorProvider1.SetError(txtPassword1, msg);
                errorProvider1.SetError(txtPassword2, msg);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        #endregion
    }
}
