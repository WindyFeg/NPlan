using LKT268.Model.CommonBase;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerBehavior playerBehavior;
    void Start()
    {
        playerBehavior = new PlayerBehavior(1, "Player", 100, 1, 10);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
