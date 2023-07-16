using Alfateam.Database.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Models.ForBusiness
{
	public class OutstaffEmployeeInfo : BaseModel
	{
		public string FIO { get; set; }
		public string Position { get; set; }
		public double HourlyRate { get; set; }
        public double HourlyRateInternal { get; set; }
        public string Address { get; set; }
		public string? Comment { get; set; }
		public string? CVPath { get; set; }
	}
}
