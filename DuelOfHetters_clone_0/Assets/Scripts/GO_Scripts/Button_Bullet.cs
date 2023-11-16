using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Bullet : MonoBehaviour
{
    public GOS_Base[] cooperatingObject;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            foreach (var item in cooperatingObject)
            {
                item.ButtonPushed();
            }
        }
    }
}
