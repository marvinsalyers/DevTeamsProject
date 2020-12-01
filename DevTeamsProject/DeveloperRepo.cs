using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DeveloperRepo  // CRUD
    {
        private List<Developer> _developerList = new List<Developer>(); // field ----with Underscore


        //Developer Create add to list of Developers
        public void AddDeveloperToList(Developer developer)
        {
            _developerList.Add(developer); // add developer to list ( _developerList )
        }

        //Developer Read
        public List<Developer> GetDeveloperList()
        {
            return _developerList;
        }

        
        
        
        //Developer Update
        public bool UpdateDeveloper(int originalEmployeeId, Developer newDeveloper)
        {
            // find employee ID
            Developer oldDeveloper = GetDeveloperById(originalEmployeeId);

            // Update Employee Record
            if (oldDeveloper != null)
            {

                oldDeveloper.Title = newDeveloper.Title;
                oldDeveloper.FirstName = newDeveloper.FirstName;
                oldDeveloper.LastName = newDeveloper.LastName;
                oldDeveloper.EmployeeId = newDeveloper.EmployeeId;
                oldDeveloper.PluralsightAccess = newDeveloper.PluralsightAccess;
                //oldDeveloper.DeveloperTeam = newDeveloper.DeveloperTeam;

                return true;
            }
            else
            {
                return false;    
            }
        }



        //Developer Delete
        public bool RemoveDeveloperFromList(int employeeId)
        {
            Developer developer = GetDeveloperById(employeeId);
            if (developer == null)
            {
                return false;
            }
            int initialCount = _developerList.Count;
            _developerList.Remove(developer);

            if (initialCount > _developerList.Count)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }


        //Developer Helper (Get Developer by ID)
        public Developer GetDeveloperById(int employeeId)
        {
            foreach (Developer developer in _developerList)
            {
                if ( developer.EmployeeId == employeeId)
                {
                    return developer;
                }
            }

            return null;
        }
    }
}
