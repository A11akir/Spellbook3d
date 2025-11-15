using System;

namespace Data
{
    [Serializable]
    public class PositionOnLevel
    {
        public string Level;

        public PositionOnLevel(string level, Vector3Data position)
        {
            Level = level;
            Position = position;
        }

        public Vector3Data Position { get; set; }
    }
}