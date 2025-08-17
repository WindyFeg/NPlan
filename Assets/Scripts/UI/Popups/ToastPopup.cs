using System.Collections;
using System.Collections.Generic;
using LTK268.Define;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ToastPopup : BasePopup
{
    [Range(0, 5)] public float displayDuration = 2f; // Duration to display the toast in seconds
    [SerializeField] private float fadeDuration = 0.3f; // time for fade in/out

    [Header("Background")] [SerializeField]
    private Image background;

    public float backgroundWidth;
    public float backgroundHeight;
    public float offsetTop = 20f;

    [Header("Text")] [SerializeField] private TextMeshProUGUI text;

    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private CanvasGroup canvasGroup;
    public Color textColor;
    public float fontSize = TextSize.Medium;

    #region Private Fields

    private RectTransform rectTransform;
    private Queue<object[]> toastQueue = new Queue<object[]>();

    #endregion

    #region Unity Methods

    private void OnValidate()
    {
        if (gameObject.name != GetType().Name)
        {
            gameObject.name = GetType().Name;
        }
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        rectTransform = background.gameObject.GetComponent<RectTransform>();
        canvasGroup.alpha = 0f;
        // Set default values
        backgroundWidth = background.rectTransform.sizeDelta.x;
        backgroundHeight = background.rectTransform.sizeDelta.y;
        text.color = textColor;
        text.fontSize = fontSize;

        descriptionText.gameObject.SetActive(false);
    }

    #endregion

    #region Popup Methods

    protected override void ApplyArgs(object[] args)
    {
        var title = args[0] as string;
        text.text = title;

        // Check if there is args[1]
        if (args.Length > 1)
        {
            var description = args[1] as string;
            if (description != null)
            {
                descriptionText.text = description;
                descriptionText.gameObject.SetActive(true);
            }
        }
    }

    public override void ShowWithArgs(object[] args)
    {
        if (gameObject.activeSelf)
        {
            // Add this args to queue and show later
            toastQueue.Enqueue(args);
            return;
        }

        base.ShowWithArgs(args);
        gameObject.SetActive(true);
        StartCoroutine(DisplayToast());
    }

    private IEnumerator DisplayToast()
    {
        if (rectTransform)
            rectTransform.anchoredPosition = new Vector2(0, -offsetTop);
        else
            rectTransform = background.gameObject.GetComponent<RectTransform>();

        gameObject.SetActive(true);

        // Fade in
        yield return StartCoroutine(FadeCanvasGroup(canvasGroup, 0f, 1f, fadeDuration));
        // Stay visible
        yield return new WaitForSeconds(displayDuration);
        // Fade out
        yield return StartCoroutine(FadeCanvasGroup(canvasGroup, 1f, 0f, fadeDuration));

        if (toastQueue.Count > 0) ShowNextInQueue();
        else Hide();
    }

    private void ShowNextInQueue()
    {
        var objectsToShow = toastQueue.Dequeue();
        base.ShowWithArgs(objectsToShow);
        StartCoroutine(DisplayToast());
    }

    private IEnumerator FadeCanvasGroup(CanvasGroup cg, float from, float to, float duration)
    {
        float elapsed = 0f;
        cg.alpha = from;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            cg.alpha = Mathf.Lerp(from, to, elapsed / duration);
            yield return null;
        }

        cg.alpha = to;
    }

    #endregion

    #region Public Methods for setting properties

    public void SetDisplayDuration(float duration)
    {
        displayDuration = Mathf.Clamp(duration, 0, 10); // Clamp to a reasonable range
    }

    public void SetBackgroundSize(float width, float height)
    {
        backgroundWidth = Mathf.Max(0, width);
        backgroundHeight = Mathf.Max(0, height);
        background.rectTransform.sizeDelta = new Vector2(backgroundWidth, backgroundHeight);
    }

    public void SetTextColor(Color color)
    {
        textColor = color;
        text.color = color;
    }

    public void SetFontSize(float size)
    {
        text.fontSize = size;
    }

    public void SetOffsetTop(float offset)
    {
        offsetTop = Mathf.Max(0, offset);
        rectTransform.anchoredPosition = new Vector2(0, -Screen.height / 2 + offsetTop);
    }

    #endregion
}