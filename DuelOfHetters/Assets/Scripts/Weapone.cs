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
    [Header("Hook Settings")]
    public GameObject HookWeapone;
    public bool hookTypeWeapone = true; // ��� ���� ���
    public bool hookGraping = false; // ��� ��������.
    public bool hookGoHome = true; // ����� ������ ��� ���������� ����
    public float hookGoHomeSpeed = 0.2f;
    public float hookMinDist = 1f;
    public float hookMaxDist = 6f;
    GameObject hook; // ���� ���, ��� ���������.
    private DistanceJoint2D distInHookWeapone;

    [Header("Time")]
    public float timeToDoubleClick;
    private float lastClickTime;


    void Start()
    {
        distInHookWeapone = GetComponent<DistanceJoint2D>();
    }

    void Update()
    {
        lastClickTime -= Time.deltaTime;
        if (hookGoHome && distInHookWeapone.distance>=hookMinDist)
        {
            distInHookWeapone.distance -= hookGoHomeSpeed;
            hook.GetComponent<Hook1>().distance = distInHookWeapone.distance;
        }
    }

    public void OnFireButtonDown()
    {
        if (lastClickTime > 0) //�������� �� �������
        {
            Debug.Log("Double Ckick");
            if (hookGraping)
            {
                HookUnCatch();
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
                    HookShot();
                }
            }
            else
            {
                BulletShot();
            }
            lastClickTime = timeToDoubleClick;
        }
    }

    private void HookShot() // ������ �����
    {
        hook = Instantiate(hookPrefab, shootPoint.position, shootPoint.rotation);
        DistanceJoint2D hookDist = hook.GetComponent<DistanceJoint2D>();
        hookDist.connectedBody = HookWeapone.GetComponent<Rigidbody2D>();
        hookDist.distance = hookMaxDist;
        distInHookWeapone.distance = hookMaxDist;
        hookGraping = true;
        distInHookWeapone.connectedBody = hook.GetComponent<Rigidbody2D>();
        distInHookWeapone.enabled = true;
        StartCoroutine(CheckHookCatch());
    }
    IEnumerator CheckHookCatch()
    {
        yield return new WaitForSeconds(0.5f);
        if(hook.GetComponent<Hook1>().catchedObj == null)
        {
            HookUnCatch();
        }
    }
    private void HookUnCatch() // ³������� ���
    {
        Destroy(hook);
        hookGraping = false;
        distInHookWeapone.enabled = false;
    }
    private void BulletShot() // ������ �����
    {
        Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
    }
    private void ChangeBulletType() // ���� ���� �������
    {
        if (hookGraping) return;
        if (hookTypeWeapone)
        {
            hookTypeWeapone = false;
            HookWeapone.SetActive(false);
            BullWeapone.SetActive(true);
        }
        else
        {
            hookTypeWeapone = true;
            HookWeapone.SetActive(true);
            BullWeapone.SetActive(false);
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
