using Repository.Models;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApi.Service;

namespace WebApi.Controllers
{
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
    public class PacientesController : ApiController
    {

        private readonly PacienteService service = new PacienteService();

        //GET: api/Pacientes  
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                var pacientes = service.BuscarTodosOsPacinetes().ToList();

                return Ok(pacientes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //POST: api/Pacientes
        [HttpPost]
        public IHttpActionResult PostPaciente(Paciente paciente)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                service.SalvarPaciente(paciente);

                return Ok(paciente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //PUT: api/Pacientes/1
        [HttpPut]
        public IHttpActionResult PutPaciente(int id, Paciente paciente)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                service.AlterarPaciente(paciente);

                return Ok(paciente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //DELETE: api/Pacientes/1
        [HttpDelete]
        public IHttpActionResult DeletePaciente(int? id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                service.ExcluirPaciente(id);

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
