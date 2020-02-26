using RepositoryWebApi.Repository.Models;
using System;
using System.Collections.Generic;
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
        public IEnumerable<Agendamento> GetAgendamento()
        {
            try
            {
                return service.BuscarTodosOsAgendamento();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public IHttpActionResult GetAll()
        //{
        //    try
        //    {
        //        var agendamentos = service.BuscarTodosOsAgendamento();

        //        return Ok(agendamentos);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
