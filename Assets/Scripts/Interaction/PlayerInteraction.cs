using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionRange = 5f; // The range within which the player can interact with NPCs
    public LayerMask npcLayer; // Layer for NPCs

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
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, interactionRange, npcLayer))
            {
                NPC_Interractions npc = hit.collider.GetComponent<NPC_Interractions>();
                if (npc != null)
                {
                    npc.PerformAction(); // Assuming NPC has a method to perform an action
                }
            }
        }

    /*if (Input.GetKeyDown(KeyCode.E))
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
            // Check if the hit object is the NPC
            NPC_Interractions npc = hit.transform.GetComponent<NPC_Interractions>();
            if (npc != null)
            {
                // Trigger the NPC's action
                npc.PerformAction();
            }
        }
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
}
