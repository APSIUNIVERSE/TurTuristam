using Auth.Data;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Auth.Identity;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Security.Claims;
using Auth.Models;
using Auth.Views.Home;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace Auth.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    private readonly IWebHostEnvironment _webHostEnvironment;

    /*private readonly SignInManager<UserTur> _signInManager;*/
    private const string IdOrgKey = "UserId";
    private const string NameOrgKey = "RegOrgName";
    private const string InnOrgKey = "RegOrgInn";
    private const string OgrnOrgKey = "RegOrgOgrn";
    private const string AdressUrOrgKey = "RegOrgAdressUr";
    private const string AdressFactOrgKey = "RegOrgAdressFact";
    private const string LicenseOrgKey = "RegOrgLicense";
    private const string ContactOrgKey = "RegOrgContact";
    private const string MailOrgKey = "RegOrgMail";
    private const string PassOrgKey = "RegOrgPass";


    public HomeController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
    {
        _context = context;
        _webHostEnvironment = webHostEnvironment;
        /*_signInManager = signInManager;*/
    }

    static string GeneratePassword()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        StringBuilder password = new StringBuilder();

        Random random = new Random();
        for (int i = 0; i < 8; i++)
        {
            int index = random.Next(chars.Length);
            password.Append(chars[index]);
        }

        return password.ToString();
    }

    public void SendPass(string pass, string email)
    {
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress("turturistam@mail.ru"); // Адрес отправителя
        mail.To.Add(new MailAddress(email)); // Адрес получателя
        mail.Subject = "TurTuristam";
        mail.Body = "Ваш пароль: " + pass; // 45j1mn09

        SmtpClient client = new SmtpClient();
        client.Host = "smtp.mail.ru";
        client.Port = 587; // Обратите внимание что порт 587
        client.EnableSsl = true;
        client.Credentials =
            new NetworkCredential("turturistam@mail.ru", "hjpVpv311vmY0625jrC4"); // Ваши логин и пароль
        client.Send(mail);
    }


    public IActionResult Chating()
    {
        int currentUserId = HttpContext.Session.GetInt32("UserId") ?? 0;
        
        List<Chat> chats = _context.Chats
            .Where(chat => chat.AgentId == currentUserId.ToString())
            .ToList();

        // Передача списка чатов в представление
        return View(chats);
    }


    public IActionResult Index()
    {
        HttpContext.Session.Clear();

        return View();
    }

    public IActionResult Auth()
    {
        HttpContext.Session.Clear();

        return View();
    }

    public IActionResult ResetPass()
    {
        return View();
    }

    public IActionResult ChangedpTur()
    {
        return View();
    }

    [HttpPost]
    public IActionResult ResetPass(string nametur)
    {
        var user = _context.UsersTur.FirstOrDefault(u => u.Mail == nametur);
        string mail = string.Empty;
        if (user != null)
        {
            mail = user.Mail;
            string q = GeneratePassword();

            SendPass(q, mail);
            user.Password = q;
            _context.SaveChanges();
            return RedirectToAction("ChangedpTur");
        }

        return RedirectToAction("Index");
    }

    public IActionResult ResetPassAgent()
    {
        return View();
    }

    public IActionResult Policy()
    {
        
        return View();
    }

    [HttpPost]
    public IActionResult ResetPassAgent(string nametur)
    {
        var user = _context.UsersAgent.FirstOrDefault(u => u.RegOrgName == nametur);
        string mail = string.Empty;
        if (user != null)
        {
            mail = user.RegOrgMail;
            string q = GeneratePassword();

            SendPass(q, mail);
            user.RegOrgPass = q;
            _context.SaveChanges();
            return RedirectToAction("ChangedpTur");
        }

        return RedirectToAction("Index");
    }

    public IActionResult Reg()
    {
        HttpContext.Session.Clear();

        return View();
    }

    public IActionResult InAgent()
    {
        HttpContext.Session.Clear();

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> InAgent(LoginViewModelAgent model)
    {
        if (ModelState.IsValid)
        {
            var user = _context.UsersAgent.FirstOrDefault(u => u.RegOrgName == model.nameorg);

            if (user != null)
            {
                HttpContext.Session.SetInt32(IdOrgKey, user.Id);
                HttpContext.Session.SetString(NameOrgKey, user.RegOrgName ?? "");
                HttpContext.Session.SetString(InnOrgKey, user.RegOrgInn ?? "");
                HttpContext.Session.SetString(OgrnOrgKey, user.RegOrgOgrn ?? "");
                HttpContext.Session.SetString(AdressFactOrgKey, user.RegOrgAdressFact ?? "");
                HttpContext.Session.SetString(AdressUrOrgKey, user.RegOrgAdressUr ?? "");
                HttpContext.Session.SetString(LicenseOrgKey, user.RegOrgLicense ?? "");
                HttpContext.Session.SetString(ContactOrgKey, user.RegOrgContact ?? "");
                HttpContext.Session.SetString(MailOrgKey, user.RegOrgMail ?? "");
                HttpContext.Session.SetString(PassOrgKey, user.RegOrgPass ?? "");
                return RedirectToAction("IndexAgent", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Неверный email или пароль");
            }
        }

        return View("Auth");
    }
    /*[HttpPost("PasswordResetAgent")]
    public IActionResult PasswordResetAgent(string nameorg)
    {
        var user = _context.UsersAgent.FirstOrDefault(u => u.RegOrgName == nameorg);
        string mail = string.Empty;
        if (user != null)
        {
            mail = user.RegOrgMail;
            string q = GeneratePassword();
            
            SendPass(q, mail);
            user.RegOrgPass = q;
            _context.SaveChanges();
            
        }

        return RedirectToAction("InAgent");
    }*/

    public IActionResult InTur()
    {
        HttpContext.Session.Clear();

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> InTur(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = _context.UsersTur.FirstOrDefault(u => u.Mail == model.nametur);

            if (user != null && model.passwordtur == user.Password && model.nametur == user.Mail)
            {
                HttpContext.Session.SetString("Name", user.Name ?? "");
                HttpContext.Session.SetString("Mail", user.Mail);
                HttpContext.Session.SetString("Password", user.Password);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Неверный email или пароль");
            }
        }

        return View("Auth");
    }

    public IActionResult RegAgent()
    {
        HttpContext.Session.Clear();

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> RegAgent(UserAgent user, IFormFile regorgskan)
    {
        if (ModelState.IsValid)
        {
            string q = GeneratePassword();
            string m = user.RegOrgMail;
            SendPass(q, m);
            user.RegOrgPass = q;
            /*_context.UsersAgent.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Index");*/
            if (regorgskan != null && regorgskan.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await regorgskan.CopyToAsync(memoryStream);
                    user.RegOrgSkan = memoryStream.ToArray();
                }
            }

            // Сохранение пользователя в базу данных

            _context.UsersAgent.Add(user);
            await _context.SaveChangesAsync();

            // Возврат результата или перенаправление пользователя на другую страницу
            return RedirectToAction("Oncheck");
        }

        return RedirectToAction("RegAgent");
    }

    [HttpGet]
    public IActionResult RegTur()
    {
        HttpContext.Session.Clear();

        return View();
    }

    [HttpPost]
    public IActionResult RegTur(UserTur user)
    {
        if (ModelState.IsValid)
        {
            string q = GeneratePassword();
            string m = user.Mail;
            SendPass(q, m);
            user.Password = q;
            /*user.Password = "1234";*/
            _context.UsersTur.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        return RedirectToAction("RegTur");
    }

    public IActionResult Oncheck()
    {
        return View();
    }

    public IActionResult IndexAgent()
    {
        int currentUserId = HttpContext.Session.GetInt32("UserId") ?? 0;
        
        List<Chat> chats = _context.Chats
            .Where(chat => chat.AgentId == currentUserId.ToString())
            .ToList();

        // Передача списка чатов в представление
        return View(chats);
    }

    public IActionResult Options()
    {
        return View();
    }

    public IActionResult ChangePass()
    {
        return View();
    }

    [HttpGet]
    public IActionResult ChangePass(ChangePassViewModel model)
    {
        if (ModelState.IsValid)
        {
            if (model.passch != model.passchrepeat)
            {
                ModelState.AddModelError(string.Empty, "Пароли не совпадают");
                //return RedirectToAction("ChangePass");
            }

            if (model.passch == model.passchrepeat)
            {
                string p = GeneratePassword();
                // Получение текущего email пользователя из сессии
                string currentEmail = HttpContext.Session.GetString("Email");

                // Поиск пользователя в базе данных по email
                var user = _context.UsersAgent.FirstOrDefault(u => u.RegOrgMail == currentEmail);

                if (user != null)
                {
                    SendPass(p, user.RegOrgMail);
                    // Обновление пароля пользователя в объекте из базы данных
                    user.RegOrgPass = p;

                    // Сохранение изменений в базе данных
                    _context.SaveChanges();
                }

                // Редирект на страницу личного кабинета или другую страницу
                return RedirectToAction("ChangedPassAgent", "Home");
            }
        }

        return RedirectToAction("Index");
    }

    public IActionResult ChangedPassAgent()
    {
        return View();
    }

    public IActionResult FeedBack()
    {
        return View();
    }

    public IActionResult Profile()
    {
        ViewBag.currentUserId = HttpContext.Session.GetInt32("UserId") ?? 0;
        ViewBag.currentUserName = HttpContext.Session.GetString("RegOrgName") ?? "0";
        ViewBag.currentUserInn = HttpContext.Session.GetString("RegOrgInn") ?? "0";
        ViewBag.currentUserOgrn = HttpContext.Session.GetString("RegOrgOgrn") ?? "0";
        ViewBag.currentUserAdressUr = HttpContext.Session.GetString("RegOrgAdressUr") ?? "0";
        ViewBag.currentUserAdressFact = HttpContext.Session.GetString("RegOrgAdressFact") ?? "0";
        ViewBag.currentUserLicense = HttpContext.Session.GetString("RegOrgLicense") ?? "0";
        ViewBag.currentUserContact = HttpContext.Session.GetString("RegOrgContact") ?? "0";
        ViewBag.currentUserMail = HttpContext.Session.GetString("RegOrgMail") ?? "0";
        ViewBag.currentUserPass = HttpContext.Session.GetString("RegOrgPass") ?? "0";

        /*List<object> chats = new List<object>();
        chats.Add(currentUserId);
        chats.Add(currentUserName);
        chats.Add(currentUserInn);
        chats.Add(currentUserOgrn);
        chats.Add(currentUserAdressUr);
        chats.Add(currentUserAdressFact);
        chats.Add(currentUserLicense);
        chats.Add(currentUserContact);
        chats.Add(currentUserMail);
        chats.Add(currentUserPass);
        // Передача списка чатов в представление

        ViewBag.Chats = chats;*/
        return View();
        
    }

    public IActionResult RedactingProfile()
    {
        return View();
    }

    public IActionResult DeleteProfile()
    {
        return View();
    }

    public IActionResult ChangeMail()
    {
        return View();
    }

    public IActionResult CreateStandartTur()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateStandartTur(Turs tur)
    {
        //if (ModelState.IsValid)
        {
            _context.Turs.Add(tur);
            _context.SaveChanges();
            return RedirectToAction("IndexAgent");
        }

        return View();
    }
    public IActionResult IndexTurist()
    {
        return View();
    }
    public IActionResult SendedStandartTur()
    {
        return View();
    }
    public IActionResult SearchTur()
    {
        return View();
    }
    public IActionResult Favourites()
    {
        return View();
    }
    public IActionResult ProfileTur()
    {
        ViewBag.Name = HttpContext.Session.GetString("Name") ?? "";
        return View();
    }
    public IActionResult RedactingProfileTur()
    {
        return View();
    }
    public IActionResult ChangePassTur()
    {
        return View();
    }
}