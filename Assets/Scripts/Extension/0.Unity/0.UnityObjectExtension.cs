using System.Collections;
using System.Collections.Generic;
using UnityEngine;





  public static class UnityObjectExtension {

    //---------------
    // @instantiate
    //---------------

    public static T instantiate<T>(this T self_obj) where T : UnityEngine.Object {
      return UnityEngine.Object.Instantiate(self_obj);
    }


    public static T instantiate<T>(this T self_obj, Vector3 position, Quaternion rotation)
        where T : UnityEngine.Object {
      return UnityEngine.Object.Instantiate(self_obj, position, rotation);
    }


    public static T instantiate<T>(
        this T self_obj,
        Vector3 position,
        Quaternion rotation,
        Transform parent)
        where T : UnityEngine.Object {
      return UnityEngine.Object.Instantiate(self_obj, position, rotation, parent);
    }


    public static T instantiate_with_parent<T>(
          this T self_obj,
          Transform parent,
          bool worldPositionStays) where T : UnityEngine.Object {
      return (T)UnityEngine.Object.Instantiate((UnityEngine.Object)self_obj, parent, worldPositionStays);
    }

    public static T instantiate_with_parent<T>(this T selfObj, Transform parent) where T : UnityEngine.Object {
      return UnityEngine.Object.Instantiate(selfObj, parent, false);
    }

    //--------
    // @name
    //--------

    public static T name<T>(this T selfObj, string name) where T : UnityEngine.Object {
      selfObj.name = name;
      return selfObj;
    }

    //-----------
    // @destroy
    //-----------

    public static void destroy_self<T>(this T self_obj) where T : UnityEngine.Object {
      UnityEngine.Object.Destroy(self_obj);
    }




    public static T destroy_self_gracefully<T>(this T self_obj) where T : UnityEngine.Object {
      if (self_obj) {
        UnityEngine.Object.Destroy(self_obj);
      }

      return self_obj;
    }

    public static T dont_destroy_on_load<T>(this T self_obj) where T : UnityEngine.Object {
      UnityEngine.Object.DontDestroyOnLoad(self_obj);
      return self_obj;
    }


    public static T[] children<T>(this Component @this, bool include_src = false) where T : Component {
      Transform parent_tf = @this.transform;
      var children_tf = parent_tf.GetComponentsInChildren<Transform>();
      var length = children_tf.Length;
      Transform[] transforms;
      if (!include_src)
        transforms = utils.algo.find_all(children_tf, t => t != parent_tf);
      else
        transforms = children_tf;

      var transforms_len = transforms.Length;
      T[] src = new T[transforms_len];
      int idx = 0;
      for (int i = 0; i < transforms_len; i++) {
        var comp = transforms[i].GetComponent<T>();
        if (comp != null) {
          src[idx] = comp;
          idx++;
        }
      }
      T[] dst = new T[idx];
      System.Array.Copy(src, 0, dst, 0, idx);
      return dst;
    }

    public static T child<T>(
      this Component @this,
      string name
    ) where T : Component {
      Transform parent_tf = @this.transform;
      var children_tf = parent_tf.GetComponentsInChildren<Transform>();
      foreach (var child_tf in children_tf) {
        if (child_tf.name == name) {
          return child_tf.GetComponent<T>();
        }
      }
      return null;
    }

    //------------------------------------
    // @find-all-comps-at-the-same-level
    //------------------------------------
    //only use with non top hierarchy comps
    public static T[] peers<T>(
      this Component @this,
      bool include_src = false
    ) where T : Component {
      Transform parent_tf = @this.transform.parent;
      var children_tf = parent_tf.GetComponentsInChildren<Transform>();
      var length = children_tf.Length;
      Transform[] transforms;
      if (!include_src)
        transforms = utils.algo.find_all(children_tf, t => t.parent == parent_tf);
      else
        transforms = utils.algo.find_all(children_tf, t => t.parent == parent_tf && t != @this);
      var transforms_len = transforms.Length;
      T[] src = new T[transforms_len];
      int idx = 0;
      for (int i = 0; i < transforms_len; i++) {
        var comp = transforms[i].GetComponent<T>();
        if (comp != null) {
          src[idx] = comp;
          idx++;
        }
      }
      T[] dst = new T[idx];
      System.Array.Copy(src, 0, dst, 0, idx);
      return dst;
    }

    //only use with non top hierarchy comps
    public static T peer<T>(
      this Component @this,
      string name
    ) where T : Component {
      Transform parent_tf = @this.transform.parent;
      var children_tf = parent_tf.GetComponentsInChildren<Transform>();
      foreach (var child_tf in children_tf) {
        if (child_tf.name == name) {
          return child_tf.GetComponent<T>();
        }
      }
      return null;
    }
















  }

