namespace SimpleBlog.Areas.Admin.ViewModels
{
    public class LoginViewModel
    {
        public string UserName { get; set; }
        public string LoginUrl { get; set; }

        public string ErrorMessage { get; set; }
        public bool HasError { get; set; }
    }
}
