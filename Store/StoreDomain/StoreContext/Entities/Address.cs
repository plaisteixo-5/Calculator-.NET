using System;
using StoreDomain.StoreContext.Enums;
using FluentValidation;

namespace StoreDomain.StoreContext.Entities
{
    public class Address
    {
        public Address(
            string street,
            string number,
            string complement,
            string district,
            string city,
            string country,
            string state,
            string zipCode,
            EAddressType type)
        {
            Street = street;
            Number = number;
            Complement = complement;
            District = district;
            City = city;
            Country = country;
            State = state;
            ZipCode = zipCode;
            Type = type;
        }

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string District { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }
        public EAddressType Type { get; private set; }

        public override string ToString()
        {
            return $"{Street}, {Number} - {City}/{State}";
        }
    }
}