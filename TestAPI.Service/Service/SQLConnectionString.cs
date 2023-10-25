using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAPI.Core.Service
{
    public class SQLConnectionString
    {
        public string ProjectCS { get; set; }
        public string ApiKey { get; set; }
        public string GetConnectionString(string ProjectCsKey)
        {
            string CS = "";
            if (ProjectCsKey == "default")
            {                
                CS = "";
            }
            return CS;
        }
        
    }
    //public class Tenant
    //{
    //    public string Name { get; set; }
    //    public string TID { get; set; }
    //    public string ConnectionString { get; set; }
    //}
}
