

namespace DebtRegister
{
    internal class Debtor
    {

        internal string FirstName { get; set; }
        internal string LastName { get; set; }
        internal InstallmentPlan InstallmentPlan { get; set; }
        internal double Debt { get; set; }
        internal double Installment { get; set; }
        internal double DebtRemnant { get; set; }
        internal DateTime CreatedAt { get; set; }
        internal DateTime NextRepaymentDate { get; set; }
        internal string GoodsDescription { get; set; }
        internal int RepaymentTimes { get; set; }
        public Debtor()
        {

        }

        internal Debtor CollectDebtorDetails()
        {
            Debtor debtor = new Debtor();
            try
            {
                Console.WriteLine("Enter First Name");
                string firstName = Console.ReadLine();
                Console.WriteLine("Enter Last Name");
                string lastName = Console.ReadLine();
                Console.WriteLine("Enter preferred Installment plan. To be charged thrice!!!");
                Console.WriteLine("\n 1 : Daily \n 2 : Weelkly \n 3 : Biweekly " +
                    "\n 4 : Monthly \n 5 : SemiAnnual \n 6 : Annual ");
                int plan = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Description of Goods");
                string description = Console.ReadLine();
                Console.WriteLine("Enter Total amount of Debt");
                double amount = double.Parse(Console.ReadLine());


                debtor.FirstName = firstName;
                debtor.LastName = lastName;
                debtor.InstallmentPlan = (InstallmentPlan)GetPlan(plan);
                debtor.Debt = amount;
                debtor.DebtRemnant = amount;
                debtor.Installment = amount / 3;
                debtor.CreatedAt = DateTime.Now;
                debtor.GoodsDescription = description;


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                CollectDebtorDetails();

            }

            Console.WriteLine($"{debtor.FirstName} has succesfully activated {debtor.InstallmentPlan} installment Payment Plan For {debtor.GoodsDescription}");

            return debtor;

        }
        public static InstallmentPlan? GetPlan(int plan)
        {
            switch (plan)
            {
                case 1:
                    return InstallmentPlan.Daily;

                case 2:
                    return InstallmentPlan.Weekly;

                case 3:
                    return InstallmentPlan.BiWeekly;

                case 4:
                    return InstallmentPlan.Monthly;

                case 5:
                    return InstallmentPlan.SemiAnnual;

                case 6:
                    return InstallmentPlan.Annual;

                default:
                    return null;

            }
        }

    }
    public enum InstallmentPlan
    {
        Daily = 1,
        Weekly = 2,
        BiWeekly = 3,
        Monthly = 4,
        SemiAnnual = 5,
        Annual = 6

    }

}
