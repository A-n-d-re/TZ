using TMPro;
using UnityEngine;
using MyEnums;

public class UIUpdater : MonoBehaviour
{
    [Header("Multimeter Canvas Text")]
    [SerializeField] private TMP_Text multimeterDisplayText;

    [Header("Camera Canvas Text")]
    [SerializeField] private TMP_Text resistanceValueText;
    [SerializeField] private TMP_Text voltageValueText;
    [SerializeField] private TMP_Text currentValueText;
    [SerializeField] private TMP_Text alternatingCurrentValueText;

    private TMP_Text lastUpdatedText;

    public void UpdateTextByMode(float value, MultimeterMode multimeterMode)
    {
        if (lastUpdatedText != null)
        {
            lastUpdatedText.text = "0";
        }

        switch (multimeterMode)
        {
            case MultimeterMode.Resistance:

                UpdateText(resistanceValueText, value);
                SetLastUpdatedText(resistanceValueText);

                break;

            case MultimeterMode.Voltage:

                UpdateText(voltageValueText, value);
                SetLastUpdatedText(voltageValueText);

                break;

            case MultimeterMode.Current:

                UpdateText(currentValueText, value);
                SetLastUpdatedText(currentValueText);

                break;

            case MultimeterMode.AlternatingCurrent:

                UpdateText(alternatingCurrentValueText, value);
                SetLastUpdatedText(alternatingCurrentValueText);

                break;
        }

        UpdateText(multimeterDisplayText, value);
    }

    private void UpdateText(TMP_Text text, float value)
    {
        if (isInteger(value))
        {
            text.text = value.ToString("0");
        }
        else
        {
            text.text = value.ToString("0.00");
        }
    }

    private void SetLastUpdatedText(TMP_Text text)
    {
        lastUpdatedText = text;
    }

    private bool isInteger(float value)
    {
        return Mathf.Round(value) == value;
    }
}
