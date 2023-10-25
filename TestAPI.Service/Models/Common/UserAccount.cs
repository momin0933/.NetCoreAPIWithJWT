using TestAPI.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAPI.Core.Models
{
    public class UserAccount : EntityBase
    {
        #region Public Properties  
       
        public string userId { get; set; }
        public string? username { get; set; }
        public string? fullName { get; set; }
        public string password { get; set; }
        public string? cpassword { get; set; }
        public string? userrole { get; set; }
        public int? PIN { get; set; }
        public string? email { get; set; }
        public virtual UserProfile? UserProfiles { get; set; }
      
        #endregion
    }
}
