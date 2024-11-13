using System;
using System.Windows.Forms;

namespace Municipality
{
    public partial class ReportDetailsForm : Form
    {
        public ReportDetailsForm(string location, string category, string description)
        {
            InitializeComponent();
            lblLocation.Text = "Location: " + location;
            lblCategory.Text = "Category: " + category;
            lblDescription.Text = "Description: " + description;
        }
    }
}
