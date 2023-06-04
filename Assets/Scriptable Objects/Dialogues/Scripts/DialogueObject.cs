using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Dialogue/Dialogue Object", fileName = "new DialogueObject")]
public class DialogueObject : ScriptableObject
{
    [SerializeField] private string name_field;
    [SerializeField] [TextArea(5, 15)] private string[] dialogue;
    [SerializeField] private Response[] responses;

    public string[] Dialogue => dialogue;

    public string Name_Field => name_field;

    public bool HasResponses => Responses != null && Responses.Length > 0;

    public Response[] Responses => responses;
    
}
