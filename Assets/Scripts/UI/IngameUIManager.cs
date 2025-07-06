using LTK268;
using UnityEngine;


public class IngameUIManager : MonoBehaviour
{
    [SerializeField] private GameObject textPopupPrefab;
    [SerializeField] private GameObject jobListPopupPrefab;
    private void Awake()
    {
        SubscribeEvent();
    }
    private void SubscribeEvent()
    {
    //     this.on(
    //     (int)EventID.Game.OnNPCInteract, () => ShowTextPopup("OnNPCInteract")
    //   );
    }
    /// <summary>
    /// Initializes the Ingame UI Manager.
    /// </summary>
    public void ShowTextPopup(string text)
    {

    }
    public void ShowJobList(string[] jobList)
    {
        
    }
    public void HidePopup()
    {
        Debug.Log("Hide Popup");
    }
}
