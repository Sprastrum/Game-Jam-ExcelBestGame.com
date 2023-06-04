using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueActivator : MonoBehaviour
{
    [SerializeField] private DialogueObject dialogue_object;
    [SerializeField] private DialogueUI dialogue_UI;

    public void setDialogue(DialogueObject dialogue)
    {
        dialogue_object = dialogue;
    }
    private void OnMouseDown()
    {
        if (!dialogue_UI.IsOpen)
        {
            dialogue_UI.ShowDialogue(dialogue_object);
        }
        
    }

}
