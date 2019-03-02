using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManager.Models;

using ProjectManager.Models;
using System.Data;
using PagedList;

using System.Net;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using Microsoft.Ajax.Utilities;

namespace ProjectManager.Controllers
{
    public interface ITreeConstructorController
    {
        DbSet<TreeConstructorModel> DbTreeConstructor { get; }
        void Add(TreeConstructorModel treeConstruct);
        //void Edit(int ID, TreeConstructorModel edit);
        //void AppDbContext();
        int SaveChanges();
        
    }

    public class TreeConstructorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //INTERFACE

        //ITreeConstructorController _treeConstruct;

        //public TreeConstructorController(ITreeConstructorController treeConstruct)
        //{
        //    _treeConstruct = treeConstruct;
        //}
    
        //public DbSet<TreeConstructorModel> DbTreeConstructor => throw new NotImplementedException();

        //public void Add(TreeConstructorModel treeConstruct)
        //{
        //    throw new NotImplementedException();
        //}

        //public int SaveChanges()
        //{
        //    throw new NotImplementedException();
        //}

        //CONSTRUCTOR

        public IQueryable<TreeConstructorModel> GetTreeConstruct()
        {
            return db.TreeConstruct;
        }

        // GET: TreeConstructor
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(TreeConstructorModel construct)
        {
            //db.PostTreeConstructorModel(construct);
            db.TreeConstruct.Add(construct);
            db.SaveChanges();
            return RedirectToAction("TreeConstructorListView", "TreeConstructor");
        }

        public ActionResult Edit(int ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TreeConstructorModel TreeConstruct = db.TreeConstruct.Find(ID);
            if (TreeConstruct == null)
            {
                return HttpNotFound();
            }

            return View("TreeConstructorEditView", TreeConstruct);

        }

        [HttpPost]
        public ActionResult Edit(TreeConstructorModel edit)
        {

            if (ModelState.IsValid)
            {
                db.Entry(edit).State = EntityState.Modified; ;
                db.SaveChanges();
            }

            return RedirectToAction("TreeConstructorListView");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                TreeConstructorModel TreeConstruct = db.TreeConstruct.Find(id);
                db.TreeConstruct.Remove(TreeConstruct);
                db.SaveChanges();
            }
            catch (RetryLimitExceededException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("DeleteIt", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("TreeConstructorListView");
        }

        public ActionResult DeleteIt(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            TreeConstructorModel TreeConstruct = db.TreeConstruct.Find(id);
            if (TreeConstruct == null)
            {
                return HttpNotFound();
            }
            return View(TreeConstruct);
        }

        //RETURN VIEWS
        public ActionResult TreeConstructorAddView(int MasterItemID, int Level)
        {
            TreeConstructorModel TreeConstruct = db.TreeConstruct.Find(MasterItemID);
            if (MasterItemID == 0)
            {
                return View();
            }
            else if (TreeConstruct == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View();
            }
        }
        public ActionResult TreeConstructorListView(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "level_asc" : "";

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            //var TreeConstruct = from t in db.GetTreeConstruct()
            //    select t;

            var TreeConstruct = from t in db.TreeConstruct
                                select t;
            if (!String.IsNullOrEmpty(searchString))
            {
                TreeConstruct = TreeConstruct.Where(t => t.ItemName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "level_asc":
                    TreeConstruct = TreeConstruct.OrderBy(t => t.Level).ThenBy(t => t.MasterItemID).ThenBy(t => t.IsBranch);
                    break;
                default:  // Name ascending 
                    TreeConstruct = TreeConstruct.OrderBy(t => t.Level).ThenBy(t => t.MasterItemID);
                    break;
            }

            
            //return View(TreeConstruct.ToPagedList(pageNumber, pageSize));
            return View(TreeConstruct.OrderBy(x => x.Level).ThenBy(x => x.MasterItemID).ToPagedList(pageNumber, pageSize));
        }

        

        
    }
}