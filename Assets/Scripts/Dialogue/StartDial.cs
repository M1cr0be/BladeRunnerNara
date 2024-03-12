using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDial : MonoBehaviour
{
    public EasyDialogue.Samples.DialogueManager DM;

    public EasyDialogue.EasyDialogueGraph Dialogue;
    public PlayerMovements playerMouvement;
    public PlayerCam playerCamera;
    public Collider player;

    bool HasEnter;

    private void Start()
    {
        HasEnter = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!HasEnter)
        {
            if (other == player)
            {
                HasEnter = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                playerMouvement.enabled = false;
                playerCamera.enabled = false;
                DM.StartDialogueEncounter(ref Dialogue);
            }
        }
    }

}
