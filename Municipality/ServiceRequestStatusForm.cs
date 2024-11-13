using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

public partial class ServiceRequestStatusForm : Form
{
    private List<ServiceRequest> serviceRequests;  // List to store service requests
    private ListBox lstServiceRequests;
    private TextBox txtRequestId;
    private Button btnSearch;
    private Button btnDisplayPriorityRequests;
    private ComboBox cmbStatus;
    private Button btnUpdateStatus;

    public ServiceRequestStatusForm()
    {
        InitializeComponent();
        // Initialize the list of service requests with sample data
        serviceRequests = new List<ServiceRequest>
        {
            new ServiceRequest { RequestId = "SR001", Description = "Broken streetlight", Priority = "High", Status = "Pending" },
            new ServiceRequest { RequestId = "SR002", Description = "Damaged road", Priority = "Medium", Status = "In Progress" },
            new ServiceRequest { RequestId = "SR003", Description = "Water leak", Priority = "High", Status = "Completed" }
        };
    }

    private void InitializeComponent()
    {
        this.lstServiceRequests = new ListBox();
        this.txtRequestId = new TextBox();
        this.btnSearch = new Button();
        this.btnDisplayPriorityRequests = new Button();
        this.cmbStatus = new ComboBox();
        this.btnUpdateStatus = new Button();
        this.SuspendLayout();

        // 
        // lstServiceRequests
        // 
        this.lstServiceRequests.FormattingEnabled = true;
        this.lstServiceRequests.Location = new System.Drawing.Point(12, 12);
        this.lstServiceRequests.Name = "lstServiceRequests";
        this.lstServiceRequests.Size = new System.Drawing.Size(360, 150);
        this.lstServiceRequests.TabIndex = 0;

        // 
        // txtRequestId
        // 
        this.txtRequestId.Location = new System.Drawing.Point(12, 170);
        this.txtRequestId.Name = "txtRequestId";
        this.txtRequestId.Size = new System.Drawing.Size(100, 20);
        this.txtRequestId.TabIndex = 1;

        // 
        // btnSearch
        // 
        this.btnSearch.Location = new System.Drawing.Point(118, 168);
        this.btnSearch.Name = "btnSearch";
        this.btnSearch.Size = new System.Drawing.Size(75, 23);
        this.btnSearch.TabIndex = 2;
        this.btnSearch.Text = "Search";
        this.btnSearch.UseVisualStyleBackColor = true;
        this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

        // 
        // btnDisplayPriorityRequests
        // 
        this.btnDisplayPriorityRequests.Location = new System.Drawing.Point(199, 168);
        this.btnDisplayPriorityRequests.Name = "btnDisplayPriorityRequests";
        this.btnDisplayPriorityRequests.Size = new System.Drawing.Size(173, 23);
        this.btnDisplayPriorityRequests.TabIndex = 3;
        this.btnDisplayPriorityRequests.Text = "Display Priority Requests";
        this.btnDisplayPriorityRequests.UseVisualStyleBackColor = true;
        this.btnDisplayPriorityRequests.Click += new System.EventHandler(this.btnDisplayPriorityRequests_Click);

        // 
        // cmbStatus
        // 
        this.cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cmbStatus.Items.AddRange(new object[] { "Pending", "In Progress", "Completed" });
        this.cmbStatus.Location = new System.Drawing.Point(12, 196);
        this.cmbStatus.Name = "cmbStatus";
        this.cmbStatus.Size = new System.Drawing.Size(121, 21);
        this.cmbStatus.TabIndex = 4;

        // 
        // btnUpdateStatus
        // 
        this.btnUpdateStatus.Location = new System.Drawing.Point(139, 196);
        this.btnUpdateStatus.Name = "btnUpdateStatus";
        this.btnUpdateStatus.Size = new System.Drawing.Size(75, 23);
        this.btnUpdateStatus.TabIndex = 5;
        this.btnUpdateStatus.Text = "Update Status";
        this.btnUpdateStatus.UseVisualStyleBackColor = true;
        this.btnUpdateStatus.Click += new System.EventHandler(this.btnUpdateStatus_Click);

        // 
        // ServiceRequestStatusForm
        // 
        this.ClientSize = new System.Drawing.Size(384, 231);
        this.Controls.Add(this.btnUpdateStatus);
        this.Controls.Add(this.cmbStatus);
        this.Controls.Add(this.btnDisplayPriorityRequests);
        this.Controls.Add(this.btnSearch);
        this.Controls.Add(this.txtRequestId);
        this.Controls.Add(this.lstServiceRequests);
        this.Name = "ServiceRequestStatusForm";
        this.Text = "Service Request Status";
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    // Event handlers for buttons (search, display priority, update status)
    private void btnSearch_Click(object sender, EventArgs e)
    {
        string requestId = txtRequestId.Text;

        // Find the service request by RequestId
        var foundRequest = serviceRequests.FirstOrDefault(r => r.RequestId.Equals(requestId, StringComparison.OrdinalIgnoreCase));

        // Display the found request or a message if not found
        lstServiceRequests.Items.Clear();
        if (foundRequest != null)
        {
            lstServiceRequests.Items.Add($"ID: {foundRequest.RequestId}, Description: {foundRequest.Description}, Priority: {foundRequest.Priority}, Status: {foundRequest.Status}");
        }
        else
        {
            lstServiceRequests.Items.Add("Request not found.");
        }
    }

    private void btnDisplayPriorityRequests_Click(object sender, EventArgs e)
    {
        // Filter and display only high priority requests
        var priorityRequests = serviceRequests.Where(r => r.Priority == "High").ToList();

        lstServiceRequests.Items.Clear();
        if (priorityRequests.Any())
        {
            foreach (var request in priorityRequests)
            {
                lstServiceRequests.Items.Add($"ID: {request.RequestId}, Description: {request.Description}, Priority: {request.Priority}, Status: {request.Status}");
            }
        }
        else
        {
            lstServiceRequests.Items.Add("No high priority requests.");
        }
    }

    private void btnUpdateStatus_Click(object sender, EventArgs e)
    {
        string requestId = txtRequestId.Text;
        string newStatus = cmbStatus.SelectedItem.ToString();

        // Find the service request by RequestId
        var foundRequest = serviceRequests.FirstOrDefault(r => r.RequestId.Equals(requestId, StringComparison.OrdinalIgnoreCase));

        if (foundRequest != null)
        {
            // Update the status
            foundRequest.Status = newStatus;

            // Refresh the ListBox to show updated request
            lstServiceRequests.Items.Clear();
            lstServiceRequests.Items.Add($"ID: {foundRequest.RequestId}, Description: {foundRequest.Description}, Priority: {foundRequest.Priority}, Status: {foundRequest.Status}");
        }
        else
        {
            lstServiceRequests.Items.Clear();
            lstServiceRequests.Items.Add("Request not found.");
        }
    }

    // ServiceRequest model with Status
    public class ServiceRequest
    {
        public string RequestId { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }  // New Status property
    }
}
