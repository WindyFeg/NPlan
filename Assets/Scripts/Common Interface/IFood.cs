namespace LTK268.Interface
{
    public interface IFood : IObject
    {
        /// <summary>
        /// Use to called by entity that require consume food
        /// </summary>
        /// <param name="entity"></param>
        void EatenBy(IEntity entity);
        /// <summary>
        /// called when player needed to pick this up
        /// </summary>
        /// <param name="entity"></param>
        void PickedUpBy(IEntity entity);
        /// <summary>
        /// Drop this current object
        /// </summary>
        /// <param name="entity"></param>
        void DroppedBy(IEntity entity);
    }
}