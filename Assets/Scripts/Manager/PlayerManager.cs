using System.Collections.Generic;
using DG.Tweening;
using LTK268.Model.CommonBase;
using LTK268.Utils;
using UnityEngine;

namespace LTK268.Manager
{
    [System.Serializable]
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager Instance { get; private set; }

        [SerializeField]
        private List<FoodBase> listOfFoods = new List<FoodBase>();
        [SerializeField]
        private List<ObjectBase> listOfObjects = new List<ObjectBase>();
        [SerializeField]
        private PlayerModel playerModel;

        // Expose lists as public properties for code access
        public List<FoodBase> ListOfFoods => listOfFoods;
        public List<ObjectBase> ListOfObjects => listOfObjects;
        public PlayerModel PlayerModel => playerModel;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }

        #region Public Methods
        public void RegisterPlayer(PlayerModel player)
        {
            if (playerModel == null)
            {
                playerModel = player;
            }
            else
            {
                Debug.LogWarning("Player is already registered.");
            }
        }

        public void UnregisterPlayer(PlayerModel player)
        {
            if (playerModel == player)
            {
                playerModel = null;
            }
            else
            {
                Debug.LogWarning("Player is not registered.");
            }
        }

        public void CameraPanForPlayer(float panSpeed, float tweenDuration)
        {
            if (PlayerModel == null || PlayerModel.EntityView == null)
            {
                LTK268Log.ManagerError("[PlayerManager] CameraPanForPlayer: PlayerModel or EntityView is not assigned.");
                return;
            }
            PlayerModel.EntityView.transform.DORotate(
                        new Vector3(panSpeed * 5, 0, 0),
                        tweenDuration,
                        RotateMode.LocalAxisAdd
                    ).SetEase(Ease.InOutQuad);
        }
        #endregion
    }
}