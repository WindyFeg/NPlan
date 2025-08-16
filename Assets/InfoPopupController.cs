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


    public void SetInfoPopupController(EntityBase entityBase)
    {
        Debug.Log("Setting InfoPopupController with EntityBase: " + entityBase?.Name);
        if (entityBase == null)
        {
            Debug.LogError("entityBase is null. Cannot set InfoPopupController.");
            return;
        }

        Sprite defaultSprite;
        try
        {
            if (entityBase is NpcModel npcModel)
            {
                defaultSprite = npcModel.GetComponentInChildren<SpriteRenderer>()?.sprite;
            }
            else if (entityBase is ResourceObject resourceObject)
            {
                defaultSprite = resourceObject.ObjectData?.resourceIcon;
            }
            // else if (entityBase is BuildingBase buildingBase)
            // {
            //     defaultSprite = buildingBase.GetComponentInChildren<SpriteRenderer>()?.sprite;
            // }
            else
            {
                defaultSprite = null;
            }
        }
        catch (System.Exception)
        {
            throw;
        }
        infoPopupAvatarImage.sprite = defaultSprite;
        infoPopupInfoText.text = $"<b><size=5>{entityBase.Name}</size></b>\n" +
        $"<b>HP: </b>{entityBase.CurrentHealth}/{entityBase.MaxHealth}\n" +
        // $"<b>Happiness: </b>{entityBase.Happiness}\n" +
        $"<b>Damage: </b>{entityBase.Damage}\n" +
        $"<b>Level: </b>{entityBase.Level}\n" +
        $"<b>Entity Type: </b>{entityBase.EntityType}\n";
    } 
}
