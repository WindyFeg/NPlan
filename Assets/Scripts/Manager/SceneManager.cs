using UnityEngine;
using UnityEngine.SceneManagement;
namespace LTK268.Manager
{
    public class SceneManager : MonoBehaviour
    {
        public static SceneManager Instance { get; private set; }

        public string CurrentScene { get; private set; }
        public string PreviousScene { get; private set; }

        protected virtual void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            CurrentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
            PreviousScene = string.Empty;
        }

        public virtual void SwitchScene(string sceneName)
        {
            if (sceneName == CurrentScene)
                return;

            PreviousScene = CurrentScene;
            CurrentScene = sceneName;
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}