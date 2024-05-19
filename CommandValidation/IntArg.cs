namespace CommandValidation
{
    public class IntArg : ArgType
    {
        private bool onlyPositive = false;
        private const string INVALID_INT_ERROR_MSG = "Must be a valid 32-bit integer.";

        public IntArg(string argumentErrorMsg = INVALID_INT_ERROR_MSG, bool onlyPositive = false)
        {
            this.argumentErrorMsg = argumentErrorMsg;
            this.onlyPositive = onlyPositive;
        }

        public override bool isValid(string argument)
        {
            bool isValid32Int = int.TryParse(argument, out int num);

            if (isValid32Int && onlyPositive)
            {
                return num > 0;
            }

            return isValid32Int;
        }
    }
}
