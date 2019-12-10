using System;

namespace ShoppingList
{
    public class Person
    {
        public Person(string Text)
        {
            this.Text = Text;
            //LastName = lastName;
            //DOB = dob;
            //DOB = DateTime.Now.Subtract(TimeSpan.FromDays(30 * 365));
        }

        public string Text { get; set; }
        //public string LastName { get; set; }
        //public DateTime DOB { get; set; }
    }
}