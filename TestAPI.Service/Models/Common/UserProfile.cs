﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAPI.Core.Models.Common
{
    public class UserProfile : EntityBase
    {
        #region Public Properties  

        public int UserAccountId { set; get; }
        [ForeignKey("UserAccountId")]
        
        public string userid { get; set; }
        public string fullname { get; set; }
        public string? nickname { get; set; }
        public string Class { get; set; }
        public string grade { get; set; }
        public string? filepath { get; set; }
        public string? filename { get; set; }        
       
        #endregion
    }
}
