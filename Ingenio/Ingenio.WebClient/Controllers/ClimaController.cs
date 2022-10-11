using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Threading.Tasks;
using Ingenio.WebClient.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Ingenio.WebClient.Controllers
{
    public class ClimaController : Controller
    {
        string baseUrl = ConfigurationManager.AppSettings["URI"];

        public async Task<ActionResult> Index()
        {
            List<Clima> lst = new List<Clima>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("Api/Clima/");

                if (res.IsSuccessStatusCode)
                {
                    var response = res.Content.ReadAsStringAsync().Result;

                    lst = JsonConvert.DeserializeObject<List<Clima>>(response);
                }
            }

            return View(lst);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(Clima clima)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                var postTask = client.PostAsJsonAsync<Clima>("Api/Clima/", clima);
                postTask.Wait();

                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return Redirect("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Error contacte al programador");
            return View(clima);
        }

        public ActionResult Actualizar(int id)
        {
            Clima clima = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                var responseTask = client.GetAsync("Api/Clima/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Clima>();
                    readTask.Wait();
                    clima = readTask.Result;
                }
            }

            return View(clima);
        }

        [HttpPost]
        public ActionResult Actualizar(int id, Clima clima)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                var putTask = client.PutAsJsonAsync($"Api/Clima/{clima.Id}", clima);
                putTask.Wait();

                var result = putTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(clima);
        }

        public ActionResult Eliminar(int id)
        {
            Clima clima = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                var responseTask = client.GetAsync("Api/Clima/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Clima>();
                    readTask.Wait();
                    clima = readTask.Result;
                }
            }

            return View(clima);
        }

        [HttpPost]
        public ActionResult Eliminar(Clima clima, int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

                var deleteTask = client.DeleteAsync($"Api/Clima/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(clima);
        }

    }
}