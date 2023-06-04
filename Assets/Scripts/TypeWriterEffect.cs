using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeWriterEffect : MonoBehaviour
{
    [SerializeField] private float type_speed;
    public Coroutine Run(string text_to_type, TMP_Text text_label)
    {
       return StartCoroutine(Typer(text_to_type, text_label));
    }

    private IEnumerator Typer(string text_to_type, TMP_Text text_label) 
    {

        text_label.text = string.Empty;

        

        float t = 0;
        int char_index = 0;

        while (char_index < text_to_type.Length)
        {
            t += Time.deltaTime * type_speed;
            char_index = Mathf.FloorToInt(t);
            char_index = Mathf.Clamp(char_index, 0,text_to_type.Length);

            text_label.text = text_to_type.Substring(0, char_index);

            yield return null;
        }


    }
}
