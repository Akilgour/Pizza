using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pizza.RepositoryCore.Model
{
    public class PersonFullName
    {
        public PersonFullName(string givenName, string surName)
        {
            GivenName = givenName;
            SurName = surName;
        }
        public string GivenName { get; set; }
        public string SurName { get; set; }
        public string FullName => $"{GivenName} {SurName}";

    }
}