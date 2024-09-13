using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.StaticPages.InnerLandings
{
    public class ILRefProgramPageTexts : LocalizableModel
    {
        public string MainBlockHeader { get; set; } = "Возможное и невозможное с Alfateam";
        public string MainBlockColumn1 { get; set; } = "Сотрудничество с профессиональной и опытной командой";
        public string MainBlockColumn2 { get; set; } = "Возможность разработки и внедрения индивидуальных решений";
        public string MainBlockColumn3 { get; set; } = "Инновационные продукты и технологии";
        public string MainBlockBtnLeaveRequest { get; set; } = "Оставить заявку";





        public string ReasonsBlockHeader { get; set; } = "Почему стоит участвовать в программе";
        public string ReasonsBlockPaymentsHTMLContent { get; set; } = "Блок Выплаты растут с каждым клиентом. Заполнить из админки";
        public string ReasonsBlockCRMHTMLContent { get; set; } = "Блок Прозрачная система фиксации лида. Заполнить из админки";
        public string ReasonsBlockReliabilityHTMLContent { get; set; } = "Блок Постоянный заработок. Заполнить из админки";
        public string ReasonsBlockStratigiesHTMLContent { get; set; } = "Блок Любые стратегии. Заполнить из админки";



        public string WeProposeBlockHeader { get; set; } = "Мы предлагаем";
        public string WeProposeBlock_HTMLContentForBusiness { get; set; } = "Блок Для бизнеса. Заполнить из админки";
        public string WeProposeBlock_HTMLContentForFreelancer { get; set; } = "Блок Для фрилансера. Заполнить из админки";



        public string WhichServicesYouCanProposeHeader { get; set; } = "КАКИЕ УСЛУГИ ВЫ МОЖЕТЕ ПРЕДЛАГАТЬ";



        public string PaymentProcedureHeader { get; set; } = "КАКИЕ УСЛУГИ ВЫ МОЖЕТЕ ПРЕДЛАГАТЬ";
        public string PaymentProcedureHTMLBlock1 { get; set; } = "Блок 1. Заполнить из админки";
        public string PaymentProcedureHTMLBlock2 { get; set; } = "Блок 2. Заполнить из админки";
        public string PaymentProcedureHTMLBlock3 { get; set; } = "Блок 3. Заполнить из админки";




        public string WorkStartWithUs { get; set; } = "Начало работы с нами";

        public string WorkStartWithUsScale1Header { get; set; } = "Регистрация в ЛК";
        public string WorkStartWithUsScale1Description { get; set; } = "Регистрация в личном кабинете для получения выплат на свой личный счет";

        public string WorkStartWithUsScale2Header { get; set; } = "Отправка контактов";
        public string WorkStartWithUsScale2Description { get; set; } = "Поделитесь контактами потенциального клиента с нами ";


        public string WorkStartWithUsScale3Header { get; set; } = "Получение вознаграждения";
        public string WorkStartWithUsScale3Description { get; set; } = "Получите деньги на свой счет и выводите их :)";
    } 

}
