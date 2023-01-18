using Xunit;

namespace GeekTrust.Tests
{
    public class ProgramTests
    {
        [Theory]
        [InlineData(10000, 4, 5, 12000)]
        [InlineData(2000, 2, 2, 2080)]
        public void Test_GetAmountToBePaidToBank(int PRINCIPAL, int RATE_OF_INTEREST, int NO_OF_YEARS, float expectedResult)
        {
            // Act
            var loan = new Loan("FAKE_BANK", "FAKE_BORROWER", PRINCIPAL, NO_OF_YEARS, RATE_OF_INTEREST);
            float actualResult = loan.GetAmountToBePaidToBank();

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
