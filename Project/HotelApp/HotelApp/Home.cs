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
    public partial class Home : Form
    {
        MainForm mainForm;
        public Home(MainForm form)
        {
            InitializeComponent();
            mainForm = form;
        }

        private void HandleButtonClick(object sender, EventArgs e)
        {
            mainForm.ShowNewForm(sender, e);
        }
    }
}
