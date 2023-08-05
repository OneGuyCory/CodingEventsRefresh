using System.ComponentModel.DataAnnotations;

namespace CodingEventsRefresh.ViewModels
{
    public class AddEventViewModel
    {

        [Required(ErrorMessage = "Name of event is required!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Event name must be between 3 and 50 characters!")]
        public string? Name { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Description is too long!")]
        public string? Description { get; set; }

        [EmailAddress]
        public string? ContactEmail { get; set; }

         

    }
}

