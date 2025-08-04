// using System.Linq;
// using LTK268.Interface;
// using LTK268.Model.CommonBase;
// using UnityEngine;

// public class PlayerBuilding : MonoBehaviour
// {
//     [SerializeField] private PlayerModel playerModel;
//     void Start()
//     {
//         playerModel = GetComponent<PlayerModel>();
//     }
//     public void OnInteract()
//     {
//         if (playerModel.HoldItems.Count == 0) return;
//         ObjectBase item = playerModel.GetComponent<HumanBase>().RemoveHoldItem().GetComponent<ObjectBase>();
//         if (item.ObjectData.resourceType != ResourceType.Blueprint || item == null)
//         {
//             playerModel.GetComponent<HumanBase>().AddHoldItem(item.gameObject);
//             return;
//         }
//         Debug.Log("OnInteract called with item: " + item.GetComponent<IObject>().Name);
//         item.GetComponent<IObject>().Use();


//     }
// }
