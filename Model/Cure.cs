using System;

namespace ActCurseTracker.Model
{
    public class Cure
    {
        public DateTime Time { get; set; }
        public string Healer { get; set; }
        public string Victim { get; set; }
        public string Curse { get; set; }
    }
}
