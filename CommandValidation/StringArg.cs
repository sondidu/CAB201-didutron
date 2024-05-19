namespace CommandValidation
{
    public class StringArg : ArgType
    {
        private HashSet<string> validValues;

        public StringArg(params string[] validValues)
        {
            this.validValues = new HashSet<string>(validValues);
            argumentErrorMsg = "Valid values are: " + string.Join(", ", validValues.ToArray());
        }

        public StringArg(string argumentErrorMsg, params string[] validValues) : this(validValues)
        {
            this.argumentErrorMsg = argumentErrorMsg;
        }

        public override bool isValid(string value)
        {
            return validValues.Contains(value);
        }
    }
}
