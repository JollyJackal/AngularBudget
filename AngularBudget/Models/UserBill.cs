using System.ComponentModel.DataAnnotations;

namespace AngularBudget.Models
{
    public class UserBill
    {
        public Guid UserBillId { get; set; }

        [Required]
        public string BillName { get; set; } = null!;

        [Required]
        public bool IsEstimate { get; set; }

        [Required]
        public int BillAmount { get; set; }

        [Required]
        public DateTime BillDate { get; set; }

        [Required]
        public int RegularityId { get; set; }
        public Regularity BillRegularity { get; set; } = null!; //Whether one time or recurring

        [Required]
        public int FrequencyId { get; set; }
        public Frequency BillFrequency { get; set; } = null!;

        [Required]
        public int FrequencyAmount { get; set; } //i.e. 30 with Frequency 'Days' means frequency is 30 Days.

        [Required]
        public Guid UserBillCompanyId { get; set; }
        public UserBillCompany UserBillCompany { get; set; } = null!;

        [Required]
        public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; } = null!;
    }
}
