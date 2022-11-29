namespace DebtRegister
{
    internal class Utility
    {
        public bool NullValidator(string input, string message)
        {

            if (string.IsNullOrWhiteSpace(input) && string.IsNullOrEmpty(input))
            {
                Exception ex = new();
                throw new NullException(message, ex);
               // return true;

            }
            else
            {
                return false;
            }

        }
    }
}
