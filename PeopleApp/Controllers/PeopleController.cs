using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using PeopleApp.Models;

namespace PeopleApp.Controllers
{
    [RoutePrefix("api/people")]
    public class PeopleController : ApiController
    {
        private PeopleAppContext db; // = new PeopleAppContext();

        public PeopleController()
        {
            db = new PeopleAppContext();
        }

        public PeopleController(PeopleAppContext context)
        {
            db = context;
        }

        // GET: api/People
        [Route("")]
        public IQueryable<Person> GetPeople()
        {
            return db.People;
        }

        // GET: api/People/Joe
        [Route("{search}")]
        public IQueryable<Person> GetCustomPeople(String search)
        {
            return db.People.Where(p => p.FirstName.Contains(search) || p.LastName.Contains(search));
            
        }

        // GET: api/People/5
        [Route("{id:int}")]
        [ResponseType(typeof(Person))]
        public async Task<IHttpActionResult> GetPerson(int id)
        {
            Person person = await db.People.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        // PUT: api/People/5
        /*[ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPerson(int id, Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != person.Id)
            {
                return BadRequest();
            }

            db.Entry(person).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }*/

        // POST: api/People
        [Route("")]
        [ResponseType(typeof(Person))]
        public async Task<IHttpActionResult> PostPerson(Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.People.Add(person);
            await db.SaveChangesAsync();

            //return CreatedAtRoute("defaultapi", new { id = person.Id }, person);
            //return CreatedAtRoute("api/people/13", new { id = person.Id }, person);
            return CreatedAtRoute("Default", new { id = person.Id }, person);
        }

        // POST api/values
        /*public void PostPerson([FromBody]string value)
        {
        }*/


        // DELETE: api/People/5
        /*[ResponseType(typeof(Person))]
        public async Task<IHttpActionResult> DeletePerson(int id)
        {
            Person person = await db.People.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            db.People.Remove(person);
            await db.SaveChangesAsync();

            return Ok(person);
        }*/

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonExists(int id)
        {
            return db.People.Count(e => e.Id == id) > 0;
        }
    }
}