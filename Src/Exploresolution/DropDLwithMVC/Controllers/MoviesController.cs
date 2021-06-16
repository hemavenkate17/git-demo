using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DropDLwithMVC.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            #region ViewBag

            List<SelectListItem> mlist = new List<SelectListItem>()
            {
                   new SelectListItem{Text ="Roman Holidays", Value ="1" },
                   new SelectListItem{Text ="Pretty Women", Value ="2" },
                   new SelectListItem{Text ="Great Escape", Value ="3" },
                   new SelectListItem{Text ="Boy with stripped pyjama", Value ="4" },
                   new SelectListItem{Text ="Memories", Value ="5" },
                   new SelectListItem{Text ="12 Angry men", Value ="6" },
                   new SelectListItem{Text ="Love stiry 1972", Value ="7" },
                   new SelectListItem { Text ="BeautifulMind",Value="8" }
            };
            ViewBag.MovList = mlist;
            ViewData["MovList "]= mlist;
            TempData["movTList"] = mlist;
            #endregion

            var moList = new List<ConMList>();
            foreach (MoviesList ml in Enum.GetValues(typeof(MoviesList)))
             moList.Add(new ConMList
            {
                Value = (int) ml,
                Text = ml.ToString()
            });
            ViewBag.EnuMovList = moList;
            return View();
        }
        public enum MoviesList
        {
            orphan,
            Night_at_the_Museum,
            Cuckoos_Nest,
            Memento,
            SoundofMusic,
            True_Story,
            The_Juror,
            GoneGirl,
            Why_Him

        }
        public struct ConMList
        {
            public int Value { get; set; }
            public String Text { get; set; }

        }
    }
}