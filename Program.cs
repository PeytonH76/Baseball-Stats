
namespace BaseballStats;

class Program
{
    static async Task Main(string[] args)
    {
        var stats = new GetTeam();
        var teams = new GetTeams();
        var standings = new GetStandings();
        //var games = new GetGames();
        
        Console.WriteLine("Welcome to the baseball stats collector.");
        Console.WriteLine("Here are some stats you can request:");
        Console.WriteLine("1. Team Stats");
        Console.WriteLine("2. List Teams");
        Console.WriteLine("3. Standings");
        string choice = Console.ReadLine();

        // Get team stats
        if (choice == "1" || choice == "one")
        {
            Console.WriteLine("What team do you want?");
            string team = Console.ReadLine();
            Console.WriteLine("Did you want a previous season?(If yes use a similar format and enter '2019'. If no enter 0)");
            Console.WriteLine("Note this data includes spring training and the postseason.");
            string season = Console.ReadLine();
            // Turn season string into an int for the API to work
            int season_id = int.Parse(season);
            Console.WriteLine();
            if (team == "Arizona Diamondbacks" || team == "Diamondbacks")
            {
                int team_id = 2;
                string info = await stats.GetInfo(team_id, season_id);
                Console.WriteLine(info);
            }            
            else if (team == "Atlanta Braves" || team == "Braves")
            {
                int team_id = 3;
                string info = await stats.GetInfo(team_id, season_id);
                Console.WriteLine(info);
            }            
            else if (team == "Baltimore Orioles" || team == "Orioles")
            {
                int team_id = 4;
                string info = await stats.GetInfo(team_id, season_id);
                Console.WriteLine(info);
            }            
            else if (team == "Boston Red Sox" || team == "Red Sox")
            {
                int team_id = 5;
                string info = await stats.GetInfo(team_id, season_id);
                Console.WriteLine(info);
            }            
            else if (team == "Chicago Cubs" || team == "Cubs")
            {
                int team_id = 6;
                string info = await stats.GetInfo(team_id, season_id);
                Console.WriteLine(info);
            }            
            else if (team == "Chicago White Sox" || team == "White Sox")
            {
                int team_id = 7;
                string info = await stats.GetInfo(team_id, season_id);
                Console.WriteLine(info);
            }            
            else if (team == "Cincinnati Reds" || team == "Reds")
            {
                int team_id = 8;
                string info = await stats.GetInfo(team_id, season_id);
                Console.WriteLine(info);
            }            
            else if (team == "Cleveland Indians" || team == "Indians" || team == "Cleveland Guardians" || team == "Guardians")
            {
                int team_id = 9;
                string info = await stats.GetInfo(team_id, season_id);
                Console.WriteLine(info);
            }
            else if (team == "Colorado Rockies" || team == "Rockies")
            {
                int team_id = 10;
                string info = await stats.GetInfo(team_id, season_id);
                Console.WriteLine(info);
            }            
            else if (team == "Detroit Tigers" || team == "Tigers")
            {
                int team_id = 12;
                string info = await stats.GetInfo(team_id, season_id);
                Console.WriteLine(info);
            }            
            else if (team == "Houston Astros" || team == "Astros")
            {
                int team_id = 15;
                string info = await stats.GetInfo(team_id, season_id);
                Console.WriteLine(info);
            }            
            else if (team == "Kansas City Royals" || team == "Royals")
            {
                int team_id = 16;
                string info = await stats.GetInfo(team_id, season_id);
                Console.WriteLine(info);
            }            
            else if (team == "Los Angeles Angels" || team == "Angels")
            {
                int team_id = 17;
                string info = await stats.GetInfo(team_id, season_id);
                Console.WriteLine(info);
            }            
            else if (team == "Los Angeles Dodgers" || team == "Dodgers")
            {
                int team_id = 18;
                string info = await stats.GetInfo(team_id, season_id);
                Console.WriteLine(info);
            }            
            else if (team == "Miami Marlins" || team == "Marlins")
            {
                int team_id = 19;
                string info = await stats.GetInfo(team_id, season_id);
                Console.WriteLine(info);
            }            
            else if (team == "Milwaukee Brewers" || team == "Brewers")
            {
                int team_id = 20;
                string info = await stats.GetInfo(team_id, season_id);
                Console.WriteLine(info);
            }            
            else if (team == "Minnesota Twins" || team == "Twins")
            {
                int team_id = 22;
                string info = await stats.GetInfo(team_id, season_id);
                Console.WriteLine(info);
            }            
            else if (team == "New York Mets" || team == "Mets")
            {
                int team_id = 24;
                string info = await stats.GetInfo(team_id, season_id);
                Console.WriteLine(info);
            }            
            else if (team == "New York Yankess" || team == "Yankees")
            {
                int team_id = 25;
                string info = await stats.GetInfo(team_id, season_id);
                Console.WriteLine(info);
            }            
            else if (team == "Oakland Athletics" || team == "Athletics" || team == "A's")
            {
                int team_id = 26;
                string info = await stats.GetInfo(team_id, season_id);
                Console.WriteLine(info);
            }            
            else if (team == "Philadelphia Phillies" || team == "Phillies")
            {
                int team_id = 27;
                string info = await stats.GetInfo(team_id, season_id);
                Console.WriteLine(info);
            }            
            else if (team == "Pittsburgh Pirates" || team == "Pirates")
            {
                int team_id = 28;
                string info = await stats.GetInfo(team_id, season_id);
                Console.WriteLine(info);
            }            
            else if (team == "San Diego Padres" || team == "Padres")
            {
                int team_id = 30;
                string info = await stats.GetInfo(team_id, season_id);
                Console.WriteLine(info);
            }            
            else if (team == "San Francisco Giants" || team == "Giants")
            {
                int team_id = 31;
                string info = await stats.GetInfo(team_id, season_id);
                Console.WriteLine(info);
            }            
            else if (team == "Seattle Mariners" || team == "Mariners")
            {
                int team_id = 32;
                string info = await stats.GetInfo(team_id, season_id);
                Console.WriteLine(info);
            }            
            else if (team == "St.Louis Cardinals" || team == "Cardinals")
            {
                int team_id = 33;
                string info = await stats.GetInfo(team_id, season_id);
                Console.WriteLine(info);
            }            
            else if (team == "Tampa Bay Rays" || team == "Rays")
            {
                int team_id = 34;
                string info = await stats.GetInfo(team_id, season_id);
                Console.WriteLine(info);
            }            
            else if (team == "Texas Rangers" || team == "Rangers")
            {
                int team_id = 35;
                string info = await stats.GetInfo(team_id, season_id);
                Console.WriteLine(info);
            }            
            else if (team == "Toronto Blue Jays" || team == "Blue Jays" || team == "Jays")
            {
                int team_id = 36;
                string info = await stats.GetInfo(team_id, season_id);
                Console.WriteLine(info);
            }            
            else if (team == "Washington Nationals" || team == "Nationals")
            {
                int team_id = 37;
                string info = await stats.GetInfo(team_id, season_id);
                Console.WriteLine(info);
            }                
        }
        // Get a list of teams
        else if (choice == "2" || choice == "two")
        {
            var teamsList = await teams.GetInfo(0, 0);
            Console.WriteLine(teamsList);
        }
        // Get a seasons standings 
        else if (choice == "3" || choice == "three")
        {
            Console.WriteLine("What season do you want?(0 for current season)");
            string season = Console.ReadLine();
            // Turn string season into an int
            int season_id = int.Parse(season);
            var standingsList = await standings.GetInfo(0, season_id);
            Console.WriteLine(standingsList);
        }
    }
}