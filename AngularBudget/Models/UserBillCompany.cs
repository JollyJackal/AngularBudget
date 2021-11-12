using System.ComponentModel.DataAnnotations;

namespace AngularBudget.Models
{
    public class UserBillCompany
    {
        public Guid UserBillCompanyId { get; set; }

        [Required]
        public string CompanyName { get; set; } = null!;

        [Required]
        public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; } = null!;
    }
}
