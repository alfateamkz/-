using Alfateam.Database.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Triggero.Models.Attributes;
using Triggero.Models.Enums;

namespace Alfateam.Database.Models.Localizations.Texts
{
    [GeneratorMetadata("Главная страница")]
    public class MainPageLocalization : LocalizationModel
    {

        [GeneratorField("калькулятор")]
        public string CalculatorFixed { get; set; } = "калькулятор";
        [GeneratorField("прокрутка")]
        public string ScrollFixed { get; set; } = "прокрутка";

        #region Main block
        [GeneratorField("ЗАПУСТИ СВОЙ БИЗНЕС С ALFA TEAM - маска {yellow} {main}")]
        public string StartYourBusinessMask { get; set; } = "{yellow} {main}";
        [GeneratorField("СВОЙ БИЗНЕС С ALFA TEAM ({main})")]
        public string StartYourBusiness { get; set; } = "СВОЙ БИЗНЕС С ALFA TEAM";
        [GeneratorField("ЗАПУСТИ ({yellow})")]
        public string StartYourBusinessYellowWord { get; set; } = "ЗАПУСТИ";


        [GeneratorField("и получи первых клиентов в короткие сроки - маска {start} {yellow} {end}")]
        public string AndGetYourClientsMask { get; set; } = "{start} {yellow} {end}";
        [GeneratorField("и получи ({start})")]
        public string AndGetYourClientsStart { get; set; } = "и получи";
        [GeneratorField("первых клиентов ({yellow})")]
        public string AndGetYourClientsYellowWord { get; set; } = "первых клиентов";
        [GeneratorField("в короткие сроки ({end})")]
        public string AndGetYourClientsEnd { get; set; } = "в короткие сроки";

        public string GetStartYourBusinessHTML()
        {
            string yellow = $"<div class=\"orange-color\">{StartYourBusinessYellowWord}</div>";

            return StartYourBusinessMask.Replace("{yellow}", yellow)
                                        .Replace("{main}", StartYourBusiness);
        }
        public string GetAndGetYourClientsHTML()
        {
            string yellow = $"<div class=\"orange-color\">{AndGetYourClientsYellowWord}</div>";

            return AndGetYourClientsMask.Replace("{yellow}", yellow)
                                        .Replace("{start}", AndGetYourClientsStart)
                                        .Replace("{end}", AndGetYourClientsEnd);
        }

        #endregion

        #region Polling block


        [GeneratorField("Ответьте на пару вопросов - маска {yellow} {main}")]
        public string AnswerOnCoupleOfQuestionsMask { get; set; } = "{yellow} {main}";
        [GeneratorField("на пару вопросов ({main})")]
        public string AnswerOnCoupleOfQuestions { get; set; } = "на пару вопросов";
        [GeneratorField("Ответьте ({yellow})")]
        public string AnswerOnCoupleOfQuestionsYellowWord { get; set; } = "Ответьте";
        [GeneratorField("И узнайте примерную стоимость Вашего проекта")]
        public string AnswerOnCoupleOfQuestionsLine2 { get; set; } = "И узнайте примерную стоимость Вашего проекта";
        [GeneratorField("пройти опрос")]
        public string PassPolling { get; set; } = "пройти опрос";

        public string GetAnswerOnCoupleOfQuestionsHTML()
        {
            string yellow = $"<div class=\"orange-color\">{AnswerOnCoupleOfQuestionsYellowWord}</div>";

            return AnswerOnCoupleOfQuestionsMask.Replace("{yellow}", yellow)
                                                .Replace("{main}", AnswerOnCoupleOfQuestions);
        }
        #endregion

        #region Advantages block
        [GeneratorField("ПОЧЕМУ ВЫБИРАЮТ НАС?- маска {yellow} {main}")]
        public string WhyPeopleSelectUsMask { get; set; } = "{main} {yellow}";
        [GeneratorField("ПОЧЕМУ ({main})")]
        public string WhyPeopleSelectUs { get; set; } = "ПОЧЕМУ";
        [GeneratorField("ВЫБИРАЮТ НАС? ({yellow})")]
        public string WhyPeopleSelectUsYellowWord { get; set; } = "ВЫБИРАЮТ НАС?";



        [GeneratorField("Сроки?")]
        public string Adv_01_Terms { get; set; } = "Сроки?";
        [GeneratorField("Стоимость?")]
        public string Adv_02_Cost { get; set; } = "Стоимость?";
        [GeneratorField("Масштабируемость?")]
        public string Adv_03_Scalability { get; set; } = "Масштабируемость?";
        [GeneratorField("Поддержка?")]
        public string Adv_04_Support { get; set; } = "Поддержка?";



