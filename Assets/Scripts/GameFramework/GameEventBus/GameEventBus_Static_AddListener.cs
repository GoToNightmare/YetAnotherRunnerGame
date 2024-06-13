using System;
using UnityEngine;
using UnityEngine.Events;

public static partial class GameEventBus
{
    public static void AddListener<T>(UnityAction<T> listener) where T : IEventDataType, new()
    {
        var instanceOfT = new T();
        var eventName = instanceOfT.GameEventType();
        AddListener(eventName, listener);
    }


    public static void AddListener<T>(GameEventType eventName, UnityAction<T> listener)
    {
        var targetEvents = AllStaticEvents;
        if (targetEvents.TryGetValue(eventName, out var eventRef))
        {
            if (eventRef is UnityEvent<T> eventInstance)
            {
                eventInstance.AddListener(listener);
                targetEvents[eventName] = eventInstance;
            }
            else
            {
                var dbgClassName = listener?.Method?.DeclaringType?.FullName;
                var dbgMethodName = listener?.Method?.Name;
                Debug.LogException(new Exception($"[GameEventBus.AddListener] Incorrect event listener for event: {eventName}. Class: {dbgClassName}, method: {dbgMethodName}. " +
                                                 $"Check event subscription and unsubscription code for this event type, all event listeners should have the same type of UnityAction<T> delegate (method that passed as parameter)."));
            }
        }
        else
        {
            var e = new UnityEvent<T>();
            e.AddListener(listener);
            targetEvents[eventName] = e;
        }
    }


    public static void AddListener(GameEventType eventName, UnityAction listener)
    {
        var targetEvents = AllStaticEvents;
        if (targetEvents.TryGetValue(eventName, out var eventRef))
        {
            if (eventRef is UnityEvent eventInstance)
            {
                eventInstance.AddListener(listener);
                targetEvents[eventName] = eventInstance;
            }
            else
            {
                var dbgClassName = listener?.Method?.DeclaringType?.FullName;
                var dbgMethodName = listener?.Method?.Name;
                Debug.LogException(new Exception($"[GameEventBus.AddListener] Incorrect event listener for event: {eventName}. Class: {dbgClassName}, method: {dbgMethodName}. " +
                                                 $"Check event subscription and unsubscription code for this event type, all event listeners should have the same type of UnityAction<T> delegate (method that passed as parameter)."));
            }
        }
        else
        {
            var e = new UnityEvent();
            e.AddListener(listener);
            targetEvents[eventName] = e;
        }
    }
}