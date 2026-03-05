using UnityEngine;

/// <summary>
/// Base class for UI menu. Handle the opneing and closing of the menu.
/// </summary>
public abstract class UI_Menu : MonoBehaviour
{
    [SerializeField] protected CanvasGroup menuGroup;

    [SerializeField] protected MenuHandler handler;

    public void OpenMenu()
    {
        menuGroup.alpha = 1.0f;
        menuGroup.interactable = true;
        menuGroup.blocksRaycasts = true;

        OnOpenMenu();
    }

    protected abstract void OnOpenMenu();

    public void CloseMenu()
    {
        OnCloseMenu();

        menuGroup.alpha = 0.0f;
        menuGroup.interactable = false;
        menuGroup.blocksRaycasts = false;
    }

    protected abstract void OnCloseMenu();
}
