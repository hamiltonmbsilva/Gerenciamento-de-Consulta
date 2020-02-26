using Repository.Models;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApi.Service;

namespace WebApi.Controllers
{
    public class AnamineseController : ApiController
    {
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        public class PacientesController : ApiController
        {

            private readonly AnamineseService service = new AnamineseService();

            //GET: api/Anamineses     
            public IHttpActionResult GetAll()
            {
                try
                {
                    var anaminese = service.BuscarTodasAnaminese().ToList(); 

                    return Ok(anaminese);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            //POST: api/Anamineses
            public IHttpActionResult PostAnaminise(Anaminese anaminese)
            {
                try
                {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }

                    service.SalvarAnaminese(anaminese);

                    return Ok(anaminese);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            //PUT: api/Anamineses/1
            public IHttpActionResult PutAnaminese(Anaminese anaminese)
            {
                try
                {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }

                    service.AlterarAnaminese(anaminese);

                    return Ok(anaminese);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            //DELETE: api/Anamineses/1
            public IHttpActionResult DeleteAnaminese(int? id)
            {
                try
                {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }
                    service.ExcluirAnaminese(id);

                    return Ok();

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}
