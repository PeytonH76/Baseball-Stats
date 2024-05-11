using Newtonsoft.Json;

namespace BaseballStats;
public class GetTeams: GatherData
{
    private string american = "American League";
    private string national = "National League";
    public override async  Task<string> GetInfo(int team_id, int season_id){
        using (var httpClient = new HttpClient())
        {
            // Convert season_id to current year
            season_id = CurrentDate(season_id);
            
            // Create a new HTTP Request message to get team info
            var request1 = new HttpRequestMessage
            {
                // URL has the API endpoint along with any other parameters
                RequestUri = new Uri($"https://v1.baseball.api-sports.io/teams?league=1&season={season_id}"),
                Method = HttpMethod.Get, // Sets HTTP method to GET
            };
            
            // Add header to get permission to use API
            AddHeader(request1);
            
            var response = await httpClient.SendAsync(request1);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                //return content;
                var teamCollection = JsonConvert.DeserializeObject<TeamsNamesCollection>(content);

                
                if (teamCollection != null && teamCollection.Response != null && teamCollection.Response.Count > 0)
                {
                    string teamNames = "";
                    
                    // Print out each team instance    
                    foreach (var team in teamCollection.Response)
                    {
                        // Get rid of 'American League' and 'National League'
                        if (team.Name != american)
                        {
                            if (team.Name != national)
                            {
                                teamNames += team.Name + "\n";
                            }
                        }
                    }
                        
                    return teamNames;
                }
            }
        }
        return "";
    }
}