using System.Runtime.InteropServices.JavaScript;
using Newtonsoft.Json;
// This code is not part of the assignment.  It is for later
//
//
//
//
//
//
//
//
//
//
namespace BaseballStats;

public class GetGames : GatherData
{
    public override async Task<string> GetInfo(int team_id, int season_id)
    {
        using (var httpClient = new HttpClient())
        {
            var currentDate = DateTime.Now;
            string formattedDate = currentDate.ToString("dd/MM/yyyy");
            Console.WriteLine(formattedDate);
            season_id = CurrentDate(season_id);
            var request1 = new HttpRequestMessage
            {
                RequestUri = new Uri($"https://v1.baseball.api-sports.io/games?league=1&season={season_id}&date={formattedDate}"),
                Method = HttpMethod.Get,
            };

            AddHeader(request1);

            var response = await httpClient.SendAsync(request1);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                //return content;
                var standingCollection = JsonConvert.DeserializeObject<GetStandingCollection>(content);

                if (standingCollection != null && standingCollection.Response != null && standingCollection.Response.Count > 0)
                {
                    string americanLeagueTeams = "\n American League: \n \n";
                    string nationalLeagueTeams = "\n National League: \n \n";
                        
                    foreach (var innerList in standingCollection.Response)
                    {
                        foreach (var team in innerList)
                        {
                            if (team.Group != null && team.Team != null)
                            {
                                if (team.Group.Name == "American League")
                                {
                                    americanLeagueTeams += $"{team.Team.Name}: \n " +
                                                           $"GP:{team.Games.Played} W:{team.Games.Win.Total} L:{team.Games.Lose.Total} W%:{team.Games.Win.Percentage} \n";
                                }

                                if (team.Group.Name == "National League")
                                {
                                    nationalLeagueTeams += $"{team.Team.Name}: \n " +
                                                           $"GP:{team.Games.Played} W:{team.Games.Win.Total} L:{team.Games.Lose.Total} W%:{team.Games.Win.Percentage} \n";
                                }
                            }
                        }
                    }
                    return americanLeagueTeams + nationalLeagueTeams;
                }
            }
        }

        return "";
    }
}