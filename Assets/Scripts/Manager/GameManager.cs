using LTK268.Utils;
using UnityEngine;

namespace LTK268.Manager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        public AmbienceManager AmbienceManager { get; private set; }
        public SaveManager SaveManager { get; private set; }
        public EventManager EventManager { get; private set; }
        public ProgressionManager ProgressionManager { get; private set; }
        public EnemyManager EnemyManager { get; private set; }
        public PopupManager PopupManager { get; private set; }
        public SceneManager SceneManager { get; private set; }
        public TutorialManager TutorialManager { get; private set; }
        public PlayerManager PlayerManager { get; private set; }
        public NpcManager NpcManager { get; private set; }
        public BuildingManager BuildingManager { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);

            InitializeManagers();
        }

        private void InitializeManagers()
        {
            if (AmbienceManager == null)
            {
                AmbienceManager = GetComponentInChildren<AmbienceManager>();
            }
            if (SaveManager == null)
            {
                SaveManager = GetComponentInChildren<SaveManager>();
            }
            if (EventManager == null)
            {
                EventManager = GetComponentInChildren<EventManager>();
            }
            if (ProgressionManager == null)
            {
                ProgressionManager = GetComponentInChildren<ProgressionManager>();
            }
            if (EnemyManager == null)
            {
                EnemyManager = GetComponentInChildren<EnemyManager>();
            }
            if (PopupManager == null)
            {
                PopupManager = GetComponentInChildren<PopupManager>();
            }
            if (SceneManager == null)
            {
                SceneManager = GetComponentInChildren<SceneManager>();
            }

            if (AmbienceManager == null)
            {
                LTK268Log.ManagerError("AmbienceManager is missing!");
            }
            if (SaveManager == null)
            {
                LTK268Log.ManagerError("SaveManager is missing!");
            }
            if (EventManager == null)
            {
                LTK268Log.ManagerError("EventManager is missing!");
            }
            if (ProgressionManager == null)
            {
                LTK268Log.ManagerError("ProgressionManager is missing!");
            }
            if (EnemyManager == null)
            {
                LTK268Log.ManagerError("EnemyManager is missing!");
            }
            if (PopupManager == null)
            {
                LTK268Log.ManagerError("PopupManager is missing!");
            }
        }

        public void NewGame()
        {
            LTK268Log.ManagerLog("Starting a new game...");
            // Load into the game scene
            // init new player model
            // load tutorial sequences
        }

        public void LoadGame()
        {
            LTK268Log.ManagerLog("Loading game...");
            // load into the game scene (seed if needed)
            // called SaveManager.LoadPlayerModel() -> Flooding data into player 
            // TODO: Implement loading logic for managers here
        }

        public void PauseGame()
        {
            LTK268Log.ManagerLog("Pausing game...");
            // Add logic for pausing the game
        }

        public void ResumeGame()
        {
            LTK268Log.ManagerLog("Resuming game...");
            // Add logic for resuming the game
        }

        public void MenuGame()
        {
            LTK268Log.ManagerLog("Returning to menu...");
            // Add logic for returning to the menu
        }

        public void ExitGame()
        {
            LTK268Log.ManagerLog("Exiting game...");
            Application.Quit();
        }
    }
}