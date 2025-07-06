namespace LKT268.Interface
{
    public interface IEnemy : IAnimal
    {
    }

    public interface IEnemyDefender : IEnemy
    {
        /// <summary>
        /// Called when other enemy detect danger 
        /// </summary>
        void OnAlert();
    }

    public interface IEnemyAttacker : IEnemy
    {
        /// <summary>
        /// Called when other enemy detect danger 
        /// </summary>
        void Looting();
    }

    public interface IEnemyFly
    {

    }

    public interface IEnemyGround
    {

    }

}