        [GeneratorField("Другое агентство")]
        public string OtherAgency { get; set; } = "Другое агентство";
        [GeneratorField("Отсутствие обширного опыта может привести к задержке сроков разработки")]
        public string OtherAgencyText1 { get; set; } = "Отсутствие обширного опыта может привести к задержке сроков разработки";
        [GeneratorField("Не фиксированная стоимость, которая регулярно меняется в процессе работы")]
        public string OtherAgencyText2 { get; set; } = "Не фиксированная стоимость, которая регулярно меняется в процессе работы";
        [GeneratorField("Сложный и долгий процесс изменения/добавления новых разделов")]
        public string OtherAgencyText3 { get; set; } = "Сложный и долгий процесс изменения/добавления новых разделов";
        [GeneratorField("По окончании работ связь теряется и Вы остаётесь “один на один” со своим продуктом")]
        public string OtherAgencyText4 { get; set; } = "По окончании работ связь теряется и Вы остаётесь “один на один” со своим продуктом";



        [GeneratorField("ALFA TEAM")]
        public string AlfaTeamAgency { get; set; } = "ALFA TEAM";



        [GeneratorField("альфатим преймущество 1 - маска {black} {main}")]
        public string AlfaTeamAgencyText1Mask { get; set; } = "{black} {main}";
        [GeneratorField("Большой опыт команды существенно сокращает срок разработки без потери качества. ({main})")]
        public string AlfaTeamAgencyText1 { get; set; } = "Большой опыт команды существенно сокращает срок разработки без потери качества.";
        [GeneratorField("Сайт “под ключ” от 10 дней. ({black})")]
        public string AlfaTeamAgencyText1_Black { get; set; } = "Сайт “под ключ” от 10 дней.";



        [GeneratorField("альфатим преймущество 2 - маска {black} {main}")]
        public string AlfaTeamAgencyText2Mask { get; set; } = "{main} {black}";
        [GeneratorField("Налаженные процессы и наработанный опыт в сочетании ({main})")]
        public string AlfaTeamAgencyText2 { get; set; } = "Налаженные процессы и наработанный опыт в сочетании ";
        [GeneratorField("с низкой ценой ({black})")]
        public string AlfaTeamAgencyText2_Black { get; set; } = "с низкой ценой";



        [GeneratorField("альфатим преймущество 3 -Достаточно просто добавить новую информацию/несложный функционал")]
        public string AlfaTeamAgencyText3 { get; set; } = "Достаточно просто добавить новую информацию/несложный функционал";



        [GeneratorField("альфатим преймущество 4 - маска {black} {main}")]
        public string AlfaTeamAgencyText4Mask { get; set; } = "{main} {black}";
        [GeneratorField("После выполнения задач мы поддерживаем наших клиентов и всегда готовы оказать поддержку.")]
        public string AlfaTeamAgencyText4 { get; set; } = "После выполнения задач мы поддерживаем наших клиентов и всегда готовы оказать поддержку.";
        [GeneratorField("Мы всегда на связи")]
        public string AlfaTeamAgencyText4_Black { get; set; } = "Мы всегда на связи";


        public string GetWhyPeopleSelectUsHTML()
        {
            string yellow = $"<div class=\"orange-color\">{WhyPeopleSelectUsYellowWord}</div>";

            return WhyPeopleSelectUsMask.Replace("{yellow}", yellow)
                                        .Replace("{main}", WhyPeopleSelectUs);
        }
        public string GetAlfaTeamAgencyText1HTML()
        {
            string black = $"<b>{AlfaTeamAgencyText1_Black}</b>";

            return AlfaTeamAgencyText1Mask.Replace("{black}", black)
                                          .Replace("{main}", AlfaTeamAgencyText1);
        }
        public string GetAlfaTeamAgencyText2HTML()
        {
            string black = $"<b>{AlfaTeamAgencyText2_Black}</b>";

            return AlfaTeamAgencyText2Mask.Replace("{black}", black)
                                          .Replace("{main}", AlfaTeamAgencyText2);
        }
        public string GetAlfaTeamAgencyText4HTML()
        {
            string black = $"<b>{AlfaTeamAgencyText4_Black}</b>";

            return AlfaTeamAgencyText4Mask.Replace("{black}", black)
                                          .Replace("{main}", AlfaTeamAgencyText4);
        }
        #endregion

