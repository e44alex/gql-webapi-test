using Bogus;
using Bogus.DataSets;
using WebApi.Domain;

namespace WebApi.Data.Fakers
{
    public static class DataFakers
    {
        public static Faker<Student> StudentFaker
        {
            get
            {
                return new Faker<Student>()
                    .RuleFor(x => x.Gender, faker => faker.PickRandom<Name.Gender>().ToString())
                    .RuleFor(x => x.Name,
                        (faker, student) => $"{faker.Name.FirstName(student.Gender == Name.Gender.Male.ToString() ? Name.Gender.Male : Name.Gender.Female)} {faker.Name.LastName()}")
                    .RuleFor(x => x.Age, faker => faker.Random.Int(18, 35))
                    .RuleFor(x => x.Email, (faker, student) => faker.Internet.Email(student.Name))
                    .RuleFor(x => x.TelNumber, faker => faker.Phone.PhoneNumber());
            }
        }

        public static Faker<Message> MessageFaker
        {
            get
            {
                return new Faker<Message>()
                    .RuleFor(x => x.FromName, faker => faker.Name.FullName())
                    .RuleFor(x => x.Subject, faker => faker.Hacker.Phrase())
                    .RuleFor(x => x.Date, faker => faker.Date.PastDateOnly().ToShortDateString())
                    .RuleFor(x => x.Body, (faker) => faker.Hacker.Phrase())
                    .RuleFor(x => x.Read, faker => faker.Random.Bool());
            }
        }
    }
}