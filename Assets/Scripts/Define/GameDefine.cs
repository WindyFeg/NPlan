namespace LTK268.Define
{
    #region Game Define
    
    public enum Season
    {
        Spring = 0,
        Summer = 1,
        Autumn = 2,
        Winter = 3,
    }
    
    #endregion

    #region Enemy

    public enum EnemyPhase
    {
        None = -1,
        Normal = 0,
        Special = 1,
        Ultimate = 2, // further development
    }
    
    #endregion
    
    
    public class TextSize
    {
        // Create constants for the text size
        public const float Small = 14f;
        public const float Medium = 18f;
        public const float Large = 24f;
        public const float ExtraLarge = 32f;
    }
}