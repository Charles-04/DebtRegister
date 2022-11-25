namespace DebtRegister
{
    internal class DebtRegister
    {
        Debtor debtor = new();
        List<Debtor> debtorList = new();
        internal void Init()
        {
            try
            {
                Console.WriteLine("\nWelcome to Buhari's Debt Register \n What do you want to do?");
                Console.WriteLine($"\n 1 : Add new Debtor \n 2 : View Debtors \n 3 : Update Payment \n 4 : Quit");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Add New Debtor");
                        debtorList.Add(debtor.CollectDebtorDetails());
                        Init();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Debtor details");
                        DisplayDebtors();
                        Init();
                        break;
                    case 3:
                        Console.Clear();
                        UpdatePayment();
                        Init();
                        break;
                    case 4:
                        Environment.Exit(0000);
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        Init();
                        break;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); 
                Init();
            }

        }
        internal Debtor? GetDebtor()
        {
            Console.WriteLine("Enter Debtor's First Name");
            string firstName = Console.ReadLine().ToLower();
            Console.WriteLine("Enter Debtor's Last Name");
            string lastName = Console.ReadLine().ToLower();
            Debtor currentDebtor = null;
            for (int i = 0; i < debtorList.Count; i++)
            {
                if (debtorList[i].LastName.ToLower() == lastName && debtorList[i].FirstName.ToLower() == firstName)
                {
                    currentDebtor = debtorList[i];
                }
                else
                {
                    return null;
                }
            }
            return currentDebtor;
        }
        internal void UpdatePayment()
        {
            Console.WriteLine("Update Debt Payment");
            Debtor debtor = GetDebtor();
            if (debtor != null && debtor.RepaymentTimes < (int)EnumClass.CommonNumbers.InstallmentSpan)
            {
                switch (debtor.InstallmentPlan)
                {
                    case InstallmentPlan.Daily:
                        debtor.NextRepaymentDate = DateTime.Now.AddDays(1);
                        break;
                    case InstallmentPlan.Weekly:
                        debtor.NextRepaymentDate = DateTime.Now.AddDays(7);
                        break;
                    case InstallmentPlan.BiWeekly:
                        debtor.NextRepaymentDate = DateTime.Now.AddDays(14);
                        break;
                    case InstallmentPlan.Monthly:
                        debtor.NextRepaymentDate = DateTime.Now.AddMonths(1);
                        break;
                    case InstallmentPlan.SemiAnnual:
                        debtor.NextRepaymentDate = DateTime.Now.AddMonths(6);
                        break;
                    case InstallmentPlan.Annual:
                        debtor.NextRepaymentDate = DateTime.Now.AddYears(1);
                        break;
                    default:
                        break;
                }

                debtor.DebtRemnant -= debtor.Installment;
                debtor.RepaymentTimes += 1;
                Console.WriteLine($"Congrats {debtor.LastName} {debtor.FirstName}, you've made an installmental payment of {debtor.Installment} for {debtor.GoodsDescription}." +
                    $" \n Your Debt remains : {debtor.DebtRemnant} \n Next Repayment date : {debtor.NextRepaymentDate}");
            }
            else
            {
                Console.WriteLine("Debtor Not found");
            }
        }
        internal void DisplayDebtors()
        {

            for (int i = 0; i < debtorList.Count; i++)
            {
                Debtor debtor = debtorList[i];
                if (debtor.RepaymentTimes >= 3)
                {
                    debtorList.Remove(debtor);
                    continue;
                }
                else if (debtorList.Count == 0)
                {
                    Console.WriteLine("Omo, You no get debtors");
                }
                else
                {
                    Console.WriteLine($"\n Debtor {i + 1} Info \n");
                    Console.WriteLine($"Name : {debtor.LastName} {debtor.FirstName}");
                    Console.WriteLine($"Debt Amount : {debtor.Debt}");
                    Console.WriteLine($"Installment Amount : {debtor.Installment}");
                    Console.WriteLine($"Debt Remains : {debtor.DebtRemnant}");
                    Console.WriteLine($"Repayment times : {debtor.RepaymentTimes}");
                }

            }
        }
    }
}
