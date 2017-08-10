namespace SimpleBlog.Areas.Admin.SubmitModels
{
    public class CategoryCreateSubmitModel
    {
        #region Properties

        public int? ParentId { get; set; }
        public string Caption { get; set; }
        public int? Code { get; set; }

        #endregion
    }
}
