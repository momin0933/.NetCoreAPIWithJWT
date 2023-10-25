
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TestAPI.Core.DataLayer.Interface;
using TestAPI.Core.Models;

namespace TestAPI.Core.DataLayer.Repository
{
    public class UserRepository : BaseRepository, IUserRepository, IDisposable
    {
        public TestDbContext context
        {
            get
            {
                return _db as TestDbContext;
            }
        }

        public UserRepository() : base(new TestDbContext())
        {

        }

        public void Dispose()
        {
            _db.Dispose();
        }                            
        
        

        public UserAccount GetBYPIN(int PIN)
        {
            return context.UserAccounts.Where(o => o.PIN == PIN).FirstOrDefault();
        }
        public UserAccount GetByUserIdandPassword(string  UserId, string password)
        {
            return context.UserAccounts.Where(o => o.userId == UserId && o.password== password).FirstOrDefault();
        }
        //public ReturnMessage SuperAdminLogin(UserLogin login, out UserAccount user)
        //{
        //    ReturnMessage message;
        //    message = ReturnMessage.SetErrorMessage();
        //    //user = new UserAccount();

        //    //message = ReturnMessage.SetSuccessMessage("Valid User");
        //    //try
        //    //{
        //    //    string saLogin = context.Database.SqlQuery<string>("SELECT name FROM sys.sql_logins where name = '"+login.UserName+ "' and pwdcompare('" + login.Password + "',password_hash) = 1 and is_disabled=0").FirstOrDefault();
        //    //    if (saLogin == null)
        //    //    {
        //    //        message = ReturnMessage.SetErrorMessage("Invalid username or password");
        //    //    }
        //    //    else
        //    //    {
        //    //        user = new ApplicationUser();
        //    //        user.UserName = "sa";
        //    //        user.RoleId = 1;
        //    //        user.UserFullName = "Super Admin";
        //    //    }




        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    message = ReturnMessage.SetErrorMessage();
        //    //}

        //    return message;
        //}

        //public ApplicationUser GetByEmail(string emailId)
        //{
        //    return context.ApplicationUsers.Where(o => o.Email == emailId).FirstOrDefault();
        //}
    }
}
