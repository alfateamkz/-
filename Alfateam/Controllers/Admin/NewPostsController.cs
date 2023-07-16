using Alfateam.Abstractions;
using Alfateam.Database;
using Alfateam.Database.Models;
using Alfateam.Database.Models.NewPosts;
using Alfateam.Models;
using Alfateam.ViewModels;
using Alfateam.ViewModels.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Alfateam.Controllers.Admin
{
    [Authorize("Admin")]
    public class NewPostsController : AbsController
    {
        public NewPostsController(DatabaseContext db, IWebHostEnvironment appEnvironment) : base(db, appEnvironment)
        {
        }

        [HttpGet, Route("Admin/NewPosts")]
        public IActionResult NewPosts()
        {
            var posts = DB.NewPosts
                .Include(o => o.Language)
                .Include(o => o.Headings)
                .Include(o => o.Paragraphs)
                .Where(o => !o.IsDeleted)
                .ToList();
            return View(@"Views\Admin\NewPosts\NewPosts.cshtml", posts);
        }


        #region Добавление/апдейт нового поста. один хуй работает одинакого
        [HttpGet, Route("Admin/CreateNewPost")]
        public IActionResult CreateNewPost(int id = 0)
        {
            var post = new NewPost();

            if(id != 0)
            {
                post = DB.NewPosts.Include(o => o.Language)
                                  .Include(o => o.Sliders).ThenInclude(o => o.Images)
                                  .Include(o => o.Headings)
                                  .Include(o => o.Paragraphs)
                                  .Include(o => o.Videos)
                                  .Include(o => o.Images)
                                  .FirstOrDefault(o => o.Id == id);
            }


            var vm = new NewPostsVM
            {
                Id = id,
                Headings = post.Headings,
                Sliders = post.Sliders,
                Images = post.Images,
                Paragraphs = post.Paragraphs,
                Videos = post.Videos,
                Languages = DB.Languages.ToList()
            };
            return View(@"Views\Admin\NewPosts\CreatePost.cshtml", vm);
        }


        [HttpPost, Route("Admin/CreateNewPostPOST")]
        public async Task<IActionResult> CreateNewPostPOST(NewPostsVM vm)
        {
            int watches = 0;
            DateTime createdAt = DateTime.Now;

            if (vm.Id != 0)
            {
                var post = DB.NewPosts.FirstOrDefault(o => o.Id == vm.Id);
                post.IsDeleted = true;
                DB.NewPosts.Update(post);

                watches = post.Watches;
                createdAt = post.CreatedAt;
            }


            int counter = 0;
            for(int i = 0; i < vm.OrderedItemsWithMedia.Count; i++)
            {
                var item = vm.OrderedItemsWithMedia[i];
                if(item is PostImage img)
                {
                    if (img.FilesCount < 1) continue;
                    img.ImgPath = await SetAttachmentIfHas(img.ImgPath, counter++);
                }
                else if (item is PostVideo video)
                {
                    if (video.FilesCount < 1) continue;
                    video.ImgPath = await SetAttachmentIfHas(video.ImgPath, counter++);
                }
                else if (item is PostSlider slider)
                {
                    for(int f = 0; f < slider.FilesCount; f++)
                    {
                        var sliderImg = new PostImage();
                        sliderImg.ImgPath = await SetAttachmentIfHas(sliderImg.ImgPath, counter++);

                        slider.Images.Add(sliderImg);
                    }
                }
            }


            var newPost = new NewPost()
            {
                Sliders = vm.Sliders,
                Headings = vm.Headings,
                Images = vm.Images,
                Paragraphs = vm.Paragraphs,
                Videos = vm.Videos,

                Watches = watches,
                CreatedAt = createdAt,
                LanguageId = vm.LanguageId
            };

            DB.NewPosts.Add(newPost);
            DB.SaveChanges();
            return RedirectToAction("NewPosts", "NewPosts");
        }
        #endregion


        [HttpGet, Route("Admin/DeleteNewPost")]
        public IActionResult DeleteNewPost(int id)
        {
            var post = DB.NewPosts.FirstOrDefault(o => o.Id == id);

            post.IsDeleted = true;

            DB.NewPosts.Update(post);
            DB.SaveChanges();
            return RedirectToAction("NewPosts", "NewPosts");
        }
    }
}
