using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using GameRetailer.Models;

namespace GameRetailer.Controllers
{

    
    public class AccountController : Controller
    {

        private GameRetailerEntities db = new GameRetailerEntities();

        #region Register Methods
        //[Authorize(Roles = "Admin")]
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        //[Authorize(Roles = "Admin")]
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register(Login user)
        {
            if (User.IsInRole("Admin")) //whatever your admin role is called
            {
                try
                {
                    using (var context = new GameRetailerEntities())
                    {
                        var chkUser = (from s in context.Login where s.Email == user.Email select s).FirstOrDefault();
                        if (chkUser == null)
                        {
                            var keyNew = Helper.GeneratePassword(10);
                            var password = Helper.EncodePassword(user.Password, keyNew);
                            var newUser = context.Login.Create();
                            newUser.Email = user.Email;
                            newUser.Password = password;
                            newUser.PasswordSalt = keyNew;
                            newUser.FName = user.FName;
                            newUser.LName = user.LName;
                            newUser.UserType = user.UserType;
                            context.Login.Add(newUser);
                            context.SaveChanges();
                            ModelState.Clear();
                            return RedirectToAction("Index", "Home");
                        }
                        ViewBag.ErrorMessage = "User already Exixts!";
                        return View();
                    }
                }
                catch (Exception e)
                {
                    ViewBag.ErrorMessage = "Some exception occured" + e;
                    return View();
                }
            }
            else
            {
                try
                {
                    using (var context = new GameRetailerEntities())
                    {
                        var chkUser = (from s in context.Login where s.Email == user.Email select s).FirstOrDefault();
                        if (chkUser == null)
                        {
                            var keyNew = Helper.GeneratePassword(10);
                            var password = Helper.EncodePassword(user.Password, keyNew);
                            var newUser = context.Login.Create();
                            newUser.Email = user.Email;
                            newUser.Password = password;
                            newUser.PasswordSalt = keyNew;
                            newUser.FName = user.FName;
                            newUser.LName = user.LName;
                            newUser.UserType = user.UserType;
                            context.Login.Add(newUser);
                            context.SaveChanges();
                            ModelState.Clear();
                            return RedirectToAction("Index", "Home");
                        }
                        ViewBag.ErrorMessage = "User already Exixts!";
                        return View();
                    }
                }
                catch (Exception e)
                {
                    ViewBag.ErrorMessage = "Some exception occured" + e;
                    return View();
                }
            }
        }

        #endregion

        #region Login methods    
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult LogIn(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new GameRetailerEntities())
            {
                var chkUser = (from s in db.Login where s.Email == model.Email select s).FirstOrDefault();
                if (chkUser != null)
                {
                    var emailCheck = db.Login.FirstOrDefault(u => u.Email == model.Email);
                    var getPassword = db.Login.Where(u => u.Email == model.Email).Select(u => u.Password).FirstOrDefault();
                    var hashCode = db.Login.Where(u => u.Email == model.Email).Select(u => u.PasswordSalt).FirstOrDefault();
                    var encryptedPassword = Helper.EncodePassword(model.Password, hashCode);
                    var getEmail = db.Login.Where(u => u.Email == model.Email).Select(u => u.Email).FirstOrDefault();
                    var getFName = db.Login.Where(u => u.Email == model.Email).Select(u => u.FName).FirstOrDefault();
                    var getLName = db.Login.Where(u => u.Email == model.Email).Select(u => u.LName).FirstOrDefault();
                    var fullname = getFName + " " + getLName;
                    var getRole = db.Login.Where(u => u.Email == model.Email).Select(u => u.UserType).FirstOrDefault();

                    if (model.Email != null && getPassword == encryptedPassword)
                    {
                        var identity = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Email,getEmail),
                        new Claim(ClaimTypes.Name,fullname),
                        new Claim(ClaimTypes.Role,getRole)
                    }, "ApplicationCookie");

                        var ctx = Request.GetOwinContext();
                        var authManager = ctx.Authentication;

                        authManager.SignIn(identity);

                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Email ou Password inválida");

                }
            }

            //ModelState.AddModelError("", "Invalid email or password");
            return View(model);
           
        }

        #endregion
        [Authorize]
        #region Log Out method.    
        public ActionResult Logout()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("Login", "Account");
        }
        #endregion

        //private string GetRedirectUrl(string returnUrl)
        //{
        //    if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
        //    {
        //        return Url.Action("index", "home");
        //    }
        //    return returnUrl;
        //}

    }
}