        #region Our works block
        [GeneratorField("НАШИ РАБОТЫ - маска {yellow} {main}")]
        public string OurWorksMask { get; set; } = "{yellow} {main}";
        [GeneratorField("РАБОТЫ - ({main})")]
        public string OurWorks { get; set; } = "РАБОТЫ";
        [GeneratorField("НАШИ - ({yellow})")]
        public string OurWorksYellowWord { get; set; } = "НАШИ";



        [GeneratorField("оставить заявку")]
        public string WatchAll { get; set; } = "оставить заявку";

        public string GetOurWorksHTML()
        {
            string yellow = $"<div class=\"orange-color\">{OurWorksYellowWord}</div>";

            return OurWorksMask.Replace("{yellow}", yellow)
                               .Replace("{main}", OurWorks);
        }

        #endregion

        #region Team block
        [GeneratorField("КОМАНДА")]
        public string Team { get; set; } = "КОМАНДА";
        #endregion

        #region Work stages block

        [GeneratorField("ЭТАПЫ РАБОТЫ - маска {yellow} {main}")]
        public string WorkStagesMask { get; set; } = "{yellow} {main}";
        [GeneratorField("РАБОТЫ - ({main})")]
        public string WorkStages { get; set; } = "РАБОТЫ";
        [GeneratorField("ЭТАПЫ - ({yellow})")]
        public string WorkStagesYellowWord { get; set; } = "ЭТАПЫ";


        [GeneratorField("Этап 1 - заголовок")]
        public string WorkStage_01_Header { get; set; } = "Обсуждение";
        [GeneratorField("Этап 1 - текст")]
        public string WorkStage_01_Text { get; set; } = "Целей и задач вашего бизнеса";



        [GeneratorField("Этап 2 - заголовок")]
        public string WorkStage_02_Header { get; set; } = "Подписание договора";
        [GeneratorField("Этап 2 - текст")]
        public string WorkStage_02_Text { get; set; } = "Со всеми деталями";



        [GeneratorField("Этап 3 - заголовок")]
        public string WorkStage_03_Header { get; set; } = "Предоплата";
        [GeneratorField("Этап 3 - текст")]
        public string WorkStage_03_Text { get; set; } = "За этап разработки";



        [GeneratorField("Этап 4 - заголовок")]
        public string WorkStage_04_Header { get; set; } = "Утверждение";
        [GeneratorField("Этап 4 - текст")]
        public string WorkStage_04_Text { get; set; } = "Прототипа/первого этапа";



        [GeneratorField("Этап 5 - заголовок")]
        public string WorkStage_05_Header { get; set; } = "Оплата следующей части разработки";
        [GeneratorField("Этап 5 - текст")]
        public string WorkStage_05_Text { get; set; } = "Количество оплат зависит от сложности проекта";



        [GeneratorField("Этап 6 - заголовок")]
        public string WorkStage_06_Header { get; set; } = "Завершение задач по проекту";
        [GeneratorField("Этап 6 - текст")]
        public string WorkStage_06_Text { get; set; } = "В установленный договором срок";



        [GeneratorField("Этап 7 - заголовок")]
        public string WorkStage_07_Header { get; set; } = "Приёмка работы";
        [GeneratorField("Этап 7 - текст")]
        public string WorkStage_07_Text { get; set; } = "Внесение правок, тестирование";


        [GeneratorField("Этап 8 - заголовок")]
        public string WorkStage_08_Header { get; set; } = "Финальная оплата";
        [GeneratorField("Этап 8 - текст")]
        public string WorkStage_08_Text { get; set; } = "Количество оплат зависит от сложности проекта";

        public string GetWorkStagesHTML()
        {
            string yellow = $"<div class=\"orange-color\">{WorkStagesYellowWord}</div>";

            return WorkStagesMask.Replace("{yellow}", yellow)
                                 .Replace("{main}", WorkStages);
        }
        #endregion

        #region Our partners block
        [GeneratorField("НАШИ ПАРТНЁРЫ")]
        public string OurPartners { get; set; } = "НАШИ ПАРТНЁРЫ";
        [GeneratorField("Компании, которые нам доверяют")]
        public string CompaniesThatTrustUs { get; set; } = "Компании, которые нам доверяют";
        #endregion

        #region Services presentation block

