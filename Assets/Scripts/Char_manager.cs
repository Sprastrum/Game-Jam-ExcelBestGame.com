using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_manager : MonoBehaviour
{
    [SerializeField] List<DialogueObject> character_dialogue;
    private Queue<DialogueObject> character_queue;
    // Start is called before the first frame update
    private void Start()
    {
        character_queue = new Queue<DialogueObject>();
        
        foreach (DialogueObject dialogue in character_dialogue)
        {
            character_queue.Enqueue(dialogue);
            
        }
    }

    public void Load_Char(GameObject character)
    {
        
        Animator animator;
        character.GetComponent<DialogueActivator>().setDialogue(character_queue.Dequeue());
        animator = character.GetComponent<Animator>();
        animator.SetBool("Enters",true);
        Destroy(gameObject);
    }
}
