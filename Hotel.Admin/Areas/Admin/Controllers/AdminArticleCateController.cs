using AutoMapper;
using Hotel.Admin.Areas.Admin.DTOs.ArticleCate;
using Hotel.Data;
using Hotel.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Admin.Areas.Admin.Controllers
{
    public class AdminArticleCateController : AdminControllerBase
    {
        public AdminArticleCateController(ApplicationDbContext DbContext, IMapper mapper) : base(DbContext, mapper)
        {

        }

        public IActionResult Index()
        {
            // Lấy dữ liệu từ database
            var articleCates = _HotelDbContext.AppArticlesCates
                                .Select(x => new IndexArticleCateDTO
                                {
                                    Id = x.Id,
                                    Name = x.Name
                                }).ToList();
            return View(articleCates);
        }
        //Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateOrUpdateContactDTO model)
        {
            if (ModelState.IsValid)
            {
                var articleCate = new AppArticleCate
                {
                    Name = model.Name
                };
                _HotelDbContext.AppArticlesCates.Add(articleCate);
                _HotelDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        // edit 
        public IActionResult Edit(int id)
        {
            var articleCate = _HotelDbContext.AppArticlesCates.Find(id);
            if (articleCate == null)
            {
                return NotFound();
            }
            var model = new CreateOrUpdateContactDTO
            {
                Name = articleCate.Name
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(int id, CreateOrUpdateContactDTO model)
        {
            if (ModelState.IsValid)
            {
                var articleCate = _HotelDbContext.AppArticlesCates.Find(id);
                if (articleCate == null)
                {
                    SetErrorMesg("Không thể xóa danh mục");
                    return NotFound();
                }
                articleCate.Name = model.Name;
                _HotelDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        // delete
        public IActionResult Delete(int id)
        {
            var articleCate = _HotelDbContext.AppArticlesCates.Find(id);
            if (articleCate == null)
            {
                return NotFound();
            }
            _HotelDbContext.AppArticlesCates.Remove(articleCate);
            _HotelDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
