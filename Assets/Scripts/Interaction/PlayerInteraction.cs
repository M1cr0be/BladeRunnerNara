using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float playerReach = 3f;
    Interactable currentInteractable;

    // Update is called once per frame
    void Update()
    {
        CheckInteraction();
        if (Input.GetKeyDown(KeyCode.F) && currentInteractable != null)
        {
            currentInteractable.Interact();
        }
        /*if (Input.GetKeyUp(KeyCode.G))
        {
            Animation
            Emote1();
        }*/
    }

    void CheckInteraction()
    {
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        
        if (Physics.Raycast(ray, out hit, playerReach)) //Is there an object in range
        {
            if (hit.collider.tag == "Interactable") //Does this object has the tag
            {
                Interactable newInteractable = hit.collider.GetComponent<Interactable>();

                // Avoid problems with overlaping object
                if (currentInteractable && newInteractable != currentInteractable)
                {
                    currentInteractable.DisableOutline();
                }
                if (newInteractable.enabled)
                {
                    SetNewCurrentInteractable(newInteractable);
                }
                else // If object is not enable
                {
                    DisableCurrentInteractable();
                }
            }
            else // If doesn't has tag
            {
                DisableCurrentInteractable();
            }
        }
        else // If nothing in range
        {
            DisableCurrentInteractable();
        }
    }
    void SetNewCurrentInteractable(Interactable newInteractable)
    {
        currentInteractable = newInteractable;
        currentInteractable.EnableOutline();
        HudController.instance.EnableInteractionText(currentInteractable.message);
    }

    void DisableCurrentInteractable()
    {
        HudController.instance.DisableInteractionText();
        if(currentInteractable)
        {
            currentInteractable.DisableOutline();
            currentInteractable = null;
        }
    }
    /*
    public void Emote1()
    {
        RaycastHit hit;

        DSGGCFGSDJKFH(hit);
        if (hit.ToString() == "PNJ1")
        {
            hit.chgdfgsdh.EventPnj("Sneak");
        }

    }*/

}
