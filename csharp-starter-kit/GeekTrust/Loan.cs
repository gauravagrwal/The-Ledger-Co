namespace GeekTrust
{
    public class Loan
    {
        public string BANK_NAME { get; set; }
        public string BORROWER_NAME { get; set; }
        public int PRINCIPAL { get; set; }
        public int NO_OF_YEARS { get; set; }
        public int RATE_OF_INTEREST { get; set; }

        public Loan(string BankName, string BorrowerName, int Principal, int NoOfYears, int RateOfInterest)
        {
            BANK_NAME = BankName;
            BORROWER_NAME = BorrowerName;
            PRINCIPAL = Principal;
            NO_OF_YEARS = NoOfYears;
            RATE_OF_INTEREST = RateOfInterest;
        }

        public float GetAmountToBePaidToBank()
        {
            var INTEREST = (PRINCIPAL * RATE_OF_INTEREST * NO_OF_YEARS) / 100;
            return PRINCIPAL + INTEREST;
        }
    }
}
