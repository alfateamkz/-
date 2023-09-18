using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Sales.Scripting;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Sales.Scripting;
using Alfateam.CRM2_0.Models.EditModels.Roles.Sales.Scripting;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.Roles.Sales.Scripting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Alfateam.CRM2_0.Controllers.Roles.Sales
{

	[DepartmentFilter]
	[AccessActionFilter(roles: UserRole.Sales)]
	public class SalesScriptingController : AbsController
    {
		//TODO: проверка, есть ли стартовый блок или нет, тоже в конфликтах
		public SalesScriptingController(ControllerParams @params) : base(@params)
        {
        }

		#region Скрипты продаж

		[HttpGet, Route("GetSalesScripts")]
		public async Task<RequestResult> GetSalesScripts(int offset, int count = 20)
		{
			var scripts = DB.SalesScripts.Include(o => o.StartBlock).ThenInclude(o => o.Nodes)
											.Where(o => o.SalesDepartmentId == this.DepartmentId)
											.Skip(offset)
											.Take(count)
											.ToList();

			ClearDeletedSalesScriptsBlocks(scripts);

			var clientModels = SalesScriptClientModel.CreateItems(scripts);
			return RequestResult<IEnumerable<SalesScriptClientModel>>.AsSuccess(clientModels);
		}

		[HttpGet, Route("GetSalesScript")]
		public async Task<RequestResult> GetSalesScript(int id)
		{
			var script = DB.SalesScripts.Include(o => o.StartBlock).ThenInclude(o => o.Nodes)
										.FirstOrDefault(o => o.Id == id && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseSalesScript(script),
				() =>
				{
					ClearDeletedSalesScriptBlocks(script);

					var model = SalesScriptClientModel.Create(script);
					return RequestResult<SalesScriptClientModel>.AsSuccess(model);
				}
			});
		}




		[HttpPost, Route("CreateSalesScript")]
		public async Task<RequestResult> CreateSalesScript(SalesScriptCreateModel model)
		{
			return TryCreateModel(DB.SalesScripts, model, (item) =>
			{
				item.SalesDepartmentId = (int)this.DepartmentId;
				return RequestResult<SalesScript>.AsSuccess(item);
			});
		}

		[HttpPut, Route("UpdateSalesScript")]
		public async Task<RequestResult> UpdateSalesScript(SalesScriptEditModel model)
		{
			var script = DB.SalesScripts.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseSalesScript(script),
				() => TryUpdateModel(DB.SalesScripts, script, model)
			});
		}

		[HttpDelete, Route("DeleteSalesScript")]
		public async Task<RequestResult> DeleteSalesScript(int id)
		{
			var script = DB.SalesScripts.FirstOrDefault(o => o.Id == id && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseSalesScript(script),
				() => DeleteModel(DB.SalesScripts, script)
			});
		}

		#endregion

		#region Блоки скриптов продаж


		[HttpPost, Route("CreateSalesScriptBlock")]
		public async Task<RequestResult> CreateSalesScriptBlock(int scriptId, int parentBlockId, SalesScriptBlockCreateModel model)
		{
			var script = DB.SalesScripts.Include(o => o.StartBlock).ThenInclude(o => o.Nodes)
									    .FirstOrDefault(o => o.Id == scriptId && !o.IsDeleted);

			var parentBlock = DB.SalesScriptBlocks.FirstOrDefault(o => o.Id == parentBlockId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseSalesScriptAndBlock(script,parentBlock),
				() => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения полей"),
				() =>
				{
					var block = model.Create();
					parentBlock.Nodes.Add(block);

					UpdateModel(DB.SalesScriptBlocks, parentBlock);
					return RequestResult<SalesScriptBlock>.AsSuccess(block);
				}
			});
		}

		[HttpPut, Route("UpdateSalesScriptBlock")]
		public async Task<RequestResult> UpdateSalesScriptBlock(int scriptId, SalesScriptBlockEditModel model)
		{
			var script = DB.SalesScripts.Include(o => o.StartBlock).ThenInclude(o => o.Nodes)
									    .FirstOrDefault(o => o.Id == scriptId && !o.IsDeleted);

			var block = DB.SalesScriptBlocks.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseSalesScriptAndBlock(script,block),
				() => TryUpdateModel(DB.SalesScriptBlocks, block, model)
			});
		}

		[HttpDelete, Route("DeleteSalesScriptBlock")]
		public async Task<RequestResult> DeleteSalesScriptBlock(int scriptId, int blockId)
		{
			var script = DB.SalesScripts.Include(o => o.StartBlock).ThenInclude(o => o.Nodes)
									    .FirstOrDefault(o => o.Id == scriptId && !o.IsDeleted);

			var block = DB.SalesScriptBlocks.FirstOrDefault(o => o.Id == blockId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseSalesScriptAndBlock(script,block),
				() => RequestResult.FromBoolean(script.StartBlockId != blockId, 400, "Нельзя удалить стартовый блок скрипта продаж"),
				() => DeleteModel(DB.SalesScriptBlocks, block)
			});
		}

		#endregion








		#region Private check methods

		private RequestResult CheckBaseSalesScript(SalesScript script)
		{
			return TryFinishAllRequestes(new[]
			{
				() => RequestResult.FromBoolean(script != null,404,"Скрипт продаж с данным id не найден"),
				() => RequestResult.FromBoolean(script.SalesDepartmentId == this.DepartmentId,403,"Нет доступа к данному скрипту продаж"),
			});
		}
		private RequestResult CheckBaseSalesScriptAndBlock(SalesScript script, SalesScriptBlock block)
		{
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseSalesScript(script),
				() => RequestResult.FromBoolean(block != null,404,"Блок скрипта продаж с данным id не найден"),
				() => RequestResult.FromBoolean(IsBlockPartOfSalesScript(script,block),403,"Блок не принадлежит текущему скрипту продаж"),
			});
		}


		#endregion

		#region IsBlockPartOfSalesScript

		private bool IsBlockPartOfSalesScript(SalesScript script, SalesScriptBlock block)
		{
			var blocks = GetAllSalesScriptBlocks(script);
			return blocks.Any(o => o.Id == block.Id);
		}

		private IEnumerable<SalesScriptBlock> GetAllSalesScriptBlocks(SalesScript script)
		{
			return GetAllSalesScriptSubblocks(script.StartBlock);
		}

		private IEnumerable<SalesScriptBlock> GetAllSalesScriptSubblocks(SalesScriptBlock block)
		{
			var blocks = new List<SalesScriptBlock>() { block };

			foreach (var subblock in block.Nodes)
			{
				blocks.AddRange(GetAllSalesScriptSubblocks(subblock));
			}

			return blocks;
		}

		#endregion

		#region Private other methods

		private void ClearDeletedSalesScriptsBlocks(IEnumerable<SalesScript> scripts)
		{
			foreach (var script in scripts)
			{
				ClearDeletedSalesScriptBlocks(script);
			}
		}
		private void ClearDeletedSalesScriptBlocks(SalesScript script)
		{
			ClearDeletedSalesScriptBlocksRecursively(script.StartBlock);
		}
		private void ClearDeletedSalesScriptBlocksRecursively(SalesScriptBlock block)
		{
			block.Nodes = block.Nodes.Where(o => !o.IsDeleted).ToList();
			foreach (var subblock in block.Nodes)
			{
				ClearDeletedSalesScriptBlocksRecursively(subblock);
			}
		}

		#endregion
	}
}
