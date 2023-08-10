using System.ComponentModel.DataAnnotations;

namespace CodingEventsRefresh.ViewModels
{
    public class AddEventCategoryViewModel
    {
        [Required(ErrorMessage = "Category name is required!")]
        [StringLength(20,MinimumLength = 3, ErrorMessage = "Name must be between 3 and 20 characters")]
        public string? CategoryName { get; set; }
    }
}
