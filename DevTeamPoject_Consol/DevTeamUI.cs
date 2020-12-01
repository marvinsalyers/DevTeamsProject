using System;

namespace DevTeamsProject
{
    class DevTeamUI
    {
        //private DevTeamRepo _devTeamRepo = new DevTeamRepo(); _
        // Methed that starts the UI of the application
        public void Run()
        {
            Menu();
        }

        //Menu
        private void Menu()
        {
            //Display our options to the user
            Console.WriteLine("Create\n" +
            "1. Create Developer\n" +
            "2. Create A Developer Team\n" +
            "3. Add A Developer To A Team\n" +
            "4. Add Multipule Developers To A Team\n\n" +

            "Read\n" +
            "5. View All Developers\n" +
            "6. View A Single Developer \n" +
            "7. View All Developer Teams\n" +
            "8. View A Single Developer Team\n\n" +

            "Update\n" +
            "9.  Update An Existing Developer\n" +
            "10. Update An Developer Team\n" +
            "11. Patch An Existing Developer Team\n" +
            "12. Patch An Existing Developer\n\n" +
            "Remove\n" +
            "13  Remove An Existing Developer\n" +
            "14. Remove An Existing Developer Team\n\n" +

            "15. Close Application\n");
            
            // Set user's input

            string input = Console.ReadLine();

            // Evaluate the user's input and act accodingly

            switch (input)
            {
                case "1":
                    AddDeveloperToList();
                    break;
                
                
                default:
                    Console.WriteLine("Please Enter a valid number.");
                    break;
            }



        }
    }
}
