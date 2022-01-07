using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FluffyBot.DataService.Models
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(64)]
        public string FirstName { get; set; }

        [MaxLength(64)]
        public string LastName { get; set; }

        public int Age { get; set; }

        [EmailAddress]
        [MaxLength(255)]
        public string EmailAddress { get; set; }

        public IEnumerable<PhoneNumber> PhoneNumbers { get; set; }

        public static IEnumerable<Customer> GetCustomers()
        {
            yield return new Customer
            {
                Id = Guid.NewGuid(),
                FirstName = "Иван",
                LastName = "Иванов",
                Age = 18,
                EmailAddress = "ivanov@gmail.com"
            };

            yield return new Customer
            {
                Id = Guid.NewGuid(),
                FirstName = "Мася",
                LastName = "Полторашка",
                Age = 22,
                EmailAddress = "masya@gmail.com"
            };

            yield return new Customer
            {
                Id = Guid.NewGuid(),
                FirstName = "Анатолий",
                LastName = "Кукушкин",
                Age = 13,
                EmailAddress = "kukushkins@ukr.net"
            };

            yield return new Customer
            {
                Id = Guid.NewGuid(),
                FirstName = "Дмитрий",
                LastName = "Омельченко",
                Age = 15,
                EmailAddress = "omel@ukr.net"
            };
        }
    }
}
