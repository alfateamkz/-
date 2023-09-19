using Alfateam.CRM2_0.Controllers.Communication.Messenger;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Helpers;
using Alfateam.DB;
using Microsoft.AspNetCore.SignalR;

namespace Alfateam.CRM2_0.Abstractions
{

	public class AbsHubConnection
	{
		public string UserSessId { set; get; }
		public string ConnectionID { set; get; }
	}

	public abstract class AbsHub : Hub
	{
		public AbsHub(ControllerParams @params)
		{
			DB = @params.DB;
			AppEnvironment = @params.AppEnvironment;
		}

		protected static List<AbsHubConnection> UserConnections { get; } = new List<AbsHubConnection>();

		protected CRMDBContext DB { get; set; }
		protected IWebHostEnvironment AppEnvironment { get; set; }


		protected string SessID => UserConnections.FirstOrDefault(o => o.ConnectionID == Context.ConnectionId).UserSessId;





		public override Task OnConnectedAsync()
		{
			UserConnections.Add(new AbsHubConnection
			{
				UserSessId = Context.GetHttpContext().Request.Query["sessId"],
				ConnectionID = Context.ConnectionId
			});

			return base.OnConnectedAsync();
		}
		public override Task OnDisconnectedAsync(Exception? exception)
		{
			var item = UserConnections.FirstOrDefault(o => o.ConnectionID == Context.ConnectionId);
			if (item != null)
			{
				UserConnections.Remove(item);
			}

			return base.OnDisconnectedAsync(exception);
		}




		protected RequestResult BaseCheckSession()
		{
			var session = SessionUserHelper.GetCurrentSession(DB, SessID);

			var checkSessionResult = SessionUserHelper.CheckSessionAsRequestResult(session);
			if (!checkSessionResult.Success)
			{
				return checkSessionResult;
			}

			return RequestResult.AsSuccess();
		}



		protected async Task TryFinishAllRequestes(string method,Func<RequestResult>[] funcs)
		{
			RequestResult successResult = null;

			foreach (var func in funcs)
			{
				var res = func.Invoke();
				if (!res.Success)
				{
					await Clients.Clients(Context.ConnectionId).SendAsync(method, res);
					return;
				}
				successResult = res;
			}

			await Clients.Clients(Context.ConnectionId).SendAsync(method, successResult);
		}
	}


}
