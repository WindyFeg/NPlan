using System.Collections;
using System.Collections.Generic;
using UnityEngine;


  public static class StackExtension {
    public static void push_range<T>(this Stack<T> stack, IEnumerable<T> items) {
      foreach (T item in items)
        stack.Push(item);
    }
  }
