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

        public Agent()
        {
            InitializeComponent();
        }
        #region Event Handlers
        private void Agent_Load(object sender, EventArgs e)
        {
            try
            {
                LoadUsernames();
                SetCurrentAgentIDAsFirstAgent(); 
                LoadAgentDetails();
                

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

        #endregion

        /// <summary>
        /// Sets the Enabled state of the Previous and Next buttons 
        /// based on the value (or lack of value) in previousAgentID and nextAgentID
        /// </summary>
        private void HandlePrevNextButtonStates()
        {
            if(previousAgentID == null)
            {
                btnPrevious.Enabled = false;
            }
            else
            {
                btnPrevious.Enabled = true;
            }

            if(nextAgentID == null)
            {
                btnNext.Enabled = false;
            }
            else
            {
                btnNext.Enabled = true;
            }
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
            DataRow agentRecord = DataAccess.GetData(sqlAgentDetailsQuery).Rows[0];

            // populate form details
            cboUsername.SelectedValue = currentAgentID;

            txtFirstName.Text = agentRecord["FirstName"].ToString();
            txtLastName.Text = agentRecord["LastName"].ToString();
            txtCompany.Text = agentRecord["Company"].ToString();
            txtPhone.Text = agentRecord["Phone"].ToString();
            txtEmail.Text = agentRecord["Email"].ToString();

            // set first and last prev next values
            SetFirstLastPrevNextValues();
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
            HandlePrevNextButtonStates();
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
                dtAgents, true, "Please select an agent");

        }        
    }
}
