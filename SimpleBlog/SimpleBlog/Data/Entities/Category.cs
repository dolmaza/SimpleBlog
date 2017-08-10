using System;
using System.Collections.Generic;

namespace SimpleBlog.Data.Entities
{
    public class Category
    {
        public int? Id { get; set; }
        public int? ParentId { get; set; }
        public string Caption { get; set; }
        public int? Code { get; set; }
        public int? SortIndex { get; set; }
        public DateTime? CreateTime { get; set; }

        public Category()
        {
            CreateTime = DateTime.Now;
            ChildCategories = new List<Category>();
        }

        public Category ParentCategory { get; set; }
        public ICollection<Category> ChildCategories { get; set; }
    }
}
