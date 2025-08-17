using UnityEngine;
using UnityEngine.UI;
using TMPro;
using LTK268.Model.CommonBase;

public class InfoPopupController : MonoBehaviour
{
    [SerializeField] private Image infoPopupAvatarImage;
    [SerializeField] private TMP_Text infoPopupInfoText;
    [SerializeField] private Image infoPopupHolding1Image;
    [SerializeField] private Image infoPopupHolding2Image;
    [SerializeField] private GameObject infoPopupContainer;

    public static InfoPopupController Instance;
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

    #region Public Methods
    public void SetInfoPopupController(EntityBase entityBase)
    {
        ShowInfoPopup();
        Debug.Log("Setting InfoPopupController with EntityBase: " + entityBase?.Name);
        if (entityBase == null)
        {
            Debug.LogError("entityBase is null. Cannot set InfoPopupController.");
            return;
        }
    
        SetupAvatar(entityBase);
        SetupHoldItem(entityBase);
        SetupText(entityBase);
    }
    
    public void HideInfoPopup()
    {
        infoPopupContainer.SetActive(false);
    }
    #endregion

    #region Private Methods
    private void ShowInfoPopup()
    {
        infoPopupContainer.SetActive(true);
    }
    
    private void SetupAvatar(EntityBase entityBase)
    {
        Sprite defaultSprite = null;
        try
        {
            if (entityBase is NpcModel npcModel)
            {
                defaultSprite = npcModel.GetComponentInChildren<SpriteRenderer>()?.sprite;
            }
            else if (entityBase is ObjectBase resourceObject)
            {
                defaultSprite = resourceObject.ObjectData?.resourceIcon;
            }
            // else if (entityBase is BuildingBase buildingBase)
            // {
            //     defaultSprite = buildingBase.GetComponentInChildren<SpriteRenderer>()?.sprite;
            // }
        }
        catch (System.Exception)
        {
            throw;
        }
        infoPopupAvatarImage.sprite = defaultSprite;
    }
    
    private void SetupHoldItem(EntityBase entityBase)
    {
        infoPopupHolding1Image.gameObject.SetActive(false);
        infoPopupHolding2Image.gameObject.SetActive(false);
    
        if (entityBase is NpcModel npcModel && npcModel.HoldItems != null)
        {
            if (npcModel.HoldItems.Count > 0)
            {
                infoPopupHolding1Image.gameObject.SetActive(true);
                infoPopupHolding1Image.sprite = npcModel.HoldItemIcon?.sprite;
            }
            if (npcModel.HoldItems.Count > 1)
            {
                infoPopupHolding2Image.gameObject.SetActive(true);
                infoPopupHolding2Image.sprite = npcModel.HoldItems[1]?.GetComponent<SpriteRenderer>()?.sprite;
            }
        }
    }
    
    private void SetupText(EntityBase entityBase)
    {
        infoPopupInfoText.text = $"<b><size=5>{entityBase.Name}</size></b>\n" +
        $"<b>HP: </b>{entityBase.CurrentHealth}/{entityBase.MaxHealth}\n" +
        // $"<b>Happiness: </b>{entityBase.Happiness}\n" +
        $"<b>Damage: </b>{entityBase.Damage}\n" +
        $"<b>Level: </b>{entityBase.Level}\n" +
        $"<b>Entity Type: </b>{entityBase.EntityType}\n";
    } 
    #endregion
}
