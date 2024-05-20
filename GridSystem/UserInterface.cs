using ConstantsAndHelpers;
namespace GridSystem
{
    public class UserInterface
    {
        public static void Help()
        {
            Help([]);
        }
        public static void Help(string[] args)
        {
            ArgumentHelper.CompareArgsCount(args, ArgumentHelper.NoArgs);
            SuccessMessage.PrintHelp();
        }
        public static void Exit()
        {
            Exit([]);
        }
        public static void Exit(string[] args)
        {
            ArgumentHelper.CompareArgsCount(args, ArgumentHelper.NoArgs);
            Console.WriteLine(SuccessMessage.Exit);
        }
        public static void Welcome()
        {
            Console.WriteLine(SuccessMessage.Welcome);
        }
    }
}
