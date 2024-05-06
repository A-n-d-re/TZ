using UnityEngine;
using MyEnums;

public class MultimeterModeChanger : MonoBehaviour
{
    [SerializeField] private MultimeterCalculator multimeterCalculator;
    [SerializeField] private UIUpdater uiUpdater;

    [Header("Selector Local Rotation")]
    [SerializeField] private Vector3 rotationToGetResistance;
    [SerializeField] private Vector3 rotationToGetVoltage;
    [SerializeField] private Vector3 rotationToGetCurrent;
    [SerializeField] private Vector3 rotationToGetAlternatingCurrent;

    private const float ANGLE_THRESHOLD = 0.1f;

    private void Update()
    {
        UpdateUIText(rotationToGetResistance, multimeterCalculator.GetResistance(), MultimeterMode.Resistance);

        UpdateUIText(rotationToGetVoltage, multimeterCalculator.CalculateVoltage(), MultimeterMode.Voltage);

        UpdateUIText(rotationToGetAlternatingCurrent, multimeterCalculator.GetAlternatingCurrent(), MultimeterMode.AlternatingCurrent);

        UpdateUIText(rotationToGetCurrent, multimeterCalculator.CalculateCurrent(), MultimeterMode.Current);

        UpdateUIText(Vector3.zero, multimeterCalculator.GetZero(), MultimeterMode.Null);
    }

    private void UpdateUIText(Vector3 targetRotation, float calculatorValue, MultimeterMode multimeterMode)
    {
        Quaternion localRotation = Quaternion.Euler(transform.localEulerAngles);

        if (Quaternion.Angle(localRotation, Quaternion.Euler(targetRotation)) < ANGLE_THRESHOLD)
        {
            uiUpdater.UpdateTextByMode(calculatorValue, multimeterMode);
        }
    }
}

