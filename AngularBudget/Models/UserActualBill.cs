using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AngularBudget.Models
{
    [Index(nameof(UserBillId), IsUnique = true)]
    public class UserActualBill
    {
        public Guid UserActualBillId { get; set; }

        [Required]
        public int BillAmount { get; set; }

        [Required]
        public DateTime BillDate { get; set; }

        [Required]
        public Guid UserBillId { get; set; }
        public UserBill UserBill { get; set; } = null!;
    }
}
