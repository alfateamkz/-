using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts
{
    public class ReviewsPageTexts : LocalizableModel
    {
        public string LastBreadcrump { get; set; } = "Отзывы";
        public string Header { get; set; } = "ОТЗЫВЫ";



        public string ReviewFormYourRate { get; set; } = "Ваша оценка";

        public string ReviewFormNameTitle { get; set; } = "Ваше имя";
        public string ReviewFormNamePlaceholder { get; set; } = "Екатерина";

        public string ReviewFormTitleTitle { get; set; } = "Заголовок";
        public string ReviewFormTitlePlaceholder { get; set; } = "Все супер";


        public string ReviewFormDescriptionTitle { get; set; } = "Текст отзыва";
        public string ReviewFormDescriptionPlaceholder { get; set; } = "Alfateam - самые крутые ребята";



        public string ReviewFormProjectLinkTitle { get; set; } = "Ссылка на ваш проект";
        public string ReviewFormProjectLinkPlaceholder { get; set; } = "https://feeno.ru";


        public string ReviewFormBtnSend { get; set; } = "Отправить";



        public string YourReview { get; set; } = "Ваш отзыв";
        public string YourReviewBtnDelete { get; set; } = "Удалить";
        public string YourReviewBtnEdit { get; set; } = "Изменить";
        public string YourReviewBtnSaveChanges { get; set; } = "Сохранить";


        public string YourReviewDeleteConfirmation { get; set; } = "Вы действительно хотите удалить отзыв?";
        public string YourReviewDeleteConfirmationYes { get; set; } = "Да";
        public string YourReviewDeleteConfirmationNot { get; set; } = "Нет";
    }
}
