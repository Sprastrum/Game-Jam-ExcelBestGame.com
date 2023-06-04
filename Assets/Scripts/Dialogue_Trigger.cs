using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_Trigger : MonoBehaviour
{
    public Dialogue dialogue;

    private void Start()
    {
        TriggerDialogue();
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<Dialogue_Manager>().Start_Dialogue(dialogue);
    }
}
