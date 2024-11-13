using System;

namespace Municipality
{
    public class Announcement
    {
        // Properties
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        // Constructor
        public Announcement(string title, DateTime date, string description)
        {
            Title = title;
            Date = date;
            Description = description;
        }
    }
}
