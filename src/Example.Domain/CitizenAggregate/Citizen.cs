using Example.Domain.CityAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Domain.CitizenAggregate
{
    public class Citizen
    {
        public Citizen() { }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Cpf { get; private init; }
        public int Age { get; private set; }
        public int CityId { get; private set; }
        public City City { get; private set; }

        public static Citizen Create(string name, string cpf, int age, int cityId)
        {
            ArgumentNullException.ThrowIfNull(name);
            ArgumentNullException.ThrowIfNull(cpf);

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name can't be empty");

            if (age <= 0)
                throw new ArgumentException("Age must be greater than 0");

            return new Citizen
            {
                Name = name,
                Cpf = cpf,
                Age = age,
                CityId = cityId
            };
        }

        public void Update(string? name, int age, int cityId)
        {
            if (name != null)
                Name = name;
            if (age > 0)
                Age = age;
            if (cityId != 0)
                CityId = cityId;
        }
    }
}
