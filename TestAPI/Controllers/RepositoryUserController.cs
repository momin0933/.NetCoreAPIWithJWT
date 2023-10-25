using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using TestAPI.Core.DataLayer.Interface;
using TestAPI.Core.DataLayer.Repository;
using TestAPI.Core.Models;

namespace TestAPI.Controllers
{
   
    [ApiController]
    public class RepositoryUserController : ControllerBase
    {     
        private IUserRepository _userrepository;
        public RepositoryUserController()
        {

            //_userManager = new UserManager();
            _userrepository = new UserRepository();
        }
        [Route("api/GetAll")]
        [HttpGet]
        public List<UserAccount> GetAll()
        {
            try
            {
                var message = new ReturnMessage();
                List<UserAccount> model = _userrepository.GetAll<UserAccount>().ToList();                
                return model;
            }
            catch
            {
                throw;
            }
        }
        [Route("api/GetUserInfoByPIN12")]
        [HttpGet]
        public UserAccount Users([FromQuery] int PIN)
        {
            //var message = new ReturnMessage();          
            //var model = _userManager.GetByPIN(PIN);
            //return View(model);
            //try
            //{
            //    RptUserInfo userinfo = _IUser.GetUserInfoByPIN(PIN);
            //    return userinfo;
            //}
            //catch
            //{
            //    throw;
            //}
            try
            {
                var message = new ReturnMessage();
                UserAccount model = new UserAccount();
               // UserAccount model = _userManager.GetByPIN(PIN);
                //RptUserInfo userinfo = _IUser.GetUserInfoByPIN(PIN);
                //return userinfo;
                return model;
            }
            catch
            {
                throw;
            }
        }
    }
}
