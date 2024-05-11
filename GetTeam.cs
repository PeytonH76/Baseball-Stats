using Newtonsoft.Json;

namespace BaseballStats;
public class GetTeam: GatherData
{
    public override async  Task<string> GetInfo(int team_id, int season_id){
        using (var httpClient = new HttpClient())
        {
            // Convert season_id to current year
            season_id = CurrentDate(season_id);
            
            // Create a new HTTP Request message to get team info
            var request1 = new HttpRequestMessage
            {
                // URL has the API endpoint along with any other parameters
                RequestUri = new Uri($"https://v1.baseball.api-sports.io/teams/statistics?league=1&season={season_id}&team={team_id}"),
                Method = HttpMethod.Get,
            };
            
            // Add header to get permission to use API
            AddHeader(request1);

            var response = await httpClient.SendAsync(request1);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                //return content;
                var teamCollection = JsonConvert.DeserializeObject<TeamCollection>(content);
                
                if (teamCollection != null && teamCollection.Response != null)
                {
                    // Get the points differential for a team
                    var pointsFor = teamCollection.Response.Points.For.Total.All;
                    var pointsAgainst = teamCollection.Response.Points.Against.Total.All;
                    var differentialInt = pointsFor - pointsAgainst;
                    string differential;
                    // Give the differential a '+' if positive
                    if (differentialInt >= 0)
                    {
                        differential = $"+{differentialInt}";
                    }
                    // Give the differential a '-' if negative
                    else
                    {
                        differential = $"-{differentialInt}";
                    }

                    string result = $"{season_id} {teamCollection.Response.Team.Name}: \n" +
                                    $"Games: \n" +
                                    $"         Games Played: {teamCollection.Response.Games.Played.All} \n" +
                                    $"                 Wins: {teamCollection.Response.Games.Wins.All.Total} \n" +
                                    $"                Loses: {teamCollection.Response.Games.Loses.All.Total} \n" +
                                    $"   Winning Percentage: {teamCollection.Response.Games.Wins.All.Percentage} \n" +
                                    $"Points: \n" +
                                    $"           Points For: {teamCollection.Response.Points.For.Total.All} \n" +
                                    $"       Points Against: {teamCollection.Response.Points.Against.Total.All} \n" +
                                    $"  Points Differential: {differential} \n" +
                                    $" \n" +
                                    $" \n" +
                                    $" \n" +
                                    $"Advanced Team Stats: \n" +
                                    $"Games: \n" +
                                    $"            Home Wins: {teamCollection.Response.Games.Wins.Home.Total} \n" +
                                    $"           Home Loses: {teamCollection.Response.Games.Loses.Home.Total} \n" +
                                    $"                Total: {teamCollection.Response.Games.Played.Home} \n" +
                                    $"            Away Wins: {teamCollection.Response.Games.Wins.Away.Total} \n" +
                                    $"           Away Loses: {teamCollection.Response.Games.Loses.Away.Total} \n" +
                                    $"                Total: {teamCollection.Response.Games.Played.Away} \n" +
                                    $"            Home Win%: {teamCollection.Response.Games.Wins.Home.Percentage} \n" +
                                    $"            Away Win%: {teamCollection.Response.Games.Wins.Away.Percentage} \n" +
                                    $"Points: \n" +
                                    $"      Points Per Game: {teamCollection.Response.Points.For.Average.All} \n" +
                                    $"     Against Per Game: {teamCollection.Response.Points.Against.Average.All} \n" +
                                    $"    Total Points Home: {teamCollection.Response.Points.For.Total.Home} \n" +
                                    $"    Total Points Away: {teamCollection.Response.Points.For.Total.Away} \n" +
                                    $"   Total Against Home: {teamCollection.Response.Points.Against.Total.Home} \n" +
                                    $"   Total Against Away: {teamCollection.Response.Points.Against.Total.Away} \n" +
                                    $"         Home Average: {teamCollection.Response.Points.For.Average.Home} \n" +
                                    $"         Away Average: {teamCollection.Response.Points.For.Average.Away} \n" +
                                    $" Home Against Average: {teamCollection.Response.Points.Against.Average.Home} \n" +
                                    $" Away Against Average: {teamCollection.Response.Points.Against.Average.Away} \n";
                    return result;
                }
            }
        }
        return "";
    }
}