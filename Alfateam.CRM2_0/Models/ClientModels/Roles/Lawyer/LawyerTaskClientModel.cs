using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.ClientModels.General;
using Alfateam.CRM2_0.Models.Enums.Roles.Lawyer;
using Alfateam.CRM2_0.Models.Roles.Lawyer;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Lawyer
{
	public class LawyerTaskClientModel : ClientModel<LawyerTask>
	{  
		/// <summary>
		/// Статус поручения
		/// </summary>
		public LawyerTaskStatus Status { get; set; }



		/// <summary>
		/// Какой документ нужно составить юристу
		/// </summary>
		public DocumentType DocumentType { get; set; }


		/// <summary>
		/// Вторая сторона
		/// </summary>
		public UserClientModel? SecondSide { get; set; }


		///// <summary>
		///// Заказ, с каким связано дело
		///// Может быть пустым
		///// </summary>
		//public Order? Order { get; set; }
		//public int? OrderId { get; set; }


		//TODO: Order client model


		/// <summary>
		/// Комментарий к поручению
		/// </summary>
		public string? Comment { get; set; }




		/// <summary>
		/// Кто создал поручение
		/// </summary>
		public UserClientModel CreatedBy { get; set; }




		/// <summary>
		/// Кто принял поручение
		/// По умолчанию null, потому что в компании может быть несколько юристов
		/// Сюда подставляется юрист, который быстрее всех подтвердил поручение
		/// </summary>
		public UserClientModel? AcceptedBy { get; set; }
	}
}
