using MamCo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MamCo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        static List<Customer> customers = new List<Customer>();
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public IActionResult GetbyId(string id)
        {
            try
            {
                var cus = customers.SingleOrDefault(n => n.id == Guid.Parse(id));
                if (cus == null)
                {
                    return NotFound();
                }
                return Ok(cus);
            } catch
            {
                return BadRequest();
            }
            
        }
        [HttpPost]
        public IActionResult Create(Customer cus)
        {
            var cus1 = new Customer
            {
                id = Guid.NewGuid(),
                Name = cus.Name,
                Gender = cus.Gender
            };
            customers.Add(cus1);
            return Ok( new
            {
                success = true, Data = cus1
            }
                );
        }
        [HttpDelete]
        public IActionResult Delete(Customer cus)
        {
            var cus1 = new Customer
            {
                id = Guid.NewGuid(),
                Name = cus.Name,
                Gender = cus.Gender
            };
            customers.Remove(cus1);
            return Ok(new
            {
                success = true,
                Data = cus1
            }
                );
        }
    }
}
