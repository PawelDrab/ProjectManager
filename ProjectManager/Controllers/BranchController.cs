using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectManager.Models;
using System.Data;
using PagedList;

using System.Net;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using Microsoft.Ajax.Utilities;
using System.Web.Mvc;

namespace ProjectManager.Controllers
{
    public class BranchController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //RETURN VIEWS
        public ActionResult BranchAddView()
        {
            return View();
        }


        public ActionResult BranchListView()
        {
            return View();
        }
    }
}
