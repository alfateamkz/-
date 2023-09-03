using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.ClientModels.Content.Videos;
using Alfateam.CRM2_0.Models.Content.Feedback;
using Alfateam.CRM2_0.Models.Content.Videos;
using Alfateam.CRM2_0.Models.EditModels.Content.Videos;
using Alfateam.CRM2_0.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel;

namespace Alfateam.CRM2_0.Controllers.Content
{

    public class ContentVideosController : AbsController
    {
        public ContentVideosController(ControllerParams @params) : base(@params)
        {
        }

        #region Видео

        #region CRUD

        [HttpGet,Route("GetVideos")]
        public async Task<RequestResult> GetVideos(int offset,int count = 20)
        {
            return GetAvailableMany<Video, VideoClientModel>(DB.Videos, offset, count);
        }
        [HttpGet, Route("GetEditableVideos")]
        [AccessActionFilter(roles: UserRole.ContentMaker)]
        public async Task<RequestResult> GetEditableVideos(int offset, int count = 20)
        {
            return GetAvailableEditableMany<Video, VideoClientModel>(DB.Videos, offset, count);
        }

        [HttpGet, Route("GetVideo")]
        [AccessActionFilter(roles: UserRole.ContentMaker)]
        public async Task<RequestResult> GetVideo(int id)
        {
            return TryGetContentModel(DB.Videos, id);
        }

        //TODO: комменты, загрузка видео и превью



        [HttpPut, Route("UpdateVideo")]
        [AccessActionFilter(roles: UserRole.ContentMaker)]
        public async Task<RequestResult> UpdateVideo(VideoEditModel model)
        {
            return TryUpdateContentModel(DB.Videos, model);
        }


        [HttpDelete, Route("DeleteVideo")]
        [AccessActionFilter(roles: UserRole.ContentMaker)]
        public async Task<RequestResult> DeleteVideo(int id)
        {
            return TryDeleteContentModel(DB.Videos, id);
        }

        #endregion

        #region Interaction


