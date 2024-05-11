
namespace BaseballStats;

public class TeamCollection
{
    public Response Response { get; set; }
}

public class Response
{
    public Team Team { get; set; }
    public GamesData Games { get; set; }
    public PointsData Points { get; set; }
}

public class Team
{
    public string Name { get; set; }
}

public class GamesData
{
    public PlayedData Played { get; set; }
    public WinsData Wins { get; set; }
    public LosesData Loses { get; set; }
}

public class PlayedData
{
    public int Home { get; set; }
    public int Away { get; set; }
    public int All { get; set; }
}

public class WinsData
{
    public WinData Home { get; set; }
    public WinData Away { get; set; }
    public WinData All { get; set; }
}

public class WinData
{
    public int Total { get; set; }
    public string Percentage { get; set; }
}

public class LosesData
{
    public LoseData Home { get; set; }
    public LoseData Away { get; set; }
    public LoseData All { get; set; }
}

public class LoseData
{
    public int Total { get; set; }
    public string Percentage { get; set; }
}

public class PointsData
{
    public PointStats For { get; set; }
    public PointStats Against { get; set; }
}

public class PointStats
{
    public PointTotalData Total { get; set; }
    public PointAverageData Average { get; set; }
}

public class PointTotalData
{
    public int Home { get; set; }
    public int Away { get; set; }
    public int All { get; set; }
}

public class PointAverageData
{
    public string Home { get; set; }
    public string Away { get; set; }
    public string All { get; set; }
}

