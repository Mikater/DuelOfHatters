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
    public bool hookTypeWeapone = true; // Тип зброї хук
    public bool hookGraping = false; // хук вистрілив.
    public bool hookGoHome = true; // зажим кнопки для повернення хука
    public float hookGoHomeSpeed = 0.2f;
    public float hookMinDist = 1f;
    public float hookMaxDist = 6f;
    GameObject hook; // обєкт хук, для керування.
    private DistanceJoint2D distInHookWeapone;
    public GameObject dynamicLine;
    public GameObject changeButton;
    private Animator changeButonAnim;

    [Header("Time")]
    public float timeToDoubleClick;
    private float lastClickTime;


    void Start()
    {
        distInHookWeapone = GetComponent<DistanceJoint2D>();
        changeButonAnim = changeButton.GetComponent<Animator>();
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
        if (lastClickTime > 0) //Перевірка на даблклік
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

    private void HookShot() // Вистріл хуком
    {
        hook = Instantiate(hookPrefab, shootPoint.position, shootPoint.rotation);
        DistanceJoint2D hookDist = hook.GetComponent<DistanceJoint2D>();
        hookDist.connectedBody = HookWeapone.GetComponent<Rigidbody2D>();
        hookDist.distance = hookMaxDist;
        distInHookWeapone.distance = hookMaxDist;
        hookGraping = true;
        distInHookWeapone.connectedBody = hook.GetComponent<Rigidbody2D>();
        distInHookWeapone.enabled = true;
        dynamicLine.GetComponent<DynamicLine>().object2 = hook.transform;
        dynamicLine.GetComponent<LineRenderer>().enabled = true;
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
    private void HookUnCatch() // Відчепити хук
    {
        dynamicLine.GetComponent<LineRenderer>().enabled = false;
        Destroy(hook);
        hookGraping = false;
        distInHookWeapone.enabled = false;
    }
    private void BulletShot() // Вистріл кулею
    {
        Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
    }
    public void ChangeBulletType() // Зміна типу патрону
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
        changeButonAnim.SetBool("Hook", hookTypeWeapone);
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
