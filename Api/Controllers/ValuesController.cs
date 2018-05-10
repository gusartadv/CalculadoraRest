using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCalc.Servicio;
using Microsoft.AspNetCore.Mvc;

namespace ApiCalc.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet("suma/{*nums}")]
        public IActionResult Addition([Bind] string nums)
        {
            var serv = new CalculadoraSvc();
            var result = serv.Addition(nums);

            return Ok(result);
        }

        [HttpGet("resta/{*nums}")]
        public IActionResult Substraction([Bind] string nums)
        {
            var serv = new CalculadoraSvc();
            var result = serv.Substraction(nums);

            return Ok(result);
        }

        [HttpGet("mult/{*nums}")]
        public IActionResult Multiplication([Bind] string nums)
        {
            var serv = new CalculadoraSvc();
            var result = serv.Multiplication(nums);

            return Ok(result);
        }

        [HttpGet("div/{*nums}")]
        public IActionResult Division([Bind] string nums)
        {
            var serv = new CalculadoraSvc();
            var result = serv.Division(nums);

            return Ok(result);
        }
    }
}
