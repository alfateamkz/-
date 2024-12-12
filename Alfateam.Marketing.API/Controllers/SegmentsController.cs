using Alfateam.Core;
using Alfateam.Marketing.API.Abstractions;
using Alfateam.Marketing.API.Models;
using Alfateam.Marketing.API.Models.DTO;
using Alfateam.Marketing.API.Models.DTO.Segments;
using Alfateam.Marketing.API.Models.SearchFilters;
using Alfateam.Marketing.Models;
using Alfateam.Marketing.Models.Segments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Marketing.API.Controllers
{
    public class SegmentsController : AbsController
    {
        public SegmentsController(ControllerParams @params) : base(@params)
        {
        }



        #region Сегменты

        [HttpGet, Route("GetSegments")]
        public async Task<ItemsWithTotalCount<SegmentDTO>> GetSegments(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<Segment, SegmentDTO>(GetAvailableSegments(), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    condition &= entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return condition;
            });
        }

        [HttpGet, Route("GetSegment")]
        public async Task<SegmentDTO> GetSegment(int id)
        {
            return (SegmentDTO)DBService.TryGetOne(GetAvailableSegments(), id, new SegmentDTO());
        }





        [HttpPost, Route("CreateSegment")]
        public async Task<SegmentDTO> CreateSegment(SegmentDTO model)
        {
            return (SegmentDTO)DBService.TryCreateEntity(DB.Segments, model, callback: (entity) =>
            {
                entity.BusinessCompanyId = (int)this.CompanyId;
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление сегмента", $"Добавлен сегмент {entity.Title}");
            });
        }

        [HttpPut, Route("UpdateSegment")]
        public async Task<SegmentDTO> UpdateSegment(SegmentDTO model)
        {
            var item = GetAvailableSegments().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (SegmentDTO)DBService.TryUpdateEntity(DB.Segments, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование сегмента", $"Отредактирован сегмент с id={item.Id}");
            });
        }




        [HttpDelete, Route("DeleteSegment")]
        public async Task DeleteSegment(int id)
        {
            var item = GetAvailableSegments().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.Segments, item);

            this.AddHistoryAction("Удаление сегмента", $"Удален сегмент {item.Title} с id={id}");
        }





        #endregion









        #region Private methods

        private IEnumerable<Segment> GetAvailableSegments()
        {
            //TODO: Segment includes and global
            return DB.Segments.Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }

        #endregion
    }
}
