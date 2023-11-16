using UnityEngine;

public class DynamicLine : MonoBehaviour
{
    public Transform object1; // ������ ��'���
    public Transform object2; // ������ ��'���
    public LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer.enabled = false;
    }
    void Update()
    {
        if (lineRenderer.enabled == true)
        {
            lineRenderer.SetPosition(0, object1.position);
            lineRenderer.SetPosition(1, object2.position);
        }
    }
}