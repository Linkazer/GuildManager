using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance => instance;

    [SerializeField] public LayerMask layerToIgnore;

    [Header("Events")]
    [SerializeField] private UnityEvent<Vector2> OnMouseLeftDown;
    [SerializeField] private UnityEvent<ClicHandler> OnMouseLeftDownOnObject;

    [Header("Inputs")]
    [SerializeField] private InputActionReference actionMouseMovementInput;
    [SerializeField] private InputActionReference actionMouseLeftClicInput;

    [Header("Datas")]
    [SerializeField] private Camera usedCamera;

    [SerializeField] private EventSystem evtSyst;

    private InputSystem_Actions inputSystemActions;

    private RaycastHit2D mouseRaycast;

    private Vector2 mouseScreenPosition;

    private Vector2 mouseWorldPosition;

    private ClicHandler currentClicHandlerTouched;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }

        instance = this;

        inputSystemActions = new InputSystem_Actions();
    }


    private void OnEnable()
    {
        inputSystemActions.Enable();

        actionMouseMovementInput.action.performed += UpdateMousePosition;

        actionMouseLeftClicInput.action.canceled += LeftMouseInput;
    }

    private void OnDisable()
    {
        inputSystemActions.Disable();

        actionMouseMovementInput.action.performed -= UpdateMousePosition;

        actionMouseLeftClicInput.action.canceled -= LeftMouseInput;
    }

    private void Update()
    {
        if (!evtSyst.IsPointerOverGameObject())
        {
            mouseRaycast = GetMouseRaycast();
        }
    }

    private void UpdateMousePosition(InputAction.CallbackContext context)
    {
        mouseScreenPosition = context.ReadValue<Vector2>();

        mouseWorldPosition = usedCamera.ScreenToWorldPoint(mouseScreenPosition);
    }

    private void LeftMouseInput(InputAction.CallbackContext context)
    {
        if (!evtSyst.IsPointerOverGameObject())
        {
            OnMouseLeftDown?.Invoke(mouseWorldPosition);

            if (currentClicHandlerTouched != null)
            {
                OnMouseLeftDownOnObject?.Invoke(currentClicHandlerTouched);
            }

            if (currentClicHandlerTouched != null)
            {
                currentClicHandlerTouched.MouseDown(0);
            }
        }
    }

    private RaycastHit2D GetMouseRaycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(mouseWorldPosition, Vector2.zero, 25f, ~layerToIgnore);

        ClicHandler lastClicHandler = currentClicHandlerTouched;

        if (hit.transform != null && hit.transform.gameObject.GetComponent<ClicHandler>() != null)
        {
            currentClicHandlerTouched = hit.transform.gameObject.GetComponent<ClicHandler>();
        }
        else if (currentClicHandlerTouched != null)
        {
            currentClicHandlerTouched = null;
        }

        if (currentClicHandlerTouched != lastClicHandler)
        {
            if (lastClicHandler != null)
            {
                lastClicHandler.MouseExit();
            }

            if (currentClicHandlerTouched != null)
            {
                currentClicHandlerTouched.MouseEnter();
            }
        }

        return hit;
    }
}
