namespace Example.Domain.CitizenAggregate
{
    public class Cpf
    {
        public string Value { get; }

        private Cpf(string value)
        {
            Value = value;
        }

        public static Cpf Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("CPF can't be null or empty");

            if (value.Length != 11)
                throw new ArgumentException("CPF must have length equal to 11");

            return new Cpf(value);
        }
    }
}
