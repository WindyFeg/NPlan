using LKT268.Utils;
using UnityEngine;

namespace LKT268.Manager
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
                AmbienceManager = FindFirstObjectByType<AmbienceManager>();
            }
            if (SaveManager == null)
            {
                SaveManager = FindFirstObjectByType<SaveManager>();
            }
            if (EventManager == null)
            {
                EventManager = FindFirstObjectByType<EventManager>();
            }
            if (ProgressionManager == null)
            {
                ProgressionManager = FindFirstObjectByType<ProgressionManager>();
            }
            if (EnemyManager == null)
            {
                EnemyManager = FindFirstObjectByType<EnemyManager>();
            }
            if (PopupManager == null)
            {
                PopupManager = FindFirstObjectByType<PopupManager>();
            }
            if (SceneManager == null)
            {
                SceneManager = FindFirstObjectByType<SceneManager>();
            }

            if (AmbienceManager == null)
            {
                LTK268Log.ManagerError("AmbienceManager is missing!", nameof(GameManager));
            }
            if (SaveManager == null)
            {
                LTK268Log.ManagerError("SaveManager is missing!", nameof(SaveManager));
            }
            if (EventManager == null)
            {
                LTK268Log.ManagerError("EventManager is missing!", nameof(EventManager));
            }
            if (ProgressionManager == null)
            {
                LTK268Log.ManagerError("ProgressionManager is missing!", nameof(ProgressionManager));
            }
            if (EnemyManager == null)
            {
                LTK268Log.ManagerError("EnemyManager is missing!", nameof(EnemyManager));
            }
            if (PopupManager == null)
            {
                LTK268Log.ManagerError("PopupManager is missing!", nameof(PopupManager));
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