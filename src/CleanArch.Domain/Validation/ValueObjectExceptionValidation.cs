namespace CleanArch.Domain.Validation
{
    public class ValueObjectExceptionValidation : Exception
    {
        public ValueObjectExceptionValidation(string error) : base(error) {}

        public static void When(bool hasError, string error)
        {
            if (hasError)
                throw new ValueObjectExceptionValidation(error);
        }
    }
}
