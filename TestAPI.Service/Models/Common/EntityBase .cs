using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAPI.Core.Models
{
    public abstract class EntityBase
    {      
        public int Id { get; set; }
        public DateTime? EntryDt { get; set; }
        public string? EntryBy { get; set; }
        public DateTime? UpdateDt { get; set; }
        public string? UpdateBy { get; set; }
        public bool? IsActive { get; set; }
        public string? Remarks { get; set; }
    }
}
