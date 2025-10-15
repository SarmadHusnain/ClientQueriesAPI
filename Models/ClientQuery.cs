using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientQueriesAPI.Models
{
    public class ClientQuery
    {
        [Key]
        public int Id { get; set; }

        //  What are you looking for? (multi-select)
        [Required]
        public List<string> Services { get; set; } = new();

        //  Your Business Name (optional)
        public string? BusinessName { get; set; }

        //  Email (required)
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        //  Phone Number (required, with country code)
        [Required]
        public string Phone { get; set; } = string.Empty;

        //  Preferred Meeting Time (optional)
        public DateTime? PreferredMeetingTime { get; set; }

        //  “I’ll decide later” checkbox
        public bool DecideLater { get; set; }

        //  Message (optional)
        public string? Message { get; set; }

        // Record creation timestamp
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
