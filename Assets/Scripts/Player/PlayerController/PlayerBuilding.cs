using System.Linq;
using LTK268.Interface;
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
        var item = playerModel.HoldItems.FirstOrDefault();
        if (item == null) return;
        Debug.Log("OnInteract called with item: " + item.GetComponent<IObject>().Name);
        item.GetComponent<IObject>().Use();


    }
}
