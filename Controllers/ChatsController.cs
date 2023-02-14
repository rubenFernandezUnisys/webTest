using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using TestApp.MVC.Models;
using System.Threading.Tasks;

namespace TestApp.MVC.Controllers 
{
    public class ChatsController : Controller
    {
        public static Dictionary<int, string> Rooms =
            new Dictionary<int, string>(){
            { 1, "Noticias" },
            { 2, "Deportes" },
            { 3, "Politica" }

        };

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Room(int room) 
        {
            return View("Room", room);
        }
    }
}


   