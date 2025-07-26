using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


  public static class IDIctionaryExtension {

    public static bool try_add<TKey, TValue>(this IDictionary<TKey, TValue> @this, TKey key, TValue value) {
      if (@this.ContainsKey(key))
        return false;
      else {
        @this.Add(key, value);
        return true;
      }
    }
    public static bool try_remove<TKey, TValue>(this IDictionary<TKey, TValue> @this, TKey key, out TValue value) {
      if (@this.ContainsKey(key)) {
        value = @this[key];
        @this.Remove(key);
        return true;
      } else {
        value = default;
        return false;
      }
    }

    //-------------------
    //-- @add-or-update
    //-------------------


    public static void add_or_update<TKey, TValue>(this IDictionary<TKey, TValue> @this, TKey key, Func<TKey, TValue> add_val_factory, Func<TKey, TValue, TValue> update_value_factory) {
      if (!@this.ContainsKey(key)) {
        @this[key] = add_val_factory(key);
      } else {
        var old_val = @this[key];
        @this[key] = update_value_factory(key, old_val);
      }
    }


    public static TValue get_or_add<TKey, TValue>(this IDictionary<TKey, TValue> @this, TKey key, Func<TValue> getDefaultValue) {
      TValue value;
      if (!@this.TryGetValue(key, out value))
        @this[key] = value = getDefaultValue();
      return value;
    }
    public static TValue get_or_add<TKey, TValue>(this IDictionary<TKey, TValue> @this, TKey key)
        where TValue : new() {
      TValue value;
      if (!@this.TryGetValue(key, out value))
        @this[key] = value = new TValue();
      return value;
    }

    public static TValue val<TKey, TValue>(this IDictionary<TKey, TValue> @this, TKey key) {
      TValue value = default(TValue);
      bool is_ok = @this.TryGetValue(key, out value);
      if (is_ok)
        return value;
      return value;
    }


    public static void for_each<K, V>(this Dictionary<K, V> dict, Action<K, V> action) {
      var dict_e = dict.GetEnumerator();

      while (dict_e.MoveNext()) {
        var current = dict_e.Current;
        action(current.Key, current.Value);
      }

      dict_e.Dispose();
    }


    public static void add_range<K, V>(this Dictionary<K, V> dict, Dictionary<K, V> add_in_dict,
        bool isOverride = false) {
      var enumerator = add_in_dict.GetEnumerator();

      while (enumerator.MoveNext()) {
        var current = enumerator.Current;
        if (dict.ContainsKey(current.Key)) {
          if (isOverride)
            dict[current.Key] = current.Value;
          continue;
        }

        dict.Add(current.Key, current.Value);
      }

      enumerator.Dispose();
    }
  }


