using Microsoft.AspNetCore.Mvc;
using ML;

namespace PL.Controllers
{
    public class TranseferenciaController : Controller
    {
        public IActionResult GetAll()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Add(ML.Tranferencia tranferencia)
        {
            ML.Result resul = BL.Transferencia.Add(tranferencia);
            if (resul.Correct)
            {
                ViewBag.Message = "Tranferencia realizada  correctamente";
            }
            else
            {
                ViewBag.Message = "No se pudo realizar la transferencia";
            }
            return PartialView("Model");
        }


        public IActionResult TransactionGetByAccount()
        {
            ML.Result result = BL.Transferencia.TransactionGetByAccount();
            ML.Tranferencia tranferencia = new ML.Tranferencia();

            if (result.Correct)
            {
                tranferencia.TranferenciaList = result.ObjectsList;
                return View(tranferencia);
            }
            return View();
        }
    }
}
