using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    [Header("Main Menu")]
    [SerializeField] private UI_Menu mainMenu;

    [Header("Utilities")]
    [SerializeField] private CanvasGroup loadingGroup;

    UI_Menu currentMenu;

    private async void Start()
    {
        DisplayLoading();
        await ReferenceDataService.Load();
        HideLoading();

        OpenMenu(mainMenu);
    }

    public void OpenMenu(UI_Menu toOpen)
    {
        if (toOpen != currentMenu)
        {
            CloseMenu(currentMenu);

            toOpen.OpenMenu();
            currentMenu = toOpen;
        }
    }

    private void CloseMenu(UI_Menu toClose)
    {
        if (toClose == currentMenu && toClose != null)
        {
            toClose.CloseMenu();
        }
    }

    public void UE_OpenMenu(UI_Menu menuToOpen)
    {
        OpenMenu(menuToOpen);
    }

    public void DisplayLoading()
    {
        ShowCanvasGroup(loadingGroup, true);
    }

    public void HideLoading()
    {
        ShowCanvasGroup(loadingGroup, false);
    }

    private void ShowCanvasGroup(CanvasGroup group, bool state)
    {
        if(state)
        {
            group.alpha = 1.0f;
        }
        else
        {
            group.alpha = 0.0f;
        }
        group.interactable = state;
        group.blocksRaycasts = state;
    }
}
