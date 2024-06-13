using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace GameFramework.GameReactiveProperty
{
    public class GameReactivePropertyOldAndNew<T> : GameReactiveProperty<T>
    {
        public new Action<T, T> OnChange;


        public new T Value
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => CurrentValue;
            set
            {
                T oldValue = CurrentValue;
                T newValue = value;
                if (Comparer.Equals(oldValue, newValue))
                {
                    return;
                }

                CurrentValue = newValue;

                try
                {
                    OnChange?.Invoke(oldValue, newValue);
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                }
            }
        }
    }
}