using System.Collections;
using System.Collections.Generic;
using UnityEngine;


  public static class OtherExtension {

    public static T get_random_item<T>(this List<T> list) {
      return list[UnityEngine.Random.Range(0, list.Count)];
    }


    public static T get_and_remove_random_item<T>(this List<T> list) {
      var random_id = UnityEngine.Random.Range(0, list.Count);
      var random_item = list[random_id];
      list.RemoveAt(random_id);
      return random_item;
    }



    public static float lerp(this float self, float a, float b) {
      return Mathf.Lerp(a, b, self);
    }

    public static bool is_approx(this float @this, float target) {
      return Mathf.Approximately(@this, target);
    }

    public static bool is_approx(this float @this, float y, float eps = 1e-8f) {
      return Mathf.Abs(@this - y) < eps;
    }

    public static float clamp(this float @this, float min, float max) {
      return Mathf.Clamp(@this, min, max);
    }

    public static float move_towards(this float @this, float target, float max_delta) {
      return Mathf.MoveTowards(@this, target, max_delta); 
    }


    public static bool is_in_range(this float @this, float a, float b) {
      return @this >= a && @this <= b;
    }

    public static bool is_in_range(this int @this, int a, int b) {
      return @this >= a && @this <= b;
    }


    public static float abs(this float self) {
      return Mathf.Abs(self);
    }

    public static float abs(this int self) {
      return Mathf.Abs(self);
    }

    public static float sign(this float self) {
      return Mathf.Sign(self);
    }


    public static float cos(this float self) {
      return Mathf.Cos(self);
    }

    public static float cos(this int self) {
      return Mathf.Cos(self);
    }

    public static float sin(this float self) {
      return Mathf.Sin(self);
    }

    public static float sin(this int self) {
      return Mathf.Sin(self);
    }


    public static float cos_angle(this float self) {
      return Mathf.Cos(self * Mathf.Deg2Rad);
    }

    public static float cos_angle(this int self) {
      return Mathf.Cos(self * Mathf.Deg2Rad);
    }


    public static float sin_angle(this float self) {
      return Mathf.Sin(self * Mathf.Deg2Rad);
    }

    public static float sin_angle(this int self) {
      return Mathf.Sin(self * Mathf.Deg2Rad);
    }


    public static float deg2rad(this float self) {
      return self * Mathf.Deg2Rad;
    }

    public static float deg2rad(this int self) {
      return self * Mathf.Deg2Rad;
    }



    public static float rad2deg(this float self) {
      return self * Mathf.Rad2Deg;
    }

    public static float rad2deg(this int self) {
      return self * Mathf.Rad2Deg;
    }

    public static Vector3 to_vector_3(this Vector2 self, float z = 0) {
      return new Vector3(self.x, self.y, z);
    }
  }

