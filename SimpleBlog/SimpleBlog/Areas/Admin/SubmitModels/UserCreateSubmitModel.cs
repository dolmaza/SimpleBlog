namespace SimpleBlog.Areas.Admin.SubmitModels
{
    public class UserCreateSubmitModel
    {
        public string UserName { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

    }
}
