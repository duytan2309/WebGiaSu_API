using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Lib.Data.Entities;
using Lib.Domain.ViewModel.Account;
using Lib.Domain.Extensions.Interfaces;
using Lib.Domain.EF;
using Lib.Domain.Utilities;

namespace Web_API.Controllers
{
    [Produces("application/json")]
    [Route("[controller]/[Action]")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private RoleManager<AppRole> _roleManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger<AccountController> _logger;
        private readonly AppDbContext _db;

        public AccountController(
            RoleManager<AppRole> roleManager,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IEmailSender emailSender,
            ILogger<AccountController> logger,
                  AppDbContext db
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _logger = logger;
            _db = db;
            _roleManager = roleManager;

        }

        [HttpPost]
        [AllowAnonymous]
        [Produces(typeof(CustomJsonResult))]
        public async Task<IActionResult> TestSendMail()
        {
            try
            {
                CustomJsonResult resultCustom = new CustomJsonResult();

                resultCustom.StatusCode = 200;
                await _emailSender.SendEmailAsync("tanduy2309@gmail.com", "Tiếp tục với Emal", "Test Send Mail");
                return Json(resultCustom);
            }
            catch (Exception ex)
            {

                     throw;//comments
            }


        }

        [HttpGet]
        [AllowAnonymous]
        [Produces(typeof(CustomJsonResult))]
        public async Task<IActionResult> GetRoles()
        {
            CustomJsonResult resultCustom = new CustomJsonResult();
            resultCustom.StatusCode = 200;
            resultCustom.Message = "Đăng Nhập Thành Công!";
            resultCustom.Result = _db.AppRoles.Where(x => x.Name == "Administrator").FirstOrDefault();
            return Json(resultCustom);
        }

        [TempData]
        public string ErrorMessage { get; set; }

        [HttpGet]
        [AllowAnonymous]
        [Produces(typeof(CustomJsonResult))]
        //[Route("dang-nhap.html", Name = "Login")]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ViewData["ReturnUrl"] = returnUrl;
                     return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [Produces(typeof(CustomJsonResult))]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            CustomJsonResult resultCustom = new CustomJsonResult();
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("Người dùng đăng nhập.");
                    resultCustom.StatusCode = 200;
                    resultCustom.Message = "Đăng Nhập Thành Công!";
                    resultCustom.Result = result;
                    return Json(resultCustom);
                }

