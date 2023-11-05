using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapone : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject bulletPrefab;
    public GameObject hookPrefab;
    public Transform shootPoint;
    [Header("Weapons")]
    public GameObject BullWeapone;
    public GameObject HookWeapone;
    public bool hookTypeWeapone = true;
    public bool hookGraping = false;
    public bool hookGoHome = true;
    public float hookGoHomeSpeed = 0.2f;
    GameObject hook;

    [Header("Time")]
    public float timeToDoubleClick;
    private float lastClickTime;


    void Start()
    {
        
    }

    void Update()
    {
        lastClickTime -= Time.deltaTime;
        if (hookGoHome)
        {
            hook.GetComponent<Hook1>().distance -= hookGoHomeSpeed;
        }
    }

    public void OnFireButtonDown()
    {
        if (lastClickTime > 0)
        {
            Debug.Log("Double Ckick");
            if (hookGraping)
            {
                Destroy(hook);
                hookGraping = false;
            }
        }
        else
        {
            if (hookTypeWeapone)
            {
                if (hookGraping)
                {
                    hookGoHome = true;
                }
                else
                {
                    hook = Instantiate(hookPrefab, shootPoint.position, shootPoint.rotation);
                    DistanceJoint2D hookDist = hook.GetComponent<DistanceJoint2D>();
                    hookDist.connectedBody = HookWeapone.GetComponent<Rigidbody2D>();
                    hookDist.distance = 5f;
                    hookGraping = true;
                }
            }
            lastClickTime = timeToDoubleClick;
        }
    }
    public void OnFireButtonUp()
    {
        if (hookTypeWeapone)
        {
            if (hookGraping)
            {
                hookGoHome = false;
            }
        }
    }
}
