using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    //public enum "Do I need a enum ???

    
    // POCO
    public class Developer
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }            //Properties
        public int EmployeeId { get; set; }
        public bool PluralsightAccess { get; set; }
        // public string DeveloperTeam { get; set; }


        public Developer() { } // why empty Constructor ??

        public Developer(string title, string firstName, string lastName, int employeeId, bool pluralsightAccess)//, string developerTeam) //parameters
        {
            // Property  = parameters
            Title = title;
            FirstName = firstName;
            LastName = lastName;
            EmployeeId = employeeId;
            PluralsightAccess = pluralsightAccess;
            // DeveloperTeam = developerTeam;

        }


    }
}
