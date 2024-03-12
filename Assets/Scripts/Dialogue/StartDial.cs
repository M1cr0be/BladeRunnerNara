using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDial : MonoBehaviour
{
    public EasyDialogue.Samples.DialogueManager DM;

    public EasyDialogue.EasyDialogueGraph Dialogue;
    public PlayerMovements playerMouvement;
    public Collider player;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Test");
        if(other == player)
        {
            Debug.Log("Test2");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            playerMouvement.enabled = false;
            DM.StartDialogueEncounter(ref Dialogue);
        }
    }

}
