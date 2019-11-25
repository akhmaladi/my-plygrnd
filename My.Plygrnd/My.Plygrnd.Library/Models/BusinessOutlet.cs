using System;
using System.Collections.Generic;
using System.Text;

namespace My.Plygrnd.Library.Models
{
    public class BusinessOutlet
    {
        public Int64 Id { get; set; }
        public Int64 BusinessId { get; set; }
        public string BranchId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
