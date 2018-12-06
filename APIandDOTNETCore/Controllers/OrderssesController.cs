using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIandDOTNETCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIandDOTNETCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderssesController : ControllerBase
    {
        //db
        private GroceryStoreModel db;
        public OrderssesController(GroceryStoreModel db)
        {
            this.db = db;
        }

        //GET:api/Orders
        #region

        [HttpGet]

        public IEnumerable<Orderss> Get()
        {

            return db.Ordersses.OrderBy(a => a.Order_ID).ToList();

        }
        #endregion

        //Get:api/Orders/5
        #region

        [HttpGet("{id}")]

        public ActionResult Get(int id)
        {
            Orderss Orderss = db.Ordersses.Find(id);
            if (Orderss == null)
            {

                return NotFound();

            }

            return Ok(Orderss);
        }
        #endregion

        //POST:api/Orders

        #region
        [HttpPost]


        public ActionResult Post([FromBody] Orderss Orderss)

        {
            if (ModelState.IsValid)

            {
                return BadRequest(ModelState);
            }

            db.Ordersses.Add(Orderss);

            db.SaveChanges();

            return CreatedAtAction("Post", Orderss);
        }

        #endregion

        //Put:api/orders/5

        #region
        [HttpPut("{id}")]

        public ActionResult Put(int id, [FromBody] Orderss Orderss)

        {
            if (!ModelState.IsValid)

            {
                return BadRequest(ModelState);
            }

            db.Entry(Orderss).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            db.SaveChanges();

            return NoContent();
        }

        #endregion

        //Delete:api/Orders/5

        #region

        [HttpDelete("{id}")]

        public ActionResult Delete(int id)
        {

            Orderss Orderss = db.Ordersses.Find(id);

            if (Orderss == null)
            {
                return NotFound();
            }

            db.Ordersses.Remove(Orderss);

            db.SaveChanges();

            return Ok();
        }

        #endregion

    }
}