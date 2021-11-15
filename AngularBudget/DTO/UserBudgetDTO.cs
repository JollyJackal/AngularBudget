namespace AngularBudget.DTO
{
    public class UserBudgetDTO
    {
        public Guid? UserBudgetId { get; set; }
        //public Guid ApplicationUserId { get; set; }
        public int FrequencyId { get; set; }
        public int FrequencyAmount { get; set; } //i.e. 30 with Budget Frequency 'Days' means frequency is 30 Days.
    }
}
