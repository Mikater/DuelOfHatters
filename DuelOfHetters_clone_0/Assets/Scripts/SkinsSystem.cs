using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinsSystem : MonoBehaviour
{
    public Sprite[] skins;
    public GameObject Hat;
    public int skinChanged;
    void Start()
    {
        Hat.GetComponent<SpriteRenderer>().sprite = skins[skinChanged];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
