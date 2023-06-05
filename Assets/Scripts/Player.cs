using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private DialogueUI dialogueUI;

    public DialogueUI DialogueUI => dialogueUI;

    public IInteractable Interactable { get; set; }

    // Update is called once per frame
    void Update()
    {
        MoveTowards();

        if (Input.GetMouseButtonDown(0))
        {
            if (!dialogueUI.IsOpen)
            {
                Interactable?.Interact(this);
            }

        }
           
    }

    void MoveTowards()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.SetPositionAndRotation(mousePosition,Quaternion.identity);
    }
}
