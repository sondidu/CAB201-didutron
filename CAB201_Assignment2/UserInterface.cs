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
            IntConstant.CompareArgsCount(args, IntConstant.NoArgs);
            SuccessMessage.PrintHelp();
        }
        public static void Exit()
        {
            Exit([]);
        }
        public static void Exit(string[] args)
        {
            IntConstant.CompareArgsCount(args, IntConstant.NoArgs);
            Console.WriteLine(SuccessMessage.Exit);
        }
        public static void Welcome()
        {
            Console.WriteLine(SuccessMessage.Welcome);
        }
    }
}
