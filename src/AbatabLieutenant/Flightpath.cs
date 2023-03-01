namespace AbatabLieutenant
{
    public static class Flightpath
    {
        public static void StartLtnt(string[] passedArguments)
        {
            LtntSession.VerifySettingFile();

            LtntSession ltntSession = LtntSession.Load();

            if (passedArguments.Length > 0 && ltntSession.ValidBranches.Contains(passedArguments[0]))
            {
                LtntSession.Update(ltntSession, passedArguments[0]);
                LtntSession.VerifyAbatabRequirements(ltntSession);
                RunLtnt(ltntSession);
            }
            else
            {
                Logger.WriteToConsole(Catalog.HelpDetail(ltntSession.AbatabLieutenantVersion, Utility.ListToString(ltntSession.ValidBranches)));
            }
        }

        public static void RunLtnt(LtntSession ltntSession)
        {
            Console.Clear();
        }

        public static void FinishLtnt()
        {

        }
    }
}
