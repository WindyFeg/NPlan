using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;


  public static class ListExtension {
    private static readonly Random random = new Random();
    public static TValue remove_last<TValue>(this List<TValue> @this) {
      var index = @this.Count - 1;
      var result = @this[index];
      @this.RemoveAt(index);
      return result;
    }

    public static TValue remove_first<TValue>(this List<TValue> @this) {
      var result = @this[0];
      @this.RemoveAt(0);
      return result;
    }

    public static TValue first<TValue>(this List<TValue> @this) {
      var result = @this[0];
      return result;
    }

    public static TValue last<TValue>(this List<TValue> @this) {
      var result = @this[@this.Count - 1];
      return result;
    }
    public static T random_item<T>(this IList<T> @this, Random rnd = null) {
      return @this[(rnd ?? random).Next(@this.Count)];
    }

    public static List<T> clone<T>(this List<T> @this) {
      List<T> cloned_list = new List<T>();

      foreach (T item in @this) {
        cloned_list.Add(item);
      }

      return cloned_list;
    }

    public static T[] reverse<T>(this T[] @this) {

      T[] res = new T[@this.Length];
      int cur_res_idx = 0;
      for (int i = @this.Length - 1; i >= 0; i--) {
        res[cur_res_idx] = @this[i];
        cur_res_idx++;
      }

      return res;

    }


    public static void insert_range<T>(this IList<T> @this, int index, IEnumerable<T> items) {
      foreach (T item in items)
        @this.Insert(index++, item);
    }

    private static readonly Random _rnd = new Random();
    //Fisher-Yates Shuffle Implementation
    public static void shuffle<T>(this IList<T> list, Random rnd = null) {
      Random random = rnd ?? _rnd;
      int n = list.Count;
      for (int i = n - 1; i > 0; i--) {
        int j = random.Next(i + 1);
        T temp = list[i];
        list[i] = list[j];
        list[j] = temp;
      }
    }


  }

