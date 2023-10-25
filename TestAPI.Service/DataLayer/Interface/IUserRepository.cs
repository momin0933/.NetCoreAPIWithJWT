using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAPI.Core.Models;
using TestAPI.Core.Models;

namespace TestAPI.Core.DataLayer.Interface
{
    public interface IUserRepository:IBaseRepository
    {
        //ReturnMessage ValidateUser(UserLogin login, out ApplicationUser user);

        //ReturnMessage SuperAdminLogin(UserLogin login, out RptUserInfo user);
        //RptUserInfo GetByName(string UserName);
        //RptUserInfo GetByEmail(string emailId);
        UserAccount GetBYPIN(int PIN);
        UserAccount GetByUserIdandPassword(string UserId, string password);

    }
}
