using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Areas.Admin.SubmitModels;
using SimpleBlog.Areas.Admin.ViewModels;
using SimpleBlog.Data.Entities;
using SimpleBlog.Data.Repositories;
using SimpleBlog.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace SimpleBlog.Services.Admin
{
    public interface ICategoryService : IBaseService
    {
        IEnumerable<CategoriesViewModel.CategoryItem> GetAll(IUrlHelper url);
        Category GetById(int? id);

        int? Add(CategoryCreateSubmitModel submitModel);
        void Update(CategoryUpdateSubmitModel submitModel);
        void Delete(int? id);

        void SyncSortIndexes(List<SimpleKeyValue<int?, int?>> sortIndexes);
    }

    public class CategoriesService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;

        public bool IsError { get; set; }

        public CategoriesService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;

        }

        public IEnumerable<CategoriesViewModel.CategoryItem> GetAll(IUrlHelper url)
        {
            var categories = _categoryRepository.GetAsync(filter: c => c.ParentId == null, includes: c => c.ChildCategories).Result.ToList();


            return categories.Select(c => new CategoriesViewModel.CategoryItem
            {
                Id = c.Id,
                ParentId = c.ParentId,
                Caption = c.Caption,
                Code = c.Code,

                UpdateUrl = url.RouteUrl("adminCategoriesUpdate", new { id = c.Id }),
                DeleteUrl = url.RouteUrl("adminCategoriesDelete", new { id = c.Id }),

                Categories = CategoriesViewModel.CategoryItem.GetSubCategories(url, c.ChildCategories.ToList())
            }).ToList();
        }

        public Category GetById(int? id)
        {
            return _categoryRepository.GetById(id);
        }

        public int? Add(CategoryCreateSubmitModel submitModel)
        {
            var category = new Category
            {
                ParentId = submitModel.ParentId,
                Caption = submitModel.Caption,
                Code = submitModel.Code
            };

            _categoryRepository.Add(category);
            _categoryRepository.Complate();
            IsError = _categoryRepository.IsError;
            return category.Id;
        }

        public void Update(CategoryUpdateSubmitModel submitModel)
        {
            var category = _categoryRepository.GetById(submitModel.Id);

            if (category == null)
            {
                IsError = true;
            }
            else
            {
                category.ParentId = submitModel.ParentId;
                category.Caption = submitModel.Caption;
                category.Code = submitModel.Code;

                _categoryRepository.Complate();
                IsError = _categoryRepository.IsError;
            }
        }

        public void Delete(int? id)
        {
            var category = _categoryRepository.GetById(id);

            if (category == null)
            {
                IsError = true;
            }
            else
            {
                _categoryRepository.Remove(category);
                _categoryRepository.Complate();
                IsError = _categoryRepository.IsError;
            }
        }

        public void SyncSortIndexes(List<SimpleKeyValue<int?, int?>> sortIndexes)
        {
            _categoryRepository.Get(c => sortIndexes.Select(s => s.Key).Contains(c.Id)).ToList().ForEach(
            c =>
            {
                sortIndexes.ForEach(s =>
                {
                    if (s.Key == c.Id)
                    {
                        c.SortIndex = s.Value;
                    }
                });
            });

            _categoryRepository.Complate();
            IsError = _categoryRepository.IsError;
        }
    }
}
