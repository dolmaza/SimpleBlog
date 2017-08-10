using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Areas.Admin.SubmitModels;
using SimpleBlog.Areas.Admin.ViewModels;
using SimpleBlog.Services.Admin;
using SimpleBlog.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace SimpleBlog.Areas.Admin.Controllers
{
    public class CategoriesController : BaseAdminController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ViewResult Categories()
        {
            var model = new CategoriesViewModel
            {
                CategoryCreateUrl = Url.RouteUrl("adminCategoriesCreate"),
                SyncSortIndexesUrl = Url.RouteUrl("adminCategoriesSyncSortIndexes"),

                Categories = _categoryService.GetAll().ToList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CategoryCreateSubmitModel submitModel)
        {
            var ajaxResponse = new AjaxResponse();

            var categoryId = _categoryService.Add(submitModel);

            if (!_categoryService.IsError)
            {
                ajaxResponse.IsSuccess = true;
                ajaxResponse.Data = new
                {
                    CategoryId = categoryId
                };
            }

            return Json(ajaxResponse);
        }

        [HttpPost]
        public IActionResult Update(CategoryUpdateSubmitModel submitModel)
        {
            var ajaxResponse = new AjaxResponse();

            _categoryService.Update(submitModel);
            ajaxResponse.IsSuccess = !_categoryService.IsError;

            return Json(ajaxResponse);
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var ajaxResponse = new AjaxResponse();

            _categoryService.Delete(id);
            ajaxResponse.IsSuccess = !_categoryService.IsError;

            return Json(ajaxResponse);
        }

        [HttpPost]
        public IActionResult SyncSortIndexes(List<SimpleKeyValue<int?, int?>> sortIndexes)
        {
            var ajaxResponse = new AjaxResponse();

            _categoryService.SyncSortIndexes(sortIndexes);
            ajaxResponse.IsSuccess = !_categoryService.IsError;

            return Json(ajaxResponse);
        }
    }
}
