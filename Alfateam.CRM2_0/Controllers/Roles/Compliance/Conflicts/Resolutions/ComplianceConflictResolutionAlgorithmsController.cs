using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Compliance.Conflicts.Resolutions;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Compliance.Fraud;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Compliance.Conflicts.Resolutions;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Compliance.Fraud;
using Alfateam.CRM2_0.Models.EditModels.Roles.Compliance.Conflicts.Resolutions;
using Alfateam.CRM2_0.Models.EditModels.Roles.Compliance.Fraud;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.Roles.Compliance.Conflicts.Resolutions;
using Alfateam.CRM2_0.Models.Roles.Compliance.Fraud;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using ConflictEntity = Alfateam.CRM2_0.Models.Roles.Compliance.Conflicts.Conflict;

namespace Alfateam.CRM2_0.Controllers.Roles.Compliance.Conflicts.Resolutions
{
	[DepartmentFilter]
	[AccessActionFilter(roles: UserRole.Compliance)]
	public class ComplianceConflictResolutionAlgorithmsController : AbsController
	{
		public ComplianceConflictResolutionAlgorithmsController(ControllerParams @params) : base(@params)
		{
		}


		#region Алгоритмы

		[HttpGet, Route("GetAlgorithms")]
		public async Task<RequestResult> GetAlgorithms(int offset, int count = 20)
		{
			var algorithms = DB.ConflictResolutionAlgorithms.Include(o => o.StartBlock).ThenInclude(o => o.Nodes)
														    .Where(o => o.ComplianceDepartmentId == this.DepartmentId)
															.Skip(offset)
															.Take(count)
															.ToList();

			ClearDeletedAlgorithmsBlocks(algorithms);

			var clientModels = ConflictResolutionAlgorithmClientModel.CreateItems(algorithms);
			return RequestResult<IEnumerable<ConflictResolutionAlgorithmClientModel>>.AsSuccess(clientModels);
		}

		[HttpGet, Route("GetAlgorithm")]
		public async Task<RequestResult> GetAlgorithm(int id)
		{
			var algorithm = DB.ConflictResolutionAlgorithms.Include(o => o.StartBlock).ThenInclude(o => o.Nodes)
														   .FirstOrDefault(o => o.Id == id && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseAlgorithm(algorithm),
				() =>
				{
					ClearDeletedAlgorithmBlocks(algorithm);

					var model = ConflictResolutionAlgorithmClientModel.Create(algorithm);
					return RequestResult<ConflictResolutionAlgorithmClientModel>.AsSuccess(model);
				}
			});
		}




		[HttpPost, Route("CreateAlgorithm")]
		public async Task<RequestResult> CreateAlgorithm(ConflictResolutionAlgorithmCreateModel model)
		{
			return TryCreateModel(DB.ConflictResolutionAlgorithms, model, (item) =>
			{
				item.ComplianceDepartmentId = (int)this.DepartmentId;
				return RequestResult<ConflictResolutionAlgorithm>.AsSuccess(item);
			});
		}

