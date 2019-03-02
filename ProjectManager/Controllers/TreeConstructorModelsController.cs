using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using ProjectManager.Models;

namespace ProjectManager.Controllers
{
    public class TreeConstructorModelsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/TreeConstructorModels
        public IQueryable<TreeConstructorModel> GetTreeConstruct()
        {
            return db.TreeConstruct;
            
        }

        // GET: api/TreeConstructorModels/5
        [ResponseType(typeof(TreeConstructorModel))]
        public IHttpActionResult GetTreeConstructorModel(int id)
        {
            TreeConstructorModel treeConstructorModel = db.TreeConstruct.Find(id);
            if (treeConstructorModel == null)
            {
                return NotFound();
            }

            return Ok(treeConstructorModel);
        }

        // PUT: api/TreeConstructorModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTreeConstructorModel(int id, TreeConstructorModel treeConstructorModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != treeConstructorModel.ID)
            {
                return BadRequest();
            }

            db.Entry(treeConstructorModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TreeConstructorModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/TreeConstructorModels
        [ResponseType(typeof(TreeConstructorModel))]
        public IHttpActionResult PostTreeConstructorModel(TreeConstructorModel treeConstructorModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TreeConstruct.Add(treeConstructorModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = treeConstructorModel.ID }, treeConstructorModel);
        }

        // DELETE: api/TreeConstructorModels/5
        [ResponseType(typeof(TreeConstructorModel))]
        public IHttpActionResult DeleteTreeConstructorModel(int id)
        {
            TreeConstructorModel treeConstructorModel = db.TreeConstruct.Find(id);
            if (treeConstructorModel == null)
            {
                return NotFound();
            }

            db.TreeConstruct.Remove(treeConstructorModel);
            db.SaveChanges();

            return Ok(treeConstructorModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TreeConstructorModelExists(int id)
        {
            return db.TreeConstruct.Count(e => e.ID == id) > 0;
        }
    }
}