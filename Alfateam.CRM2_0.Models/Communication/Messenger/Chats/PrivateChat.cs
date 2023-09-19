using Alfateam.CRM2_0.Models.Abstractions.Communication.Messenger;
using Alfateam.CRM2_0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Communication.Messenger.Chats
{
	/// <summary>
	/// Модель чата между двумя людьми 
	/// </summary>
	public class PrivateChat : Chat
    {
        public User CreatedBy { get; set; }
		public int CreatedById { get; set; }

		public User CreatedWith { get; set; }
		public int CreatedWithId { get; set; }

		public override bool HasUserAccess(int userId)
		{
			return CreatedById == userId || CreatedWithId == userId;
		}
	}
}
