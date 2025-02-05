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

        public Content UpdateContentMedia(Content oldContent, Content newContent)
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
            var newContentItems = GetAllContentItems(newContent);

            var deletedContentItems = GetDeletedContentItems(oldContentItems, newContentItems);
            var newCreatedContentItems = GetNewCreatedContentItems(oldContentItems, newContentItems);

            foreach (var newItem in newContentItems)
            {
                var old = oldContentItems.FirstOrDefault(o => o.Guid == newItem.Guid);
                if (old != null)
                {
                    //newItem.ContentId = old.ContentId;
                    if (old is AudioContentItem audio)
                    {
                        (newItem as AudioContentItem).AudioPath = audio.AudioPath;
                    }
                    else if (old is ImageContentItem image)
                    {
                        (newItem as ImageContentItem).ImgPath = image.ImgPath;
                    }
                    //else if (item is ImageSliderContentItem slider)
                    //{
                    //    foreach (var img in slider.Images)
                    //    {
                    //        img.ImgPath = TryUploadFile(item.Guid, FileType.Image);
                    //    }
                    //}
                    else if (old is VideoContentItem video)
                    {
                        (newItem as VideoContentItem).VideoPath = video.VideoPath;
                    }
                }
                else
                {

                }
            }

            DeleteDeletedItemFiles(deletedContentItems);
            UploadNewCreatedContentItemFiles(newCreatedContentItems);

            return newContent;
        }
        public void UploadContentMedia(Content content)
        {
            if (content == null)
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
                        img.ImgPath = TryUploadFile(img.Guid, FileType.Image);
                    }
                }
                else if (item is VideoContentItem video)
                {
                    video.VideoPath = TryUploadFile(item.Guid, FileType.Video);
                }
            }
        }


        #region UpdateContentMedia Private methods

        private IEnumerable<ContentItem> GetDeletedContentItems(IEnumerable<ContentItem> oldContentItems, IEnumerable<ContentItem> newContentItems)
        {
            var deletedContentItems = new List<ContentItem>();

            foreach (var oldItem in oldContentItems)
            {
                if (!newContentItems.Any(o => o.Guid == oldItem.Guid))
                {
                    deletedContentItems.Add(oldItem);
                }
            }

            return deletedContentItems;
        }
        private IEnumerable<ContentItem> GetNewCreatedContentItems(IEnumerable<ContentItem> oldContentItems, IEnumerable<ContentItem> newContentItems)
        {
            var newCreatedContentItems = new List<ContentItem>();

            foreach (var newItem in newContentItems)
            {
                var old = oldContentItems.FirstOrDefault(o => o.Guid == newItem.Guid);
                if (old == null)
                {
                    newCreatedContentItems.Add(newItem);
                } 
            }

            return newCreatedContentItems;
        }
        private void DeleteDeletedItemFiles(IEnumerable<ContentItem> deletedContentItems)
        {
            foreach (var item in deletedContentItems)
            {
                if (item is AudioContentItem audio && !string.IsNullOrEmpty(audio.AudioPath))
                {
                    var path = Path.Combine(AppEnvironment.WebRootPath, audio.AudioPath);
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
                else if (item is ImageContentItem image && !string.IsNullOrEmpty(image.ImgPath))
                {
                    var path = Path.Combine(AppEnvironment.WebRootPath, image.ImgPath);
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
                else if (item is VideoContentItem video && !string.IsNullOrEmpty(video.VideoPath))
                {
                    var path = Path.Combine(AppEnvironment.WebRootPath, video.VideoPath);
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
            }
        }
        private void UploadNewCreatedContentItemFiles(IEnumerable<ContentItem> newCreatedContentItems)
        {
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

        #endregion

        private IEnumerable<ContentItem> GetAllContentItems(Content content)
        {
            var contentItems = new List<ContentItem>(content.Items);

            foreach (var item in content.Items.Where(o => o is ImageSliderContentItem).Cast<ImageSliderContentItem>())
            {
                contentItems.AddRange(item.Images);
            }

            return contentItems;
        }


        #endregion

    }
}
