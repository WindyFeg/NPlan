namespace LKT268.Interface
{
    /// <summary>
    /// Interface for human control, extending IEntityControl.
    /// </summary>
    public interface IHumanControl : IEntityControl
    {

    }

    public interface IHumanCommonChecking
    {
        /// <summary>
        /// Use to check if that NPC is an Functional NPC()
        /// </summary>
        /// <returns></returns>
        public bool IsHuman();
    }

    public interface IHuman : IHumanCommonChecking, IHumanControl { }
}