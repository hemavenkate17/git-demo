using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CRUDController : Controller
    {
        // GET: CRUD
        public ActionResult Index()
        {
            CRUDModel mdl = new CRUDModel();
            DataTable dt = mdl.DisplayBook();
            return View("Home", dt);
        }
        public ActionResult Insert()
        {

            CRUDModel mdl = new CRUDModel();
            DataTable dt = mdl.DisplayAuthor();
            return View("Create",dt);
        }
        public ActionResult InsertRecord(FormCollection frm, string action)
        {
            if (action == "Submit")
            {
                CRUDModel mdl = new CRUDModel();
                string Title = frm["txtTitle"];
                string AuthorName = frm["txtAuthorName"];
                double price = Convert.ToDouble(frm["txtPrice"]);
                int rowIns = mdl.NewBook(Title, AuthorName, price);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
        public ActionResult AuthorIndex()
        {
            CRUDModel mdl = new CRUDModel();
            DataTable dt = mdl.DisplayAuthor();
            return View("HomeAuthor", dt);
        }
        public ActionResult CreateAuthor()
        {
            return View();
        }
        public ActionResult InsertAuthor(FormCollection frm, string action)
        {
            if (action == "Submit")
            {
                CRUDModel mdl = new CRUDModel();
                string AuthorName = frm["txtAuthorName"];
                int rowIns = mdl.NewAuthor(AuthorName);
                return RedirectToAction("AuthorIndex");
            }
            else
            {
                return RedirectToAction("AuthorIndex");
            }

        }
        public ActionResult Delete(int Bookid)
        {
            CRUDModel mdl = new CRUDModel();
            mdl.DeleteBook(Bookid);
            return RedirectToAction("Index");
        }
        public ActionResult Update (FormCollection frm, string action)
        {
            if (action == "Submit")
            {
                CRUDModel mdl = new CRUDModel();
                int BookID = Convert.ToInt32(frm["txtBookID"]);
                string Title = frm["txtTitle"];
                int aid = Convert.ToInt32(frm["txtAid"]);
                double price = Convert.ToDouble(frm["txtPrice"]);
                int rowupd = mdl.UpdateBook(BookID,Title, aid, price);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        
        }
        public ActionResult Edit(int Bookid )
        {
            CRUDModel mdl = new CRUDModel();
            DataTable dt = mdl.BookbyID(Bookid);
            return View("Edit", dt);

        }
    }
}

