using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace mvc_edison_test.Models
{
    public class ExtraRating
    {
        public struct Extrasens
        {
            public int extraRate;//рейтинг экстрасенса
            public string extraNum;//число-предпложение экстрасенса
            public string extraHistory;//история чисел называемых экстрасенсом
        }

        [RegularExpression("[1-9][0-9]", ErrorMessage = "Вы ввели не двузначное число!")]
        public string GamerNum { get; set; }//загаданное число
        public string GamerHistory = "";//история загаданных чисел
        public static int ExtraCount = 5;//число экстрасенсов
        public Extrasens[] ExtrasensData = new Extrasens[ExtraCount];//данные по экстрасенсам
        public string EnableButton = "";//состояние enabled/disabled кнопки Загадал
    }
}