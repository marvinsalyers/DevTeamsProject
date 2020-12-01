using DevTeamsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeam_Console
{
    class KomodoUI
    {
        private DevTeamRepo _devTeamRepo = new DevTeamRepo();
        private DeveloperRepo _developerRepo = new DeveloperRepo();
        public void Run()
        {
            //Seed
            SeedDeveloperList();
            //  SeedDeveloperTeamList();

            Menu();
        } // end Run()
        private void Menu()
        {
            bool keeprunning = true;
            while (keeprunning)
            {
                //Display our options to the user
                Console.WriteLine(
            "1. Create Developer\n" +
            "2. View a Single Developer\n" +
            "3. View All Developers\n" +
            "4. Update Developer\n" +
            "5. Delete Developer\n" +
            "6. Create New Developer Team\n" +
            "7. View All Developer Teams\n" +
            "8. View Developer Team By Id\n" +
            "9. Update Developer Team\n" +
            "10. Delete Developer Team By Id\n" +
            "11. Add Multipule Developers to a team \n" +



            "\n15. Close Application\n");


                //Get users input

                string input = Console.ReadLine();

                //evaluate Input
                switch (input)
                {
                    case "1":
                        // Create Developer
                        Console.Clear();
                        CreateNewDeveloper();
                        break;
                    case "2":
                        // View a Developer By ID
                        ViewDeveloperById();
                        break;
                    case "3":
                        // View All Developers
                        ViewAllDevelopers();
                        break;
                    case "4":
                        // Update Developer
                        UpdateDeveloper();
                        break;
                    case "5":
                        // Delete Developer
                        DeleteDeveloper();
                        break;
                    case "6":
                        // Create New Developer Team
                        CreateNewTeam();
                        break;
                    case "7":
                        // View All Developer Teams
                        ViewAllDeveloperTeams();
                        break;
                    case "8":
                        // View A Single Developer Team
                        ViewDeveloperTeamById();
                        break;
                    case "9":
                        // Update An Developer Team
                        UpdateDeveloperTeam();
                        break;
                    case "10":
                        //Delete Developer Team
                        DeleteDeveloperTeam();
                        break;
                    case "11":
                        // add multi developer to team
                        AddMultipleDevelopersToTeam();
                        break;
                    case "12":
                        //
                        break;
                    case "13":
                        // 
                        break;
                    case "14":
                        //
                        break;
                    case "15":
                        // Exit
                        Console.WriteLine("Goodbye!");
                        keeprunning = false;
                        break;
                    default:
                        Console.WriteLine("Please Enter a valid number.");
                        break;
                } // end case               
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            } // end while
        } // end Menu()

        private void AddMultipleDevelopersToTeam()
        {
            Console.Clear();
            bool hasFilledAllPositions = false;
            Console.WriteLine("Please Input an Team id.");
            int inputTeamId = int.Parse(Console.ReadLine());

            List<Developer> developersToAdd = new List<Developer>();

            while (hasFilledAllPositions==false)
            {
                Console.WriteLine("Do you have any developers to add to the team y/n");
                string inputNeededDeveloper = Console.ReadLine();
                if (inputNeededDeveloper=="Y" || inputNeededDeveloper=="y")
                {
                    Console.Clear();
                    Developer newdeveloper = new Developer();


                    Console.WriteLine("Please Input Developer Title: ");
                    string developerTitleInput = Console.ReadLine();
                    newdeveloper.Title = developerTitleInput;

                    Console.WriteLine("Please Input Developer First Name: ");
                    string developerFirstNameInput = Console.ReadLine();
                    newdeveloper.FirstName = developerFirstNameInput;

                    Console.WriteLine("Please Input Developer Last Name: ");
                    string developerLastNameInput = Console.ReadLine();
                    newdeveloper.LastName = developerLastNameInput;


                    Console.WriteLine("Enter the Developer ID :");
                    // obtain user info / input about specific developer ( key : employeeID ) 
                    int inputEmployeeId = int.Parse(Console.ReadLine());
                    newdeveloper.EmployeeId = inputEmployeeId;
                    Console.WriteLine("Does this delvelopoer have a PluralsightLicense(Y or N)");
                    string inputpluralSight = Console.ReadLine();
                    if (inputpluralSight == "Y")
                    {
                        newdeveloper.PluralsightAccess = true;
                    }
                    else if (inputpluralSight == "N")
                    {
                        newdeveloper.PluralsightAccess = false;
                    }

                    developersToAdd.Add(newdeveloper);
                    _developerRepo.AddDeveloperToList(newdeveloper);
                    Console.Clear();
                }

                if (inputNeededDeveloper == "N" || inputNeededDeveloper == "n")
                {
                    _devTeamRepo.AddMultipleDevelopersToTeam(inputTeamId, developersToAdd);
                    hasFilledAllPositions = true;
                }



            }

        }

        private void UpdateDeveloperTeam()
        {
            Console.Clear();
            Console.WriteLine("Enter Team ID to Update");
            int inputOldTeamId = int.Parse(Console.ReadLine());
            DevTeam newDevTeam = new DevTeam();

            Console.WriteLine("Enter a new Team Name: ");
            string inputTeamName = Console.ReadLine();
            newDevTeam.DevTeamName = inputTeamName;

            Console.WriteLine("Enter new Team Language:");
            string inputTeamLanguage = Console.ReadLine();
            newDevTeam.DevTeamLanguage = inputTeamLanguage;

            Console.WriteLine("Enter new Responsilbilty: ");
            string inputTeamResponsibilty = Console.ReadLine();
            newDevTeam.DevTeamResponsibilty = inputTeamResponsibilty;

            bool isSuccessful = _devTeamRepo.UpdateDevTeam(inputOldTeamId, newDevTeam);
            if (isSuccessful)
            {
                Console.WriteLine("Team has been updated");
            }
            else
            {
                Console.WriteLine("Error Team failed to update");
            }

        }

        private void DeleteDeveloperTeam()
        {
            Console.Clear();
            Console.WriteLine("Input Team ID to be removed: ");
            int inputTeamID = int.Parse(Console.ReadLine());
            bool isSuccessful = _devTeamRepo.RemoveDevTeamFromList(inputTeamID);
            if (isSuccessful == true)
            {
                Console.WriteLine("The Team has been Deleted");
            }
            if (isSuccessful == false)
            {
                Console.WriteLine("The team Has not been deleted");
            }
        }


        private void ViewDeveloperTeamById()
        {
            Console.Clear();

            Console.WriteLine("Enter Team ID");
            int inputTeamId = int.Parse(Console.ReadLine());
            DevTeam devTeam = _devTeamRepo.GetDevTeamById(inputTeamId);

            Console.WriteLine($"{devTeam.DevTeamId}\n" +
                $"{devTeam.DevTeamName}\n" +
                $"{devTeam.DevTeamLanguage}\n" +
                $"{devTeam.DevTeamResponsibilty}");

            foreach (var developer in devTeam.Developers)
            {
                Console.WriteLine($"{developer.EmployeeId}\n" +
                    $"{developer.Title}\n" +
                    $"{developer.FirstName } {developer.LastName}\n" +
                    $"{developer.PluralsightAccess}");
            }
        }



        private void DeleteDeveloper()
        {
            Console.Clear();
            Console.WriteLine("Please Input Employee ID to Delete: ");
            int inputEmployeeId = int.Parse(Console.ReadLine());
            bool isSuccessful = _developerRepo.RemoveDeveloperFromList(inputEmployeeId);
            if (isSuccessful == true)
            {
                Console.WriteLine("Developer has been removed from List");
            }
            else
            {
                Console.WriteLine("Developer Failed to be Removed");
            }


        }

        private void UpdateDeveloper()
        {
            Console.Clear();
            Console.WriteLine("Please Input Old Developer Employee ID: to be updated: ");
            int inputOldEmployeeId = int.Parse(Console.ReadLine());
            // We are retreiving the data of the old developer
            Developer oldDeveloper = _developerRepo.GetDeveloperById(inputOldEmployeeId);
            // We are constructing a new developer and assiging values
            Developer newDeveloper = new Developer();

            Console.WriteLine("Please input a developer Title: ");
            string inputEmployeeTitle = Console.ReadLine();
            newDeveloper.Title = inputEmployeeTitle;

            Console.WriteLine("Please Enter First Name");
            string inputEmployeeFirstName = Console.ReadLine();
            newDeveloper.FirstName = inputEmployeeFirstName;

            Console.WriteLine("Please Enter Last Name: ");
            string inputEmployeeLastName = Console.ReadLine();
            newDeveloper.LastName = inputEmployeeLastName;

            Console.WriteLine("Pleas Enter Employee ID: ");
            string inputEmployeeId = Console.ReadLine();
            newDeveloper.EmployeeId = int.Parse(inputEmployeeId);

            Console.WriteLine("Does this Developer have PluralSight access: Y or N");
            string inputHasPluralSight = Console.ReadLine();
            if (inputHasPluralSight == "Y".ToLower())
            {
                newDeveloper.PluralsightAccess = true;
            }
            else if (inputHasPluralSight == "N".ToLower())
            {
                newDeveloper.PluralsightAccess = false;
            }

            bool isSuccessful = _developerRepo.UpdateDeveloper(oldDeveloper.EmployeeId, newDeveloper);
            if (isSuccessful == true)
            {
                Console.WriteLine("A new Developer has been created ");
            }
            else
            {
                Console.WriteLine("Sorry new Developer Failed to Update");
            }
        }

        // ViewDeveloperByEmployeeID
        private void ViewDeveloperById()
        {

            Console.Clear();
            Console.WriteLine("Please input employee ID number: ");

            int input = int.Parse(Console.ReadLine());
            // Store a developer variable of type Developer
            Developer developer = _developerRepo.GetDeveloperById(input);
            DisplayDeveloperInfo(developer);

        }
        private void DisplayDeveloperInfo(Developer developer)
        {
            Console.WriteLine($"Employee ID: {developer.EmployeeId}\n" +
                $"Employee Name: {developer.FirstName} {developer.LastName}\n" +
                $"Has PluralSights Access: {developer.PluralsightAccess}");
        }

        // *********************************************************************************
        // Create new Developer
        private void CreateNewDeveloper()
        {
            Console.Clear();
            Developer newdeveloper = new Developer();


            Console.WriteLine("Please Input Developer Title: ");
            string developerTitleInput = Console.ReadLine();
            newdeveloper.Title = developerTitleInput;

            Console.WriteLine("Please Input Developer First Name: ");
            string developerFirstNameInput = Console.ReadLine();
            newdeveloper.FirstName = developerFirstNameInput;

            Console.WriteLine("Please Input Developer Last Name: ");
            string developerLastNameInput = Console.ReadLine();
            newdeveloper.LastName = developerLastNameInput;


            Console.WriteLine("Enter the Developer ID :");
            // obtain user info / input about specific developer ( key : employeeID ) 
            int inputEmployeeId = int.Parse(Console.ReadLine());
            newdeveloper.EmployeeId = inputEmployeeId;
            Console.WriteLine("Does this delvelopoer have a PluralsightLicense(Y or N)");
            string inputpluralSight = Console.ReadLine();
            if (inputpluralSight == "Y")
            {
                newdeveloper.PluralsightAccess = true;
            }
            else if (inputpluralSight == "N")
            {
                newdeveloper.PluralsightAccess = false;
            }

            _developerRepo.AddDeveloperToList(newdeveloper);
        }

        private void ViewAllDevelopers()
        {
            Console.Clear();

            List<Developer> listOfDevelopers = _developerRepo.GetDeveloperList();

            foreach (Developer developer in listOfDevelopers)
            {
                Console.WriteLine($"Title:{developer.Title}\n" +
                    $"First Name: {developer.FirstName}\n" +
                   $"Last Name: {developer.LastName}\n" +
                $"Pluralsight Access: {developer.PluralsightAccess}\n");
            }
        } //end of ViewAllDevelopers

        private void ViewAllDeveloperTeams()
        {
            Console.Clear();

            List<DevTeam> listOfDeveloperTeams = _devTeamRepo.GetDevTeamList();

            foreach (DevTeam devTeam in listOfDeveloperTeams)
            {
                Console.WriteLine($"Team ID:{devTeam.DevTeamId}\n" +
                                  $"Team Name: {devTeam.DevTeamName}\n" +
                                  $"Team Responsibilities: {devTeam.DevTeamResponsibilty}\n" +
                                  $"Team Language: {devTeam.DevTeamLanguage}\n" +
                                  $"****************************************\n");

                //this will allow the developers in a speciffic devTeam to show
                ViewDeveloperInfo(devTeam);
            }



        } //end of ViewAllDeveloperTeams

        private void ViewDeveloperInfo(DevTeam devTeam)
        {
            foreach (var developer in devTeam.Developers)
            {
                Console.WriteLine($"Developer Id: {developer.EmployeeId}\n" +
                    $"Developer Title: {developer.Title}\n" +
                    $"Developer Name: {developer.FirstName} {developer.LastName}\n" +
                    $"Developer HasPluralsight: {developer.PluralsightAccess}\n" +
                    $"");

            }
        }

        private void SeedDeveloperList()
        {
            DevTeam Sharpies = new DevTeam(1, "Sharpies", "Windows Forms", "C#");
            DevTeam coolbeans = new DevTeam(2, "Cool Beans", "Java Beans", "Java");
            DevTeam webbies = new DevTeam(3, "Webbies", "MySQL Integration ", "PHP");

            _devTeamRepo.AddDevTeamToList(Sharpies);
            _devTeamRepo.AddDevTeamToList(coolbeans);
            _devTeamRepo.AddDevTeamToList(webbies);

            Developer flintstone = new Developer("Code Monkey", "Fred", "Flintstone", 1, true);
            Developer rubble = new Developer("Jr. Coder", "Barney", "Rubble", 2, false);
            Developer jetson = new Developer("Senior Coder", "George", "Jetson", 3, true);
            Developer smith = new Developer("Senior Coder", "Megan", "Smith", 4, true);

            _developerRepo.AddDeveloperToList(flintstone);
            _developerRepo.AddDeveloperToList(rubble);
            _developerRepo.AddDeveloperToList(jetson);
            _developerRepo.AddDeveloperToList(smith);


            //we need to use the devTeam variables to add developers
            Sharpies.Developers.Add(flintstone);
            Sharpies.Developers.Add(rubble);
            coolbeans.Developers.Add(jetson);
            webbies.Developers.Add(smith);


        }
        private void SeedDeveloperTeamList()
        {
            //DevTeam Sharpies = new DevTeam(1, "Sharpies", "Windows Forms", "C#");
            //DevTeam coolbeans = new DevTeam(2, "Cool Beans", "Java Beans", "Java");
            //DevTeam webbies = new DevTeam(3, "Webbies", "MySQL Integration ", "PHP");

            //_devTeamRepo.AddDevTeamToList(Sharpies);
            //_devTeamRepo.AddDevTeamToList(coolbeans);
            //_devTeamRepo.AddDevTeamToList(webbies);
            //_devTeamRepo.AddDeveloperToTeam(1, 1);
            //_devTeamRepo.AddDeveloperToTeam(2, 2);
            //_devTeamRepo.AddDeveloperToTeam(3, 3);
            //_devTeamRepo.AddDeveloperToTeam(1, 4);

        }

        private void CreateNewTeam()
        {
            Console.Clear();
            DevTeam newdevteam = new DevTeam();

            Console.WriteLine("Enter the Developer Team ID :");
            // obtain user info / input about specific developer Team
            int inputDevTeamId = int.Parse(Console.ReadLine());
            newdevteam.DevTeamId = inputDevTeamId;


            Console.WriteLine("Please Input Team Name: ");
            string devTeamNameInput = Console.ReadLine();
            newdevteam.DevTeamName = devTeamNameInput;

            Console.WriteLine("Please Input Developer Team Responsibility: ");
            string devTeamResponsibiltyInput = Console.ReadLine();
            newdevteam.DevTeamResponsibilty = devTeamResponsibiltyInput;

            Console.WriteLine("Please Input Developer Team Primary Language: ");
            string devTeamLanguageInput = Console.ReadLine();
            newdevteam.DevTeamLanguage = devTeamLanguageInput;



            _devTeamRepo.AddDevTeamToList(newdevteam);

        }






    } //end class
} //end namespace







