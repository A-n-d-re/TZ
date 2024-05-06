using UnityEngine;

public class SelectorRotator : MonoBehaviour
{
    [SerializeField] private int rotationAmount = 15;

    private Outline outline;

    private void Start()
    {
        outline = GetComponent<Outline>();
    }

    void Update()
    {
        if (outline.enabled)
        {
            float scrollWheelInput = Input.GetAxis("Mouse ScrollWheel");

            if (scrollWheelInput > 0f)
            {
                transform.Rotate(0, 0, rotationAmount);
            }

            if (scrollWheelInput < 0f)
            {
                transform.Rotate(0, 0, -rotationAmount);
            }
        }
    }
}
