using UnityEngine;

public class MultimeterCalculator : MonoBehaviour
{
    [SerializeField] private float alternatingCurrent = 0.01f;
    [SerializeField] private float power = 400f;
    [SerializeField] private float resistance = 1000f;

    public float CalculateVoltage()
    {
        return Mathf.Sqrt(power * resistance);
    }

    public float CalculateCurrent()
    {
        return Mathf.Sqrt(power / resistance);
    }

    public float GetResistance()
    {
        return resistance;
    }

    public float GetAlternatingCurrent()
    {
        return alternatingCurrent;
    }

    public float GetZero()
    {
        return 0;
    }
}
