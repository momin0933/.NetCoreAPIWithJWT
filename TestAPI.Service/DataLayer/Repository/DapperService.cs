using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using TestAPI.Core.Service;
using TestAPI.Core.DataLayer.Interface;

namespace TestAPI.Core.DataLayer.Repository
{
    public class DapperService : IDapperService
    {
        private readonly string connectionString;
        SQLConnectionString _connectionStringService = new SQLConnectionString();
        public DapperService()
        {
            connectionString = _connectionStringService.GetConnectionString("default");
        }

        public virtual IEnumerable<T> GetAllByQuery<T>(string query) where T : class
        {
            using (SqlConnection SqlConnection1 = new SqlConnection(connectionString))
            {
                SqlConnection1.Open();
                var q = SqlConnection1.Query<T>(query).ToList();
                dynamic collectionWrapper = new
                {
                    OEBuyerFactName = q
                };
                //serializer.MaxJsonLength = Int32.MaxValue;
                string output = JsonConvert.SerializeObject(collectionWrapper, Formatting.Indented);
                //serializer.Serialize(collectionWrapper);
                return q;
            }
        }
        public virtual string GetStringByQuery(string query)
        {

            using (SqlConnection SqlConnection1 = new SqlConnection(connectionString))
            {
                SqlConnection1.Open();
                var q = SqlConnection1.QueryFirstOrDefault<string>(query);
                //dynamic collectionWrapper = new
                //{
                //    OEBuyerFactName = q
                //};
                ////serializer.MaxJsonLength = Int32.MaxValue;
                //string output = JsonConvert.SerializeObject(collectionWrapper, Formatting.Indented);
                ////serializer.Serialize(collectionWrapper);

                return q;
            }
        }

        public IEnumerable<T> GetAllBySP<T>(string procedure, DynamicParameters p) where T : class
        {
            using (SqlConnection SqlConnection1 = new SqlConnection(connectionString))
            {

                SqlConnection1.Open();
                //JsonSerializer jss = new JsonSerializer();
                //jss.MaxJsonLength = Int32.MaxValue;
                var q = SqlConnection1.Query<T>(procedure, p, commandType: CommandType.StoredProcedure).ToList();
                dynamic collectionWrapper = new
                {
                    OEBuyerFactName = q
                };
                string output = JsonConvert.SerializeObject(collectionWrapper, Formatting.Indented);
                return q;
            }
        }
        public T GetByDynamicSPSingle<T>(string procedure, DynamicParameters p) where T : class
        {
            using (SqlConnection SqlConnection1 = new SqlConnection(connectionString))
            {

                SqlConnection1.Open();
                var q = SqlConnection1.Query<T>(procedure, p, commandType: CommandType.StoredProcedure).FirstOrDefault();
                dynamic collectionWrapper = new
                {
                    OEBuyerFactName = q
                };
                //string output = JsonSerializer.Serialize(collectionWrapper);
                string output = JsonConvert.SerializeObject(collectionWrapper);
                return q;
            }
        }
        public int Post(string query)
        {
            using (SqlConnection SqlConnection1 = new SqlConnection(connectionString))
            {
                SqlConnection1.Open();
                //JavaScriptSerializer serializer = new JavaScriptSerializer();
                var q = SqlConnection1.Execute(query);
                dynamic collectionWrapper = new
                {
                    OEBuyerFactName = q
                };
                //serializer.MaxJsonLength = Int32.MaxValue;               
                string output = JsonConvert.SerializeObject(collectionWrapper);
                return q;
            }
        }
        public void GetByMultipleQueryResult(string query, out string ReqQty, out string ActQty)
        {
            using (SqlConnection SqlConnection1 = new SqlConnection(connectionString))
            {
                SqlConnection1.Open();

                var q = SqlConnection1.QueryMultiple(query);
                ReqQty = q.Read<string>().Single();
                ActQty = q.Read<string>().Single();
                //dynamic collectionWrapper = new
                //{
                //    OEBuyerFactName = q
                //};
                //serializer.MaxJsonLength = Int32.MaxValue;
                //string output = serializer.Serialize(collectionWrapper);

                // return q;
            }
        }
        public int UpdateByQuery(string query)
        {
            using (SqlConnection SqlConnection1 = new SqlConnection(connectionString))
            {
                SqlConnection1.Open();
                var q = SqlConnection1.Query(query);
                return 1;
            }
        }
    }
}