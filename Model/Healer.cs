using System.Drawing;

namespace ActCurseTracker.Model
{
    public class Healer
    {
        public static readonly int DEFAULT_RECAST = 60;
        public static readonly string DEFAULT_GROUP = "Default";
        public static readonly Color DEFAULT_COLOUR = Color.RoyalBlue;

        public string Name { get; set; }
        public string Group { get; set; }
        public int RecastSeconds { get; set; }
        public bool Active { get; set; }
        public bool Pinned { get; set; }
        public Color Colour { get; set; }

        public Healer()
        {
            Colour = DEFAULT_COLOUR;
            Group = DEFAULT_GROUP;
        }

        public Healer(Healer copy)
        {
            Name = copy.Name;
            Group = copy.Group;
            RecastSeconds = copy.RecastSeconds;
            Active = copy.Active;
            Pinned = copy.Pinned;
            Colour = copy.Colour;
        }
    }
}
