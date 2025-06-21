using LKT268.Interface;
using LKT268.Utils;
using UnityEngine;

namespace LKT268.Model.CommonBase
{
    public class ObjectBase : EntityBase, IObject
    {
        #region Private Field
        [SerializeField] int xPos;
        [SerializeField] int yPos;
        #endregion

        #region Public Properties
        public int XPos { get; set; }
        public int YPos { get; set; }
        #endregion

        #region Public Constructors
        public ObjectBase(int id, string name, int maxHealth, int level, int damage) : base(id, name, maxHealth, level, damage)
        {
        }
        #endregion

        #region Public Properties
        public EntityType GetEntityType() => EntityType.Object;
        public void InteractWithEntity(IEntity target)
        {
            OnInteractedByEntity(target);
        }

        public void InteractWithObject(IEntity target)
        {
            OnInteractedByObject(target);
        }

        public bool IsHuman()
        {
            throw new System.NotImplementedException();
        }

        public void OnInteractedByEntity(IEntity target)
        {
            LTK268Log.LogNotImplement(this);
        }

        public void OnInteractedByObject(IEntity target)
        {
            LTK268Log.LogNotImplement(this);
        }

        public void Spawn()
        {
            Instantiate(this, new Vector3(xPos, yPos, 0), Quaternion.identity);
        }

        public void Destroy()
        {
            LTK268Log.LogNotImplement(this);
        }
        #endregion
    }
}