using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
