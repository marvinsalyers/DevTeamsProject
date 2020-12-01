using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DevTeamRepo
    {
         private readonly DeveloperRepo _developerRepo = new DeveloperRepo(); // this gives you access to the _developerList so you can access existing 
        // Developers and add them to a team
        private readonly List<DevTeam> _devTeamDirectory = new List<DevTeam>();

        //DevTeam Create
        public void AddDevTeamToList(DevTeam devTeam)
        {
            _devTeamDirectory.Add(devTeam); // add developer to list ( _devTeamDirectory )
        }

        //DevTeam Read
        public List<DevTeam> GetDevTeamList()
        {
            return _devTeamDirectory;
        }

        //DevTeam Update

        public bool UpdateDevTeam(int oldTeamId, DevTeam newDevTeam)
        {
            DevTeam oldDevTeam = GetDevTeamById(oldTeamId);

            if (oldDevTeam != null)
            {
                newDevTeam.DevTeamId = oldDevTeam.DevTeamId;
                newDevTeam.Developers = oldDevTeam.Developers;
                oldDevTeam.DevTeamName = newDevTeam.DevTeamName;
                oldDevTeam.DevTeamLanguage = newDevTeam.DevTeamLanguage;
                oldDevTeam.DevTeamResponsibilty = newDevTeam.DevTeamResponsibilty;

                return true;
            }
            else
            {
                return false;
            }
        }

         

        //DevTeam Delete
        public bool RemoveDevTeamFromList(int devTeamId)
        {
            DevTeam devTeam = GetDevTeamById(devTeamId);
            if (devTeam == null)
            {
                return false;
            }
            int initialCount = _devTeamDirectory.Count;
            _devTeamDirectory.Remove(devTeam);

            if (initialCount > _devTeamDirectory.Count) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //DevTeam Helper (Get Team by ID)
        public DevTeam GetDevTeamById(int devTeamId)
        {
            foreach (DevTeam devTeam in _devTeamDirectory)
            {
                if (devTeam.DevTeamId == devTeamId)
                {
                    return devTeam;
                }
            }

            return null;
        }

        //DevTeam Method (Get TeamId and assign a developer to that team
        public void AddDeveloperToTeam(int devTeamId, int developerId)
        {
            //using helper method to obtain devTeam
            var devTeam = GetDevTeamById(devTeamId);

            //check to see if we have a team 
            if (devTeam != null)
            {
                //using helper method inside of the developer repository to get a 
                //speciffic developer.
                var developer = _developerRepo.GetDeveloperById(developerId);
               
                //check to see if a developer exist
                if (developer!=null)
                {
                    //if the developer exist add the developer and add
                    //the developer to the dev team 
                    devTeam.Developers.Add(developer);
                }
                else
                {
                    //the developer doesn't exist
                    Console.WriteLine($"Sorry there is no Developer with id: {developerId}");
                }
            }
            else
            {
                    //the devTeam doesn't exist
                    Console.WriteLine($"Sorry there is no DevTeam with id: {devTeamId}");
                Console.WriteLine();
            }

        }

        public void AddMultipleDevelopersToTeam(int devTeamId, List<Developer> developers)
        {
            //using helper method to obtain devTeam
            var devTeam = GetDevTeamById(devTeamId);

            if (devTeam != null)
            {
                foreach (var developer in developers)
                {
                    devTeam.Developers.Add(developer);
                }
            }
        }

    }
}
