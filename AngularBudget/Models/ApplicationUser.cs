using Microsoft.AspNetCore.Identity;

namespace AngularBudget.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public UserBudget UserBudget { get; set; } = null!;
        public List<UserBill> UserBills { get; set; } = null!;
        public List<UserBillCompany> UserBillCompanies { get; set; } = null!;
        public List<UserIncome> UserIncomes { get; set;} = null!;
        public List<UserIncomeCompany> UserIncomeCompanies { get; private set; } = null!;
    }
}