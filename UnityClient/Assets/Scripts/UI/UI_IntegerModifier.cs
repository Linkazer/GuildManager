using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// UI Tool that handle the modification of an integer using buttons that increment or decrement the value.
/// </summary>
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

    /// <summary>
    /// Reseet the value to its starting value.
    /// </summary>
    public void ResetValue()
    {
        SetValue(startingValue);
    }

    /// <summary>
    /// Set the value. Clamp between limits.
    /// </summary>
    /// <param name="valueToSet"></param>
    public void SetValue(int valueToSet)
    {
        value = Math.Clamp(valueToSet, limits.x, limits.y);

        if (valueText != null)
        {
            valueText.text = value.ToString();
        }
        onValueChanged?.Invoke(value);
    }

    /// <summary>
    /// Add toAdd to the value.
    /// </summary>
    /// <param name="toAdd">The amount to add.</param>
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
