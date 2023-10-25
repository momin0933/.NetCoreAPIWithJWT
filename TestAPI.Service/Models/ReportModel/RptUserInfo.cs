using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAPI.Core.Models
{
    public class RptUserInfo : EntityBase
    {
        public string userid { get; set; }      
        public string? userrole { get; set; }
        public int? PIN { get; set; }
        public string fullname { get; set; }
        public string password { get; set; }
        public string? nickname { get; set; }
        public string Class { get; set; }
        public string grade { get; set; }
        public string? filepath { get; set; }
        public string? filename { get; set; }

    }
}
