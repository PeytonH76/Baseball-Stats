using System.Collections.Generic;

namespace BaseballStats
{
    public class GetStandingCollection
    {
        public List<List<Response1>>? Response { get; set; }
    }

    public class Response1
    {
        public Group? Group { get; set; }
        public Team1? Team { get; set; }
        public Game1? Games { get; set; }
    }

    public class Group
    {
        public string? Name { get; set; }
    }

    public class Team1
    {
        public string? Name { get; set; }
    }

    public class Game1
    {
        public int Played { get; set; }
        public Win1? Win { get; set; }
        public Lose1? Lose { get; set; }
    }

    public class Win1
    {
        public int Total { get; set; }
        public string? Percentage { get; set; }
    }

    public class Lose1
    {
        public int Total { get; set; }
    }
}