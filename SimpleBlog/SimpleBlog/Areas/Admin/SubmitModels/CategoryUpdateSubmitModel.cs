namespace SimpleBlog.Areas.Admin.SubmitModels
{
    public class CategoryUpdateSubmitModel
    {
        #region Properties

        public int? Id { get; set; }
        public int? ParentId { get; set; }
        public string Caption { get; set; }
        public int? Code { get; set; }

        #endregion
    }
}
