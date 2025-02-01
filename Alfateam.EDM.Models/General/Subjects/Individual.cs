using Alfateam.Core;
using Alfateam.EDM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.General.Subjects
{
    public class Individual : EDMSubject
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string? Patronymic { get; set; }

        public DateTime Birthdate { get; set; }


        /// <summary>
        /// Статический пользователь с подвязкой в Alfateam ID
        /// </summary>
        public User Me { get; set; }


        /// <summary>
        /// Паспортные данные или что-то в этом духе
        /// </summary>
        public string IdentificationDocumentData { get; set; }


        public bool IsSelfEmployed { get; set; }


        public override string ToString()
        {
            return $"{Surname} {Name} {Patronymic}";
        }
    }
}
