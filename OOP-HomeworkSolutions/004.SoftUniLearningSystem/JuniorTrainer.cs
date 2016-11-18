using System;

class JuniorTrainer : Trainer
{
    public JuniorTrainer(string firstName, string lastName, int age) : base(firstName, lastName, age)
    {
    }
        public override string ToString()
    {
        return string.Format("{0} {1} ({2}) - Junior Trainer!",
            this.FirstName, this.LastName, this.Age);
    }
}