        [HttpGet, Route("GetComments")]
        public async Task<RequestResult> GetComments(int videoId,int offset, int count = 20)
        {
            var video = DB.Videos.Include(o => o.CommentsList).ThenInclude(o => o.CreatedBy)
                                 .Include(o => o.CommentsList).ThenInclude(o => o.Attachments)
                                 .Include(o => o.CommentsList).ThenInclude(o => o.Subcomments).ThenInclude(o => o.CreatedBy)
                                 .Include(o => o.CommentsList).ThenInclude(o => o.Subcomments).ThenInclude(o => o.Attachments)
                                 .FirstOrDefault(o => o.Id == videoId);

            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(video != null, 404, "Сущность с данным id не найдена"),
                () =>
                {
                    var comments = video.CommentsList.Skip(offset).Take(count);
                    return RequestResult<IEnumerable<Comment>>.AsSuccess(comments);
                }
            });
        }
 
        [HttpGet, Route("GetRates")]
        public async Task<RequestResult> GetRates(int videoId, bool isLike, int offset, int count = 20)
        {
            Video video = null;

            if (isLike) video = DB.Videos.Include(o => o.LikesList).FirstOrDefault(o => o.Id == videoId);
            else video = DB.Videos.Include(o => o.DislikesList).FirstOrDefault(o => o.Id == videoId);

            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(video != null, 404, "Сущность с данным id не найдена"),
                () =>
                {
                    IEnumerable<FeedbackEntry> entries;
                    if(isLike) entries = video.LikesList;
                    else entries = video.DislikesList;

                    var entriesChunk = entries.Skip(offset).Take(count);
                    return RequestResult<IEnumerable<FeedbackEntry>>.AsSuccess(entriesChunk);
                }
            });
        }






        [HttpPut, Route("AddWatch")]
        public async Task<RequestResult> AddWatch(int id)
        {
            var video = DB.Videos.FirstOrDefault(o => o.Id == id);

            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(video != null, 404, "Сущность с данным id не найдена"),
                () =>
                {
                    video.Watches++;

                    DB.Videos.Update(video);
                    DB.SaveChanges();
                    return RequestResult.AsSuccess();
                }
            });
        }

        [HttpPut, Route("ToggleVideoRate")]
        public async Task<RequestResult> ToggleVideoRate(int id, bool isLike)
        {
            var user = GetAuthorizedUser();
            Video video = null;

            if (isLike) video = DB.Videos.Include(o => o.LikesList).FirstOrDefault(o => o.Id == id);
            else video = DB.Videos.Include(o => o.DislikesList).FirstOrDefault(o => o.Id == id);

            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(video != null, 404, "Сущность с данным id не найдена"),
                () =>
                {
                    //TODO: баг с лайками и дизлайками
                    bool res = false;
                    if (isLike)
                    {
                        res = FeedbackEntry.Toggle(video.LikesList,user.Id);
                        if(res) video.Likes++;
                        else video.Likes--;
                    }
                    else
                    {
                        res = FeedbackEntry.Toggle(video.DislikesList,user.Id);
                        if(res) video.Dislikes++;
                        else video.Dislikes--;

                    }                   

                    DB.Videos.Update(video);
                    DB.SaveChanges();
                    return RequestResult<bool>.AsSuccess(res);
                }
            });
        }





        [HttpPut, Route("ToggleCommentLike")]
        public async Task<RequestResult> ToggleCommentLike(int id)
        {
            var user = GetAuthorizedUser();
            var comment = DB.Comments.FirstOrDefault(o => o.Id == id);

            //TODO: проверка бизнеса и прав доступа

            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(comment != null, 404, "Сущность с данным id не найдена"),
                () =>
                {
                    bool res = FeedbackEntry.Toggle(comment.LikesList, user.Id);
                    if(res) comment.Likes++;
                    else comment.Likes--;

                    DB.Comments.Update(comment);
                    DB.SaveChanges();
                    return RequestResult<bool>.AsSuccess(res);
                }
            });
        }


        //TODO: comments crud



        #endregion


        #endregion









        #region Категории видео

        [HttpGet, Route("GetVideoCategories")]
        public async Task<RequestResult> GetVideoCategories(int offset, int count = 20)
        {
            return GetAvailableMany<VideoCategory,VideoCategoryClientModel>(DB.VideoCategories, offset, count);
        }

        [HttpGet, Route("GetEditableVideoCategories")]
        [AccessActionFilter(roles: UserRole.ContentMaker)]
        public async Task<RequestResult> GetEditableVideoCategories(int offset, int count = 20)
        {
            return GetAvailableEditableMany<VideoCategory, VideoCategoryClientModel>(DB.VideoCategories, offset, count);
        }

        [HttpGet, Route("GetVideoCategory")]
        [AccessActionFilter(roles: UserRole.ContentMaker)]
        public async Task<RequestResult> GetVideoCategory(int id)
        {
            return TryGetContentModel(DB.VideoCategories,id);
        }




        [HttpPost, Route("CreateVideoCategory")]
        [AccessActionFilter(roles: UserRole.ContentMaker)]
        public async Task<RequestResult> CreateVideoCategory(VideoCategoryEditModel model)
        {
            return TryCreateContentModel("Videos", model);
        }



        [HttpPut, Route("UpdateVideoCategory")]
        [AccessActionFilter(roles: UserRole.ContentMaker)]
        public async Task<RequestResult> UpdateVideoCategory(VideoCategoryEditModel model)
        {
            return TryUpdateContentModel(DB.VideoCategories, model);
        }


        [HttpDelete, Route("DeleteVideoCategory")]
        [AccessActionFilter(roles: UserRole.ContentMaker)]
        public async Task<RequestResult> DeleteVideoCategory(int id)
        {
            return TryDeleteContentModel(DB.VideoCategories, id);
        }

        #endregion


 
    }
}
