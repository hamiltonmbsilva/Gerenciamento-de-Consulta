using System;
using System.Web.Http;
using WebApi.Service;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    
    public class AgendamentoController : ApiController
    {
        private readonly AgendamentoService service = new AgendamentoService();

        //GET: api/Agendamentos
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                var agendamentos = service.BuscarTodosOsAgendamento();

                return Ok(agendamentos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
