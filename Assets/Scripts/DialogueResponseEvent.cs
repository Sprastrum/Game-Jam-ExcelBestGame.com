
using UnityEngine;
using System;

public class DialogueResponseEvent : MonoBehaviour
{
    [SerializeField] private DialogueObject dialogue;
    [SerializeField] private ResponseEvent[] events;

    public ResponseEvent[] Events => events;

    public void OnValidate()
    {
        if (dialogue == null) return;
        if (dialogue.Responses == null) return;
        if (events != null && events.Length == dialogue.Responses.Length) return;

        if (events == null)
        {
            events = new ResponseEvent[dialogue.Responses.Length];
        }
        else
        {
            Array.Resize(ref events, dialogue.Responses.Length);
        }

        for (int i = 0; i < dialogue.Responses.Length; i++)
        {
            Response response = dialogue.Responses[i];

            if(events[i] != null)
            {
                events[i].rname = response.ResponseText;
                continue;
            }

            events[i] = gameObject.AddComponent<ResponseEvent>();
        }

    }
}

