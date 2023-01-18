namespace GeekTrust
{
    class Payment
    {
        public string BANK_NAME { get; set; }
        public string BORROWER_NAME { get; set; }
        public int LUMP_SUM_AMOUNT { get; set; }
        public int EMI_NO { get; set; }

        public Payment(string BankName, string BorrowerName, int LumpSumAmount, int EMINo)
        {
            BANK_NAME = BankName;
            BORROWER_NAME = BorrowerName;
            LUMP_SUM_AMOUNT = LumpSumAmount;
            EMI_NO = EMINo;
        }
    }
}
