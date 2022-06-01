using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelApp.MenuForms;

namespace HotelApp
{
    public partial class MainForm : Form
    {
        private int childFormNumber = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        #region Event Handlers

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                // instantiate splash screen
                Splash frmSplash = new Splash();
                // display splash as dialog box
                frmSplash.ShowDialog();

                // if cancel is selected, close app
                if(frmSplash.DialogResult != DialogResult.OK)
                {
                    this.Close();
                }

                // otherwise, load login form
                // instantiate login form
                Login frmLogin = new Login();
                // Show login as Dialog Box
                frmLogin.ShowDialog();
                // close form is cancel result is returned
                if(frmLogin.DialogResult != DialogResult.OK)
                {
                    this.Close();
                }

                // otherwise, show this mdi container MainForm
                this.Show();

                // open home page, by default
                SwitchToForm(new Home(this));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        internal void ShowNewForm(object sender, EventArgs e)
        {
            /*Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();*/

            String tag = null;

            if(sender is Button)
            {
                tag = ((Button)sender).Tag.ToString();
            }
            else if(sender is ToolStripMenuItem)
            {
                tag = ((ToolStripMenuItem)sender).Tag.ToString();
            } 
            else if (sender is ToolStripButton)
            {
                tag = (((ToolStripButton)sender).Tag).ToString();
            }

            if(tag == null)
            {
                // calling form control was not anticipated, throwing an error
                throw new ArgumentException(sender.ToString() 
                    + " was not a Button, ToolStripMenu Item or ToolStripButton");
            }

            Form requestedForm = null;

            switch (tag.ToUpper())
            {
                case "HOTEL":
                    requestedForm = new CreateReservation();
                    break;
                case "AGENT":
                    requestedForm = new Agent();
                    break;
                case "GUEST":
                    requestedForm = new Guest();
                    break;
                case "AVAILBOOKING":
                    requestedForm = new BookingManager();
                    break;
                case "CANCELBOOKING":
                    requestedForm = new BookingManager();
                    break;
                case "HOME":
                    requestedForm = new Home(this);
                    break;
                default:
                    break;
            }

            // throw exception if tag did not match any above
            if(requestedForm == null)
            {
                throw new ArgumentException("The tag: " + tag + " was unexpected.");
            }

            SwitchToForm(requestedForm);
        }
        

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        #endregion

        void SwitchToForm(Form requestedForm)
        {
            // check if form is already been instantiated. If so, activate it then return to end method
            foreach (Form childForm in this.MdiChildren)
            {
                if (childForm.GetType() == requestedForm.GetType())
                {
                    childForm.Activate();
                    childForm.BringToFront();
                    return;
                }
            }

            // otherwise, assign this form as requestedForm's parent and display it
            requestedForm.MdiParent = this;
            // set to maximized
            requestedForm.WindowState = FormWindowState.Maximized;
            requestedForm.Show();

            
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // show splash screen 
                Splash splash = new Splash();
                splash.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }
    }
}
