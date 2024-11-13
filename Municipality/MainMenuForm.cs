using System;
using System.Windows.Forms;

namespace Municipality
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        // Open the Report Issues Form
        private void btnReportIssues_Click(object sender, EventArgs e)
        {
            ReportIssuesForm reportIssuesForm = new ReportIssuesForm();
            reportIssuesForm.Show();
        }

        // Open the Local Events Form
        private void btnLocalEvents_Click(object sender, EventArgs e)
        {
            LocalEventsForm localEventsForm = new LocalEventsForm();
            localEventsForm.Show();
        }

        // Open the Service Request Status Form
        private void btnServiceRequestStatus_Click(object sender, EventArgs e)
        {
            // Open the Service Request Status Form
            ServiceRequestStatusForm serviceRequestStatusForm = new ServiceRequestStatusForm();
            serviceRequestStatusForm.Show();
        }

        // Open the Report Details Form
        private void btnViewReportDetails_Click(object sender, EventArgs e)
        {
            // For demonstration, we're using default values
            string location = "Default Location";
            string category = "Default Category";
            string description = "Default Description";

            // Open the Report Details Form
            ReportDetailsForm reportDetailsForm = new ReportDetailsForm(location, category, description);
            reportDetailsForm.ShowDialog(); // Show as a dialog so user must close it
        }
    }
}
