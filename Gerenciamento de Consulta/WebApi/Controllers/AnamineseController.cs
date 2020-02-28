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
        private readonly AnamineseService service = new AnamineseService();
            

            //GET: api/Anaminese 
            [HttpGet]
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

        //POST: api/Anaminese
        [HttpPost]
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

        //PUT: api/Anaminese/1
        [HttpPut]
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

        //DELETE: api/AnamineseAn/1
        [HttpDelete]
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
