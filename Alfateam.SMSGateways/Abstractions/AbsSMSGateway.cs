using Alfateam.SMSGateways.Enums;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Alfateam.SMSGateways.Abstractions
{
    public abstract class AbsSMSGateway
    {
        public abstract Task<GetBalanceStatus> GetBalance();
        public abstract Task<SentSmsStatus> Send(string phone, string message);



        protected SentSmsStatus? CheckParameters(string phone, string message)
        {
            if (string.IsNullOrEmpty(phone) || !IsPhoneNumber(phone))
            {
                return new SentSmsStatus(SentSmsStatusType.IncorrectPhoneNumber, "Пустой или неверный номер телефона");
            }
            else if(string.IsNullOrEmpty(message))
            {
                return new SentSmsStatus(SentSmsStatusType.EmptyMessage, "Пустой текст");
            }
            else if (System.Text.Encoding.Unicode.GetByteCount(message) > 140 * 8) //Если длина превышает размер в 8 SMS (размер 1 SMS - 140 байтов)
            {
                return new SentSmsStatus(SentSmsStatusType.MessageTooLong, "Сообщение слишком длинное (превышает 1120 байт или же 8 SMS");
            }
            return null;
        }
        protected bool IsPhoneNumber(string number)
        {
            return true; //TODO: IsPhoneNumber
                         //  return Regex.Match(number, @"^(\[0-9]{9})$").Success;
        }


        protected bool DoesPropertyExist(dynamic obj, string name)
        {
            Type objType = obj.GetType();

            if (objType == typeof(ExpandoObject))
            {
                return ((IDictionary<string, object>)obj).ContainsKey(name);
            }
            else if (objType == typeof(JObject))
            {
                return (obj as JObject).ContainsKey(name);
            }

            return objType.GetProperty(name) != null;
        }
    }
}
