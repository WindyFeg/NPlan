using System.Collections.Generic;
using DG.Tweening;
using LTK268.Model.CommonBase;
using LTK268.Utils;
using UnityEngine;

namespace LTK268.Manager
{
    public class ResourceManager : IDManager<ObjectBase>
    {
        #region Public Properties
        public static ResourceManager Instance { get; private set; }
        public List<ObjectBase> ObjectBases => objectBase;
        #endregion

        #region Private Properties
        [SerializeField] private List<ObjectBase> objectBase = new List<ObjectBase>();
        #endregion

        #region Unity Methods
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Call this from ObjectBase's Awake/OnEnable
        /// </summary>
        /// <param name="npc"></param>
        public void RegisterObject(ObjectBase obj)
        {
            RegisterEntity(obj);
        }

        /// <summary>
        /// Call this from ObjectBase's OnDisable/OnDestroy
        /// </summary>
        /// <param name="npc"></param>
        public void UnRegisterObject(ObjectBase obj)
        {
            UnregisterEntity(obj);
        }
        #endregion
    }
}