using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeveloperTest.Database.Models
{
    public class Job
    {
        public int JobId { get; set; }
        public int? CustomerId { get; set; }

        [NotMapped]
        public string CustomerName { get; set; }

        public string Engineer { get; set; }

        public DateTime When { get; set; }
    }
}
