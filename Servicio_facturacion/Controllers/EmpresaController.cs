using Microsoft.AspNetCore.Mvc;

namespace x
{
    [ApiController]
    public class Empresas : ControllerBase
    {
        public Empresa[] EmpresaDatos = new Empresa[]
        {
            new Empresa
            {
                Id_Empresa = 1,
                Nombre_Empresa = "EmpresaINC",
                Rut_Empresa = "123456789-K",
                Giro_Empresa = "primera",
                Monto_Pagar = 3000000,
                Total = 300
            }
        };

        [HttpGet]
        [Route("L_Empresas")]
        public IActionResult Listar()
        {
            try
            {
                if (EmpresaDatos != null && EmpresaDatos.Length >= 3)
                {
                    var TresEmpresas = EmpresaDatos.Take(3).ToArray();
                    return StatusCode(200, TresEmpresas);
                }
                else
                {
                    return StatusCode(401, "No hay suficientes empresas para listar.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno por: " + ex);
            }
        }

        [HttpGet]
        [Route("Empresa/{Id_Empresa}")]
        public IActionResult ListarEmpresa(int Id_Empresa)
        {
            try
            {
                if (Id_Empresa > 0 && Id_Empresa <= EmpresaDatos.Length)
                {
                    return StatusCode(200, EmpresaDatos[Id_Empresa - 1]);
                }
                else
                {
                    return StatusCode(401, "No se ha encontrado la empresa");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno por: " + ex);
            }
        }

        // aca cree el metodo get que elimina datos
        [HttpPost]
        [Route("Empresas")]
        public IActionResult GuardaEmpresa([FromBody] Empresa empresa)
        {
            try
            {

                return StatusCode(200, EmpresaDatos);
            }
            catch (Exception ex)
            {
                return StatusCode(400, "No se pudo crear la empresa por: " + ex);
            }
        }

        // aca cree el metodo get que elimina datos
        [HttpDelete]
        [Route("Empresa/{Id_Empresa}")]
        public IActionResult EliminarEmpresa(int id)
        {
            try
            {
                if (id > 0 && id <= EmpresaDatos.Length)
                {

                    return StatusCode(200, "Se ha eliminado el registro.");
                }
                else
                {
                    return StatusCode(401, "No se pudo borrar el registro porque no existe");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "No se pudo borrar por: " + ex);
            }
        }
    }
}