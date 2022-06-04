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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            try
            {
                // set username to windows username
                txtUserName.Text = Environment.UserName;

                // set password textbox to use password character (***)
                txtPassword.UseSystemPasswordChar = true;
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
                // return cancel DialogResult to quit app
                DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                
                if(AuthenticationHelper.IsValidUsernamePassword(txtUserName.Text.Trim(), txtPassword.Text.Trim()))
                {
                    // return DialogResult OK to proceed to MainForm
                    DialogResult=DialogResult.OK;
                }
                else
                {
                    // DEBUG: Display message box
                    // TODO: implement system where user is kicked out for 
                    // too many wrong attempts
                    MessageBox.Show("Incorrect username and password combination", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }
    }
}
