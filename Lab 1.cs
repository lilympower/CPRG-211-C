using System;
using System.Collections.Generic;
using System.Linq;


namespace ConsoleApp2
{
    class Person
    {
        public int personID;
        public string firstName;
        public string lastName;
        public string favoriteColour;
        public int age;
        public bool isWorking;

        public Person(int personID, string firstName, string lastName, string favoriteColour, int age, bool isWorking) 
        {
            this.personID = personID;
            this.firstName = firstName; 
            this.lastName = lastName;
            this.favoriteColour = favoriteColour;
            this.age = age;
            this.isWorking = isWorking;
        }

        public void DisplayPersonInfo()
        {
           string Name = this.firstName + " " + this.lastName;
           Console.WriteLine($"{Convert.ToString(this.personID)}: {Name}'s favorite colour is {this.favoriteColour}");


        }

        public void ChangeFavoriteColour()
        {
            this.favoriteColour = "White";
        }

        public int GetAgeInTenYears()
        {
            return this.age + 10;
        }

        public override string ToString()
        {
            return $"Person ID: {this.personID}\nFirst Name: {this.firstName}\nLast Name: {this.lastName}\nFavorite Colour: {this.favoriteColour}\nAge: {this.age}\nIs Working: {this.isWorking}";
           
        }
    }
    class Relation
    {
        private string RelationshipType;
        private Person person1;
        private Person person2;
        
        public Relation(string relationshipType, Person person1, Person person2)
        {
            this.RelationshipType = relationshipType;
            this.person1 = person1;
            this.person2 = person2;
        }

        public void ShowRelationship() 
        {
            //Relationship between Gina and Mary is: Sisterhood
            //Relationship between Ian and Mike is: Brotherhood
            Console.WriteLine($"Relationship between {this.person1.firstName} and {this.person2.firstName} is: {this.RelationshipType}");
        }
    }

    class MainClass
    {
        static void Main(string[] args)
        {
            var Ian = new Person(1,"Ian","Brooks","Red",30,true);
            var Gina = new Person(2,"Gina", "James", "Green", 18, false);
            var Mike = new Person(3,"Mike","Briscoe","Blue",45,true);
            var Mary = new Person(4,"Mary","Beals","Yellow",28,true);

            Gina.DisplayPersonInfo();
            Console.WriteLine(Mike.ToString());
            Ian.ChangeFavoriteColour();
            Ian.DisplayPersonInfo();
            Console.WriteLine($"{Mary.firstName}'s Age in 10 years is: {Mary.GetAgeInTenYears()}");

            var Relationship1 = new Relation("Sisterhood",Mary,Gina);
            var Relationship2 = new Relation("Brotherhood", Mike, Ian);

            Relationship1.ShowRelationship();
            Relationship2.ShowRelationship();

            var listOfPeople = new List<Person>()
            {
                Ian, Gina, Mike, Mary
            };

            double totalAge = 0.0;
            
            for (int i = 0; i < listOfPeople.Count; i++)
            {
                totalAge = totalAge + listOfPeople[i].age;
            }
            
            var averageAge = totalAge / listOfPeople.Count;
            Console.WriteLine($"Average age is: {averageAge}");

            var oldestPerson = listOfPeople.OrderByDescending(i => i.age).First();
            var youngestPerson = listOfPeople.OrderBy(i => i.age).First();
            Console.WriteLine($"The youngest person is: {youngestPerson.firstName}");
            Console.WriteLine($"The oldest person is: {oldestPerson.firstName}");

            var mNames = listOfPeople.Where(i => i.firstName.ToLower().StartsWith("m"));
            foreach (Person person in mNames)
            {
                Console.WriteLine(person.ToString());
            }

            var blueEnjoyers = listOfPeople.Where(i => i.favoriteColour.ToLower().Equals("blue"));
            foreach (Person person in blueEnjoyers)
            {
                Console.WriteLine(person.ToString());
            }
        }

        
    }
}
