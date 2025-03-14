using Microsoft.AspNetCore.Mvc;
using UITraining.Interfaces;
using UITraining.Models.DTO;

namespace UITraining.Controllers
{
    public class UserAccessController : Controller
    {
        private readonly IUserAccess _interface;

        public UserAccessController(IUserAccess interfaces)
        {

            _interface = interfaces;
        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterUser(UserAccsessDTO dto)
        {
            try
            {
                var isSuccess = _interface.InsertUserAccess(dto);
                if (isSuccess)
                {
                    return RedirectToAction("Index", "Dashboard");
                }

                return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
