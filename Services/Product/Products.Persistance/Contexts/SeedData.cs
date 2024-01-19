using Bogus;
using BusinessApp.Shared.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Persistance.Contexts
{
    internal class SeedData
    {
        private List<User> GetUsers()
        {

            //TODO- complete
            var users = new Faker<User>("tr")
                .RuleFor(i => i.Id, i => Guid.NewGuid())
                .Generate(250);


            return users;
        }
    }
}
