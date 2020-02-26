using RepositoryWebApi.Repository.Models;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApi.Service;


namespace WebApi.Controllers
{

    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
    //[Route("api/[controller]")]
    public class AgendamentoController : ApiController
    {
        private readonly AgendamentoService service = new AgendamentoService();

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

        //public IHttpActionResult PostAgendamento(Agendamento agendamento)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }
        //        service.SalvarAgendamento(agendamento);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

    }
}
