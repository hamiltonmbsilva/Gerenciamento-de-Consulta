using Repository.Models;
using RepositoryWebApi.Repository.Models;
using System;
using System.Linq;
using System.Web.Http;
using WebApi.Service;

namespace WebApi.Controllers
{

    //[Route("api/[controller]")]
    public class AgendamentoController : ApiController
    {
        private readonly AgendamentoService service = new AgendamentoService();

        //GET: api/Agendamento
        [HttpGet]
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
        [Route("api/agendamento/id")]
        [HttpGet]
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

        // POST: api/Agendamento
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

        // PUT: api/Agendamento/1
        //[Route("api/agendamento/alterar/id")]
        [HttpPut]
        public IHttpActionResult PutAgendamento(int id, Agendamento agendamento)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                service.AlterarAgendamento(agendamento);

                return Ok(agendamento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Route("api/agendamento/dia")]
        [HttpGet]
        public IHttpActionResult AgendamentosDoDia(DateTime dia)
        {
            try
            {
                if (dia == new DateTime())
                {
                    return BadRequest("Dia inválido");
                }

                var agendamentos = service.AgendamentosDoDia(dia);
                return Ok(agendamentos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/agendamento/periodoPlano")]
        [HttpGet]
        public IHttpActionResult AgendamentosDoDia(DateTime diaInicial, DateTime diaFinal, EnumPlanos plano)
        {
            try
            {
                if (diaInicial == new DateTime())
                {
                    return BadRequest("Dia inicial inválido");
                }

                if (diaFinal == new DateTime())
                {
                    return BadRequest("Dia final inválido");
                }

                var agendamentos = service.AgendamentosPeriodoPlano(diaInicial, diaFinal, plano);
                return Ok(agendamentos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
