using RepositoryWebApi.Repository.Models;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApi.Service;

namespace WebApi.Controllers
{
   
    //[Route("api/[controller]")]
    public class AgendamentoController : ApiController
    {
        private readonly AgendamentoService service = new AgendamentoService();
        private readonly AnamineseService anaminese = new AnamineseService();

        //GET: api/Agendamento     
        public IHttpActionResult GetAll()
        {
            try
            {
                var agendamentos = service.BuscarTodosOsAgendamento().ToList();

                return Ok(agendamentos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //GET: api/Agendamento/1
        public IHttpActionResult GetById( int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var agendamento = service.BuscarAgendamentoPeloId(id);

                if(agendamento == null)
                {
                    return NotFound();
                }

                return Ok(agendamento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult PostAgendamento(Agendamento agendamento)
        {
            try
            {
                    
                service.SalvarAgendamento(agendamento);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
