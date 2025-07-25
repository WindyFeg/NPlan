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
        private int nextId = 1;

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
            if (player == null)
            {
                LTK268Log.ManagerError("RegisterPlayer: Player parameter is null");
                return;
            }

            if (playerModel == null)
            {
                // Check if entity already has an ID
                if (player.Id == 0)
                {
                    // Assign next available ID
                    player.Id = GetNextAvailableId();
                    LTK268Log.ManagerLog($"Player registered with new ID: {player.Id} - {player.Name}");
                }
                else
                {
                    // Entity already has an ID, use it
                    LTK268Log.ManagerLog($"Player registered with existing ID: {player.Id} - {player.Name}");
                }

                playerModel = player;
            }
            else
            {
                LTK268Log.ManagerError($"Player is already registered: {playerModel.Name}");
            }
        }

        public void UnregisterPlayer(PlayerModel player)
        {
            if (player == null)
            {
                LTK268Log.ManagerError("UnregisterPlayer: Player parameter is null");
                return;
            }

            if (playerModel == player)
            {
                LTK268Log.ManagerLog($"Player unregistered: {player.Name}");
                playerModel = null;
            }
            else
            {
                LTK268Log.ManagerError($"Player is not registered: {player.Name}");
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

        /// <summary>
        /// Gets the next available ID by finding the highest ID and adding 1
        /// </summary>
        /// <returns>The next available ID</returns>
        private int GetNextAvailableId()
        {
            // For PlayerManager, we only have one player, so we can use a simple approach
            // If playerModel exists and has an ID, return that ID + 1, otherwise return 1
            if (playerModel != null && playerModel.Id > 0)
            {
                return playerModel.Id + 1;
            }
            return 1;
        }
        #endregion
    }
}