using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Municipality
{
    public partial class LocalEventsForm : Form
    {
        private SortedDictionary<DateTime, List<Event>> events = new SortedDictionary<DateTime, List<Event>>();

        public LocalEventsForm()
        {
            InitializeComponent();
            LoadEvents(); // Load example events on startup
            CustomizeUI(); // Apply custom UI settings
        }

        private void LoadEvents()
        {
            // Example events
            AddEvent(new Event { Category = "Community Service", Date = DateTime.Now.AddDays(1), Description = "Park Clean-up Day" });
            AddEvent(new Event { Category = "Cultural Events", Date = DateTime.Now.AddDays(3), Description = "Art Exhibition" });
            AddEvent(new Event { Category = "Sports", Date = DateTime.Now.AddDays(5), Description = "Local Football Match" });
            DisplayEvents();
        }

        private void AddEvent(Event newEvent)
        {
            if (!events.ContainsKey(newEvent.Date))
            {
                events[newEvent.Date] = new List<Event>();
            }
            events[newEvent.Date].Add(newEvent);
        }

        private void DisplayEvents()
        {
            listBoxEvents.Items.Clear();
            foreach (var eventGroup in events)
            {
                foreach (var eventItem in eventGroup.Value)
                {
                    // Create a formatted string for each event
                    string displayText = $"{eventItem.Date.ToShortDateString()} - {eventItem.Category}: {eventItem.Description}";
                    listBoxEvents.Items.Add(displayText);
                }
            }
        }

        private void btnBackToMainMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rtbDescription.Text) || cmbCategory.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newEvent = new Event
            {
                Category = cmbCategory.SelectedItem.ToString(),
                Date = dtpDate.Value,
                Description = rtbDescription.Text
            };

            AddEvent(newEvent);
            MessageBox.Show("Event submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DisplayEvents();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dtpSearchDate.Value.Date;
            string selectedCategory = cmbSearchCategory.SelectedItem?.ToString();

            var filteredEvents = events
                .SelectMany(group => group.Value)
                .Where(ev => ev.Date.Date == selectedDate && (selectedCategory == null || ev.Category == selectedCategory || selectedCategory == "All"))
                .ToList();

            listBoxEvents.Items.Clear();
            foreach (var eventItem in filteredEvents)
            {
                listBoxEvents.Items.Add($"{eventItem.Date.ToShortDateString()} - {eventItem.Category}: {eventItem.Description}");
            }

            if (!filteredEvents.Any())
            {
                MessageBox.Show("No events found for the selected criteria.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CustomizeUI()
        {
            this.BackColor = Color.LightBlue; // Set a pleasant background color
            listBoxEvents.BackColor = Color.White; // Set the background of the listbox
            listBoxEvents.ForeColor = Color.DarkBlue; // Set text color for better visibility

            // Set font for better aesthetics
            this.Font = new Font("Arial", 10);
            listBoxEvents.Font = new Font("Arial", 10);

            // Optionally adjust sizes of components for better layout
            cmbCategory.Size = new Size(200, 25);
            dtpDate.Size = new Size(200, 25);
            rtbDescription.Size = new Size(200, 75);
            btnSubmit.Size = new Size(100, 30);
            btnBackToMainMenu.Size = new Size(100, 30);
            btnSearch.Size = new Size(100, 30);
            listBoxEvents.Size = new Size(300, 200);
        }

        private void InitializeComponent()
        {
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnBackToMainMenu = new System.Windows.Forms.Button();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.listBoxEvents = new System.Windows.Forms.ListBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbSearchCategory = new System.Windows.Forms.ComboBox();
            this.dtpSearchDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();

            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Items.AddRange(new object[] {
            "Community Service",
            "Cultural Events",
            "Sports",
            "Workshops"});
            this.cmbCategory.Location = new System.Drawing.Point(50, 50);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(200, 21);
            this.cmbCategory.TabIndex = 0;

            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(50, 100);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDate.TabIndex = 1;

            // 
            // rtbDescription
            // 
            this.rtbDescription.Location = new System.Drawing.Point(50, 150);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(200, 100);
            this.rtbDescription.TabIndex = 2;
            this.rtbDescription.Text = "";

            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(50, 270);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 30);
            this.btnSubmit.TabIndex = 3;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);

            // 
            // btnBackToMainMenu
            // 
            this.btnBackToMainMenu.Location = new System.Drawing.Point(175, 270);
            this.btnBackToMainMenu.Name = "btnBackToMainMenu";
            this.btnBackToMainMenu.Size = new System.Drawing.Size(75, 30);
            this.btnBackToMainMenu.TabIndex = 4;
            this.btnBackToMainMenu.Text = "Back";
            this.btnBackToMainMenu.UseVisualStyleBackColor = true;
            this.btnBackToMainMenu.Click += new System.EventHandler(this.btnBackToMainMenu_Click);

            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(50, 30);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(53, 13);
            this.lblCategory.TabIndex = 5;
            this.lblCategory.Text = "Category:";

            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(50, 80);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(36, 13);
            this.lblDate.TabIndex = 6;
            this.lblDate.Text = "Date:";

            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(50, 130);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 7;
            this.lblDescription.Text = "Description:";

            // 
            // listBoxEvents
            // 
            this.listBoxEvents.Location = new System.Drawing.Point(50, 320);
            this.listBoxEvents.Name = "listBoxEvents";
            this.listBoxEvents.Size = new System.Drawing.Size(300, 200);
            this.listBoxEvents.TabIndex = 8;

            // 
            // cmbSearchCategory
            // 
            this.cmbSearchCategory.FormattingEnabled = true;
            this.cmbSearchCategory.Items.AddRange(new object[] {
            "All",
            "Community Service",
            "Cultural Events",
            "Sports",
            "Workshops"});
            this.cmbSearchCategory.Location = new System.Drawing.Point(50, 550);
            this.cmbSearchCategory.Name = "cmbSearchCategory";
            this.cmbSearchCategory.Size = new System.Drawing.Size(100, 21);
            this.cmbSearchCategory.TabIndex = 9;
            this.cmbSearchCategory.SelectedIndex = 0;

            // 
            // dtpSearchDate
            // 
            this.dtpSearchDate.Location = new System.Drawing.Point(175, 550);
            this.dtpSearchDate.Name = "dtpSearchDate";
            this.dtpSearchDate.Size = new System.Drawing.Size(200, 20);
            this.dtpSearchDate.TabIndex = 10;

            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(400, 550);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 30);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // 
            // LocalEventsForm
            // 
            this.ClientSize = new System.Drawing.Size(500, 600);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.rtbDescription);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnBackToMainMenu);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.listBoxEvents);
            this.Controls.Add(this.cmbSearchCategory);
            this.Controls.Add(this.dtpSearchDate);
            this.Controls.Add(this.btnSearch);
            this.Name = "LocalEventsForm";
            this.Text = "Local Events and Announcements";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnBackToMainMenu;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.ListBox listBoxEvents;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbSearchCategory;
        private System.Windows.Forms.DateTimePicker dtpSearchDate;
    }

    public class Event
    {
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
