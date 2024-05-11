using Newtonsoft.Json;

namespace BaseballStats;

public class GetStandings : GatherData
{
    public override async Task<string> GetInfo(int team_id, int season_id)
    {
        using (var httpClient = new HttpClient())
        {
            // Convert season_id to current year
            season_id = CurrentDate(season_id);
            
            // Create a new HTTP Request message to get team info
            var request1 = new HttpRequestMessage
            {
                // URL has the API endpoint along with any other parameters
                RequestUri = new Uri($"https://v1.baseball.api-sports.io/standings?league=1&season={season_id}"),
                Method = HttpMethod.Get,
            };

            // Add header to get permission to use API
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
                    
                    // Needed to create a list within a list so had to create to loop statements to make it work    
                    foreach (var innerList in standingCollection.Response)
                    {
                        foreach (var team in innerList)
                        {
                            // Checking that there is no empty data
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