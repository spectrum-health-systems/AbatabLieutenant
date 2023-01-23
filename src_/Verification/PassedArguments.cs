using AbatabLieutenant.StockData;

namespace AbatabLieutenant.Verification
{
    public class PassedArguments
    {
        public static bool VerifyArguments(string arg) =>
            VerificationList.CommandLineArguments().Contains($"{arg}");
    }
}
}
