using AccessibleWebsite.Models;
using CoreLayer.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Hosting;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MimeKit;
using Org.BouncyCastle.Crypto.Macs;

namespace AccessibleWebsite.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        //Kullanıcının kayıt olma, giriş yapma ve çıkış yapma işlemleri tek bir controller'da birleştirildi.

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterViewModel ap)
        {

            Random random = new Random();
            int code;
            code = random.Next(100000, 1000000);
            AppUser appUser = new AppUser
            {
                Name = ap.Name,
                Surname = ap.Surname,
                Email = ap.Email,
                UserName = ap.UserName,
                Branch = ap.Branch,
                ConfirmCode = code
            };

            if (ap.Password == ap.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(appUser, ap.Password);

                if (result.Succeeded)
                {
                    if (ap.Branch != null)  // Eğer Branch "null" değilse, TrainerId ataması yap.
                    {

                        appUser.TrainerId = appUser.Id; //TrainerId ile AppUserId eşittir.
                        await _userManager.UpdateAsync(appUser);
                    }
                    else
                    {
                        // Branch değeri null ise, üye rolü ataması yap
                        await _userManager.AddToRoleAsync(appUser, "Üye");
                    }

                   
                    MimeMessage mimeMessage = new MimeMessage();
                    MailboxAddress mailboxAddressFrom = new MailboxAddress("Acesgym Admin", "projemail7@gmail.com");
                    MailboxAddress mailboxAddressTo = new MailboxAddress("User", appUser.Email);

                    mimeMessage.From.Add(mailboxAddressFrom);
                    mimeMessage.To.Add(mailboxAddressTo);

                    var body = new BodyBuilder();
                    body.TextBody = "Kayıt işlemini gerçekleştirmek için onay kodunuz:" + code;
                    mimeMessage.Body = body.ToMessageBody();

                    mimeMessage.Subject = "Onay Kodu";

                    SmtpClient client = new SmtpClient();
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("projemail7@gmail.com", "cftbrctlokugbwhn");
                    client.Send(mimeMessage);
                    client.Disconnect(true);

                    return RedirectToAction("SignIn", "Login");

                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(ap);
        }

        [HttpGet]
        public async Task<IActionResult> SignIn()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserSignInViewModel user)
        {
            // Kullanıcı "Hesabı Askıya Al" rolünde ise giriş yapmasını engellenecek.
            var users = await _userManager.FindByNameAsync(user.UserName);
            var isInRole = await _userManager.IsInRoleAsync(users, "Hesabı Askıya Al");

            if (isInRole)
            {
                TempData["ShowAlert"] = true; // Kullanıcı SweetAlert'e yönlendirilecek.
                return View();
            }


            if (ModelState.IsValid)
            {

                var result = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, true, true); // ilk "true" ile kullanıcı sistemde hatırlanacak, ikinci "t" ile de şifre beş defa yanlış girildiği taktirde kullanıcı bloklanacak.


                if (result.Succeeded)
                {

                    return RedirectToAction("Index", "Default");
                }

                else
                {
                    ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre hatalı.");
                    return View();
                }

            }
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Default");
        }
    }
}