                ModelState.AddModelError(string.Empty, "Đăng nhập thất bại.");
                resultCustom.StatusCode = 400;
                resultCustom.Message = "Đăng nhập thất bại!";
                resultCustom.Result = result;
                return Json(resultCustom);
            }

            resultCustom.StatusCode = 500;
            resultCustom.Message = "Form Nhập Không Chính Xác";
            resultCustom.Result = null;
            return Json(resultCustom);

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> LoginWith2fa(bool rememberMe, string returnUrl = null)
        {
            // Ensure the user has gone through the username & password screen first
            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();

            if (user == null)
            {
                throw new ApplicationException($"Không thể tải người dùng xác thực hai yếu tố.");
            }

            var model = new LoginWith2faViewModel { RememberMe = rememberMe };
            ViewData["ReturnUrl"] = returnUrl;

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginWith2fa(LoginWith2faViewModel model, bool rememberMe, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                throw new ApplicationException($"Không thể tải người dùng với ID '{_userManager.GetUserId(User)}'.");
            }

            var authenticatorCode = model.TwoFactorCode.Replace(" ", string.Empty).Replace("-", string.Empty);

            var result = await _signInManager.TwoFactorAuthenticatorSignInAsync(authenticatorCode, rememberMe, model.RememberMachine);

            if (result.Succeeded)
            {
                _logger.LogInformation("Người dùng có ID {UserId} đã đăng nhập bằng 2fa.", user.Id);
                return RedirectToLocal(returnUrl);
            }
            else if (result.IsLockedOut)
            {
                _logger.LogWarning("Người dùng có tài khoản ID {UserId} bị khóa.", user.Id);
                return RedirectToAction(nameof(Lockout));
            }
            else
            {
                _logger.LogWarning("Mã xác thực không hợp lệ được nhập cho người dùng có ID {UserId}.", user.Id);
                ModelState.AddModelError(string.Empty, "Mã xác thực không hợp lệ.");
                return View();
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> LoginWithRecoveryCode(string returnUrl = null)
        {
            // Ensure the user has gone through the username & password screen first
            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                throw new ApplicationException($"Không thể tải người dùng xác thực hai yếu tố.");
            }

            ViewData["ReturnUrl"] = returnUrl;

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginWithRecoveryCode(LoginWithRecoveryCodeViewModel model, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                throw new ApplicationException($"Không thể tải người dùng xác thực hai yếu tố.");
            }

            var recoveryCode = model.RecoveryCode.Replace(" ", string.Empty);

            var result = await _signInManager.TwoFactorRecoveryCodeSignInAsync(recoveryCode);

            if (result.Succeeded)
            {
                _logger.LogInformation("Người dùng có ID {UserId} đã đăng nhập bằng mã khôi phục.", user.Id);
                return RedirectToLocal(returnUrl);
            }
            if (result.IsLockedOut)
            {
                _logger.LogWarning("Người dùng có tài khoản ID {UserId} bị khóa.", user.Id);
                return RedirectToAction(nameof(Lockout));
            }
            else
            {
                _logger.LogWarning("Mã khôi phục không hợp lệ được nhập cho người dùng có ID {UserId}", user.Id);
                ModelState.AddModelError(string.Empty, "Mã khôi phục không hợp lệ được nhập.");
                return View();
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Lockout()
        {
            return View();
        }

        //[HttpGet]
        //[AllowAnonymous]
        //[Produces(typeof(CustomJsonResult))]
        //public async Task<IActionResult> Register(/*string returnUrl = null*/)
        //{
        //    try
        //    {
        //        var resultJson = new CustomJsonResult();

        //        //ViewData["ReturnUrl"] = returnUrl;
        //        resultJson.Result = null;
        //        resultJson.Message = "Bạn Đang Ở Trang Đăng Ký";
        //        resultJson.StatusCode = 200;
        //        // If we got this far, something failed, redisplay form
        //        return Json(resultJson);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        throw;
        //    }
        //}

        [HttpPost]
        [AllowAnonymous]
        [Produces(typeof(CustomJsonResult))]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            var resultJson = new CustomJsonResult();
            try
            {
                //var roleAdmin = _roleManager.FindByNameAsync("Administrator").Result;
                //var rolesResult = await _roleManager.RoleExistsAsync("Administrator");
                //if (!rolesResult)
                //{
                //    var role = new AppRole()
                //    {
                //        Name = "Administrator",
                //        NormalizedName = "ADMINISTRATOR",
                //        Description = "Admin Name"
                //    };
                //    var rsCreateRoles = await _roleManager.CreateAsync(role);
                //    if (!rsCreateRoles.Succeeded)
                //    {
                //        resultJson.Result = rsCreateRoles.Errors;
                //        resultJson.Message = "Tạo quyền truy cập thất bại!";
                //        resultJson.StatusCode = 400;
                //        // If we got this far, something failed, redisplay form
                //        return Json(resultJson.Result);
                //    }

                //}

                var user = new AppUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FullName = model.FullName,
                    PhoneNumber = model.PhoneNumber,
                    BirthDay = model.BirthDay,
                    //Status= Status.Active,
                    Avatar = string.Empty
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    resultJson.Result = result;
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.EmailConfirmationLink(user.Id.ToString(), code, Request.Scheme);
                    //await _emailSender.SendEmailConfirmationAsync(model.Email, callbackUrl);
                    await _emailSender.SendEmailAsync(model.Email, "Tiếp tục với Emal", callbackUrl);

                    _logger.LogInformation("Người dùng đã tạo một tài khoản mới bằng mật khẩu.");
                    resultJson.Message = "Đăng ký tài khoản thành công \n Trạng thái đang chờ phê duyệt";
                    resultJson.StatusCode = 200;
                    return Json(resultJson);
                }
                resultJson.Result = result.Errors;
                resultJson.Message = "Đăng ký thất bại";
                resultJson.StatusCode = 400;
                return Json(resultJson.Result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult ExternalLogin(string provider, string returnUrl = null)
        {
            // Request a redirect to the external login provider.
            var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Account", new { returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Challenge(properties, provider);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            if (remoteError != null)
            {
                ErrorMessage = $"Lỗi từ nhà cung cấp bên ngoài: {remoteError}";
                return RedirectToAction(nameof(Login));
            }
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return RedirectToAction(nameof(Login));
            }

            // Sign in the user with this external login provider if the user already has a login.
            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
            if (result.Succeeded)
            {
                _logger.LogInformation("Người dùng đăng nhập với nhà cung cấp {Name}.", info.LoginProvider);
                return RedirectToLocal(returnUrl);
            }
            if (result.IsLockedOut)
            {
                return RedirectToAction(nameof(Lockout));
            }
            else
            {
                // If the user does not have an account, then ask the user to create an account.
                ViewData["ReturnUrl"] = returnUrl;
                ViewData["LoginProvider"] = info.LoginProvider;
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                return View("ExternalLogin", new ExternalLoginViewModel());
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExternalLoginConfirmation(ExternalLoginViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await _signInManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    throw new ApplicationException("Lỗi tải thông tin đăng nhập bên ngoài trong khi xác nhận.");
                }
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);

                var user = new AppUser
                {
                    UserName = email,
                    Email = email,
                    FullName = model.FullName,
                    BirthDay = DateTime.Parse(model.DOB),
                    PhoneNumber = model.PhoneNumber
                };
                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await _userManager.AddLoginAsync(user, info);
                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        _logger.LogInformation("Người dùng đã tạo tài khoản bằng nhà cung cấp {Name}.", info.LoginProvider);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewData["ReturnUrl"] = returnUrl;
            return View(nameof(ExternalLogin), model);
        }

        [HttpGet]
        [AllowAnonymous]
        [Produces(typeof(CustomJsonResult))]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            var resultJson = new CustomJsonResult();
            if (userId == null || code == null)
            {
                resultJson.StatusCode = 400;
                resultJson.Message = "Thông báo! Mã Người Dùng Không Được Tạo!";
                resultJson.Result = null;
                return Json(resultJson)/*RedirectToAction(nameof(HomeController.Index), "Home")*/;
            }
            //var user = await _userManager.FindByIdAsync(userId);
            var user = await _db.AppUsers.FindAsync(Guid.Parse(userId));
            if (user == null)

            {
                resultJson.StatusCode = 404;
                resultJson.Message = "Thông báo! Người Dùng Không Tìm Thấy!";
                resultJson.Result = null;
                return Json(resultJson);
                throw new ApplicationException($"Không thể tải người dùng với ID '{userId}'.");
            }

            var result = await _userManager.ConfirmEmailAsync(user, code);
            resultJson.StatusCode = 200;
            resultJson.Message = "Thông báo! Đăng Ký Tài Khoản Thành Công!";
            resultJson.Result = result;
            return Json(resultJson);
            //return View(result.Succeeded ? "Tiếp Tục với email!" : "Xác thực email");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [Produces(typeof(CustomJsonResult))]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            var resultJson = new CustomJsonResult();
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                {
                    resultJson.StatusCode = 400;
                    resultJson.Message = "Thông báo! Email Không Chính Xác!";
                    resultJson.Result = null;
                    return Json(resultJson);
                    //// Don't reveal that the user does not exist or is not confirmed
                    //return RedirectToAction(nameof(ForgotPasswordConfirmation));
                }

                // For more information on how to enable account confirmation and password reset
                // please visit https://go.microsoft.com/fwlink/?LinkID=532713
                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.ResetPasswordCallbackLink(user.Id.ToString(), code, Request.Scheme);
                await _emailSender.SendEmailAsync(model.Email, "Lấy lại mật khẩu",
                   $"Vui lòng đặt lại mật khẩu của bạn bằng cách nhấn vào đây: <a href='{callbackUrl}'>Vào đây</a>");

                resultJson.StatusCode = 400;
                resultJson.Message = "Thông báo! Kiểm tra Email để lấy lại mật khẩu!";
                resultJson.Result = null;
                return Json(resultJson);
                //return RedirectToAction(nameof(ForgotPasswordConfirmation));
            }

            resultJson.StatusCode = 400;
            resultJson.Message = "Thông báo! Nhập Đầy Đủ Thông Tin!";
            resultJson.Result = null;
            return Json(resultJson);
            // If we got this far, something failed, redisplay form
            //return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        //[Produces(typeof(CustomJsonResult))]
        public IActionResult ResetPassword(string code = null)
        {
            var resultJson = new CustomJsonResult();
            if (code == null)
            {
                throw new ApplicationException("Mã phải được cung cấp để đặt lại mật khẩu.");
            }
            var model = new ResetPasswordViewModel { Code = code };
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [Produces(typeof(CustomJsonResult))]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            var resultJson = new CustomJsonResult();
            if (!ModelState.IsValid)
            {
                resultJson.StatusCode = 400;
                resultJson.Message = "Thông báo! Nhập đầy đủ thông tin!";
                resultJson.Result = null;
                return Json(resultJson);
                //return View(model);
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                resultJson.StatusCode = 400;
                resultJson.Message = "Thông báo! Không tìm thấy Email người dùng!";
                resultJson.Result = null;
                return Json(resultJson);

                // Don't reveal that the user does not exist
                //return RedirectToAction(nameof(ResetPasswordConfirmation));
            }
            var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded)
            {
                resultJson.StatusCode = 200;
                resultJson.Message = "Thông báo! Dổi mật khẩu thành công!";
                resultJson.Result = null;

                return Json(resultJson);
                //return RedirectToAction(nameof(ResetPasswordConfirmation));
            }
            AddErrors(result);

            resultJson.StatusCode = 200;
            resultJson.Message = "Thông báo! Lỗi hệ Thống!";
            resultJson.Result = result;

            return Json(resultJson);
            //return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        #endregion Helpers
    }
}