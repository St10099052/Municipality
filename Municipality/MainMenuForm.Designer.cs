namespace Municipality
{
    partial class MainMenuForm
    {
        private System.Windows.Forms.Button btnReportIssues;
        private System.Windows.Forms.Button btnLocalEvent;
        private System.Windows.Forms.Button btnServiceRequestStatus;
        private System.Windows.Forms.Button btnViewReportDetails;

        private void InitializeComponent()
        {
            this.btnReportIssues = new System.Windows.Forms.Button();
            this.btnLocalEvent = new System.Windows.Forms.Button();
            this.btnServiceRequestStatus = new System.Windows.Forms.Button();
            this.btnViewReportDetails = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.btnReportIssues.BackColor = Color.LightCoral;
            this.btnReportIssues.ForeColor = Color.White;
            this.btnReportIssues.Font = new Font("Arial", 12, FontStyle.Bold);
            this.btnReportIssues.Location = new System.Drawing.Point(50, 50);
            this.btnReportIssues.Name = "btnReportIssues";
            this.btnReportIssues.Size = new System.Drawing.Size(200, 60);
            this.btnReportIssues.TabIndex = 0;
            this.btnReportIssues.Text = "Report Issues";
            this.btnReportIssues.UseVisualStyleBackColor = false;
            this.btnReportIssues.Click += new System.EventHandler(this.btnReportIssues_Click);

            this.btnLocalEvent.BackColor = Color.SkyBlue;
            this.btnLocalEvent.ForeColor = Color.White;
            this.btnLocalEvent.Font = new Font("Arial", 12, FontStyle.Bold);
            this.btnLocalEvent.Location = new System.Drawing.Point(50, 120);
            this.btnLocalEvent.Name = "btnLocalEvent";
            this.btnLocalEvent.Size = new System.Drawing.Size(200, 60);
            this.btnLocalEvent.TabIndex = 1;
            this.btnLocalEvent.Text = "Local Events and Announcements";
            this.btnLocalEvent.UseVisualStyleBackColor = false;
            this.btnLocalEvent.Click += new System.EventHandler(this.btnLocalEvents_Click);

            this.btnServiceRequestStatus.BackColor = Color.LightGreen;
            this.btnServiceRequestStatus.ForeColor = Color.White;
            this.btnServiceRequestStatus.Font = new Font("Arial", 12, FontStyle.Bold);
            this.btnServiceRequestStatus.Location = new System.Drawing.Point(50, 190);
            this.btnServiceRequestStatus.Name = "btnServiceRequestStatus";
            this.btnServiceRequestStatus.Size = new System.Drawing.Size(200, 60);
            this.btnServiceRequestStatus.TabIndex = 2;
            this.btnServiceRequestStatus.Text = "Service Request Status";
            this.btnServiceRequestStatus.UseVisualStyleBackColor = false;
            this.btnServiceRequestStatus.Click += new System.EventHandler(this.btnServiceRequestStatus_Click);

            this.btnViewReportDetails.BackColor = Color.Gold;
            this.btnViewReportDetails.ForeColor = Color.White;
            this.btnViewReportDetails.Font = new Font("Arial", 12, FontStyle.Bold);
            this.btnViewReportDetails.Location = new System.Drawing.Point(50, 260);
            this.btnViewReportDetails.Name = "btnViewReportDetails";
            this.btnViewReportDetails.Size = new System.Drawing.Size(200, 60);
            this.btnViewReportDetails.TabIndex = 3;
            this.btnViewReportDetails.Text = "View Report Details";
            this.btnViewReportDetails.UseVisualStyleBackColor = false;
            this.btnViewReportDetails.Click += new System.EventHandler(this.btnViewReportDetails_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 350);
            this.Controls.Add(this.btnViewReportDetails);
            this.Controls.Add(this.btnServiceRequestStatus);
            this.Controls.Add(this.btnLocalEvent);
            this.Controls.Add(this.btnReportIssues);
            this.BackColor = Color.LightBlue;
            this.Name = "MainMenuForm";
            this.Text = "Main Menu";
            this.ResumeLayout(false);
        }
    }
}
