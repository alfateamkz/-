using Alfateam.Marketing.Autoposting.Lib.Abstractions;
using Alfateam.Marketing.Autoposting.Lib.Models.CrtUpdDTO.Comments;
using Alfateam.Marketing.Autoposting.Lib.Models.Results.Comments;
using Alfateam.Marketing.Autoposting.Lib.Models.Results.Posts;
using Alfateam.Marketing.Autoposting.Lib.Models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.Marketing.Autoposting.Lib.Models.Posts;
using Alfateam.Marketing.Autoposting.Lib.Models.Comments;
using Alfateam.Marketing.Autoposting.Lib.Helpers;
using RestSharp;
using Newtonsoft.Json;
using Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Login;
using Alfateam.Marketing.Autoposting.Lib.Enums;
using Alfateam.Marketing.Autoposting.Lib.Enums.Posts;
using Alfateam.Marketing.Autoposting.Lib.Enums.Comments;
using Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Refresh;
using Alfateam.Core.Extensions;
using Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Error;
using Alfateam.Marketing.Autoposting.Lib.Exceptions;
using Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Comment.GetComments;
using Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Comment;
using Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Success;
using Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Post;
using Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Post.GetPosts;
using Alfateam.Marketing.Autoposting.Lib.Models;
using Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Profile;
using Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.FileUpload;
using Alfateam.Marketing.Autoposting.Lib.Abstractions.Posts;
using Alfateam.Marketing.Autoposting.Lib.Models.CrtUpdDTO.Posts.Blog;
using Alfateam.Marketing.Autoposting.Lib.Models.CrtUpdDTO.Posts.Social;
using Alfateam.Marketing.Autoposting.Lib.Models.CrtUpdDTO.Posts.Blog.Blocks;
using Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Post.BlocksData;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Net.Mime.MediaTypeNames;
using Alfateam.Marketing.Autoposting.Lib.Enums.Posts.Blocks;
using Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Post.BlocksData.Audio;

namespace Alfateam.Marketing.Autoposting.Lib.Resources
{
    public class VC_RUAutoposter : AbsAutoposter
    {
        public const string HOST = "https://api.vc.ru";

      

        public string Email { get; private set; }
        protected string Password { get; set; }



        protected string AccessToken { get; set; }
        protected DateTime AccessTokenExpDate { get; set; }
        protected string RefreshToken { get; set; }
        protected DateTime RefreshTokenExpDate { get; set; }
        protected int AuthorizedUserId { get; set; }

        public VC_RUAutoposter(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }

        public override async Task<AuthResult> Auth()
        {
            string url = HOST + "/v3.4/auth/email/login";
            var response = await RequestsHelper.MakeRequestAsForm(url, Method.Post, new
            {
                email = Email,
                password = Password
            });

            if((int)response.StatusCode == 400)
            {
                return new AuthResult(AuthResultType.InvalidCredentials, "Неверный логин или пароль");
            }

            var successResponseModel = JsonConvert.DeserializeObject<VC_RULoginSuccess>(response.Content);
            this.AccessToken = successResponseModel.Data.AccessToken;
            this.RefreshToken = successResponseModel.Data.RefreshToken;
            this.AccessTokenExpDate = DateTimeExtensions.FromUnixMilliseconds(successResponseModel.Data.AccessExpTimestamp);
            this.RefreshTokenExpDate = DateTimeExtensions.FromUnixMilliseconds(successResponseModel.Data.RefreshExpTimestamp);

            var profile = await GetAuthorizedProfile() as VC_RUProfile;
            this.AuthorizedUserId = profile.Id;

            return new AuthResult(AuthResultType.Success);
        }
    

        public override async Task<CommentCreationResult> CreateComment(string postId, CommentCrtUpdDTO model, string? replyCommentId = null)
        {
            await RefreshIfTokenExpiredAndThrowIf401();

            string url = HOST + $"/v2.4/comment/add";
            var response = await RequestsHelper.MakeRequestAsForm(url, Method.Post, new
            {
                id = postId,
                text = model.Text,
                referer = "post",
                reply_to = replyCommentId,
                //TODO: attachments
            });

            if((int)response.StatusCode == 404)
            {
                return new CommentCreationResult(CommentCreationResultType.PostNotFound);
            }
            if ((int)response.StatusCode == 403)
            {
                return new CommentCreationResult(CommentCreationResultType.NoAccess);
            }
            else if((int)response.StatusCode == 200)
            {
                dynamic responseDynamic = JsonConvert.DeserializeObject(response.Content);
                if(responseDynamic.status == 400)
                {
                    return new CommentCreationResult(CommentCreationResultType.InvalidData);
                }
                else if (responseDynamic.status == 403)
                {
                    return new CommentCreationResult(CommentCreationResultType.NoAccess);
                }
            }

            var comment = JsonConvert.DeserializeObject<VC_RUSuccessResponse<VC_RUComment>>(response.Content);
            return new CommentCreationResult(CommentCreationResultType.Success) 
            {
                Comment = comment.Result
            };
        }

