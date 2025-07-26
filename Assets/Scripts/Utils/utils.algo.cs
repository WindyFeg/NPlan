using System;
using System.Collections.Generic;
using System.Text;



  public partial class utils {
    public static class algo {

      public static void sort_by_descend<T, K>(IList<T> array, Func<T, K> handler, int start, int end) where K : IComparable<K> {

        if (array == null)
          throw new ArgumentNullException("SortByDescend : array is null");
        if (handler == null)
          throw new ArgumentNullException("SortByDescend : handler is null");
        if (start < 0 || end < 0 || start >= end) {
          return;
        }
        int pivot = start;
        T pivot_val = array[pivot];
        swap(array, end, pivot);
        int store_id = start;
        for (int i = start; i <= end - 1; i++) {
          if (handler(array[i]).CompareTo(handler(pivot_val)) > 0) {
            swap(array, i, store_id);
            store_id++;
          }
        }
        swap(array, store_id, end);
        sort_by_descend(array, handler, start, store_id - 1);
        sort_by_descend(array, handler, store_id + 1, end);
      }

      public static void sort_by_ascend<T, K>(IList<T> array, Func<T, K> handler, int start, int end) where K : IComparable<K> {
        if (array == null)
          throw new ArgumentNullException("QuickSortByAscend : array is null");
        if (handler == null)
          throw new ArgumentNullException("QuickSortByAscend : handler is null");
        if (start < 0 || end < 0 || start >= end) {
          return;
        }
        int pivort = start;
        T pivortValue = array[pivort];
        swap(array, end, pivort);
        int storeIndex = start;
        for (int i = start; i <= end - 1; i++) {
          if (handler(array[i]).CompareTo(handler(pivortValue)) < 0) {
            swap(array, i, storeIndex);
            storeIndex++;
          }
        }
        swap(array, storeIndex, end);
        sort_by_ascend(array, handler, start, storeIndex - 1);
        sort_by_ascend(array, handler, storeIndex + 1, end);
      }

      //bubble sort
      public static void sort_by_ascend<T, K>(IList<T> array, Func<T, K> handler)
        where K : IComparable<K> {
        for (int i = 0; i < array.Count; i++) {
          for (int j = 0; j < array.Count; j++) {
            if (handler(array[i]).CompareTo(handler(array[j])) < 0) {
              T temp = array[i];
              array[i] = array[j];
              array[j] = temp;
            }
          }
        }
      }
      public static void sort_by_descend<T, K>(IList<T> array, Func<T, K> handler)
        where K : IComparable<K> {
        for (int i = 0; i < array.Count; i++) {
          for (int j = 0; j < array.Count; j++) {
            if (handler(array[i]).CompareTo(handler(array[j])) > 0) {
              T temp = array[i];
              array[i] = array[j];
              array[j] = temp;
            }
          }
        }
      }




      // array deduplication
      public static T[] distinct<T>(IList<T> array) where T : IComparable {
        var length = array.Count;
        T[] dst = new T[length];
        int idx = 0;
        for (int i = 0; i < length; i++) {
          bool is_duplicate = false;
          for (int j = 0; j < i; j++) {
            if (array[i].CompareTo(array[j]) == 0) {
              is_duplicate = true;
              break;
            }
          }
          if (!is_duplicate) {
            dst[idx] = array[i];
            idx++;
          }
        }
        Array.Resize(ref dst, idx);
        return dst;
      }


      //--------
      // @find
      //--------
      public static T[] find_all<T>(IList<T> array, Predicate<T> handler) {
        var dstArray = new T[array.Count];
        int idx = 0;
        for (int i = 0; i < array.Count; i++) {
          if (handler(array[i])) {
            dstArray[idx] = array[i];
            idx++;
          }
        }
        Array.Resize(ref dstArray, idx);
        return dstArray;
      }
      public static T find<T>(IList<T> array, Predicate<T> handler) {
        T temp = default(T);
        for (int i = 0; i < array.Count; i++) {
          if (handler(array[i])) {
            return array[i];
          }
        }
        return temp;
      }

      //----------
      // @others
      //----------
      public static T min<T, K>(IList<T> array, Func<T, K> handler)
                  where K : IComparable<K> {
        T temp = default(T);
        temp = array[0];
        foreach (var arr in array) {
          if (handler(temp).CompareTo(handler(arr)) > 0) {
            temp = arr;
          }
        }
        return temp;
      }


      public static T max<T, K>(IList<T> array, Func<T, K> handler)
      where K : IComparable<K> {
        T temp = default(T);
        temp = array[0];
        foreach (var arr in array) {
          if (handler(temp).CompareTo(handler(arr)) < 0) {
            temp = arr;
          }
        }
        return temp;
      }


      public static void swap<T>(ref T t1, ref T t2) {
        T t3 = t1;
        t1 = t2;
        t2 = t3;
      }

      public static void swap<T>(IList<T> array, int idxA, int idxB) {
        T temp = array[idxA];
        array[idxA] = array[idxB];
        array[idxB] = temp;
      }



      //----------
      // @random
      //----------
      static Random random = new Random(Guid.NewGuid().GetHashCode());
      public static int random_range(int min_val, int max_val) {
        if (min_val >= max_val)
          throw new ArgumentNullException("rangom_range : min_val is greater than or equal to max_val");
        int seed = Guid.NewGuid().GetHashCode();
        Random random = new Random(seed);
        int result = random.Next(min_val, max_val);
        return result;
      }

      // shuffle array randomly
      public static void disrupt<T>(IList<T> array) {
        int index = 0;
        T tmp;
        for (int i = 0; i < array.Count; i++) {
          index = random_range(0, array.Count);
          if (index != i) {
            tmp = array[i];
            array[i] = array[index];
            array[index] = tmp;
          }
        }
      }
      // used to create a more balanced and fair random number generator, especially in situations where a truly even distribution is important.
      public static float average_random(double min_val, double max_val) {
        int min = (int)(min_val * 10000);
        int max = (int)(max_val * 10000);
        int result = random.Next(min, max);
        return result / 10000f;
      }

      public static float average_random(float min_val, float max_val) {
        int min = (int)(min_val * 10000);
        int max = (int)(max_val * 10000);
        int result = random.Next(min, max);
        return result / 10000f;
      }

    }
  }

