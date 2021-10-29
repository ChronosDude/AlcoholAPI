using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Services;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlcoholController : ControllerBase
    {
        //Metodo POST para calcular ingresando los datos por medio de un json en el body. Ej. {"Bebida":"Cerveza","Cantidad":3, "Peso":80}
        
        [HttpPost]
        [Route("")]
        public IActionResult Calculate([FromBody]Somebody alguien)
        {
            var vaspedo = new AlcoholVolumeService();
            var vasonovas = vaspedo.Calculate(alguien);
            return Ok(vasonovas);
        }


        //Metodo GET para calcular ingresando los datos en la direccion. Ej. https://localhost:5001/api/alcohol/cerveza.3.80
        [HttpGet]
        [Route("{bebida}.{cantidad}.{peso}")]
        public IActionResult CalculateD(string bebida, int cantidad,int peso)
        {
            var alguien = new Somebody(bebida,cantidad,peso);
            
            var vaspedo = new AlcoholVolumeService();
            var vasonovas = vaspedo.Calculate(alguien);
            return Ok(vasonovas);
        }

        //Ambos metodos hacen uso del archivo AlcoholVolumeServices
    }
}