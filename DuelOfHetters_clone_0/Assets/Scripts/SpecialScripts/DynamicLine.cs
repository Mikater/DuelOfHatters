using UnityEngine;

public class DynamicLine : MonoBehaviour
{
    public Transform object1; // Перший об'єкт
    public Transform object2; // Другий об'єкт
    public LineRenderer lineRenderer;

    void Update()
    {
        lineRenderer.SetPosition(0, object1.position);
        lineRenderer.SetPosition(1, object2.position);
    }
}