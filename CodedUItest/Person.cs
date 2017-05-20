using System;

namespace CodedUItest
{
    public class Person
    {

        public Person()
        {
            PersonId = Guid.NewGuid().ToString();
        }
        public string PersonId { get; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}