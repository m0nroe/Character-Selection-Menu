﻿using UnityEngine;
using UnityEngine.EventSystems;

public class RotationHandler : MonoBehaviour, IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        EventStreams.Game.Publish(new RotationEvent(eventData.delta.x));
    }
}