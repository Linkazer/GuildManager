using UnityEngine;
using UnityEngine.Events;

public class ClicHandler : MonoBehaviour
{
    [SerializeField] private CharacterDisplay linkedDisplay;

    [SerializeField] private UnityEvent OnLeftMouseDown;
    [SerializeField] private UnityEvent OnRightMouseDown;
    [SerializeField] private UnityEvent PlayOnMouseEnter;
    [SerializeField] private UnityEvent PlayOnMouseExit;

    public void MouseDown(int mouseID)
    {
        switch (mouseID)
        {
            case 0:
                //UI_MainMenu.Instance.OpenCharacterDetail(linkedDisplay);

                OnLeftMouseDown?.Invoke();
                break;
            case 1:
                OnRightMouseDown?.Invoke();
                break;
        }
    }

    public void MouseEnter()
    {
        PlayOnMouseEnter?.Invoke();
    }

    public void MouseExit()
    {
        PlayOnMouseExit?.Invoke();
    }
}
