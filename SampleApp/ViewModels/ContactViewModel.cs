using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.ViewModels
{
    public class ContactViewModel
    {
        [Required]
        [MinLength(5, ErrorMessage = "Too short..minimum should be 5 chars atleast")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        [MaxLength(250)]
        public string Message { get; set; }

    }
}
