using System;

namespace Data
{
    [Serializable]
    public class PlayerProgress
    {
        public State HeroState;
        public WorldData WorldData;

        public PlayerProgress(string initialLevel)
        {
            HeroState = new State();
            WorldData = new WorldData(initialLevel);
        }
        
    }
}
