using System.ComponentModel.DataAnnotations;

namespace CRUD_dotnetProject.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty; 
    }
}
