using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickyStart : MonoBehaviour
{
    [SerializeField] GameObject[] buttons;

    private void OnMouseDown()
    {
        foreach  (GameObject gameObject in buttons)
        {
            gameObject.SetActive(true);
        }
        gameObject.SetActive(false);
    }
}
