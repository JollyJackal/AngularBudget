using System.ComponentModel.DataAnnotations;

namespace AngularBudget.Models
{
    public class Regularity
    {
        public int RegularityId { get; set; }

        [Required]
        public string RegularityName { get; set; } = null!; //recurring, one time
    }
}
