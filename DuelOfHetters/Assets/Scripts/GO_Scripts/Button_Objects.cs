using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Objects : MonoBehaviour
{
    public GOS_Base[] cooperatingObject;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (var item in cooperatingObject)
        {
            item.ButtonPushed();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        foreach (var item in cooperatingObject)
        {
            item.ButtonUnPushed();
        }
    }
}
