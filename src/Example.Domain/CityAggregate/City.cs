namespace Example.Domain.CityAggregate
{
    public class City
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public UF UF { get; private set; }

        public static City Create(string name, UF uf)
        {
            ArgumentNullException.ThrowIfNull(name);
            ArgumentNullException.ThrowIfNull(uf);

            return new City
            {
                Name = name,
                UF = uf
            };
        }

        public void Update(string? name, UF? uf)
        {
            if (name != null)
                Name = name;
            if (uf != null)
                UF = uf.Value;
        }
    }
}
