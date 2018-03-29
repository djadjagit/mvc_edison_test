using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc_edison_test.Models;

namespace mvc_edison_test.Controllers
{
    public class HomeController : Controller
    {
        private int Rating(int extraRate, int extraNum, int userNum) //подсчет рейтинга экстрасенсов
        {
            if (userNum == extraNum) return (extraRate + 100);
            else return (extraRate - Math.Abs(userNum - extraNum));
        }

        [HttpGet]
        public ViewResult Index(ExtraRating answer)
        {
            Session["dataServer"] = answer;
            return View(answer);
        }

        [HttpPost]
        public ViewResult Index(ExtraRating answer, int flag = 0)
        {
            string promNum = answer.GamerNum;
            answer = (ExtraRating)Session["dataServer"];
            answer.GamerNum = promNum;
            if (answer.EnableButton == "")//true это нажатие кнопки Загадал, false нажатие кнопки Отправить
            {
                Random rnd = new Random();
                for (int i = 0; i < answer.ExtrasensData.Length; i++) answer.ExtrasensData[i].extraNum= rnd.Next(10, 99).ToString();
                answer.EnableButton = "disabled";
                Session["dataServer"] = answer;
            }
            else
            {
                if (ModelState.IsValid)
                {
                    answer.GamerHistory = answer.GamerHistory + answer.GamerNum + ";";
                    for (int i = 0; i < answer.ExtrasensData.Length; i++)
                    {
                        answer.ExtrasensData[i].extraRate = Rating(answer.ExtrasensData[i].extraRate, Convert.ToInt16(answer.ExtrasensData[i].extraNum),
                            Convert.ToInt16(answer.GamerNum));
                        answer.ExtrasensData[i].extraHistory = answer.ExtrasensData[i].extraHistory + answer.ExtrasensData[i].extraNum + ";";
                        answer.ExtrasensData[i].extraNum = "";
                    }
                    answer.EnableButton = "";
                    Session["dataServer"] = answer;
                }
            }
            return View(answer);
        }
    }
}