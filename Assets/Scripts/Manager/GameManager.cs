using LTK268.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    // public AmbienceManager AmbienceManager { get; private set; }
    // public SaveManager SaveManager { get; private set; }
    // public EventManager EventManager { get; private set; }
    // public ProgressionManager ProgressionManager { get; private set; }
    // public EnemyManager EnemyManager { get; private set; }
    // public PopupManager PopupManager { get; private set; }
    // public SceneManager SceneManager { get; private set; }
    // public TutorialManager TutorialManager { get; private set; }
    // public PlayerManager PlayerManager { get; private set; }
    // public NpcManager NpcManager { get; private set; }
    // public BuildingManager BuildingManager { get; private set; }

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
        // if (AmbienceManager == null)
        // {
        //     AmbienceManager = FindObjectOfType<AmbienceManager>();
        // }
        // if (SaveManager == null)
        // {
        //     SaveManager = FindObjectOfType<SaveManager>();
        // }
        // if (EventManager == null)
        // {
        //     EventManager = FindObjectOfType<EventManager>();
        // }
        // if (ProgressionManager == null)
        // {
        //     ProgressionManager = FindObjectOfType<ProgressionManager>();
        // }
        // if (EnemyManager == null)
        // {
        //     EnemyManager = FindObjectOfType<EnemyManager>();
        // }
        // if (PopupManager == null)
        // {
        //     PopupManager = FindObjectOfType<PopupManager>();
        // }
        // if (SceneManager == null)
        // {
        //     SceneManager = FindObjectOfType<SceneManager>();
        // }
        //
        // if (AmbienceManager == null)
        // {
        //     LTK268Log.ManagerError("AmbienceManager is missing!", this);
        // }
        // if (SaveManager == null)
        // {
        //     LTK268Log.ManagerError("SaveManager is missing!", this);
        // }
        // if (EventManager == null)
        // {
        //     LTK268Log.ManagerError("EventManager is missing!", this);
        // }
        // if (ProgressionManager == null)
        // {
        //     LTK268Log.ManagerError("ProgressionManager is missing!", this);
        // }
        // if (EnemyManager == null)
        // {
        //     LTK268Log.ManagerError("EnemyManager is missing!", this);
        // }
        // if (PopupManager == null)
        // {
        //     LTK268Log.ManagerError("PopupManager is missing!", this);
        // }
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
        
        // SaveManager.LoadProgressionManager(ref ProgressionManager);
        // SaveManager.LoadBuildingManager(ref BuildingManager);
        // SaveManager.LoadPlayerManager(ref PlayerManager);
        // SaveManager.LoadEnemyManager(ref EnemyManager);
        // SaveManager.LoadEventManager(ref EventManager);
        // SaveManager.LoadNpcManager(ref NpcManager);
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