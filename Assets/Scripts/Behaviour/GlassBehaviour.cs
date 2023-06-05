using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GlassBehaviour : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public RaycastHit2D gravity;
    public Transform left;
    public Transform right;
    public Rigidbody2D rb;
    public BoxCollider2D collider;
    public Image image;
    public GameObject fluid;
    public GameObject prefab;
    public float power = 10f;
    public int glassCapacity;

    public Vector2 minPower;
    public Vector2 maxPower;

    Vector3 startPoint;
    Vector2 force;
    bool isDrag;
    LiquidBehaviour liquidBehaviour;
    float ginCount;
    int vodkaCount;
    int vineCount;
    int bearCount;
    int tequilaCount;
    int waterCount;
    float fluidCount;

    // Start is called before the first frame update
    void Start()
    {
        liquidBehaviour = fluid.GetComponent<LiquidBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        FullGlass();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (rb.velocity.x != 0 || rb.velocity.y != 0)
        {
            rb.velocity.Set(0, 0);
            rb.Sleep();
        }

        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
        isDrag = true;

        startPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;
        isDrag = false;

        force = new Vector2(Mathf.Clamp(transform.position.x - startPoint.x, minPower.x, maxPower.x), Mathf.Clamp(transform.position.y - startPoint.y, minPower.y, maxPower.y));
        rb.AddForce(force * power, ForceMode2D.Impulse);
    }

    private void FullGlass()
    {
        if(fluidCount >= glassCapacity)
        {
            collider.isTrigger = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Gin")
        {
            ginCount++;
            fluidCount++;

            Debug.Log(ginCount + "---" + fluidCount);
        }
        else if (collision.gameObject.name == "Vodka")
        {
            vodkaCount++;
            fluidCount++;

            Debug.Log(ginCount + "---" + vodkaCount);
        }
        else if (collision.gameObject.name == "Vine")
        {
            vineCount++;
            fluidCount++;
        }
        else if (collision.gameObject.name == "Bear")
        {
            bearCount++;
            fluidCount++;
        }
        else if (collision.gameObject.name == "Tequila")
        {
            tequilaCount++;
            fluidCount++;
        }
        else if(collision.gameObject.name == "Water")
        {
            waterCount++;
            fluidCount++;
        }
    }

    private void TotalFluid()
    {

    }
}