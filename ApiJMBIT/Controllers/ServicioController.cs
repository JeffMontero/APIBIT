using BusinessLogic.Interface;
using DataAccess.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApiJMBIT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : Controller
    {
        private readonly IServicio _servicio;

        public ServicioController(IServicio servicio)
        {
            this._servicio = servicio;
        }

        /// <summary>
        /// Listado de servicio por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("servicio/id")]

        public async Task<ActionResult<Response>> GetServicioId(int id)
        {
            Response status = new Response();
            try
            {

                var list = await _servicio.GetServicioId(id);
                status.ObjetoADeserializar = list;
                status.IsSuccess = true;
                status.Message = "OK";
                return status;
            }
            catch (System.Exception ex)
            {

                status.IsSuccess = false;
                status.Message = ex.Message;
                return status;
            }

        }

        /// <summary>
        /// Listado de servicios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("servicio/lista")]
        public async Task<ActionResult<Response>> GetServicio()
        {
            Response status = new Response();
            try
            {

                var list = await _servicio.GetServicio();
                status.ObjetoADeserializar = list;
                status.IsSuccess = true;
                status.Message = "OK";
                return status;
            }
            catch (System.Exception ex)
            {

                status.IsSuccess = false;
                status.Message = ex.Message;
                return status;
            }

        }

        /// <summary>
        /// Insercion de servicios
        /// </summary>
        /// <param name="calificacion"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("servicio/insertar")]
        public async Task<ActionResult<Response>> PostServicio([FromBody] ServicioViewModel servicio)
        {
            Response status = new Response();

            try
            {
                var dataServicio= await _servicio.PostServicio(servicio);

                status.IsSuccess = true;
                status.Message = "Insertado";
                status.ObjetoADeserializar = dataServicio;
                return status;
            }
            catch (Exception ex)
            {
                status.IsSuccess = false;
                status.Message = ex.Message;
                return status;
            }
        }

        /// <summary>
        /// Modifica servicio
        /// </summary>
        /// <param name="calificacion"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("servicio/modificar")]
        public async Task<ActionResult<Response>> PutServicio([FromBody] ServicioViewModel servicio)
        {
            Response status = new Response();
            try
            {
                var dataServicio = await _servicio.PutServicio(servicio);

                status.IsSuccess = true;
                status.Message = "Actualizado";
                status.ObjetoADeserializar = dataServicio;
                return status;
            }
            catch (Exception ex)
            {
                status.IsSuccess = false;
                status.Message = ex.Message;
                return status;
            }
        }

        /// <summary>
        /// Elimina servicio
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("servicio/eliminar")]
        public async Task<ActionResult<Response>> DeleteServicio(int id)
        {
            Response status = new Response();
            try
            {
                var dataServicio = await _servicio.DeleteServicio(id);

                status.IsSuccess = true;
                status.Message = "Eliminado";
                status.ObjetoADeserializar = dataServicio;
                return status;
            }
            catch (Exception ex)
            {
                status.IsSuccess = false;
                status.Message = ex.Message;
                return status;
            }
        }
    }
}