        [GeneratorField("Продвижение сайта")]
        public string Presentation1Header { get; set; } = "Продвижение сайта";
        [GeneratorField("Продвижение сайта - текст")]
        public string Presentation1Text { get; set; } = "SEO оптимизация и поисковое продвижение сайта - это комплекс работ по выводу" +
            " вашего сайта в ТОП поисковых запросов, которые выполняются командой из сео-специалиста, программиста, копирайтера и контент-менеджера.";
        [GeneratorField("Продвижение сайта - маска стоимости ({price})")]
        public string Presentation1PriceMask { get; set; } = "от {price} рублей";
        [GeneratorField("Продвижение сайта - стоимость",GeneratorControlType.Number)]
        public int Presentation1Price { get; set; } = 1000;


        [GeneratorField("Разработка мобильного приложения")]
        public string Presentation2Header { get; set; } = "Разработка мобильного приложения";
        [GeneratorField("Разработка мобильного приложения - текст 1")]
        public string Presentation2Text1 { get; set; } = "Проектирование и разработка мобильных приложений — сложный процесс," +
            " требующий участия большого количества специалистов: менеджеров, маркетологов, разработчиков, дизайнеров, тестировщиков.";
        [GeneratorField("Разработка мобильного приложения - текст 2")]
        public string Presentation2Text2 { get; set; } = "В ALFA TEAM все процессы идеально отлажены — мы работаем одной командой " +
            "и создали более 50 приложений для интернет-магазинов, банков, служб доставки, игровых студий и пр.";
        [GeneratorField("Разработка мобильного приложения - маска стоимости ({price})")]
        public string Presentation2PriceMask { get; set; } = "от {price} рублей";
        [GeneratorField("Разработка мобильного приложения - стоимость", GeneratorControlType.Number)]
        public int Presentation2Price { get; set; } = 30000;


        [GeneratorField("Сопровождение сайта")]
        public string Presentation3Header { get; set; } = "Сопровождение сайта";
        [GeneratorField("Сопровождение сайта - текст 1")]
        public string Presentation3Text1 { get; set; } = "Контроль безопасности, резервные копии, размещение информации и " +
            "доработка существующих страниц. мероприятия по противодействию атакам хакеров; гарантию на программное " +
            "обеспечение сайта; ежедневный мониторинг функционирования веб-сайта; консультации специалистов заказчика.";
        [GeneratorField("Сопровождение сайта - текст 2")]
        public string Presentation3Text2 { get; set; } = "Стоимость и частота работ разарабатывается в зависимости от потребностей проекта в индивидуальном порядке.";
        public string Presentation3PriceMask { get; set; } = "от {price} рублей";
        [GeneratorField("Сопровождение сайта - стоимость", GeneratorControlType.Number)]
        public int Presentation3Price { get; set; } = 5000;




        [GeneratorField("Разработка сайта")]
        public string Presentation4Header { get; set; } = "Разработка сайта";
        [GeneratorField("Разработка сайта - текст 1")]
        public string Presentation4Text1 { get; set; } = "Наша главная цель — ваша выгода от проекта, и опыт " +
            "помогает нам находить лучшие решения. Вы будете участвовать" +
            " в разработке и в итоге получите сайт, идеально отвечающий потребностям Вашей компании.";
        [GeneratorField("Разработка сайта - текст 2")]
        public string Presentation4Text2 { get; set; } = "Цена услуг находится в среднем диапазоне по рынку. Заказать у нас" +
            " дизайн любой сложности, разработать сайт или интернет-магазин — это верное решение.";
        public string Presentation4PriceMask { get; set; } = "от {price} рублей";
        [GeneratorField("Разработка сайта - стоимость", GeneratorControlType.Number)]
        public int Presentation4Price { get; set; } = 25000;




        [GeneratorField("Прикладное ПО")]
        public string Presentation5Header { get; set; } = "Прикладное ПО";
        [GeneratorField("Прикладное ПО - текст 1")]
        public string Presentation5Text1 { get; set; } = "Разработка программного обеспечения на заказ позволяет Компании" +
            " получить программный продукт, который точно соответствует " +
            "потребностям Компании и особенностям ее бизнес-процессов.";
        [GeneratorField("Прикладное ПО - текст 2")]
        public string Presentation5Text2 { get; set; } = "Заказное ПО будет выполнять лишь тот функционал, который необходим " +
            "Вашей Компании для решения задач. В ней будет отсутствовать все «лишнее» и избыточное," +
            " что может мешать работе пользователя или требовать от него высокой квалификации," +
            " как в случае применения сложных универсальных и типовых программных продуктов.";
        public string Presentation5PriceMask { get; set; } = "от {price} рублей";
        [GeneratorField("Прикладное ПО - стоимость", GeneratorControlType.Number)]
        public int Presentation5Price { get; set; } = 10000;


