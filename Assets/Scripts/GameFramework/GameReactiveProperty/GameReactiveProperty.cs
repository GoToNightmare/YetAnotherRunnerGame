using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameReactiveProperty<T>
{
    public static EqualityComparer<T> Comparer = EqualityComparer<T>.Default;

    protected T CurrentValue;

    public Action<GameReactiveProperty<T>> OnChange;

    public T Value
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => CurrentValue;
        set
        {
            if (Comparer.Equals(CurrentValue, value))
            {
                return;
            }

            CurrentValue = value;

            try
            {
                OnChange?.Invoke(this);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
    }
}