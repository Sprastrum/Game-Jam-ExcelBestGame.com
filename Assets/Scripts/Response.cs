using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Response
{
    [SerializeField] private string response_text;
    [SerializeField] private DialogueObject dialogue_object;

    public string ResponseText => response_text;

    public DialogueObject Dialogue_Object => dialogue_object;

}
