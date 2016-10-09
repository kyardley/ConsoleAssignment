using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleAssignment
{
        //Create Classes
        /*
         *Class: Team
         *Properties name, wins, losses
         */
        public class Team
        {
            //initiate attributes
            public string name;
            public int wins;
            public int loss;

            
        };

        /*
         *Class: SoccerTeam
         *Attributes: draw, goalsFor, goalsAgainst, differential, points, games
         */
        public class SoccerTeam : Team
        {
            private int draw;
            private int goalsFor;
            private int goalsAgainst;
            private int differential;
            public int points;
            public int games;



            public SoccerTeam(string sName, int iPoints)
            {
                this.name = sName;
                this.points = iPoints;
                this.games = 0;
                this.wins = 0;
                this.loss = 0;
            }

            public void updategames()
            {
                this.games++;
            }

            public void updatewins()
            {
                this.wins++;
            }

            public void updateloss()
            {
                this.loss++;
            }

        };

        /*
         * Class: Game
         * Attributes: homeTeam, visittingTeam.
         */
        public class game
        {
            public string homeTeam;
            public string visittingTeam;


            public game(string sHomeTeam, string sVisittingTeam)
            {
                this.homeTeam = sHomeTeam;
                this.visittingTeam = sVisittingTeam;
            }

            public  void CompleteGame(SoccerTeam oHomeTeam, SoccerTeam oVisittingTeam)
            {
                //Updates the game count for Home and Visitting team
                oHomeTeam.updategames();
                oVisittingTeam.updategames();

                //Gets random number to determine winner
                Random random = new Random();
                int rand = random.Next(0, 2);
                
                
                if (rand == 0) //Home Team wins and updates the wins and losses for each team
                {
                   
                    Console.WriteLine("\n" + oHomeTeam.name + " won!");
                    oHomeTeam.updatewins();
                    oVisittingTeam.updateloss();
                }
                else //Visitting team wins and updates the wins and losses for each team
                {
                    Console.WriteLine("\n" + oVisittingTeam.name + " won!");
                    oVisittingTeam.updatewins();
                    oHomeTeam.updateloss();
   
                }


            }
        };
}