		[HttpPut, Route("UpdateAlgorithm")]
		public async Task<RequestResult> UpdateAlgorithm(ConflictResolutionAlgorithmEditModel model)
		{
			var algorithm = DB.ConflictResolutionAlgorithms.FirstOrDefault(o => o.Id == id && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseAlgorithm(algorithm),
				() => TryUpdateModel(DB.ConflictResolutionAlgorithms, algorithm, model)
			});
		}

		[HttpDelete, Route("DeleteAlgorithm")]
		public async Task<RequestResult> DeleteAlgorithm(int id)
		{
			var algorithm = DB.ConflictResolutionAlgorithms.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
			
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseAlgorithm(algorithm),
				() => DeleteModel(DB.ConflictResolutionAlgorithms, algorithm)
			});
		}

		#endregion

		#region Блоки алгоритмов


		[HttpPost, Route("CreateAlgorithmBlock")]
		public async Task<RequestResult> CreateAlgorithmBlock(int algorithmId, int parentBlockId, ConflictResolutionAlgorithmBlockCreateModel model)
		{
			var algorithm = DB.ConflictResolutionAlgorithms.Include(o => o.StartBlock).ThenInclude(o => o.Nodes)
												   .FirstOrDefault(o => o.Id == id && !o.IsDeleted);

			var parentBlock = DB.ConflictResolutionAlgorithmBlocks.FirstOrDefault(o => o.Id == parentBlockId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseAlgorithmAndBlock(algorithm,block),
				() => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения полей"),
				() =>
				{
					var block = model.Create();
					parentBlock.Nodes.Add(block);

					UpdateModel(DB.ConflictResolutionAlgorithmBlocks, parentBlock);
					return RequestResult<ConflictResolutionAlgorithmBlock>.AsSuccess(block);
				}
			});
		}

		[HttpPut, Route("UpdateAlgorithmBlock")]
		public async Task<RequestResult> UpdateAlgorithmBlock(int algorithmId,ConflictResolutionAlgorithmBlockEditModel model)
		{
			var algorithm = DB.ConflictResolutionAlgorithms.Include(o => o.StartBlock).ThenInclude(o => o.Nodes)
														   .FirstOrDefault(o => o.Id == id && !o.IsDeleted);

			var block = DB.ConflictResolutionAlgorithmBlocks.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseAlgorithmAndBlock(algorithm,block),
				() => TryUpdateModel(DB.ConflictResolutionAlgorithmBlocks, block, model)
			});
		}

		[HttpDelete, Route("DeleteAlgorithmBlock")]
		public async Task<RequestResult> DeleteAlgorithmBlock(int algorithmId, int blockId)
		{
			var algorithm = DB.ConflictResolutionAlgorithms.Include(o => o.StartBlock).ThenInclude(o => o.Nodes)
														   .FirstOrDefault(o => o.Id == algorithmId && !o.IsDeleted);

			var block = DB.ConflictResolutionAlgorithmBlocks.FirstOrDefault(o => o.Id == blockId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseAlgorithmAndBlock(algorithm,block),
				() => RequestResult.FromBoolean(algorithm.StartBlockId != blockId, 400, "Нельзя удалить стартовый блок алгоритма"),
				() => DeleteModel(DB.ConflictResolutionAlgorithmBlocks, block)
			});
		}

		#endregion








		#region Private check methods

		private RequestResult CheckBaseAlgorithm(ConflictResolutionAlgorithm algorithm)
		{
			return TryFinishAllRequestes(new[]
			{
				() => RequestResult.FromBoolean(algorithm != null,404,"Алгоритм урегулирования конфликтов с данным id не найден"),
				() => RequestResult.FromBoolean(algorithm.ComplianceDepartmentId == this.DepartmentId,403,"Нет доступа к данному алгоритму урегулирования конфликтов"),
			});
		}
		private RequestResult CheckBaseAlgorithmAndBlock(ConflictResolutionAlgorithm algorithm, ConflictResolutionAlgorithmBlock block)
		{
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseAlgorithm(algorithm),
				() => RequestResult.FromBoolean(block != null,404,"Блок алгоритма с данным id не найден"),
				() => RequestResult.FromBoolean(IsBlockPartOfAlgorithm(algorithm,block),403,"Блок алгоритма не принадлежит текущему алгоритму"),
			});
		}


		#endregion

		#region IsBlockPartOfAlgorithm

		private bool IsBlockPartOfAlgorithm(ConflictResolutionAlgorithm algorithm, ConflictResolutionAlgorithmBlock block)
		{
			var blocks = GetAllAlgorithmBlocks(algorithm);
			return blocks.Any(o => o.Id == block.Id);
		}

		private IEnumerable<ConflictResolutionAlgorithmBlock> GetAllAlgorithmBlocks(ConflictResolutionAlgorithm algorithm)
		{
			return GetAllAlgorithmSubblocks(algorithm.StartBlock);
		}

		private IEnumerable<ConflictResolutionAlgorithmBlock> GetAllAlgorithmSubblocks(ConflictResolutionAlgorithmBlock block)
		{
			var blocks = new List<ConflictResolutionAlgorithmBlock>() { block };

			foreach (var subblock in block.Nodes)
			{
				blocks.AddRange(GetAllAlgorithmSubblocks(subblock));
			}

			return blocks;
		}

		#endregion

		#region Private other methods

		private void ClearDeletedAlgorithmsBlocks(IEnumerable<ConflictResolutionAlgorithm> algorithms)
		{
			foreach(var algorithm in algorithms)
			{
				ClearDeletedAlgorithmBlocks(algorithm);
			}
		}
		private void ClearDeletedAlgorithmBlocks(ConflictResolutionAlgorithm algorithm)
		{
			ClearDeletedAlgorithmBlocksRecursively(algorithm.StartBlock);
		}
		private void ClearDeletedAlgorithmBlocksRecursively(ConflictResolutionAlgorithmBlock block)
		{
			block.Nodes = block.Nodes.Where(o => !o.IsDeleted).ToList();
			foreach (var subblock in block.Nodes)
			{
				ClearDeletedAlgorithmBlocksRecursively(subblock);
			}
		}

		#endregion
	}
}
