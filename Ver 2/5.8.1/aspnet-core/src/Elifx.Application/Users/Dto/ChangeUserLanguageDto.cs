using System.ComponentModel.DataAnnotations;

namespace Elifx.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}