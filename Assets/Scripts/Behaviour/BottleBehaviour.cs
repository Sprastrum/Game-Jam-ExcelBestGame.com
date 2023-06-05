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
    public float rotationGrades;
    public GameObject nozzleBottle;
    public Canvas canvas;
    public string alcohol;

    public Vector2 minPower;
    public Vector2 maxPower;
    public Vector2 canvasPosition;

    Vector2 force;
    Vector3 startPoint;
    bool isDrag;
    bool thereIsGravity = false;
    RectTransform canvasRectTransform;

    [HideInInspector] public Transform parentAfterDrag;

    private void Start()
    {
        canvasRectTransform = canvas.GetComponent<RectTransform>();

    }

    private void Update()
    {
        if (isDrag)
        {
            BottleController();
            BottleRotate();
        }
    }

    private void BottleController()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.W) && isDrag)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, nozzleBottle.transform.position, null, out canvasPosition);
            GameObject liquidAlcohol = Instantiate(fluid, canvas.transform);
            liquidAlcohol.name = alcohol;
            fluid.GetComponent<RectTransform>().anchoredPosition = canvasPosition;
        }
    }

    private void BottleRotate()
    {
        if(Input.GetKeyDown(KeyCode.Q) || Input.GetKey(KeyCode.Q) && isDrag)
        {
            transform.Rotate(Vector3.forward * rotationGrades * Time.deltaTime);
        }
        if(Input.GetKeyDown(KeyCode.E) || Input.GetKey(KeyCode.E) && isDrag)
        {
            transform.Rotate(-Vector3.forward * rotationGrades * Time.deltaTime);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(rb.velocity.x != 0 || rb.velocity.y != 0)
        {
            rb.velocity.Set(0, 0);
            rb.Sleep();
        }

        startPoint = transform.position;

        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
        isDrag = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;
        isDrag = false;

        if(!thereIsGravity)
        {
            force = new Vector2(Mathf.Clamp(transform.position.x - startPoint.x, minPower.x, maxPower.x), Mathf.Clamp(transform.position.y - startPoint.y, minPower.y, maxPower.y));
            rb.AddForce(force * power, ForceMode2D.Impulse);
        }
    }

    private void StartPointUpdate()
    {
        startPoint = transform.position;
    }
}