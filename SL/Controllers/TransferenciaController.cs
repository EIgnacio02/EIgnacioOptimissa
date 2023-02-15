using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
    public class TransferenciaController : Controller
    {
        [HttpGet ("Transferencia/GetAll")]
        public IActionResult GetAll()
        {
            return View();
        }

        [HttpPost ("Transferencia/Add")]
        public IActionResult Add([FromBody] ML.Tranferencia tranferencia)
        {
            ML.Result result = BL.Transferencia.Add(tranferencia);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);

            }
        }

        [HttpGet ("Transferencia/{ToAccount}")]
        public IActionResult TransactionGetByToAccount(string ToAccount)
        {

            ML.Result result=BL.Transferencia.TransactionGetByToAccount(ToAccount);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }



    }
}
