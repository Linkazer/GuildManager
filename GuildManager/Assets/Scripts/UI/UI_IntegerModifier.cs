using System;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Events;

public class UI_IntegerModifier : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI valueText;
    [SerializeField] private int increment = 1;
    [SerializeField] private Vector2Int limits = new Vector2Int(0, 10);
    [SerializeField] private bool loop;

    [SerializeField] private int startingValue = 0;

    [Header("Events")]
    public UnityEvent<int> onValueChanged = new UnityEvent<int>();

    private int value = 0;

    private void Start()
    {
        if(limits.x >= limits.y)
        {
            Debug.LogError($"Limits on {gameObject}'s {this} component are invalid.");
        }
    }

    public void ResetValue()
    {
        SetValue(startingValue);
    }

    public void SetValue(int valueToSet)
    {
        value = Math.Clamp(valueToSet, limits.x, limits.y);

        if (valueText != null)
        {
            valueText.text = value.ToString();
        }
        onValueChanged?.Invoke(value);
    }

    private void ChangeValue(int toAdd)
    {
        value += toAdd;
        if (loop)
        {
            if(value < limits.x)
            {
                value = limits.y;
            }
            else if(value > limits.y)
            {
                value = limits.x;
            }
        }
        else
        {
            value = Math.Clamp(value, limits.x, limits.y);
        }

        if(valueText != null)
        {
            valueText.text = value.ToString();
        }
        onValueChanged?.Invoke(value);
    }

    public void UE_Increment()
    {
        ChangeValue(increment);
    }

    public void UE_Decrement()
    {
        ChangeValue(-increment);
    }
}
