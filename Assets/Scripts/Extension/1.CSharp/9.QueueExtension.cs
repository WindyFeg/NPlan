using System.Collections;
using System.Collections.Generic;
using UnityEngine;


  public static class QueueExtension {
    public static void enqueue_range<T>(this Queue<T> queue, IEnumerable<T> items) {
      foreach (T item in items)
        queue.Enqueue(item);
    }
  }
