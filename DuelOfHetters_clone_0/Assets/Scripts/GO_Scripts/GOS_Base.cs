using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOS_Base : MonoBehaviour
{
    public bool buttonPushed;
    public void ButtonPushed()
    {
        buttonPushed = true;
    }
    public void ButtonUnPushed() 
    { 
        buttonPushed = false;
    }
}
