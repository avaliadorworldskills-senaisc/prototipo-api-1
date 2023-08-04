using ClassLibrary2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using ClassLibrary2;
namespace WEBAPICRUD.Controllers
{
    public class ValuesController : ApiController
    {
        private masterEntities master = new masterEntities();
        
     
        // GET api/values
        public IHttpActionResult Get()
        {
            var list = master.veiculos.ToList();

            return Ok(list);
        }

        // GET api/values/5
        public IHttpActionResult Get(String id)
        {
            var list = master.veiculos.ToList().Where(v => v.placa == id).ToList();
            return Ok(list);
        }




        // POST api/values
        public IHttpActionResult Post([FromBody] veiculo v)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            master.veiculos.Add(v);
            Console.WriteLine("Placa: " + v.placa + " | veiculo: " + v.veiculo1 + " | condutor: " + v.condutor + " | tipo: " + v.tipo);
            master.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = v.placa}, v);
        }

        // PUT api/values/5
        public IHttpActionResult Put(String id, [FromBody] veiculo v)
        {
           if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var veiculoExistente = master.veiculos.Find(id);

            if(veiculoExistente == null)
            {
                return NotFound();
            }
            var list = master.veiculos.Find(veiculoExistente.placa);

            master.veiculos.Remove(veiculoExistente);



            veiculo veiculoNew = v;





            master.veiculos.Add(veiculoNew);

            master.SaveChanges();

            
            return Ok(list);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {

        }
    }
}
