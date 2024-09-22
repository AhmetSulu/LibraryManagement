using FinalProjectWeek9.Models;
using FinalProjectWeek9.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FinalProjectWeek9.Controllers
{
    public class AuthController : Controller
    {
        // Static list of users (simulated user storage)
        static List<User> userList = new List<User>
        {
            new User{ Id = 1, Email = "test@example.com", Password = "." }
        };

        private readonly IDataProtector _dataProtector;

        // Constructor to initialize data protector
        public AuthController(IDataProtectionProvider dataProtectionProvider)
        {
            _dataProtector = dataProtectionProvider.CreateProtector("security");
        }

        // GET: /Auth/SignUp
        // Display the SignUp page
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        // POST: /Auth/SignUp
        // Handle the SignUp form submission
        [HttpPost]
        public IActionResult SignUp(SignUpViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["SignUpError"] = "Please fill out the form correctly.";
                return View(model);
            }

            // Encrypt the password and add the user to the list
            var encryptedPassword = _dataProtector.Protect(model.Password);
            userList.Add(new User { Email = model.Email, Password = encryptedPassword });

            TempData["SignUpSuccess"] = "Registration was successful.";
            return RedirectToAction("SignUpSuccess");  // Redirect to the SignUpSuccess action
        }

        // GET: /Auth/SignUpSuccess
        // Display the SignUp success message before redirecting to the login page
        [HttpGet]
        public IActionResult SignUpSuccess()
        {
            return View();
        }

        // GET: /Auth/Login
        // Display the login page
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Auth/Login
        // Handle the login form submission
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["LoginError"] = "Invalid login credentials.";
                return View(model);
            }

            // Find the user by email
            var findUser = userList.FirstOrDefault(user => user.Email == model.Email);

            if (findUser == null)
            {
                TempData["LoginError"] = "Invalid login credentials.";
                return View(model);
            }

            // Decrypt the password and validate
            var rawPassword = _dataProtector.Unprotect(findUser.Password);
            if (rawPassword != model.Password)
            {
                TempData["LoginError"] = "Invalid login credentials.";
                return View(model);
            }

            // Successful login process
            TempData["LoginSuccess"] = "Login successful.";

            // Create user claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, findUser.Email),
                new Claim(ClaimTypes.NameIdentifier, findUser.Id.ToString())
            };

            // Create a claims identity for authentication
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            // Set authentication properties
            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddHours(48)
            };

            // Sign in the user
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

            // Redirect to LoginSuccess action
            return RedirectToAction("LoginSuccess");
        }

        // GET: /Auth/LoginSuccess
        // Display the Login success message before redirecting to the home page
        [HttpGet]
        public IActionResult LoginSuccess()
        {
            return View();
        }

        // GET: /Auth/Logout
        // Handle the logout process
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

    }
}
