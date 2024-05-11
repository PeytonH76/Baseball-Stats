
namespace BaseballStats;

public abstract class GatherData
{
    // APIKey and APIHost in order to get server data
    protected const string ApiKey = "2266020eb2c3ca5360da62f51b138ceb";
    protected const string ApiHost = "v1.baseball.api-sports.io";
    
    public abstract Task<string> GetInfo(int team_id, int season_id);

    // Get the current date
    public int CurrentDate(int season_id)
    {
        if (season_id == 0)
        {
            season_id = DateTime.Now.Year;
        }
        return season_id;
    }

    // Add the headers to get access to server
    public void AddHeader(HttpRequestMessage request1)
    {
        request1.Headers.Add("x-rapidapi-key", ApiKey);
        request1.Headers.Add("x-rapidapi-host", ApiHost);
    }
}