using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem;

public class HandPresence : MonoBehaviour
{
    


    public InputActionProperty pinchAnimationAction;
    public InputActionProperty gripAnimationAction;
    public InputActionProperty primaryButtonAnimationAction;
    public InputActionProperty secondaryButtonAnimationAction;

    public Material material;
    
   

    public float triggerValue;
    public float gripValue;
    public float primaryButtonValue;
    public float secondaryButtonValue;


    public bool isCasting;
    public bool isTriggered;

    public bool togglePressed;
    public bool toggleClamp;


    public Caster casterForHand;

    // Start is called before the first frame update
    void Start()
    {
        isCasting = false;
        isTriggered = false;
        togglePressed = false;
        toggleClamp = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();

        VerifyInput();
 

    }

    public void CheckInput() 
    {
        triggerValue = pinchAnimationAction.action.ReadValue<float>();
        gripValue = gripAnimationAction.action.ReadValue<float>();
        primaryButtonValue = primaryButtonAnimationAction.action.ReadValue<float>();
        secondaryButtonValue = secondaryButtonAnimationAction.action.ReadValue<float>();
    }


    public void VerifyInput()
    {
        if (triggerValue > 0.9f)
        {
            isTriggered = true;
            casterForHand.isTriggered = true;
            // casterForHand.hasTriggered = true;


            //inventory trigger interactions 
            Inventory.instance.IsInteracting = true;

        }
        else {
            isTriggered = false;
            casterForHand.isTriggered = false;
            casterForHand.hasTriggered = false;

            //inventory trigger interactions 
            Inventory.instance.IsInteracting = false;

        }

        if (gripValue > 0.9f)
        {
            isCasting = true;
            if (casterForHand != null) {
                casterForHand.isCasting = true;
            }


        }
        else {
            isCasting = false;
            casterForHand.isCasting = false;
        }


        //Toggle Button Setting / Weapons Switching
        //Desired effect only updates per ress of the button
        if (primaryButtonValue > 0.9f && !toggleClamp)
        {
            casterForHand.isToggled = true;
            //casterForHand.toggleClamp = true;
           // toggleClamp = true;

        }
        else {
            casterForHand.isToggled = false;
            casterForHand.toggleClamp = false;
           
            // toggleClamp = false;
        }
       
    }

}
