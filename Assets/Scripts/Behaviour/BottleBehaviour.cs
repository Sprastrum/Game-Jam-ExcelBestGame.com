using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BottleBehaviour : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Image image;
    public float power = 10f;
    public Rigidbody2D rb;
    public GameObject fluid;
    public float fluidSpeed;
    public float timeToFluid;
    public GameObject nozzleBottle;
    public Canvas canvas;

    public Vector2 minPower;
    public Vector2 maxPower;
    public Vector2 canvasPosition;

    Vector2 force;
    Vector3 startPoint;
    bool isDrag;
    RectTransform canvasRectTransform;

    [HideInInspector] public Transform parentAfterDrag;

    private void Start()
    {
        canvasRectTransform = canvas.GetComponent<RectTransform>();

    }

    private void Update()
    {
        BottleController();
    }

    private void BottleController()
    {
        if (Input.GetKeyDown(KeyCode.W) && isDrag)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, nozzleBottle.transform.position, null, out canvasPosition);
            Instantiate(fluid, canvas.transform);
            fluid.GetComponent<RectTransform>().anchoredPosition = canvasPosition;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(rb.velocity.x != 0 || rb.velocity.y != 0)
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
}