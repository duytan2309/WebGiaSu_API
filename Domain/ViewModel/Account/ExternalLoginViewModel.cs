using System.ComponentModel.DataAnnotations;

namespace Lib.Domain.ViewModel.Account
{
    public class ExternalLoginViewModel
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string DOB { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}