        public override async Task<PostCreationResult> CreatePost(PostCrtUpdDTO model)
        {
            await RefreshIfTokenExpiredAndThrowIf401();

            var uploadedFiles = new List<VC_RUFileUploadResultFile>();
            if (model.Attachments.Any())
            {
                var dictionary = new Dictionary<string, string>();
                int counter = 0;

                foreach(var attachment in model.Attachments)
                {
                    dictionary.Add($"files_{counter++}", attachment.Path);
                }
                uploadedFiles = await UploadFiles(dictionary);
            }

            throw new NotImplementedException();

                    //{
                  //  "message": "Пост уже опубликован",
           // "error": {
             //           "code": 422,
             //   "info": {
               //             "errorCode": "POST_ALREADY_PUBLISHED"
               // }
            //}
           // }
        }

        public override async Task<PostUpdateResult> UpdatePost(string postId, PostCrtUpdDTO model)
        {
            await RefreshIfTokenExpiredAndThrowIf401();






            throw new NotImplementedException();
        }

        public override async Task<CommentDeletionResult> DeleteComment(string commentId, string postId = "не нужен")
        {
            await RefreshIfTokenExpiredAndThrowIf401();

            string url = HOST + $"/v3.0/comments/{commentId}?withThread=false";
            var response = await RequestsHelper.MakeRequestAsForm(url, Method.Delete);
            dynamic responseModel = JsonConvert.DeserializeObject(response.Content);

            if(responseModel.message == "COMMENT_NOT_FOUND")
            {
                return new CommentDeletionResult(CommentDeletionResultType.NotFound);
            }
            else if (responseModel.message == "AUTHOR_ACCESS_DENIED")
            {
                return new CommentDeletionResult(CommentDeletionResultType.NoAccess);
            }

            return new CommentDeletionResult(CommentDeletionResultType.Success);
        }
        public override async Task<PostDeletionResult> DeletePost(string postId)
        {
            await RefreshIfTokenExpiredAndThrowIf401();

            string url = HOST + $"/v2.4/content/{postId}";
            var response = await RequestsHelper.MakeRequestAsForm(url, Method.Delete);

            if((int)response.StatusCode == 422)
            {
                return new PostDeletionResult(PostDeletionResultType.NotFound, "Запись с данным Id на найдена");
            }
            else if ((int)response.StatusCode == 403)
            {
                return new PostDeletionResult(PostDeletionResultType.NoAccess, "Нет доступа к записи");
            }

            return new PostDeletionResult(PostDeletionResultType.Success);
        }
        public override async Task<CommentUpdateResult> EditComment(string postId, string commentId, CommentCrtUpdDTO model)
        {
            await RefreshIfTokenExpiredAndThrowIf401();

            string url = HOST + $"/v2.4/comment/edit";
            var response = await RequestsHelper.MakeRequestAsForm(url, Method.Post, new
            {
                comment_id = commentId,
                text = model.Text,
                //TODO: attachments
            });

            if((int)response.StatusCode == 422)
            {
                var error = JsonConvert.DeserializeObject<VC_RUErrorResponse>(response.Content);

                if (error.Error.Info.ErrorCode == "COMMENT_EDITING_TIME_EXPIRED")
                {
                    return new CommentUpdateResult(CommentUpdateResultType.UnableToUpdate, error.Message);
                }
                else if (error.Error.Info.ErrorCode == "COMMENT_CAN_BE_EDITED_ONLY_BY_AUTHOR")
                {
                    return new CommentUpdateResult(CommentUpdateResultType.NoAccess, error.Message);
                }
            }
            else if((int)response.StatusCode == 404)
            {
                return new CommentUpdateResult(CommentUpdateResultType.NotFound, "Комментарий не найден");
            }
            else if ((int)response.StatusCode == 400)
            {
                return new CommentUpdateResult(CommentUpdateResultType.InvalidData, "Ошибка при заполнении комментария");
            }
            return new CommentUpdateResult(CommentUpdateResultType.Success, "Комментарий успешно обновлен");
        }

