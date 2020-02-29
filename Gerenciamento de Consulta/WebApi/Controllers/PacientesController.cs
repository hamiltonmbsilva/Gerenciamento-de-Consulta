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

        //GET: api/Pacinetes/1
        //[Route("api/Pacinetes/id")]
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var paciente = service.BuscarPeloId(id);

                if (paciente == null)
                {
                    return NotFound();
                }

                return Ok(paciente);
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
                
                    //Removendo os espações antes e depois da string
                    paciente.CPF = paciente.CPF.Trim();

                    //Esta subistituindo o ('.') por espaço e o ('-') tambem por espaço
                    paciente.CPF = paciente.CPF.Replace(".", "").Replace("-", ""); 
                

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
        //[Route("api/paciente/alterar/id")]
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
        //[Route("api/Pacientes/id")]
        [HttpDelete]
        public IHttpActionResult DeletePaciente(int id)
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

        [Route("api/Pacientes/dados")]
        [HttpGet]
        public IHttpActionResult AgendamentosDoDia(int codigo)
        {
            try
            {
                if (codigo == 0)
                {
                    return BadRequest("Código inválido");
                }

                var paciente = service.DadosDoPaciente(codigo);
                return Ok(paciente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
