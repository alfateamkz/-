using Alfateam.Abstractions;
using Alfateam.Database;
using Alfateam.Database.Models;
using Alfateam.Models;
using Alfateam.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Controllers.Admin
{
    [Authorize("Admin")]
    public class PostsController : AbsController
    {
        public PostsController(DatabaseContext db, IWebHostEnvironment appEnvironment) : base(db, appEnvironment)
        {
        }

        [HttpGet, Route("Admin/Posts")]
        public IActionResult Posts()
        {
            var posts = DB.Posts
                .Include(o => o.Captions).ThenInclude(o => o.Language)
                .Include(o => o.Contents).ThenInclude(o => o.Language)
                .ToList();
            return View(@"Views\Admin\Posts\Posts.cshtml", posts);
        }


        #region Добавление нового поста
        [HttpGet, Route("Admin/CreatePost")]
        public IActionResult CreatePost()
        {
            return View(@"Views\Admin\Posts\CreatePost.cshtml");
        }
        [HttpPost, Route("Admin/CreatePostPOST")]
        public async Task<IActionResult> CreatePostPOST(Post post)
        {
            post.ImgPath = await SetAttachmentIfHas(post.ImgPath);

            DB.Posts.Add(post);
            DB.SaveChanges();
            return RedirectToAction("Posts", "Posts");
        }
        #endregion

        #region Редактирование поста
        [HttpGet, Route("Admin/UpdatePost")]
        public IActionResult UpdatePost(int id)
        {
            var post = DB.Posts
              .Include(o => o.Captions).ThenInclude(o => o.Language)
              .Include(o => o.Contents).ThenInclude(o => o.Language)
              .FirstOrDefault(o => o.Id == id);
            var vm = new VMWithLanguages<Post>()
            {
                TargetType = post,
                Languages = GetOtherLanguages()
            };
            return View(@"Views\Admin\Posts\UpdatePost.cshtml", vm);
        }
        [HttpPost, Route("Admin/UpdatePostPOST")]
        public async Task<IActionResult> UpdatePostPOST(VMWithLanguages<Post> vm)
        {
            vm.TargetType.ImgPath = await SetAttachmentIfHas(vm.TargetType.ImgPath);

            DB.Posts.Update(vm.TargetType);
            DB.SaveChanges();
            return RedirectToAction("Posts", "Posts");
        }

        #region Удаляем удаленные на фронте переводы и добавляем выбранные
        [HttpPost, Route("SetPostCaptionTranslations")]
        public async Task SetPostCaptionTranslations([FromBody] IdsModel ids)
        {
            var obj = DB.Posts.Include(o => o.Captions).ThenInclude(o => o.Language).FirstOrDefault(o => o.Id == ids.Id);
            foreach (var translation in obj.Captions.Where(o => o.Language.Code != "RU").ToList())
            {
                obj.Captions.Remove(translation);
            }

            foreach (var id in ids.Ids)
            {
                var translation = DB.TranslationItems.FirstOrDefault(o => o.Id == id);
                obj.Captions.Add(translation);
            }
            DB.SaveChanges();
        }
        [HttpPost, Route("SetPostContentTranslations")]
        public async Task SetPostContentTranslations([FromBody] IdsModel ids)
        {
            var obj = DB.Posts.Include(o => o.Contents).ThenInclude(o => o.Language).FirstOrDefault(o => o.Id == ids.Id);
            foreach (var translation in obj.Contents.Where(o => o.Language.Code != "RU").ToList())
            {
                obj.Contents.Remove(translation);
            }

            foreach (var id in ids.Ids)
            {
                var translation = DB.TranslationItems.FirstOrDefault(o => o.Id == id);
                obj.Contents.Add(translation);
            }
            DB.SaveChanges();
        }
        #endregion


        #endregion


        [HttpGet, Route("Admin/DeletePost")]
        public IActionResult DeletePost(int id)
        {
            var post = DB.Posts
                .Include(o => o.Captions)
                .Include(o => o.Contents)
                .FirstOrDefault(o => o.Id == id);

            DB.TranslationItems.RemoveRange(post.Captions);
            DB.TranslationItems.RemoveRange(post.Contents);

            DB.Posts.Remove(post);
            DB.SaveChanges();
            return RedirectToAction("Posts", "Posts");
        }
    }
}
