using UnityEngine;

public class Rope : MonoBehaviour
{
    public Rigidbody2D hook;
    public GameObject linkPrefab;
    public Weight weight;
    public float distanseLinks;
    public int links = 7;
    private void Start()
    {
        GenerateRope();
    }
    private void GenerateRope()
    {
        Rigidbody2D previousRB = hook;
        for (int i = 0; i < links; i++)
        {
            GameObject link = Instantiate(linkPrefab, transform);
            HingeJoint2D joint = link.GetComponent<HingeJoint2D>();
            DistanceJoint2D dist = link.GetComponent<DistanceJoint2D>();
            joint.connectedBody = previousRB;
            dist.autoConfigureDistance = false;
            dist.distance = distanseLinks;
            dist.connectedBody = previousRB;
            dist.maxDistanceOnly = true;

            if (i<links - 1)
            {
                previousRB = link.GetComponent<Rigidbody2D>();
            }
            else
            {
                weight.ConnectRopeEnd(link.GetComponent<Rigidbody2D>());
            }

        }
    }
}
