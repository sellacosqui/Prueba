using Ingenio.WebClient.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Ingenio.WebClient.Controllers
{
    public class UsuarioController : Controller
    {
        string baseUrl = ConfigurationManager.AppSettings["URI"];

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuarios usuario)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);

            if (ModelState.IsValid)
            {
                var postTask = client.PostAsJsonAsync<Usuarios>("Api/Usuario", usuario);
                var result = postTask.Result;

                var validacion = (bool)result.Content.ReadAsAsync<bool>().Result;

                if (validacion)
                {
                    return RedirectToAction("Index", "Clima");
                }
            }

            return View(usuario);
        }

    }
}