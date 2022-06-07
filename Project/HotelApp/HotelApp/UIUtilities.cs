using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelApp
{
    public static class UIUtilities
    {

        private static MainForm mainForm;

        #region Static Methods

        /// <summary>
        /// Binds a DataTable to a ListControl as its dataSource, and sets the ValueMember and DisplayMember 
        /// properties
        /// </summary>
        /// <param name="listControl">ListControl form element, such as ListBox or ComboBox</param>
        /// <param name="valueMember">Name of Column from DataTable that should be the ValueMember, usually the primary key value</param>
        /// <param name="displayMember">Name of the Column from DataTable that should have its value displayed in the ListControl dropdown</param>
        /// <param name="dt">DataTable that you wish to bind to the ListControl</param>
        /// <param name="insertBlank">Choose True for a blank starter row in dropdown</param>
        /// <param name="defaultText">Alternative text to use in a blank starter row, is insertBlank is True</param>
        public static void BindListControl(ListControl listControl, string valueMember, string displayMember, DataTable dt, bool insertBlank = false, string defaultText = "")
        {
            // if blank row selected, add blank row to data table first
            if (insertBlank)
            {
                // create new row object from datatable
                DataRow newRow = dt.NewRow();
                // set value member, usually a primary key value, to DBNull
                newRow[valueMember] = DBNull.Value;
                // set display text as the defaultText selected in the parameters
                newRow[displayMember] = defaultText;
                // insert new row into datatable, in first position
                dt.Rows.InsertAt(newRow, 0);
            }

            // set valueMember and displayMember property on listControl
            listControl.ValueMember = valueMember;
            listControl.DisplayMember = displayMember;
            // set datatable as listControl datasource
            listControl.DataSource = dt;
        }

        /// <summary>
        /// Animates progressBar, updating one value per stepTime
        /// </summary>
        /// <param name="progressBar">Progress bar to animate</param>
        /// <param name="stepTime"></param>
        public static void ProgressBarAnimation(ProgressBar progressBar, int stepTime)
        {
            progressBar.Value = 0;

            while(progressBar.Value < progressBar.Maximum)
            {
                Thread.Sleep(stepTime);
                // work around for slow Windows progress bar animation
                progressBar.Value++;
                progressBar.Value--;
                progressBar.Value++;

            }

            progressBar.Value = progressBar.Maximum;
        }

<<<<<<< HEAD
        /// <summary>
        /// Sets a reference the parent MDI container MainForm for use in 
        /// UI Utility methods such as DisplayInStatusStrip
        /// </summary>
        /// <param name="theMainForm"></param>
        public static void SetMainFormForUIUtilities(MainForm theMainForm)
        {
            mainForm = theMainForm;
        }


        /// <summary>
        /// Displays a message in one of the three toolstrips on the MainForm MDI container
        /// </summary>
        /// <param name="labelNum"></param>
        /// <param name="msg"></param>
        public static void DisplayInStatusStrip(int labelNum, string msg)
        {
            // make sure we have a reference to the MainForm
            if(mainForm == null)
            {
                return;
            }

            // make sure labelNum is zero, one or two
            if(labelNum > 2 || labelNum < 0)
            {
                return;
            }

            // set display message depending on labelNum
            switch (labelNum)
            {
                case 0:
                    mainForm.toolStripStatusLabel.Text = msg;
                    break;
                case 1:
                    mainForm.toolStripStatusLabel1.Text = msg;
                    break;
                case 2:
                    mainForm.toolStripStatusLabel2.Text = msg;
                    break;
            }
        }

        /// <summary>
        /// Displays a message in one of the three toolstrips on the MainForm MDI container
        /// </summary>
        /// <param name="labelNum"></param>
        /// <param name="msg"></param>
        public static void DisplayInStatusStrip(int labelNum, string msg, Color color)
        {
            // make sure we have a reference to the MainForm
            if (mainForm == null)
            {
                return;
            }

            // make sure labelNum is zero, one or two
            if (labelNum > 2 || labelNum < 0)
            {
                return;
            }

            // set display message depending on labelNum
            switch (labelNum)
            {
                case 0:
                    mainForm.toolStripStatusLabel.Text = msg;
                    mainForm.toolStripStatusLabel.ForeColor = color;
                    break;
                case 1:
                    mainForm.toolStripStatusLabel1.Text = msg;
                    mainForm.toolStripStatusLabel1.ForeColor = color;
                    break;
                case 2:
                    mainForm.toolStripStatusLabel2.Text = msg;
                    mainForm.toolStripStatusLabel2.ForeColor = color;
                    break;
            }
=======
     
        public static bool ValidateDate(DateTime value)
        {
           return value > DateTime.Now ? true : false;
>>>>>>> seb_branch
        }

        #endregion
    }
}
