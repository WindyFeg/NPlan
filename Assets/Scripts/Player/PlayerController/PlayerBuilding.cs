using System.Linq;
using UnityEngine;

public class PlayerBuilding : MonoBehaviour
{
    [SerializeField] private PlayerModel playerModel;
    void Start()
    {
        playerModel = GetComponent<PlayerModel>();
    }
    public void OnInteract()
    {
        if (playerModel.HoldItems.Count == 0) return;
        playerModel.HoldItems.First().InteractWithEntity(playerModel);

    }
}
