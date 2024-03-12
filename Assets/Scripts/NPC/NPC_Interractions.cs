using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Interractions : MonoBehaviour
{
     
    public void PerformAction()
    {
        Debug.Log("InNPC");
        // Example: Play an animation
        GetComponentInChildren<Animator>().Play("Salute");
        //GetComponent<Animator>().Play("YourAnimationName");
        Debug.Log("Action performed on NPC");
    }


    /*public void PerformAction()
    {
        // Define the action here, e.g., playing an animation
        Debug.Log("saleté");
        Animator animator = GetComponent<Animator>();
        if (animator != null)
        {
            animator.Play("NPCReactToEmote");
            Debug.Log("chien");
        }
    }
    /*void OnTriggerEnter(Collider other)
    {
        Debug.Log("saleté");
        // Check if the collider belongs to the player's emote raycast
        if (other.gameObject.tag == "EmoteRaycast")
        {
            // Perform an action
            PerformAction(); 
        }
        else
        {
            Debug.Log("pute");
        }
    }
    void PerformAction() //met l'action qu'il doit faire ici
    {
        // Access the Animator component attached to the NPC
        Animator animator = GetComponent<Animator>();

        // Check if the Animator component exists
        if (animator != null)
        {
            // Play the "NPCReactToEmote" animation
            animator.Play("NPCReactToEmote");
        }
        else
        {
            Debug.LogError("Animator component not found on this GameObject.");
        }
        // Example: Play an animation
        // Assuming the NPC has an Animator component
        animator.Play("NPCReactToEmote");

    }*/
}
