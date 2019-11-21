﻿using System;

namespace Assignment
{
    public class Address : IAddress
    {
        public string StreetAddress { get; set; }   = "";
        public string City { get; set; }            = "";
        public string State { get; set; }           = "";
        public string Zip { get; set; }             = "";

        public override bool Equals(object other)
        {
            if (other is IAddress addr)
                return StreetAddress == addr.StreetAddress &&
                    City == addr.City &&
                    State == addr.State &&
                    Zip == addr.Zip;
            else
                return false;
        }

        public override int GetHashCode() =>
            StreetAddress.GetHashCode() ^
                City.GetHashCode() ^
                State.GetHashCode() ^
                Zip.GetHashCode();
    }
}
