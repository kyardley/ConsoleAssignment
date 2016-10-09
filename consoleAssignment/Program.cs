using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Assignment: ConsoleAssignment
 * Author: Klynt Yardley
 * Date: 9/14/2016
 * Description: Olympic Soccer Tournament. Prompts the user to enter in the number of teams, team names, and points.
 * The Program then creates Soccer Team objects and sorts them by their points.  Then the program gives the user an option to 
 * begin a season of games and choose the home/visitting teams.  At the end of the season, the program prints out the season results.
*/
 

namespace consoleAssignment
{
    class Program
    {
        //Classes are found in Class.cs
        
        //Functions
        /*
         * Function: UppercaseFirst()
         * Capitalize the name of each team
         * Parameters: s
         * Returns: Capitalized team name
         */
        static string UppercaseFirst(string s)
        {
            //check if string is empty
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            //Return char and concat substring
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        /*
         * Function: CheckInterger
         * Makes sure user inputs an integer when needed
         * Parameters sInput
         * Return: Valid integer
         */
        static int CheckInteger(string sInput)
        {
            //Bool for while loop
            bool validTeamNum = false;
            int value = 0;
            
            while (!validTeamNum)
            {
              
                try
                {
                    value  = int.Parse(sInput);
                    validTeamNum = true;
                }
                catch
                {
                    Console.Write("Please enter a valid integer: ");
                    sInput = Console.ReadLine();
                }
            }
            return value;
        }


        static void Main(string[] args)
        {
            //Initialize variables
            string sTeamNumber;
            int iTeamNumber = 0;

            //Read user's input and convert to int
            Console.Write("How many teams? ");
            sTeamNumber = Console.ReadLine();

            //Check for valid integer
            iTeamNumber = CheckInteger(sTeamNumber);
            
            List<SoccerTeam> unsortedTeam = new List<SoccerTeam>();                 

            /*
             Receive User's input of team names
             Add them to team list
             */
            for (int i = 1; i <= iTeamNumber; i++)
            {
                // User's input
                Console.Write("\n \nEnter Team " + i + "'s name: ");
                string userinput = Console.ReadLine();
                string teamName = UppercaseFirst(userinput);
                
                Console.Write("\nEnter " + teamName +"'s points: ");
                string sPoints = Console.ReadLine();

                int inputPoints = CheckInteger(sPoints); // Exception Handling for integer

                //Create object and add it to the list.
                SoccerTeam oTeam = new SoccerTeam(teamName, inputPoints);
                unsortedTeam.Add(oTeam);
            }
            
            //sort teams
            List<SoccerTeam> sortedTeams = unsortedTeam.OrderByDescending(team => team.points).ToList();
            
            
            Console.WriteLine("\n\nHere is the sorted list: \n\n");
            Console.WriteLine("Position".PadRight(15, ' ') + "Name".PadRight(25, ' ') + "Points");
            Console.WriteLine("---------".PadRight(15, ' ') + "----".PadRight(25, ' ') + "------");
            
            //initiate possition variable
            int iPosition = 1;

            foreach(SoccerTeam team in sortedTeams)
            {
                string sPosition = Convert.ToString(iPosition);
                string sPoints = Convert.ToString(team.points);

                Console.WriteLine(sPosition.PadRight(15, ' ') + team.name.PadRight(25, ' ') + team.points);
                iPosition++;
            }

            // Asks user if they want to start a new season
            Console.Write("\nPlay the first game of the season? (Y/N): ");
            string gameDecision = Console.ReadLine();
            gameDecision = UppercaseFirst(gameDecision);//Capitalize first letter
            
            
            char Y_N = gameDecision[0]; //Selects the first Character if user accidentally entered 'Yes' or 'No'
            
            bool PlayGame = true;

            
            if (Y_N == 'N')
            {
                PlayGame = false;
            }
            
           //Enter While loop for the season games
            while(PlayGame)
            {
                iPosition = 1; //helps with user selection.
                Console.WriteLine("\nCurrent list of teams: (Team number is listed on the left)");

                //Prints current list of teams
                foreach(SoccerTeam team in sortedTeams)     
                {
                    Console.WriteLine("("+ iPosition + ")\t" + team.name);
                    iPosition++;
                }

                // User inputs the Home Team
                Console.Write("\nChoose the team number of the home team: ");
                    string sHomeTeam = Console.ReadLine();
                    int HomeTeamIndex = CheckInteger(sHomeTeam) - 1;
                    sHomeTeam = sortedTeams[HomeTeamIndex].name;

                // User inputs the Visitting Team
                Console.Write("Choose the team number of the visitting team: ");
                string sVisittingTeam = Console.ReadLine();
                int VisittingTeamIndex = CheckInteger(sVisittingTeam) - 1;
                sVisittingTeam = sortedTeams[VisittingTeamIndex].name;


               game oSeasonGame = new game(sHomeTeam, sVisittingTeam);  //Creates new Game Object


                //determine the winner of the game
                oSeasonGame.CompleteGame(sortedTeams[HomeTeamIndex], sortedTeams[VisittingTeamIndex]);

                //User's input if they want to play another game
                Console.Write("\nPlay another season game? (Y/N): ");
                gameDecision = Console.ReadLine();
                gameDecision = UppercaseFirst(gameDecision);
                Y_N = gameDecision[0];

                // If No, program prints the season results
                if (Y_N == 'N')
                {
                    Console.WriteLine("\nSeason Results:\n");
                    Console.WriteLine("Team".PadRight(25, ' ') + "Games".PadRight(15, ' ') + "Wins".PadRight(15, ' ') + "Losses");
                    Console.WriteLine("----".PadRight(25, ' ') + "----".PadRight(15, ' ') + "----".PadRight(15, ' ') + "------");

                    foreach (SoccerTeam team in sortedTeams)
                    {
                        string sGames = Convert.ToString(team.games);
                        string sWins = Convert.ToString(team.wins);
                        string sLoss = Convert.ToString(team.loss);

                        Console.WriteLine(team.name.PadRight(25, ' ') + sGames.PadRight(15, ' ') + sWins.PadRight(15, ' ') + sLoss);
                        
                    }
  
                    PlayGame = false;
                }
            }


                Console.Read();
        }
    }
}

