using ApiBit.Interface;
using DataAccess.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApiBit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ICliente _cliente;

        public ClienteController(ICliente cliente)
        {
            this._cliente = cliente;
        }


        /// <summary>
        /// Listado de clientes por Identificación
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("cliente/id")]

        public async Task<ActionResult<Response>> GetClienteId(int id)
        {
            Response status = new Response();
            try
            {

                var list = await _cliente.GetClienteId(id);
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
        /// Listado de clientes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("cliente/lista")]
        public async Task<ActionResult<Response>> GetCliente()
        {
            Response status = new Response();
            try
            {

                var list = await _cliente.GetCliente();
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
        /// Insercion de clientes
        /// </summary>
        /// <param name="calificacion"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("cliente/insertar")]
        public async Task<ActionResult<Response>> PostCliente([FromBody] ClienteViewModel cliente)
        {
            Response status = new Response();

            try
            {
                var dataCliente = await _cliente.PostCliente(cliente);

                status.IsSuccess = true;
                status.Message = "Insertado";
                status.ObjetoADeserializar = dataCliente;
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
        /// Modifica cliente
        /// </summary>
        /// <param name="calificacion"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("cliente/modificar")]
        public async Task<ActionResult<Response>> PutCliente([FromBody] ClienteViewModel cliente)
        {
            Response status = new Response();
            try
            {
                var dataCliente = await _cliente.PutCliente(cliente);

                status.IsSuccess = true;
                status.Message = "Actualizado";
                status.ObjetoADeserializar = dataCliente;
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
        /// Elimina Cliente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("cliente/eliminar")]
        public async Task<ActionResult<Response>> DeleteCliente(int id)
        {
            Response status = new Response();
            try
            {
                var dataCliente = await _cliente.DeleteCliente(id);

                status.IsSuccess = true;
                status.Message = "Eliminado";
                status.ObjetoADeserializar = dataCliente;
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
