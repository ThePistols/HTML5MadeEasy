using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class QuestionaireController : Controller
    {
        // GET: Questionaire
        [HttpGet]
        public ActionResult Questionaire()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Teacher()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProcessQuestionaire(string Answer1, string Answer2, string Answer3, string Answer4, string Answer5, string Answer6, string Answer7, string Answer8, string Answer9, string Answer10, string Answer11, string Answer12, string Answer13, string Answer14, string Answer15, string Answer16, string Answer17)
        {
            ViewData["Answer1"] = Answer1;
            if (Answer1 == "C")
            {
                ViewData["Answer1Result"] = "/Content/Images/checkmark.png";
            }
            else
            {
                ViewData["Answer1Result"] = "/Content/Images/x mark.png";

            }

            ViewData["Answer2"] = Answer2;
            if (Answer2 == "A")
            {
                ViewData["Answer2Result"] = "/Content/Images/checkmark.png";
            }
            else
            {
                ViewData["Answer2Result"] = "/Content/Images/x mark.png";

            }
            ViewData["Answer3"] = Answer3;
            if (Answer3 == "B")
            {
                ViewData["Answer3Result"] = "/Content/Images/checkmark.png";
            }
            else
            {
                ViewData["Answer3Result"] = "/Content/Images/x mark.png";

            }
            ViewData["Answer4"] = Answer4;
            if (Answer4 == "A")
            {
                ViewData["Answer4Result"] = "/Content/Images/checkmark.png";
            }
            else
            {
                ViewData["Answer4Result"] = "/Content/Images/x mark.png";

            }
            ViewData["Answer5"] = Answer5;
            if (Answer5 == "A")
            {
                ViewData["Answer5Result"] = "/Content/Images/checkmark.png";
            }
            else
            {
                ViewData["Answer5Result"] = "/Content/Images/x mark.png";

            }
            ViewData["Answer6"] = Answer6;
            if (Answer6 == "A")
            {
                ViewData["Answer6Result"] = "/Content/Images/checkmark.png";
            }
            else
            {
                ViewData["Answer6Result"] = "/Content/Images/x mark.png";

            }
            ViewData["Answer7"] = Answer7;
            if (Answer7 == "B")
            {
                ViewData["Answer7Result"] = "/Content/Images/checkmark.png";
            }
            else
            {
                ViewData["Answer7Result"] = "/Content/Images/x mark.png";

            }
            ViewData["Answer8"] = Answer8;
            if (Answer8 == "C")
            {
                ViewData["Answer8Result"] = "/Content/Images/checkmark.png";
            }
            else
            {
                ViewData["Answer8Result"] = "/Content/Images/x mark.png";

            }
            ViewData["Answer9"] = Answer9;
            if (Answer9 == "B")
            {
                ViewData["Answer9Result"] = "/Content/Images/checkmark.png";
            }
            else
            {
                ViewData["Answer9Result"] = "/Content/Images/x mark.png";

            }
            ViewData["Answer10"] = Answer10;
            if (Answer10 == "A")
            {
                ViewData["Answer10Result"] = "/Content/Images/checkmark.png";
            }
            else
            {
                ViewData["Answer10Result"] = "/Content/Images/x mark.png";

            }
            ViewData["Answer11"] = Answer11;
            if (Answer11 == "A")
            {
                ViewData["Answer11Result"] = "/Content/Images/checkmark.png";
            }
            else
            {
                ViewData["Answer11Result"] = "/Content/Images/x mark.png";

            }
            ViewData["Answer12"] = Answer12;
            if (Answer12 == "C")
            {
                ViewData["Answer12Result"] = "/Content/Images/checkmark.png";
            }
            else
            {
                ViewData["Answer12Result"] = "/Content/Images/x mark.png";

            }
            ViewData["Answer13"] = Answer13;
            if (Answer13 == "C")
            {
                ViewData["Answer13Result"] = "/Content/Images/checkmark.png";
            }
            else
            {
                ViewData["Answer13Result"] = "/Content/Images/x mark.png";

            }
            ViewData["Answer14"] = Answer14;
            if (Answer14 == "C")
            {
                ViewData["Answer14Result"] = "/Content/Images/checkmark.png";
            }
            else
            {
                ViewData["Answer14Result"] = "/Content/Images/x mark.png";

            }
            ViewData["Answer15"] = Answer15;
            if (Answer15 == "B")
            {
                ViewData["Answer15Result"] = "/Content/Images/checkmark.png";
            }
            else
            {
                ViewData["Answer15Result"] = "/Content/Images/x mark.png";

            }
            ViewData["Answer16"] = Answer16;
            if (Answer16 == "B")
            {
                ViewData["Answer16Result"] = "/Content/Images/checkmark.png";
            }
            else
            {
                ViewData["Answer16Result"] = "/Content/Images/x mark.png";

            }
            ViewData["Answer17"] = Answer17;
            if (Answer17 == "A")
            {
                ViewData["Answer17Result"] = "/Content/Images/checkmark.png";
            }
            else
            {
                ViewData["Answer17Result"] = "/Content/Images/x mark.png";

            }
            return View();
        }

    }
}