namespace LTK268.Interface
{

    public interface IBuilding
    {

        /// <summary>
        /// Defines the basic operations that can be performed on a building entity,
        /// such as building
        /// </summary>
        void Build();
        /// <summary>
        /// Defines the basic operations that can be performed on a building entity,
        /// such as Upgrade
        /// </summary>
        void Upgrade();
        /// <summary>
        /// Defines the basic operations that can be performed on a building entity,
        /// such as Destroy
        /// </summary>
        void Demolish();
        /// <summary>
        /// Defines the basic operations that can be performed on a building entity,
        /// such as moving
        /// </summary>
        void Move();
    }
}