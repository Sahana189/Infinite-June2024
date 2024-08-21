using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Prj.Models;

namespace WebApi.Prj.Controllers
{
    public class CountryController : ApiController
    {
        private static List<Country> countries = new List<Country>();
        private static int nextId = 1;

        // GET
        [HttpGet]
        public IEnumerable<Country> GetCountries()
        {
            return countries;
        }

        // GET BY ID
        [HttpGet]
        public IHttpActionResult GetCountry(int id)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }

        // POST
        [HttpPost]
        public IHttpActionResult PostCountry(Country country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            country.ID = nextId++;
            countries.Add(country);
            return CreatedAtRoute("DefaultApi", new { id = country.ID }, country);
        }

        // PUT
        [HttpPut]
        public IHttpActionResult PutCountry(int id, Country country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != country.ID)
            {
                return BadRequest();
            }

            var existingCountry = countries.FirstOrDefault(c => c.ID == id);
            if (existingCountry == null)
            {
                return NotFound();
            }

            existingCountry.CountryName = country.CountryName;
            existingCountry.Capital = country.Capital;

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE
        [HttpDelete]
        public IHttpActionResult DeleteCountry(int id)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
            {
                return NotFound();
            }

            countries.Remove(country);
            return Ok(country);
        }
    }
}
