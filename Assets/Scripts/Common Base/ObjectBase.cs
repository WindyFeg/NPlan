using Common_Utils;
using DG.Tweening;
using LTK268.Interface;
using LTK268.Manager;
using LTK268.Utils;
using UnityEngine;

namespace LTK268.Model.CommonBase
{
    public class ObjectBase : EntityBase, IObject
    {
        #region Private Field
        [Header("Object Unique Stats")]
        [SerializeField] int xPosStart;
        [SerializeField] int yPosStart;
        [SerializeField] int xPosEnd;
        [SerializeField] int yPosEnd;
        [SerializeField] private ObjectData objectData;
        #endregion

        #region Public Properties
        public int XPosStart { get; set; }
        public int YPosStart { get; set; }
        public int XPosEnd { get; set; }
        public int YPosEnd { get; set; }
        public ObjectData ObjectData
        {
            get => objectData;
            set => objectData = value;
        }
        #endregion

        #region Public Constructors
        public ObjectBase(int id, string name, int maxHealth, int level, int damage) : base(id, name, maxHealth, level, damage)
        {
        }
        #endregion

        #region Public Unity Methods
        void Start()
        {
            if (objectData == null)
            {
                Debug.LogError("ObjectData is not assigned in ObjectBase.");
                return;
            }

            // Message bus
            // MessageBus.Subscribe<ObjectData>(OnObjectDataReceived);
        }
        void OnValidate()
        {
            if (!gameObject.CompareTag("Object"))
            {
                gameObject.tag = "Object";
            }
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

        public void PickedUpBy(IHuman entity)
        {
            // Add hold to target entity
            entity.AddHoldItem(this.gameObject);

            // Update into PlayerManager
            PlayerManager.Instance.ListOfObjects.Add(this.gameObject);
            LTK268Log.LogEntityAction(this, $"Picked up by {entity}");
            this.transform.DOScale(this.transform.localScale * 1.2f, 0.2f).OnComplete(() =>
            {
                this.transform.DOScale(Vector3.zero, 0.2f).OnComplete(() =>
                {
                    this.gameObject.SetActive(false);
                });

            });

        }

        public void DroppedBy(IHuman entity)
        {
            throw new System.NotImplementedException();
        }

        public void HoverBy(IHuman entity)
        {
            //Looping
        }

        #endregion
    }
}