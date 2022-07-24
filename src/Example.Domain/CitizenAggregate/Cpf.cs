namespace Example.Domain.CitizenAggregate
{
    public class Cpf
    {
        public Int64 Value { get; }

        public Cpf(Int64 value)
        {
            Value = value;
        }

        public static Cpf Create(Int64 value)
        {
            if (value == 0)
                throw new ArgumentException("CPF can't be null or empty");

            if (value != 11)
                throw new ArgumentException("CPF must have length equal to 11");

            return new Cpf(value);
        }
    }
}
