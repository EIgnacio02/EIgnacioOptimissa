using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
    public class CuentaController : Controller
    {
        [HttpGet ("GetAll")]
        public IActionResult GetAll()
        {
            ML.Result result = BL.Cuenta.GetAll();

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }

        [HttpGet("GetById/{Account}")]
        public IActionResult GetById(string Account)
        {
            ML.Result result=BL.Cuenta.GetById(Account);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }

        [HttpPost ("Add")]
        public IActionResult Add([FromBody] ML.Cuenta cuenta)
        {
            ML.Result result = BL.Cuenta.Add(cuenta);

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
