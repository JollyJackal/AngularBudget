using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AngularBudget.Models
{
    [Index(nameof(ApplicationUserId), IsUnique = true)] //Do we only want one? I suppose it would be possible to have more than one budget...
    public class UserBudget
    {
        public Guid UserBudgetId { get; set; }
        
        [Required]
        public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; } = null!;

        [Required]
        public int FrequencyId { get; set; }
        public Frequency BudgetFrequency { get; set; } = null!;

        [Required]
        public int FrequencyAmount { get; set; } //i.e. 30 with Budget Frequency 'Days' means frequency is 30 Days.

    }
}
