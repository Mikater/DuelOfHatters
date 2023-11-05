using UnityEngine;

public class Weight : MonoBehaviour
{
    public float distanceFromChainEnd = 0.6f;
    public void ConnectRopeEnd(Rigidbody2D endRB)
    {
        HingeJoint2D joint = gameObject.AddComponent<HingeJoint2D>();
        joint.autoConfigureConnectedAnchor = false;
        joint.connectedBody = endRB;
        joint.anchor = Vector2.zero;
        joint.connectedAnchor = new Vector2 (0, -distanceFromChainEnd);

        DistanceJoint2D distance = gameObject.AddComponent<DistanceJoint2D>();
        distance.connectedBody = endRB;
        distance.autoConfigureDistance = false;
        distance.distance = 0.3f;
    }
}
