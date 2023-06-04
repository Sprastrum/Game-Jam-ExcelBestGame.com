using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidBehaviour : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector2 force;

    public Vector2 minPower;
    public Vector2 maxPower;
    public Canvas canvas;
    public GameObject particle;

    void Start()
    {
        particle.transform.SetParent(canvas.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
