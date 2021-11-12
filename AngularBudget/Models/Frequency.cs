using System.ComponentModel.DataAnnotations;

namespace AngularBudget.Models
{
    public class Frequency
    {
        public int FrequencyId { get; set; }

        [Required]
        public string FrequencyName { get; set; } = null!; //days, weeks, months
    }
}
