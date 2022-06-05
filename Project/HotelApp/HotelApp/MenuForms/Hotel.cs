﻿using System;
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
                // load hotels into dropdown
                LoadHotelsDropdown();
                // set current hotel ID to the ID of the first hotel, if sorted alphabetically
                currentHotelID = GetFirstHotelID();
                // load first hotel's information into fields
                LoadHotelInformation();                
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

        #endregion

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
            SetRadioButtonsFromAmenityResults(amenitiesResults);

            // set FirstPrevNextLast
            SetFirstPrevNextLastHotelID();
            // set nav button states
            SetPrevNextButtonState();

        }

        private void SetRadioButtonsFromAmenityResults(DataTable amenitiesResults)
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

        private void DisplayHotelInformationFromRecord(DataRow selectedRecord)
        {
            // verify DataRow is valid
            if(selectedRecord == null || selectedRecord["HotelName"] == null)
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
            if(result == null || result == DBNull.Value)
            {
                throw new Exception("Database did not return a result for the first HotelID");
            }

            // convert result to int and return
            return Convert.ToInt32(result);
        }

        
    }
}
