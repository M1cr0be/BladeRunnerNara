using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Interractions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("saleté");
        // Check if the collider belongs to the player's emote raycast
        if (other.gameObject.tag == "EmoteRaycast")
        {
            // Perform an action
            PerformAction(); 
            //met l'action qu'il doit faire ici
        }
        else
        {
            Debug.Log("pute");
        }
    }
    void PerformAction()
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

    }
}
