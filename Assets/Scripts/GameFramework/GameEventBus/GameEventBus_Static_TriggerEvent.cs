using System;
using UnityEngine;
using UnityEngine.Events;

public static partial class GameEventBus
{
    public static void TriggerEvent<T>(this T eventData) where T : struct, IEventDataType
    {
        var eventType = eventData.GameEventType();
        TriggerEvent(eventType, eventData);
    }


    public static void TriggerEvent<T>(this T eventData, GameEventType eventName)
    {
        TriggerEvent(eventName, eventData);
    }


    public static void TriggerEvent<T>(GameEventType eventName, T eventTriggerData)
    {
        var targetEvents = AllStaticEvents;
        if (targetEvents.TryGetValue(eventName, out var eventRef))
        {
            if (eventRef is UnityEvent<T> eventInstance)
            {
                try
                {
                    eventInstance.Invoke(eventTriggerData);
                }
                catch (Exception e)
                {
                    Debug.LogException(new Exception($"[GameEventBus.TriggerEvent] Fail to invoke event: {eventName}\n{e}"));
                }
            }
            else
            {
                Debug.LogException(new Exception($"[GameEventBus.TriggerEvent] Incorrect event handler for event: {eventName}"));
            }
        }
    }


    public static void TriggerEvent(GameEventType eventName)
    {
        var targetEvents = AllStaticEvents;
        if (targetEvents.TryGetValue(eventName, out var eventRef))
        {
            if (eventRef is UnityEvent eventInstance)
            {
                try
                {
                    eventInstance.Invoke();
                }
                catch (Exception e)
                {
                    Debug.LogException(new Exception($"[GameEventBus.TriggerEvent] Fail to invoke event: {eventName}\n{e}"));
                }
            }
            else
            {
                Debug.LogException(new Exception($"[GameEventBus.TriggerEvent] Incorrect event handler for event: {eventName}"));
            }
        }
    }
}