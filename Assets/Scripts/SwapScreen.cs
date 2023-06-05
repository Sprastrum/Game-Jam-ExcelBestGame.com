using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapScreen : MonoBehaviour
{
    [SerializeField] string SceneToChoose;
    private void OnMouseDown()
    {
        SceneManager.LoadScene(SceneToChoose);
    }

    public void ChooseScene(string chooseScene)
    {
        SceneManager.LoadScene(SceneToChoose);
    }
}
