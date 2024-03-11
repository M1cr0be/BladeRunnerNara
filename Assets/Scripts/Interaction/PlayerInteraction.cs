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

        
        if (Input.GetKeyDown(KeyCode.E))
        {
            PerformEmote();        
        }
        

        void PerformEmote()
        {
            // Assuming the emote is a simple animation, you can start it here
            // Start your emote animation

            // Cast a ray from the player's position in the direction they are facing
            Debug.Log("lul");
            RaycastHit hit;
            Debug.Log("biteu");
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                Debug.Log("bonjour");
                // The ray hit something, you can now send a message to the NPC
                // For example, you could use a custom event or a direct method call
                // depending on your architecture
                GameObject emoteRaycastObject = new GameObject("EmoteRaycastObject");
                emoteRaycastObject.transform.position = hit.point;
                emoteRaycastObject.tag = "EmoteRaycast";
                Debug.Log(hit.point);
            }
        }

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
}
