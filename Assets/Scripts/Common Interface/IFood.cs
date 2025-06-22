namespace LKT268.Interface
{
    public interface IFood : IObject
    {
        void EatenBy(IEntity entity);
        void PickedUpBy(IEntity entity);
        void DroppedBy(IEntity entity);
    }
}