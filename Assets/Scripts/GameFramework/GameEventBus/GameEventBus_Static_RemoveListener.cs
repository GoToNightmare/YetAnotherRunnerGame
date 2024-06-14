using System;
using Game.Core.GameEventBusVariants.EventTypes;
using UnityEngine;
using UnityEngine.Events;

namespace GameFramework.GameEventBus
{
    public static partial class GameEventBus
    {
        public static void RemoveListener<T>(UnityAction<T> listener) where T : IEventDataType, new()
        {
            var instanceOfT = new T();
            var eventName = instanceOfT.GameEventType();
            RemoveListener(eventName, listener);
        }


        public static void RemoveListener<T>(GameEventType eventName, UnityAction<T> listener)
        {
            var targetEvents = AllStaticEvents;
            if (targetEvents.TryGetValue(eventName, out var eventRef))
            {
                if (eventRef is UnityEvent<T> eventInstance)
                {
                    eventInstance.RemoveListener(listener);
                    targetEvents[eventName] = eventInstance;
                }
                else
                {
                    var dbgClassName = listener?.Method?.DeclaringType?.FullName;
                    var dbgMethodName = listener?.Method?.Name;
                    Debug.LogException(new Exception($"[GameEventBus.RemoveListener] Incorrect event listener for event: {eventName}. Class: {dbgClassName}, method: {dbgMethodName}. " +
                                                     $"Check event subscription and unsubscription code for this event type, all event listeners should have the same type of UnityAction<T> delegate (method that passed as parameter)."));
                }
            }
        }


        public static void RemoveListener(GameEventType eventName, UnityAction listener)
        {
            var targetEvents = AllStaticEvents;
            if (targetEvents.TryGetValue(eventName, out var eventRef))
            {
                if (eventRef is UnityEvent eventInstance)
                {
                    eventInstance.RemoveListener(listener);
                    targetEvents[eventName] = eventInstance;
                }
                else
                {
                    var dbgClassName = listener?.Method?.DeclaringType?.FullName;
                    var dbgMethodName = listener?.Method?.Name;
                    Debug.LogException(new Exception($"[GameEventBus.RemoveListener] Incorrect event listener for event: {eventName}. Class: {dbgClassName}, method: {dbgMethodName}. " +
                                                     $"Check event subscription and unsubscription code for this event type, all event listeners should have the same type of UnityAction<T> delegate (method that passed as parameter)."));
                }
            }
        }
    }
}