        public override async Task<Post> GetPost(string postId)
        {
            string url = HOST + $"/v2.8/content?id={postId}&markdown=false";
            var response = await RequestsHelper.MakeRequestAsForm(url, Method.Get);

            if((int)response.StatusCode == 404)
            {
                return null;
            }

            var model = JsonConvert.DeserializeObject<VC_RUSuccessResponse<VC_RUPost>>(response.Content);
            return model.Result;
        }

        public override async Task<Comment> GetPostComment(string postId, string commentId)
        {
            var comments = (await GetPostComments(postId, 0, int.MaxValue)).Cast<VC_RUComment>();

            var commentIdInt = 0;
            int.TryParse(commentId, out commentIdInt);

            return comments.FirstOrDefault(o => o.Id == commentIdInt);
        }
        public override async Task<IEnumerable<Comment>> GetPostComments(string postId, int offset = 0, int count = 20)
        {
            string url = HOST + $"/v2.5/comments?sorting=hotness&contentId={postId}&firstLoad=true";
            var response = await RequestsHelper.MakeRequestAsForm(url, Method.Get);

            if((int)response.StatusCode == 404 || (int)response.StatusCode == 500)
            {
                return new List<VC_RUComment>();
            }

            var commentsResponse = JsonConvert.DeserializeObject<VC_RUSuccessResponse<GetCommentsResult>>(response.Content);
            return commentsResponse.Result.Items.Skip(offset).Take(count);
        }

        public override async Task<IEnumerable<Post>> GetPosts(int offset = 0, int count = 20)
        {
            await RefreshIfTokenExpiredAndThrowIf401();

            string url = HOST + $"/v2.8/timeline?markdown=false&sorting=new&subsitesIds={this.AuthorizedUserId}";
            var response = await RequestsHelper.MakeRequestAsForm(url, Method.Get);

            var model = JsonConvert.DeserializeObject<VC_RUSuccessResponse<VC_RUGetPostsResult>>(response.Content);
            return model.Result.Items.Select(o => o.Data);
        }

        public override async Task<LogoutResult> Logout()
        {
            AccessToken = null;
            RefreshToken = null;

            return new LogoutResult();
        }

        public override async Task<AuthResult> Ping()
        {
            string url = HOST + $"/v2.1/subsite/me";
            var response = await RequestsHelper.MakeRequestAsForm(url, Method.Get);

            if((int)response.StatusCode == 401)
            {
                return new AuthResult(AuthResultType.InvalidCredentials);
            }
            return new AuthResult(AuthResultType.Success);
        }
        public override async Task<Profile> GetAuthorizedProfile()
        {
            await RefreshIfTokenExpiredAndThrowIf401();

            string url = HOST + $"/v2.1/subsite/me";
            var response = await RequestsHelper.MakeRequestAsForm(url, Method.Get);

            return JsonConvert.DeserializeObject<VC_RUSuccessResponse<VC_RUProfile>>(response.Content).Result;
        }
        public override async Task<AuthResult> Send2FACode(string code)
        {
            throw new NotSupportedException("vc.ru не запрашивает код для подтверждения входа");
        }

    



        #region Private methods

        private Dictionary<string, string> MakeAuthHeaders()
        {
            return new Dictionary<string, string>
            {
                {"jwtauthorization", $"bearer {this.AccessToken}" }
            };
        }

        private async Task RefreshIfTokenExpiredAndThrowIf401()
        {
            if (string.IsNullOrEmpty(RefreshToken))
            {
                throw new AutoposterUnauthorizedError();
            }
            else if (RefreshTokenExpDate < DateTime.UtcNow)
            {
                throw new AutoposterUnauthorizedError();
            }
            else if(AccessTokenExpDate < DateTime.UtcNow)
            {
                var result = await Refresh();
                if (!result)
                {
                    throw new AutoposterUnauthorizedError();
                }
            }
        }
        private async Task<bool> Refresh()
        {
            string url = HOST + "/v3.4/auth/refresh";
            var response = await RequestsHelper.MakeRequestAsForm(url, Method.Post, new
            {
                token = this.RefreshToken,
            });
            
            if((int)response.StatusCode != 200)
            {
                return false;
            }

            var responseModel = JsonConvert.DeserializeObject<VC_RURefreshSuccess>(response.Content);
            this.RefreshToken = responseModel.Data.RefreshToken;
            this.AccessToken = responseModel.Data.AccessToken;
            this.AccessTokenExpDate = DateTimeExtensions.FromUnixMilliseconds(responseModel.Data.AccessExpTimestamp);
            this.RefreshTokenExpDate = DateTimeExtensions.FromUnixMilliseconds(responseModel.Data.RefreshExpTimestamp);

            return true;
        }

