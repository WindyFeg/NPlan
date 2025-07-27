using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;


  public static class IEnumerableExtension {


    public static IEnumerable<T> concat<T>(params IEnumerable<T>[] enumerables) {
      return enumerables.SelectMany(e => e);
    }

    public static IEnumerable<T> concat<T>(this IEnumerable<T> @this, params T[] values) {
      foreach (T item in @this)
        yield return item;
      foreach (T value in values)
        yield return value;
    }

    // to avoid this(numbers.Concat(new[] { 6 })
    public static IEnumerable<T> concat<T>(this IEnumerable<T> @this, T value) {
      foreach (T item in @this)
        yield return item;
      yield return value;
    }




    // careful to use this. the ids should be valid (0 <= id < len)
    public static T[] exclude_ids<T>(this IEnumerable<T> @this, params int[] ids) {
      int count = @this.Count();
      int new_count = count - ids.Count();
      if (new_count <= 0) return null;

      T[] arr = new T[new_count];
      int new_id = 0;

      // ids.for_each(e => aclf.log.info("ids: {0}", e));
      // aclf.log.info("{0} - {1}", count, ids.Count());

      int owner_id = 0;
      foreach (var e in @this) {
        if (!ids.Contains(owner_id)) {
          arr[new_id] = e;
          new_id++;
        }
        owner_id++;
      }

      return arr;
    }


    public static T[] exclude<T>(this IEnumerable<T> @this, params T[] exclude_items) {
      int count = @this.Count();
      T[] arr = new T[count - exclude_items.Count()];
      int index = 0;

      foreach (var e in @this) {
        if (!exclude_items.Contains(e)) {
          arr[index] = e;
          index++;
        }
      }
      return arr;
    }


    public static T[] clone<T>(this IEnumerable<T> @this) {
      return @this.to_arr();
    }

    public static T[] to_arr<T>(this IEnumerable<T> @this) {
      int count = @this.Count();
      T[] arr = new T[count];
      int index = 0;

      foreach (var e in @this) {
        arr[index] = e;
        index++;
      }

      return arr;
    }

    //-----------
    // @flatten
    //-----------
    public static IEnumerable<T> flatten<T>(this IEnumerable<IEnumerable<T>> @this) {
      return @this.SelectMany(i => i);
    }

    public static IEnumerable<T> flatten<TKey, T>(this IEnumerable<IDictionary<TKey, T>> @this) {
      return @this.SelectMany(i => i.Values);
    }


    public static IEnumerable<T> flatten<TKey, T>(this IDictionary<TKey, IEnumerable<T>> @this) {
      return @this.Values.SelectMany(i => i);
    }

    public static IEnumerable<T> flatten<TKey1, TKey2, T>(this IDictionary<TKey1, IDictionary<TKey2, T>> @this) {
      return @this.Values.SelectMany(i => i.Values);
    }


    //-----------
    //-- @loops
    //-----------

    public static IEnumerable<T> for_each<T>(this IEnumerable<T> @this, Action<T> action) {
      foreach (var item in @this) {
        action(item);
      }
      return @this;
    }



    public static List<T> for_each_reverse<T>(this List<T> selfList, Action<T> action) {
      for (var i = selfList.Count - 1; i >= 0; --i)
        action(selfList[i]);

      return selfList;
    }


    public static void for_each<T>(this List<T> list, Action<int, T> action) {
      for (var i = 0; i < list.Count; i++) {
        action(i, list[i]);
      }
    }

    //--------------
    //-- add-range
    //--------------
    public static void add_range<T>(this ICollection<T> @this, IEnumerable<T> items) {
      foreach (T item in items)
        @this.Add(item);
    }
    public static void remove_range<T>(this ICollection<T> @this, IEnumerable<T> items) {
      foreach (T item in items)
        @this.Remove(item);
    }
    public static void replace<T>(this ICollection<T> @this, IEnumerable<T> items) {
      @this.Clear();
      @this.add_range(items);
    }



    public static int index_of<T>(this IEnumerable<T> @this, Func<T, bool> condition) {
      int i = 0;
      foreach (T item in @this) {
        if (condition(item))
          return i;
        i++;
      }
      return -1;
    }

    public static bool is_valid_id<T>(this IEnumerable<T> @this, int id) {
      return id >= 0 && id < @this.Count();
    }

    public static T try_get<T>(this IEnumerable<T> @this, int id, T default_val) {
      if (!@this.is_valid_id(id)) return default_val;
      return @this.ElementAt(id);
    }








  }
