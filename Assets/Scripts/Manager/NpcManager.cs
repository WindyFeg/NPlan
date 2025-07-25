using System.Collections.Generic;
using DG.Tweening;
using LTK268.Model.CommonBase;
using LTK268.Utils;
using UnityEngine;

namespace LTK268.Manager
{
    public class NpcManager : MonoBehaviour
    {
        #region Public Properties
        public static NpcManager Instance { get; private set; }
        public List<NPCBase> NpcBases => npcBases;
        #endregion

        #region Private Properties
        [SerializeField] private List<NPCBase> npcBases = new List<NPCBase>();
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
        /// Call this from NPCBase's Awake/OnEnable
        /// </summary>
        /// <param name="npc"></param>
        public void RegisterNPC(NPCBase npc)
        {
            EntityIDManager.RegisterEntity(npc, npcBases, "NPC");
        }

        /// <summary>
        /// Call this from NPCBase's OnDisable/OnDestroy
        /// </summary>
        /// <param name="npc"></param>
        public void UnregisterNPC(NPCBase npc)
        {
            EntityIDManager.UnregisterEntity(npc, npcBases, "NPC");
        }

        public void CameraPanForNpcs(float panSpeed, float tweenDuration)
        {
            Debug.Log($"[NpcManager] CameraPanForNpcs: Panning NPCs with speed {panSpeed} and duration {tweenDuration}");
            foreach (var npc in NpcBases)
            {
                if (npc == null || npc.transform == null) continue;

                // Rotate each NPC by the specified pan speed
                try
                {
                    npc.EntityView.transform.DORotate(
                            new Vector3(panSpeed * 5, 0, 0), // Rotate 5 degrees on X, 0 on Y, 0 on Z
                            tweenDuration,
                            RotateMode.LocalAxisAdd // Add this rotation to the current local rotation
                        ).SetEase(Ease.InOutQuad);
                }
                catch (System.Exception)
                {
                    LTK268Log.ManagerError($"[NpcManager] CameraPanForEntities: {npc.name} has no EntityView assigned.");
                }
            }
        }


        #endregion
    }
}