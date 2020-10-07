using System;
namespace Mermory
{
    public class Person
    {

        public int age { get; set; }

        public string name { get; set; }

        public int weight { get; set; }

        public string phone { get; set; }

        public string job { get; set; }

        public string city { get; set; }

        public Person(int age, string name, int weight, string phone, string job, string city)
        {
            this.age = age;
            this.name = name;
            this.weight = weight;
            this.phone = phone;
            this.job = job;
            this.city = city;


        }

        public int getBirthYear()
        {
            return 2020 - this.age;
        }

        public string getNameCapitalized()
        {
            return this.name.ToUpper();
        }

        public bool isAgeEven()
        {
            return this.age % 2 == 0;
        }
    }
}
