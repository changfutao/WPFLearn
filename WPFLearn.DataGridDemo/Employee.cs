using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFLearn.DataGridDemo
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDay { get; set; }
        public int Salary { get; set; }
        public static IEnumerable<Employee> FakeMany(int count) => employeeFaker.Generate(count);
        public static Employee FakeOne() => employeeFaker.Generate();
        private static readonly Faker<Employee> employeeFaker = new Faker<Employee>()
            .RuleFor(x => x.Id, x => x.IndexFaker)
            .RuleFor(x => x.FirstName, x => x.Person.FirstName)
            .RuleFor(x => x.LastName, x => x.Person.LastName)
            .RuleFor(x => x.BirthDay, x => DateOnly.FromDateTime(x.Person.DateOfBirth))
            .RuleFor(x => x.Salary, x => x.Random.Int(6, 30) * 1000);
    }
}
