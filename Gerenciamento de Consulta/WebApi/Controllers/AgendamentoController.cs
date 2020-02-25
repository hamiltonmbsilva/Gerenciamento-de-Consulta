using System;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApi.Service;


namespace WebApi.Controllers
{
    //[Route("api/[controller]")]
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
    public class AgendamentoController : ApiController
    {
        private readonly AgendamentoService service = new AgendamentoService();

        //GET: api/Agendamento      
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
