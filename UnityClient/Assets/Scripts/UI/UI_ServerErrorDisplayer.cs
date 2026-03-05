using GuildManager;
using TMPro;
using UnityEngine;

/// <summary>
/// Display server's error message when one is triggered.
/// </summary>
public class UI_ServerErrorDisplayer : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private TextMeshProUGUI errorTextHolder;

    private void OnEnable()
    {
        HttpRequests.OnErrorTriggered += DisplayError;
    }

    private void OnDisable()
    {
        HttpRequests.OnErrorTriggered -= DisplayError;
    }

    private void DisplayError(ApiErrorResponse errorResponse)
    {
        errorTextHolder.text = errorResponse.GetMessage();

        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;
    }

    public void UE_CloseErrorDisplayer()
    {
        canvasGroup.alpha = 0.0f;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;
    }
}
