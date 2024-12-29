using Microsoft.AspNetCore.Mvc;
using ExamManagementSystem.Models;

namespace ExamManagementSystem.Controllers
{
    public class LoginController : Controller
    {
        private BusinessLayer businessLayer;
        public LoginController(BusinessLayer businessLayer)
        {
            this.businessLayer = businessLayer;
        }
        public IActionResult CheckUserExist(User user)
        {
            bool flag = businessLayer.CheckUserExist(user);
            if (flag)
            {
              return   RedirectToAction("Dashboard", "Admin");
            }
            return RedirectToAction("Login", "Home");
        }
    }
}
