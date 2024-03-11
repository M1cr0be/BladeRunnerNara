using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDial : MonoBehaviour
{
    public EasyDialogue.Samples.DialogueManager DM;

    public EasyDialogue.EasyDialogueGraph Dialogue;


    private void OnTriggerEnter(Collider other)
    {
        DM.StartDialogueEncounter(ref Dialogue);
    }

}
