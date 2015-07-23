using System;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using TestProject.Models;

namespace TestProject.Controllers
{
    [Authorize]
    public class MeController : ApiController
    {
        private ApplicationUserManager _userManager;

        public MeController()
        {
            Console.WriteLine("Initialization");
        }

        public MeController(ApplicationUserManager userManager) : this()
        {
            UserManager = userManager;
            Console.WriteLine("One more change");
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET api/Me
        public GetViewModel Get()
        {
            var userId = User.Identity.GetUserId();
            var user = UserManager.FindById(userId);
            return new GetViewModel { Hometown = user.Hometown };
        }
    }
}