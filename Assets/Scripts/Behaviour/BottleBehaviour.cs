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
    public Transform nozzleBottle;

    public Vector2 minPower;
    public Vector2 maxPower;

    Vector2 force;
    Vector3 startPoint;

    [HideInInspector] public Transform parentAfterDrag;

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

        startPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;

        timeToFluid += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && timeToFluid >= fluidSpeed)
        {
            Instantiate(fluid, nozzleBottle.position, Quaternion.identity);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;

        force = new Vector2(Mathf.Clamp(transform.position.x - startPoint.x, minPower.x, maxPower.x), Mathf.Clamp(transform.position.y - startPoint.y, minPower.y, maxPower.y));
        rb.AddForce(force * power, ForceMode2D.Impulse);
    }
}
