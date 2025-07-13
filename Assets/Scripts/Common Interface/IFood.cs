namespace LTK268.Interface
{
    public interface IFood : IObject
    {
        /// <summary>
        /// Use to called by entity that require consume food
        /// </summary>
        /// <param name="entity"></param>
        void EatenBy(IEntity entity);
    }
}