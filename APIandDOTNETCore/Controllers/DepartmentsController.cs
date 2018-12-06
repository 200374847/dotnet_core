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
    public class DepartmentsController : ControllerBase
    {
        //db
        private GroceryStoreModel db;
        public DepartmentsController(GroceryStoreModel db)
        {
            this.db = db;
        }

        //GET:api/Departments
        #region

        [HttpGet]

        public IEnumerable<Department> Get()
        {

            return db.Departments.OrderBy(a => a.Department_ID).ToList();

        }
        #endregion

        //Get:api/Departments/5
        #region

        [HttpGet("{id}")]

        public ActionResult Get(int id)
        {
            Department Department = db.Departments.Find(id);
            if (Department == null)
            {

                return NotFound();

            }

            return Ok(Department);
        }
        #endregion

        //POST:api/Departments

        #region
        [HttpPost]


        public ActionResult Post([FromBody] Department Department)

        {
            if (ModelState.IsValid)

            {
                return BadRequest(ModelState);
            }

            db.Departments.Add(Department);

            db.SaveChanges();

            return CreatedAtAction("Post", Department);
        }

        #endregion

        //Put:api/Departments/5

        #region
        [HttpPut("{id}")]

        public ActionResult Put(int id, [FromBody] Department Department)

        {
            if (!ModelState.IsValid)

            {
                return BadRequest(ModelState);
            }

            db.Entry(Department).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            db.SaveChanges();

            return NoContent();
        }

        #endregion

        //Delete:api/Departments/5

        #region

        [HttpDelete("{id}")]

        public ActionResult Delete(int id)
        { 

        Department Department = db.Departments.Find(id);

        if(Department == null)
            {
            return NotFound();
    }

    db.Departments.Remove(Department);

        db.SaveChanges();

        return Ok();
}

            #endregion


        }
    }