using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using System.Web.Mvc;
using ProjectManager.Models;

namespace ProjectManager.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using ProjectManager.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<BranchModel>("BranchModels");
    builder.EntitySet<TreeConstructorModel>("TreeConstruct"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class BranchModelController : ODataController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: odata/BranchModels
        [EnableQuery]
        public IQueryable<BranchModel> GetBranchModels()
        {
            return db.Tree;
        }

        // GET: odata/BranchModels(5)
        [EnableQuery]
        public SingleResult<BranchModel> GetBranchModel([FromODataUri] int key)
        {
            return SingleResult.Create(db.Tree.Where(branchModel => branchModel.ID == key));
        }

        // PUT: odata/BranchModels(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<BranchModel> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BranchModel branchModel = db.Tree.Find(key);
            if (branchModel == null)
            {
                return NotFound();
            }

            patch.Put(branchModel);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BranchModelExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(branchModel);
        }

        // POST: odata/BranchModels
        public IHttpActionResult Post(BranchModel branchModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tree.Add(branchModel);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (BranchModelExists(branchModel.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(branchModel);
        }

        // PATCH: odata/BranchModels(5)
        [System.Web.Mvc.AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<BranchModel> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BranchModel branchModel = db.Tree.Find(key);
            if (branchModel == null)
            {
                return NotFound();
            }

            patch.Patch(branchModel);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BranchModelExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(branchModel);
        }

        // DELETE: odata/BranchModels(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            BranchModel branchModel = db.Tree.Find(key);
            if (branchModel == null)
            {
                return NotFound();
            }

            db.Tree.Remove(branchModel);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/BranchModels(5)/TreeConstruct
        [EnableQuery]
        public SingleResult<TreeConstructorModel> GetTreeConstruct([FromODataUri] int key)
        {
            return SingleResult.Create(db.Tree.Where(m => m.ID == key).Select(m => m.TreeConstruct));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BranchModelExists(int key)
        {
            return db.Tree.Count(e => e.ID == key) > 0;
        }

        
    }
}
