using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PUUUU.Data;

namespace PUUUU.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class UsersController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        public UsersController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        // GET: UsersController
        public ActionResult Index()
        {
            return View(_userManager.Users);
        }

        // GET: UsersController/Edit/5
        public ActionResult Edit(string id)
        {
            return View(_userManager.FindByIdAsync(id).Result);
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, [Bind("UserName, Email, EmailConfirmed, PhoneNumber, PhoneNumberConfirmed, AccessFailedCount, LockoutEnabled, LockoutEnd, TwoFactorEnabled")] IdentityUser updatedUser, string role)
        {
            try
            {
                var oldUser = _userManager.FindByIdAsync(id).Result;
                oldUser.UserName = updatedUser.UserName;
                oldUser.Email = updatedUser.Email;
                oldUser.EmailConfirmed = updatedUser.EmailConfirmed;
                oldUser.PhoneNumber = updatedUser.PhoneNumber;
                oldUser.PhoneNumberConfirmed = updatedUser.PhoneNumberConfirmed;
                oldUser.AccessFailedCount = updatedUser.AccessFailedCount;
                oldUser.LockoutEnabled = updatedUser.LockoutEnabled;
                oldUser.LockoutEnd = updatedUser.LockoutEnd;
                oldUser.TwoFactorEnabled = updatedUser.TwoFactorEnabled;
                _userManager.UpdateAsync(oldUser);
                var oldRole = _userManager.GetRolesAsync(oldUser).Result;
                _userManager.RemoveFromRolesAsync(oldUser, oldRole);
                _userManager.AddToRoleAsync(oldUser, role);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(updatedUser);
            }
        }

        // GET: UsersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