        public string GetPresentation1PriceHTML()
        {
            string yellow = $"<div class=\"orange-color\">{Presentation1Price}</div>";
            return Presentation1PriceMask.Replace("{price}", yellow);
        }
        public string GetPresentation2PriceHTML()
        {
            string yellow = $"<div class=\"orange-color\">{Presentation2Price}</div>";
            return Presentation2PriceMask.Replace("{price}", yellow);
        }
        public string GetPresentation3PriceHTML()
        {
            string yellow = $"<div class=\"orange-color\">{Presentation3Price}</div>";
            return Presentation3PriceMask.Replace("{price}", yellow);
        }
        public string GetPresentation4PriceHTML()
        {
            string yellow = $"<div class=\"orange-color\">{Presentation4Price}</div>";
            return Presentation4PriceMask.Replace("{price}", yellow);
        }
        public string GetPresentation5PriceHTML()
        {
            string yellow = $"<div class=\"orange-color\">{Presentation5Price}</div>";
            return Presentation5PriceMask.Replace("{price}", yellow);
        }
        #endregion

        #region Our news block

        [GeneratorField("НАШИ НОВОСТИ - маска {main} {yellow}")]
        public string OurNewsMask { get; set; } = "{main} {yellow}";
        [GeneratorField("НАШИ ({main})")]
        public string OurNewsMain { get; set; } = "НАШИ";
        [GeneratorField("НОВОСТИ ({yellow})")]
        public string OurNewsYellowWord { get; set; } = "НОВОСТИ";

        [GeneratorField("БОЛЬШЕ НОВОСТЕЙ")]
        public string MoreNews { get; set; } = "БОЛЬШЕ НОВОСТЕЙ";

        public string GetOurNewsHTML()
        {
            string yellow = $"<div class=\"orange-color\">{OurNewsYellowWord}</div>";

            return OurNewsMask.Replace("{yellow}", yellow)
                              .Replace("{main}", OurNewsMain);
        }

        #endregion

        #region Order form block


        [GeneratorField("ОСТАВЬТЕ ЗАЯВКУ - маска {main} {yellow}")]
        public string MakeOrderMask { get; set; } = "{main} {yellow}";
        [GeneratorField("ОСТАВЬТЕ ({main})")]
        public string MakeOrderMain { get; set; } = "ОСТАВЬТЕ";
        [GeneratorField("ЗАЯВКУ ({yellow})")]
        public string MakeOrderYellowWord { get; set; } = "ЗАЯВКУ";


        [GeneratorField("Как к Вам обращаться?")]
        public string MakeOrderNamePlaceholder { get; set; } = "Как к Вам обращаться?";
        [GeneratorField("Название вашей компании")]
        public string MakeOrderCompanyPlaceholder { get; set; } = "Название вашей компании";
        [GeneratorField("Опишите задачу")]
        public string MakeOrderDescribeTaskPlaceholder { get; set; } = "Опишите задачу";
        [GeneratorField("Ваш бюджет")]
        public string MakeOrderYourBudgetPlaceholder { get; set; } = "Ваш бюджет";
        [GeneratorField("Контакты для связи")]
        public string MakeOrderContactsPlaceholder { get; set; } = "Контакты для связи";



        [GeneratorField("*нажимая кнопку отправить, вы соглашаетесь")]
        public string PolicyTextMain { get; set; } = "*нажимая кнопку отправить, вы соглашаетесь";
        [GeneratorField("с политикой конфиденциальности")]
        public string PolicyTextLink { get; set; } = "с политикой конфиденциальности";


        [GeneratorField("отправить")]
        public string MakeOrderBtn { get; set; } = "отправить";

        public string GetMakeOrderMainHTML()
        {
            string yellow = $"<div class=\"orange-color\">{MakeOrderYellowWord}</div>";

            return MakeOrderMask.Replace("{yellow}", yellow)
                                .Replace("{main}", MakeOrderMain);
        }
        #endregion

        #region Fixed navigation
        [GeneratorField("Главная")]
        public string FixedNavMain { get; set; } = "Главная";
        [GeneratorField("Наши работы")]
        public string FixedNavOurWorks { get; set; } = "Наши работы";
        [GeneratorField("Стоимость")]
        public string FixedNavCost { get; set; } = "Стоимость";
        [GeneratorField("Услуги")]
        public string FixedNavServices { get; set; } = "Услуги";
        [GeneratorField("Новости")]
        public string FixedNavNews { get; set; } = "Новости";
        #endregion



        [GeneratorField("оставить заявку")]
        public string LeaveOrder { get; set; } = "оставить заявку";
    }
}
