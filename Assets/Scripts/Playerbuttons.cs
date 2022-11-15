using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Playerbuttons : MonoBehaviour
{

    private bool isHeld = false;
      
    public void Jump()
    {
        Playermovement playermovement = FindObjectOfType<Playermovement>();
        playermovement.Jump();
    }
}
