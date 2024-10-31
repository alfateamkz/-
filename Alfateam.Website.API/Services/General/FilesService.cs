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

        public void UpdateContentMedia(Content oldContent, Content newContent)
        {
            if (oldContent == null)
            {
                throw new Exception400("oldContent не должен быть равен null");
            }
            else if (newContent == null)
            {
                throw new Exception400("newContent не должен быть равен null");
            }

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
                    audio.AudioPath = TryUploadFile(item.Guid, FileType.Audio);
                }
                else if (item is ImageContentItem image)
                {
                    image.ImgPath = TryUploadFile(item.Guid, FileType.Image);
                }
                else if (item is ImageSliderContentItem slider)
                {
                    foreach (var img in slider.Images)
                    {
                        img.ImgPath = TryUploadFile(item.Guid, FileType.Image);
                    }
                }
                else if (item is VideoContentItem video)
                {
                    video.VideoPath = TryUploadFile(item.Guid, FileType.Video);
                }
            }
        }
        public void UploadContentMedia(Content content)
        {
            if(content == null)
            {
                throw new Exception400("content не должен быть равен null");
            }

            foreach (var item in content.Items)
            {
                if (item is AudioContentItem audio)
                {
                    audio.AudioPath = TryUploadFile(item.Guid, FileType.Audio);
                }
                else if (item is ImageContentItem image)
                {
                    image.ImgPath = TryUploadFile(item.Guid, FileType.Image);
                }
                else if (item is ImageSliderContentItem slider)
                {
                    foreach (var img in slider.Images)
                    {
                        img.ImgPath = TryUploadFile(item.Guid, FileType.Image);
                    }
                }
                else if (item is VideoContentItem video)
                {
                    video.VideoPath =  TryUploadFile(item.Guid, FileType.Video);
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
