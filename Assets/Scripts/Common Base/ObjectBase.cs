using LKT268.Interface;
using LKT268.Utils;
using UnityEngine;

namespace LKT268.Model.CommonBase
{
    public class ObjectBase : EntityBase, IObject
    {
        #region Private Field
        [Header("Object Unique Stats")]
        [SerializeField] int xPosStart;
        [SerializeField] int yPosStart;
        [SerializeField] int xPosEnd;
        [SerializeField] int yPosEnd;
        #endregion

        #region Public Properties
        public int XPosStart { get; set; }
        public int YPosStart { get; set; }
        public int XPosEnd { get; set; }
        public int YPosEnd { get; set; }
        #endregion

        #region Public Constructors
        public ObjectBase(int id, string name, int maxHealth, int level, int damage) : base(id, name, maxHealth, level, damage)
        {
        }
        #endregion

        #region Public Methods
        public EntityType GetEntityType() => EntityType.Object;
        public new void InteractWithEntity(IEntity target)
        {
            OnInteractedByEntity(target);
        }

        public bool IsHuman()
        {
            throw new System.NotImplementedException();
        }

        public new void OnInteractedByEntity(IEntity target)
        {
            LTK268Log.LogNotImplement(this);
        }

        public void Spawn()
        {
            Instantiate(this, new Vector3(xPosStart, yPosStart, 0), Quaternion.identity);
        }

        public void Destroy()
        {
            LTK268Log.LogNotImplement(this);
        }

        public void Use()
        {
            LTK268Log.LogNotImplement(this);
        }

        public void Inspect()
        {
            LTK268Log.LogNotImplement(this);
        }

        public void Dead()
        {
            LTK268Log.LogNotImplement(this);
        }
        #endregion
    }
}