using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SimpleBlog.Areas.Admin.ViewModels
{
    public class CategoriesViewModel
    {
        #region Properties

        public string CategoryCreateUrl { get; set; }
        public string SyncSortIndexesUrl { get; set; }
        public List<CategoryItem> Categories { get; set; }

        #endregion

        #region Sub Calsses

        public class CategoryItem
        {
            #region Properties

            public int? Id { get; set; }
            public int? ParentId { get; set; }
            public string Caption { get; set; }
            public int? Code { get; set; }

            public List<CategoryItem> Categories { get; set; }
            public bool HasSubCategories => Categories?.Count > 0;

            public string UpdateUrl { get; set; }
            public string DeleteUrl { get; set; }

            #endregion

            #region Methods

            public static List<CategoryItem> GetSubCategories(IUrlHelper url, List<Category> categories)
            {
                if (categories?.Count > 0)
                {
                    return categories.Select(c => new CategoryItem
                    {
                        Id = c.Id,
                        ParentId = c.ParentId,
                        Caption = c.Caption,
                        Code = c.Code,

                        UpdateUrl = url.RouteUrl("adminCategoriesUpdate", new { id = c.Id }),
                        DeleteUrl = url.RouteUrl("adminCategoriesDelete", new { id = c.Id }),

                        Categories = GetSubCategories(url, c.ChildCategories.ToList())
                    }).ToList();
                }
                else
                {
                    return null;
                }
            }


            #endregion

        }

        #endregion
    }
}
