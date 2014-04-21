namespace IcbmikeBlag.Models.Admin
{
    public class LoginModel : BlagModelBase
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool HasErrors { get; set; }
    }
}