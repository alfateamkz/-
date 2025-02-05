using Alfateam.AdminPanelGeneral.API.Abstractions;
using Alfateam.AdminPanelGeneral.API.Models;
using Alfateam.Core;
using Alfateam.Core.Enums;
using Alfateam.Telephony.API.Models.DTO.General.AudioRecords.Internal;
using Alfateam.Telephony.Models.General.AudioRecords.Internal;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.AdminPanelGeneral.API.Controllers.Products.Telephony
{
    [Route("Products/Telephony/[controller]")]
    public class TelephonyReadingVoicesController : AbsController
    {
        public TelephonyReadingVoicesController(ControllerParams @params) : base(@params)
        {
        }

        #region Голоса для озвучки начиток

        [HttpGet, Route("GetReadingVoices")]
        public async Task<ItemsWithTotalCount<ReadingVoiceDTO>> GetReadingVoices([FromQuery] SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<ReadingVoice, ReadingVoiceDTO>(GetAvailableReadingVoices(), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;

                if (!string.IsNullOrEmpty(filter.Query))
                {
                    condition &= entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }

                return condition;
            });
        }

        [HttpGet, Route("GetReadingVoice")]
        public async Task<ReadingVoiceDTO> GetReadingVoice(int id)
        {
            return (ReadingVoiceDTO)DBService.TryGetOne(GetAvailableReadingVoices(), id, new ReadingVoiceDTO());
        }








        [HttpPost, Route("CreateReadingVoice")]
        public async Task<ReadingVoiceDTO> CreateReadingVoice([FromForm(Name ="model")]ReadingVoiceDTO model, IFormFile file)
        {
            return (ReadingVoiceDTO)DBService.TryCreateEntity(TelephonyDb.ReadingVoices, model, async (entity) =>
            {
                entity.ReadingProcessorFilepath = FilesService.TryUploadFile(file, FileType.Any);
            });
        }

        [HttpPut, Route("UpdateReadingVoice")]
        public async Task<ReadingVoiceDTO> UpdateReadingVoice(ReadingVoiceDTO model, IFormFile file = null)
        {
            var group = DBService.TryGetOne(GetAvailableReadingVoices(), model.Id);
            return (ReadingVoiceDTO)DBService.TryUpdateEntity(TelephonyDb.ReadingVoices, model, group, (entity) =>
            {
                if(file != null)
                {
                    entity.ReadingProcessorFilepath = FilesService.TryUploadFile(file, FileType.Any);
                }
            });
        }

        [HttpDelete, Route("DeleteReadingVoice")]
        public async Task DeleteReadingVoice(int id)
        {
            var group = DBService.TryGetOne(GetAvailableReadingVoices(), id);
            DBService.TryDeleteEntity(TelephonyDb.ReadingVoices, group);
        }

        #endregion









        #region Private methods
        private IEnumerable<ReadingVoice> GetAvailableReadingVoices()
        {
            return TelephonyDb.ReadingVoices.Where(o => !o.IsDeleted);
        }

        #endregion
    }
}
