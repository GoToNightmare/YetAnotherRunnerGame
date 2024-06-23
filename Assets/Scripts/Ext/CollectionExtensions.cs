using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityRandom = UnityEngine.Random;

public static class CollectionExtensions
{
    public static bool DictionaryHasSameSizeAndKeys<T, K, V>(this IDictionary<T, K> source, IDictionary<T, V> target)
    {
        if (source != null && target != null)
        {
            if (source.Count == target.Count)
            {
                bool allKeysMatch = true;

                foreach (var kv in source)
                {
                    if (!target.ContainsKey(kv.Key))
                    {
                        // One collection don't have one of the keys
                        allKeysMatch = false;
                        break;
                    }
                }

                if (allKeysMatch)
                {
                    return true;
                }
            }
        }

        return false;
    }


    /// <summary>
    /// Checks for null, if null -> not in range.
    /// </summary>
    /// <param name="collection"></param>
    /// <param name="index"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IndexInRangeOfCollection<T>(this ICollection<T> collection, int index)
    {
        if (collection == null)
        {
            return false;
        }

        return index >= 0 && index < collection.Count;
    }


    /// <summary>
    /// Checks for null, if null -> not in range.
    /// </summary>
    /// <param name="collection"></param>
    /// <param name="index"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IndexInRangeOfReadOnlyCollection<T>(this IReadOnlyCollection<T> collection, int index)
    {
        if (collection == null)
        {
            return false;
        }

        return index >= 0 && index < collection.Count;
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T TakeElementInRangeOfCollection<T>(this T[] collection, int index)
    {
        var collectionCount = collection.Length;
        if (collectionCount == 0)
        {
            // no elements
            return default;
        }

        // correct index
        if (index >= 0 && index < collectionCount)
        {
            return collection[index];
        }

        // wrong index - negative
        if (index < 0)
        {
            return collection[0];
        }

        // wrong index - more than elements collection
        if (index >= collectionCount)
        {
            return collection[collectionCount - 1];
        }

        return default;
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T TakeElementInRangeOfCollection<T>(this List<T> collection, int index)
    {
        var collectionCount = collection.Count;
        if (collectionCount == 0)
        {
            // no elements
            return default;
        }

        // correct index
        if (index >= 0 && index < collectionCount)
        {
            return collection[index];
        }

        // wrong index - negative
        if (index < 0)
        {
            return collection[0];
        }

        // wrong index - more than elements collection
        if (index >= collectionCount)
        {
            return collection[collectionCount - 1];
        }

        return default;
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T TakeRandomElementInRangeOfCollection<T>(this List<T> collection)
    {
        var collectionCount = collection.Count;
        if (collectionCount == 0)
        {
            // no elements
            return default;
        }

        int randomIndex = UnityRandom.Range(0, collectionCount);

        // correct index
        if (randomIndex >= 0 && randomIndex < collectionCount)
        {
            return collection[randomIndex];
        }

        // wrong index - negative
        if (randomIndex < 0)
        {
            return collection[0];
        }

        // wrong index - more than elements collection
        if (randomIndex >= collectionCount)
        {
            return collection[collectionCount - 1];
        }

        return default;
    }


    /// <summary>
    /// To add element into collection and filter collection elements.
    /// </summary>
    /// <param name="collection">ref - is required</param>
    /// <param name="newElement"></param>
    /// <param name="condition"></param>
    /// <typeparam name="T"></typeparam>
    /// <exception cref="ArgumentNullException"></exception>
    public static void AddElementToCollectionAndRemoveElementsWithCondition<T>(ref List<T> collection, T newElement, Func<T, bool> condition)
    {
        if (collection == null) throw new ArgumentNullException();
        if (condition == null) throw new ArgumentNullException();

        if (collection.Count == 0)
        {
            if (condition(newElement))
            {
                collection.Add(newElement);
            }
        }
        else
        {
            var newCollection = new List<T>();

            foreach (var element in collection)
            {
                if (condition(element))
                {
                    newCollection.Add(element);
                }
            }

            if (condition(newElement))
            {
                newCollection.Add(newElement);
            }

            collection = newCollection;
        }
    }
}