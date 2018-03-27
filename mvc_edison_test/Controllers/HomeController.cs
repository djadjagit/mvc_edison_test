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
            answer.enableButton1 = "";//enabled кнопка "Загадал"
            answer.enableButton2 = "disabled";//disabled кнопка "Отправить"
            Session["dataServer"] = answer;
            return View(answer);
        }

        [HttpPost]
        public ViewResult Index(ExtraRating answer, int flag = 0)
        {
            string promNum = answer.numGamer;//промежуточная переменная для сохранения загаданного числа
            answer = (ExtraRating)Session["dataServer"];
            answer.numGamer = promNum;
            if (answer.enableButton1 == "")//true это нажатие кнопки Загадал, false нажатие кнопки Отправить
            {
                Random rnd = new Random();
                answer.extraNumber1 = rnd.Next(10, 99).ToString();
                answer.extraNumber2 = rnd.Next(10, 99).ToString();
                answer.extraNumber3 = rnd.Next(10, 99).ToString();
                answer.enableButton1 = "disabled";
                answer.enableButton2 = "";
                Session["dataServer"] = answer;
                return View(answer);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    Random rnd = new Random();
                    answer.extraRate1 = Rating(answer.extraRate1, Convert.ToInt16(answer.extraNumber1), Convert.ToInt16(answer.numGamer));
                    answer.extraRate2 = Rating(answer.extraRate2, Convert.ToInt16(answer.extraNumber2), Convert.ToInt16(answer.numGamer));
                    answer.extraRate3 = Rating(answer.extraRate3, Convert.ToInt16(answer.extraNumber3), Convert.ToInt16(answer.numGamer));
                    answer.historyGamer = answer.historyGamer + answer.numGamer + ";";
                    answer.historyExtra1 = answer.historyExtra1 + answer.extraNumber1 + ";";
                    answer.historyExtra2 = answer.historyExtra2 + answer.extraNumber2 + ";";
                    answer.historyExtra3 = answer.historyExtra3 + answer.extraNumber3 + ";";
                    answer.extraNumber1 = "";
                    answer.extraNumber2 = "";
                    answer.extraNumber3 = "";
                    answer.enableButton1 = "";
                    answer.enableButton2 = "disabled";
                    Session["dataServer"] = answer;
                    return View(answer);
                }
                else
                {
                    return View(answer);
                }
            }
        }
    }
}