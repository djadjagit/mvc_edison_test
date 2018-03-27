using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace mvc_edison_test.Models
{
    public class ExtraRating
    {
        [RegularExpression("[1-9][0-9]", ErrorMessage = "Вы ввели не двузначное число!")]
        public string numGamer { get; set; }//загаданное число
        public int extraRate1 { get; set; }//рейтинг экстрасенса 1
        public int extraRate2 { get; set; }//рейтинг экстрасенса 2
        public int extraRate3 { get; set; }//рейтинг экстрасенса 3
        public string extraNumber1 { get; set; }//число экстрасенса 1
        public string extraNumber2 { get; set; }//число экстрасенса 2
        public string extraNumber3 { get; set; }//число экстрасенса 3
        public string historyGamer { get; set; }//история загаданных чисел
        public string historyExtra1 { get; set; }//историия экстрасенса 1
        public string historyExtra2 { get; set; }//историия экстрасенса 2
        public string historyExtra3 { get; set; }//историия экстрасенса 3
        public string enableButton1 { get; set; }//состояние enabled/disabled кнопки Загадал
        public string enableButton2 { get; set; }//состояние enabled/disabled кнопки Отправить и поля Input
    }
}