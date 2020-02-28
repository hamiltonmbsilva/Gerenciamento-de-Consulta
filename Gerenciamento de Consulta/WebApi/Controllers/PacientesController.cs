using Repository.Models;
using System;
using System.Linq;
using System.Web.Http;
using WebApi.Service;

namespace WebApi.Controllers
{

    public class PacientesController : ApiController    {

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

        //GET: api/Pacientes  
        [HttpGet]
        [Route ("api/Pacientes/Select")]
        public IHttpActionResult GetPacientesSelect()
        {
            try
            {
                var pacientes = service.GetPacienteSelect().ToList();

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

                var retorno = service.SalvarPaciente(paciente);

                if(retorno == null)
                {
                    return BadRequest("Erro ao salvar");

                }

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
