using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class SerializableDictionaryBase<TKey, TValue> : ISerializationCallbackReceiver,
                                                             IDictionary<TKey, TValue> // Implement the full IDictionary interface
{
    [SerializeField]
    protected List<TKey> keys = new List<TKey>();

    [SerializeField]
    protected List<TValue> values = new List<TValue>();

    protected Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();

    public void OnBeforeSerialize()
    {
        keys.Clear();
        values.Clear();
        foreach (var pair in dictionary)
        {
            keys.Add(pair.Key);
            values.Add(pair.Value);
        }
    }

    public void OnAfterDeserialize()
    {
        dictionary.Clear();
        for (int i = 0; i < keys.Count; i++)
        {
            if (keys[i] != null)
            {
                dictionary[keys[i]] = values[i];
            }
        }
    }

    // ---- Methods to expose the dictionary's functionality ----
    // You can choose to implement the full IDictionary interface, or just the ones you need.
    // For foreach to work, you need GetEnumerator() at a minimum.

    public ICollection<TKey> Keys => dictionary.Keys;
    public ICollection<TValue> Values => dictionary.Values;
    public int Count => dictionary.Count;
    public bool IsReadOnly => false; // Or implement as needed.

    public TValue this[TKey key]
    {
        get => dictionary[key];
        set => dictionary[key] = value;
    }

    public void Add(TKey key, TValue value) => dictionary.Add(key, value);
    public void Add(KeyValuePair<TKey, TValue> item) => ((IDictionary<TKey, TValue>)dictionary).Add(item);
    public void Clear() => dictionary.Clear();
    public bool Contains(KeyValuePair<TKey, TValue> item) => ((IDictionary<TKey, TValue>)dictionary).Contains(item);
    public bool ContainsKey(TKey key) => dictionary.ContainsKey(key);
    public bool Remove(TKey key) => dictionary.Remove(key);
    public bool Remove(KeyValuePair<TKey, TValue> item) => ((IDictionary<TKey, TValue>)dictionary).Remove(item);
    public bool TryGetValue(TKey key, out TValue value) => dictionary.TryGetValue(key, out value);
    public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) => ((IDictionary<TKey, TValue>)dictionary).CopyTo(array, arrayIndex);

    // ---- The crucial part for foreach loops ----
    // This is the GetEnumerator method that fulfills the IEnumerable<T> interface.
    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
        return dictionary.GetEnumerator();
    }

    // This is the non-generic GetEnumerator method that fulfills the IEnumerable interface.
    // The C# compiler will automatically prefer the generic version if available.
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

// Generic concrete implementation that can be used directly
[System.Serializable]
public class SerializableDictionary<TKey, TValue> : SerializableDictionaryBase<TKey, TValue>
{
}

