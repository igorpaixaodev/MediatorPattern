namespace MyMediator.Domain.People
{
    public class Person
    {
        public Person(int age, string name)
        {
            Age = age;
            Name = name;
        }

        public int Age { get; private set; }
        public string Name { get; private set; }

        #region Overrides
        public override string ToString()
        {
            return $"Name: {Name} with age {Age} created";
        }
        #endregion

    }
}
