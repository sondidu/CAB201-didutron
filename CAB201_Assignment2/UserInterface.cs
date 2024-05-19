using ConstantsAndHelpers;
namespace Didutron
{
    public class UserInterface
    {
        public static void Help()
        {
            Help([]);
        }
        public static void Help(string[] args)
        {
            IntConstants.CompareArgsCount(args, IntConstants.NoArgs);
            SuccessMessages.PrintHelp();
        }
        public static void Exit()
        {
            Exit([]);
        }
        public static void Exit(string[] args)
        {
            IntConstants.CompareArgsCount(args, IntConstants.NoArgs);
            Console.WriteLine(SuccessMessages.OnExit);
        }
        public static void Welcome()
        {
            Console.WriteLine(SuccessMessages.OnWelcome);
        }
    }
}
