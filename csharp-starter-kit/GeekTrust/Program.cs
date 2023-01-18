using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GeekTrust
{
    class Program
    {
        #region Input Commands
        public const string LOAN = "LOAN";
        public const string PAYMENT = "PAYMENT";
        public const string BALANCE = "BALANCE";
        #endregion

        static void Main(string[] args)
        {
            try
            {
                string[] inputData = File.ReadAllLines(args[0]);
                //Add your code here to process the input commands
                List<Loan> loans = new List<Loan>();
                List<Payment> payments = new List<Payment>();

                foreach (var line in inputData)
                {
                    if (line.StartsWith(LOAN))
                    {
                        string[] inputArgs = line.Split(' ');
                        loans.Add(new Loan(inputArgs[1], inputArgs[2], int.Parse(inputArgs[3]), int.Parse(inputArgs[4]), int.Parse(inputArgs[5])));
                    }
                    else if (line.StartsWith(PAYMENT))
                    {
                        string[] inputArgs = line.Split(' ');
                        payments.Add(new Payment(inputArgs[1], inputArgs[2], int.Parse(inputArgs[3]), int.Parse(inputArgs[4])));
                    }
                    else if (line.StartsWith(BALANCE))
                    {
                        string[] inputArgs = line.Split(' ');
                        GetBalance(loans, payments, inputArgs);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        static void GetBalance(List<Loan> loansList, List<Payment> paymentsList, string[] inputArgs)
        {
            // I/O Arguments
            string BANK_NAME = inputArgs[1];
            string BORROWER_NAME = inputArgs[2];
            int EMI_NO = int.Parse(inputArgs[3]);
            int AMOUNT_PAID = 0;
            int NO_OF_EMIS_LEFT = 0;

            Loan loan = loansList.Where(l => l.BANK_NAME.Equals(BANK_NAME) && l.BORROWER_NAME.Equals(BORROWER_NAME)).FirstOrDefault();
            float AmountToBePaidToBank = loan.GetAmountToBePaidToBank();
            int NumberOfEMIs = loan.NO_OF_YEARS * 12;
            int AmountPerEMI = Convert.ToInt32(Math.Ceiling(AmountToBePaidToBank / NumberOfEMIs));

            List<Payment> payments = paymentsList.Where(l => l.BANK_NAME.Equals(BANK_NAME) && l.BORROWER_NAME.Equals(BORROWER_NAME) && l.EMI_NO <= EMI_NO).ToList();
            int LumpSumAmountPaid = payments.Sum(p => p.LUMP_SUM_AMOUNT);
            AMOUNT_PAID = LumpSumAmountPaid + (AmountPerEMI * EMI_NO);

            // 5. If the last EMI is more than the remaining amount to pay, then it should be adjusted to match the amount remaining to pay.
            if (AMOUNT_PAID > AmountToBePaidToBank)
                AMOUNT_PAID = Convert.ToInt32(AmountToBePaidToBank);

            var AmountDue = AmountToBePaidToBank - AMOUNT_PAID;
            NO_OF_EMIS_LEFT = Convert.ToInt32(Math.Ceiling(AmountDue / AmountPerEMI));

            //Output
            Console.WriteLine($"{BANK_NAME} {BORROWER_NAME} {AMOUNT_PAID} {NO_OF_EMIS_LEFT}");
        }
    }
}
