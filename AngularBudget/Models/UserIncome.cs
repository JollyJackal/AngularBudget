using System.ComponentModel.DataAnnotations;

namespace AngularBudget.Models
{
    public class UserIncome
    {
        public Guid UserIncomeId { get; set; }

        [Required]
        public string IncomeName { get; set; } = null!;

        [Required]
        public bool IsEstimate { get; set; }

        [Required]
        public int IncomeAmount { get; set; }

        [Required]
        public DateTime IncomeDate { get; set; }

        [Required]
        public int RegularityId { get; set; }
        public Regularity IncomeRegularity { get; set; } = null!; //Whether one time or recurring

        [Required]
        public int FrequencyId { get; set; }
        public Frequency IncomeFrequency { get; set; } = null!;

        [Required]
        public int FrequencyAmount { get; set; } //i.e. 30 with Frequency 'Days' means frequency is 30 Days.

        [Required]
        public Guid UserIncomeCompanyId { get; set; }
        public UserIncomeCompany UserIncomeCompany { get; set; } = null!;

        [Required]
        public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; } = null!;
    }
}
