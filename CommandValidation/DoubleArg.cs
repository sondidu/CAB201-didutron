namespace CommandValidation
{
    public class DoubleArg : ArgType
    {
        private bool onlyPositive;
        private const string INVALID_DOUBLE_ERROR_MSG = "Must be a valid number.";

        public DoubleArg(string argumentErrorMsg = INVALID_DOUBLE_ERROR_MSG, bool onlyPositive = false)
        {
            this.argumentErrorMsg = argumentErrorMsg;
            this.onlyPositive = onlyPositive;
        }

        public override bool isValid(string argument)
        {
            bool isValidNumber = double.TryParse(argument, out double num);

            if (isValidNumber && onlyPositive)
            {
                return num > 0;
            }

            return isValidNumber;
        }
    }
}
