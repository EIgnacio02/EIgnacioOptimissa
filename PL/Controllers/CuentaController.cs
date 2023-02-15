using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class CuentaController : Controller
    {
        private readonly IConfiguration _configuration;

        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        public CuentaController(IConfiguration configuration, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult GetAll()
        {
            ML.Cuenta cuenta = new ML.Cuenta();
            ML.Result result= new ML.Result();
            result.ObjectsList = new List<object>();

            try
            {
                string urlAPI = _configuration["UrlAPI"];
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(urlAPI);
                    var responseTask = client.GetAsync("GetAll");
                    responseTask.Wait();

                    var resultServicio = responseTask.Result;

                    if (resultServicio.IsSuccessStatusCode)
                    {
                        var readTask = resultServicio.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();

                        foreach (var resultItem in readTask.Result.ObjectsList)
                        {
                            ML.Cuenta resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Cuenta>(resultItem.ToString());
                            result.ObjectsList.Add(resultItemList);
                        }

                        result.Correct = true;
                    }
                }
            }
            catch (Exception )
            {

                throw;
            }
            if (result.Correct)
            {
                cuenta.CuentaList = result.ObjectsList;
                return View(cuenta);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Form(string account)
        {
            ML.Cuenta cuenta = new ML.Cuenta();         
            ML.Result result = new ML.Result();
            //ML.Result result = BL.Cuenta.GetById(account);
            result.ObjectsList = new List<object>();
            if(account == null)
            {
                return View();
            }
            else
            {
                try
                {
                    string urlAPI = _configuration["UrlAPI"];
                    using (var client =new HttpClient())
                    {
                        client.BaseAddress = new Uri(urlAPI);

                        var responseTask= client.GetAsync("GetById/"+account);
                        responseTask.Wait();

                        var resultServicio = responseTask.Result;

                        if (resultServicio.IsSuccessStatusCode)
                        {
                            var readTask = resultServicio.Content.ReadAsAsync<ML.Result>();
                            readTask.Wait();

                            ML.Cuenta resultItemList = new ML.Cuenta();

                            resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Cuenta>(readTask.Result.Object.ToString());
                            result.Object = resultItemList;

                            result.Correct = true;
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                if (result.Correct)
                {
                    cuenta = (ML.Cuenta)result.Object;
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al consultar los datos";
                }
                return View(cuenta);
            }
        }

        [HttpPost]
        public IActionResult Form(ML.Cuenta cuenta)
        {
            ML.Result result = new ML.Result();
            //ML.Result result = BL.Cuenta.Add(cuenta);
            result.ObjectsList = new List<object>();

            try
            {

                string urlAPI = _configuration["UrlAPI"];
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(urlAPI);
                    var postTask = client.PostAsJsonAsync("Add", cuenta);
                    postTask.Wait();

                    var resultServicio = postTask.Result;

                    if (resultServicio.IsSuccessStatusCode)
                    {
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Usario no se pudo agregar";
            }
            if (result.Correct)
            {
                ViewBag.Message = "Uusario agregado correctamente";
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al agregar al usuario" + result.Message;
            }
            return PartialView("Modal");

        }
    }
}
