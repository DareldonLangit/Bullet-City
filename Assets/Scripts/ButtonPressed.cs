using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class ButtonPressed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public bool isHeld = false;


    private void Update()
    {
        if (isHeld)
        {
            Gun gun = FindObjectOfType<Gun>();
            gun.checkIfCanFire();
        }    
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        //Output the name of the GameObject that is being clicked
        isHeld = true;
    }

    //Detect if clicks are no longer registering
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        isHeld = false;
    }
}
