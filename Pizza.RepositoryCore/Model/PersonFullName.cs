using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pizza.RepositoryCore.Model
{
    public class PersonFullName
    {

        public static  PersonFullName Create(string givenName, string surName)
        {
            return new PersonFullName(givenName, surName);
        }

        public static PersonFullName Empty( )
        {
            return new PersonFullName("", "");
        }

        public override bool Equals(object obj)
        {
            return obj is PersonFullName name &&
                   GivenName == name.GivenName &&
                   SurName == name.SurName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(GivenName, SurName);
        }

        private PersonFullName(string givenName, string surName)
        {
            GivenName = givenName;
            SurName = surName;
        }
        public string GivenName { get; private set; }
        public string SurName { get; private set; }
        public string FullName => $"{GivenName} {SurName}";

        public static bool operator ==(PersonFullName left, PersonFullName right)
        {
            return EqualityComparer<PersonFullName>.Default.Equals(left, right);
        }

        public static bool operator !=(PersonFullName left, PersonFullName right)
        {
            return !(left == right);
        }
    }
}