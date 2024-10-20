using Alfateam.Website.API.Core;
using Alfateam.Website.API.Enums;
using Alfateam.Core.Exceptions;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.ContentItems;
using Alfateam.Core.Services;
using Alfateam.Core.Enums;

namespace Alfateam.Website.API.Services.General
{
    public class FilesService : AbsFilesService
    {
        public FilesService(IWebHostEnvironment appEnv, IHttpContextAccessor httpContextAccessor) : base(appEnv, httpContextAccessor)
        {
        }


        #region Upload content media

        public async Task UpdateContentMedia(Content oldContent, Content newContent)
        {
            var oldContentItems = GetAllContentItems(oldContent);
            var newContentItems = GetAllContentItems(oldContent);


            var deletedContentItems = new List<ContentItem>();
            var newCreatedContentItems = new List<ContentItem>();

            foreach (var oldItem in oldContentItems)
            {
                if (!newContentItems.Any(o => o.Guid == oldItem.Guid))
                {
                    deletedContentItems.Add(oldItem);
                }
            }

            foreach (var newItem in newContentItems)
            {
                if (!oldContentItems.Any(o => o.Guid == newItem.Guid))
                {
                    newCreatedContentItems.Add(newItem);
                }
            }


            foreach (var item in deletedContentItems)
            {
                if (item is AudioContentItem audio)
                {
                    File.Delete(Path.Combine(AppEnvironment.WebRootPath, audio.AudioPath));
                }
                else if (item is ImageContentItem image)
                {
                    File.Delete(Path.Combine(AppEnvironment.WebRootPath, image.ImgPath));
                }
                else if (item is ImageSliderContentItem slider)
                {
                    foreach (var img in slider.Images)
                    {
                        File.Delete(Path.Combine(AppEnvironment.WebRootPath, img.ImgPath));
                    }
                }
                else if (item is VideoContentItem video)
                {
                    File.Delete(Path.Combine(AppEnvironment.WebRootPath, video.VideoPath));
                }
            }

            foreach (var item in newCreatedContentItems)
            {
                if (item is AudioContentItem audio)
                {
                    audio.AudioPath = await TryUploadFile(item.Guid, FileType.Audio);
                }
                else if (item is ImageContentItem image)
                {
                    image.ImgPath = await TryUploadFile(item.Guid, FileType.Image);
                }
                else if (item is ImageSliderContentItem slider)
                {
                    foreach (var img in slider.Images)
                    {
                        img.ImgPath = await TryUploadFile(item.Guid, FileType.Image);
                    }
                }
                else if (item is VideoContentItem video)
                {
                    video.VideoPath = await TryUploadFile(item.Guid, FileType.Video);
                }
            }
        }
        public async Task UploadContentMedia(Content content)
        {
            foreach (var item in content.Items)
            {
                if (item is AudioContentItem audio)
                {
                    audio.AudioPath = await TryUploadFile(item.Guid, FileType.Audio);
                }
                else if (item is ImageContentItem image)
                {
                    image.ImgPath = await TryUploadFile(item.Guid, FileType.Image);
                }
                else if (item is ImageSliderContentItem slider)
                {
                    foreach (var img in slider.Images)
                    {
                        img.ImgPath = await TryUploadFile(item.Guid, FileType.Image);
                    }
                }
                else if (item is VideoContentItem video)
                {
                    video.VideoPath = await TryUploadFile(item.Guid, FileType.Video);
                }
            }
        }



        private IEnumerable<ContentItem> GetAllContentItems(Content content)
        {
            var contentItems = content.Items;

            foreach (var item in content.Items.Where(o => o is ImageSliderContentItem).Cast<ImageSliderContentItem>())
            {
                contentItems.AddRange(item.Images);
            }

            return contentItems;
        }


        #endregion

    }
}
