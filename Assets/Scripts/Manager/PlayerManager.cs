using System.Collections.Generic;
using DG.Tweening;
using LTK268.Model.CommonBase;
using LTK268.Utils;
using UnityEngine;

namespace LTK268.Manager
{
    [System.Serializable]
    public class PlayerManager : IDManager<PlayerModel>
    {
        public static PlayerManager Instance { get; private set; }

        [SerializeField]
        private List<GameObject> listOfFoods = new List<GameObject>();
        [SerializeField]
        private List<GameObject> listOfObjects = new List<GameObject>();
        [SerializeField]
        private PlayerModel playerModel;

        // Expose lists as public properties for code access
        public List<GameObject> ListOfFoods => listOfFoods;
        public List<GameObject> ListOfObjects => listOfObjects;
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

        #endregion
    }
}