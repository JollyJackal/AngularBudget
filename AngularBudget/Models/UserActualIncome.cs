using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AngularBudget.Models
{
    [Index(nameof(UserIncomeId), IsUnique = true)]
    public class UserActualIncome
    {
        public Guid UserActualIncomeId { get; set; }

        [Required]
        public int IncomeAmount { get; set; }

        [Required]
        public DateTime IncomeDate { get; set; }

        [Required]
        public Guid UserIncomeId { get; set; }
        public UserIncome UserIncome { get; set; } = null!;
    }
}
