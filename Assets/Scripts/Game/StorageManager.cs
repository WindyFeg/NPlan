using UnityEngine;
using LTK268.Utils;
// public enum ResourceType
// {
//     Wood,
//     Stone,
//     Food,
//     Blueprint
// }
public class StorageManager : MonoBehaviour
{
    public int wood = 0;
    public int stone = 0;
    public int food = 0;
    public static StorageManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void UpdateResource(int amount, ResourceType type)
    {
        switch (type)
        {
            case ResourceType.Wood:
                wood += amount;
                break;
            case ResourceType.Stone:
                stone += amount;
                break;
            case ResourceType.Food:
                food += amount;
                break;

        }
    }
}
