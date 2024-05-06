using UnityEngine;

public class OutlineActivator : MonoBehaviour
{
    [SerializeField] private LayerMask outlineLayer;

    [SerializeField] private float maxRayDistance;

    private Camera mainCamera;

    private Outline lastOutlinedObject;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hit, maxRayDistance, outlineLayer))
        {
            var outline = hit.transform.GetComponent<Outline>();

            if (outline != null && outline != lastOutlinedObject)
            {
                DisableLastOutline();

                lastOutlinedObject = outline;
                lastOutlinedObject.enabled = true;
            }
        }
        else
        {
            DisableLastOutline();
        }
    }

    private void DisableLastOutline()
    {
        if (lastOutlinedObject != null)
        {
            lastOutlinedObject.enabled = false;
            lastOutlinedObject = null;
        }
    }
}