        private async Task<List<VC_RUFileUploadResultFile>> UploadFiles(Dictionary<string, string> keyFilepathFiles)
        {
            await RefreshIfTokenExpiredAndThrowIf401();

            string url =  $"https://upload.vc.ru/v2.8/uploader/upload";
            var response = await RequestsHelper.MakeRequestAsFormFileUpload(url, Method.Post, keyFilepathFiles);
            var filesResponse = JsonConvert.DeserializeObject<VC_RUSuccessResponse<List<VC_RUFileUploadResultFile>>>(response.Content);

            return filesResponse.Result;
        }
        private async Task<VC_RUFileUploadResultFile> UploadFile(string key, string filepath)
        {
            var files = await UploadFiles(new Dictionary<string, string>
            {
                {key,filepath }
            });
            return files.FirstOrDefault();
        } 


        private async Task<VC_RUPost> CreateVC_RUPost(BlogPostCrtUpdDTO dto)
        {
            var post = new VC_RUPost()
            {
                Title = dto.Title
            };

            foreach(var block in dto.Block)
            {
                var vcPostBlock = new PostBlock();

                if (block is PostAudioBlockDTO audio)
                {
                    var file = await UploadFile("files_0", audio.Filepath);

                    vcPostBlock.Type = "audio";
                    vcPostBlock.Data = new PostAudioBlockData
                    {
                        Audio = new PostAudioBlockDataAudio
                        {
                            Type = "audio",
                            Data = new PostAudioBlockDataAudioData 
                            { 
                                UUID = file.Data.UUID,
                                Filename = "",
                                AudioInfo = null,
                                Size = 0,
                            }
                        }
                    };
                }
                else if (block is PostCodeBlockDTO code)
                {
                    vcPostBlock.Type = "code";
                    vcPostBlock.Data = new PostCodeBlockData
                    {
                        Lang = code.Lang,
                        Text = code.Text
                    };
                }
                else if (block is PostDelimiterBlockDTO delimiter)
                {
                    vcPostBlock.Type = "delimiter";
                    vcPostBlock.Data = new PostDelimiterBlockData();
                }
                else if (block is PostHeaderBlockDTO header)
                {
                    vcPostBlock.Type = "header";
                    vcPostBlock.Data = new PostHeaderBlockData
                    {
                        Text = header.Text,
                        Style = "h2"
                    };
                }
                else if (block is PostImageBlockDTO image)
                {
                    var file = await UploadFile("files_0", image.Filepath);
                }
                else if (block is PostListBlockDTO list)
                {
                    vcPostBlock.Type = "list";

                    string listType = "ol";
                    switch (list.Type)
                    {
                        case PostListBlockDTOType.Unordered:
                            listType = "ul";
                            break;
                        case PostListBlockDTOType.Ordered:
                            listType = "ol";
                            break;
                    }

                    vcPostBlock.Data = new PostListBlockData
                    {
                        Items = list.Items,
                        Type = listType
                    };
                }
                else if (block is PostQuoteBlockDTO quote)
                {
                    vcPostBlock.Type = "quote";
                    vcPostBlock.Data = new PostQuoteBlockData
                    {
                        Text = quote.Text
                    };
                }
                else if (block is PostTextBlockDTO text)
                {
                    vcPostBlock.Type = "text";
                    vcPostBlock.Data = new PostTextBlockData
                    {
                        Text = text.Text
                    };
                }
                else if (block is PostVideoBlockDTO video)
                {
                    var file = await UploadFile("files_0", video.Filepath);


                }
            }


            return post;
        }

        private async Task<VC_RUPost> CreateVC_RUPost(SocialMediaPostCrtUpdDTO dto)
        {
            var post = new VC_RUPost();

            if (!string.IsNullOrEmpty(dto.Content))
            {
                post.Blocks.Add(new PostBlock
                {
                    Type = "text",
                    Data = new PostTextBlockData
                    {
                        Text = dto.Content
                    }
                });
            }

            var uploadedFiles = new List<VC_RUFileUploadResultFile>();
            if (dto.Attachments.Any())
            {
                var dictionary = new Dictionary<string, string>();
                int counter = 0;

                foreach (var attachment in dto.Attachments)
                {
                    dictionary.Add($"files_{counter++}", attachment.Path);
                }
                uploadedFiles = await UploadFiles(dictionary);
            }

            foreach(var uploadedFile in uploadedFiles)
            {

            }

            return post;
        }


        #endregion
    }
}
