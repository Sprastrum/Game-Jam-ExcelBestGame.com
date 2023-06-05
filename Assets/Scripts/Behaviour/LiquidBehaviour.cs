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
    public string alcohol;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Glass"))
        {
            Destroy(gameObject);
        }
    }

    public string GetAlcohol()
    {
        return alcohol;
    }

    public void SetAlcohol(string alcohol)
    {
        this.alcohol = alcohol;
    }
}
