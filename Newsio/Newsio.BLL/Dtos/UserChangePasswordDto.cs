namespace Newsio.BLL.Dtos
{
    public class UserChangePasswordDto
    {
        public string PreviousPassword { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
    }
}
