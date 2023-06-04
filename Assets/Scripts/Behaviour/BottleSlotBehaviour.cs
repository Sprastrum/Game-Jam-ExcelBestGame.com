using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BottleSlotBehaviour : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        BottleBehaviour bottleBehaviour = dropped.GetComponent<BottleBehaviour>();
        bottleBehaviour.parentAfterDrag = transform;
    }
}
