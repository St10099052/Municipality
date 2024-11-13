using System;
using System.IO;
using System.Windows.Forms;

namespace Municipality
{
    public partial class ReportIssuesForm : Form
    {
        public ReportIssuesForm()
        {
            InitializeComponent();
        }

        private void ReportIssuesForm_Load(object sender, EventArgs e)
        {
           
            cmbCategory.SelectedIndex = 0; 
        }

        private void btnAttachMedia_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png|Document Files|*.pdf;*.doc;*.docx",
                Title = "Select a File to Attach"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                lblAttachedFile.Text = "Attached File: " + openFileDialog.FileName;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string location = txtLocation.Text;
            string category = cmbCategory.SelectedItem?.ToString() ?? "Uncategorized";
            string description = rtbDescription.Text;

            // Save the report to a file
            string filePath = "reports.txt";
            string report = $"{DateTime.Now}\nLocation: {location}\nCategory: {category}\nDescription: {description}\n\n";
            File.AppendAllText(filePath, report);

            // Open the Report Details Form
            ReportDetailsForm reportDetailsForm = new ReportDetailsForm(location, category, description);
            reportDetailsForm.ShowDialog(); // Show as a dialog so user must close it

            // Clear form for next input
            txtLocation.Clear();
            cmbCategory.SelectedIndex = -1;
            rtbDescription.Clear();
            lblAttachedFile.Text = "No file attached";
        }

        private void btnBackToMainMenu_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the form and return to the main menu
        }
    }
}
