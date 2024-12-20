using AutoMapper;
using Hotel.Admin.Areas.Admin.DTOs.Article;
using Hotel.Admin.Areas.Admin.DTOs.ArticleCate;
using Hotel.Data;
using Hotel.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hotel.Admin.Areas.Admin.Controllers
{
    public class AdminArticleController : AdminControllerBase
    {
        public AdminArticleController(ApplicationDbContext DbContext, IMapper mapper) : base(DbContext, mapper)
        {

        }

        public IActionResult Index()
        {
            // Lấy dữ liệu từ database
            var articles = _HotelDbContext.AppArticles
                                .Select(x => new IndexArticleDTO
                                {
                                    Id = x.Id,
                                    Title = x.Title,
                                    Summary = x.Summary,
                                    Image = x.Images,
                                    CategoryName = x.AppArticleCate.Name
                                }).ToList();
            return View(articles);
        }
        
        public IActionResult Create()
        {
            // tạo danh sách danh mục cho dropdownlist
            var categories = _HotelDbContext.AppArticlesCates.ToList();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateOrUpdateArticleDTO model)
        {
            if (ModelState.IsValid)
            {
                //upload file ảnh
                if (model.ImageFile != null)
                {
                    IFormFile file = model.ImageFile;
                    var fileName = Guid.NewGuid() + file.FileName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    model.Image = "/images/" + fileName;
                }
                var article = new AppArticle
                {
                    Title = model.Title,
                    Summary = model.Summary,
                    Content = model.Content,
                    Images = model.Image,
                    IdCategory = model.IdCategory
                };
                _HotelDbContext.AppArticles.Add(article);
                _HotelDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            var categories = _HotelDbContext.AppArticlesCates.ToList();
            ViewBag.Categories = new SelectList(categories, "Id", "Name", model.IdCategory);
            return View(model);
        }
        // edit
        public IActionResult Edit(int id)
        {
            var article = _HotelDbContext.AppArticles.Find(id);
            if (article == null)
            {
                return NotFound();
            }
            var model = new CreateOrUpdateArticleDTO
            {
                Title = article.Title,
                Summary = article.Summary,
                Content = article.Content,
                Image = article.Images,
                IdCategory = article.IdCategory
            };
            var categories = _HotelDbContext.AppArticlesCates.ToList();
            ViewBag.Categories = new SelectList(categories, "Id", "Name", model.IdCategory);
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(int id, CreateOrUpdateArticleDTO model)
        {
            if (ModelState.IsValid)
            {
                var article = _HotelDbContext.AppArticles.Find(id);
                if (article == null)
                {
                    SetErrorMesg("Không thể xóa bài viết");
                    return NotFound();
                }
                //upload file ảnh
                if (model.ImageFile != null)
                {
                    IFormFile file = model.ImageFile;
                    var fileName = Guid.NewGuid() + file.FileName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    model.Image = "/images/" + fileName;
                }
                article.Title = model.Title;
                article.Summary = model.Summary;
                article.Content = model.Content;
                article.Images = model.Image;
                article.IdCategory = model.IdCategory;
                _HotelDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            var categories = _HotelDbContext.AppArticlesCates.ToList();
            ViewBag.Categories = new SelectList(categories, "Id", "Name", model.IdCategory);
            return View(model);
        }
        // delete
        public IActionResult Delete(int id)
        {
            var article = _HotelDbContext.AppArticles.Find(id);
            if (article == null)
            {
                return NotFound();
            }
            _HotelDbContext.AppArticles.Remove(article);
            _HotelDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
