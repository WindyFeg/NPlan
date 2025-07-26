using UnityEngine;
using System;
using System.Collections.Generic;


  public static class TransformExtension {
    //-------------
    // @transform
    //-------------

    public static T identity<T>(this T selfComponent) where T : Component {
      selfComponent.transform.position = Vector3.zero;
      selfComponent.transform.rotation = Quaternion.identity;
      selfComponent.transform.localScale = Vector3.one;
      return selfComponent;
    }
    public static GameObject identity(this GameObject self) {
      self.transform.position = Vector3.zero;
      self.transform.rotation = Quaternion.identity;
      self.transform.localScale = Vector3.one;
      return self;
    }
    //-----------------
    // @local-position
    //-----------------

    public static T local_pos_identity<T>(this T @this) where T : Component {
      @this.transform.localPosition = Vector3.zero;
      @this.transform.localRotation = Quaternion.identity;
      @this.transform.localScale = Vector3.one;
      return @this;
    }

    public static GameObject local_pos_identity(this GameObject @this) {
      @this.transform.localPosition = Vector3.zero;
      @this.transform.localRotation = Quaternion.identity;
      @this.transform.localScale = Vector3.one;
      return @this;
    }


    //----------------------------------------

    // 3 params
    public static T local_pos<T>(this T @this, float x, float y, float z) where T : Component {
      @this.gameObject.set_local_pos(new Vector3(x, y, z));
      return @this;
    }

    public static GameObject local_pos(this GameObject @this, float x, float y, float z) {
      @this.set_local_pos(new Vector3(x, y, z));
      return @this;
    }

    // 2 params
    public static T local_pos<T>(this T @this, float x, float y) where T : Component {
      @this.gameObject.set_local_pos(new Vector3(x, y, @this.transform.localPosition.z));
      return @this;
    }

    public static GameObject local_pos(this GameObject @this, float x, float y) {
      @this.set_local_pos(new Vector3(x, y, @this.transform.localPosition.z));
      return @this;
    }

    // vector
    public static T local_pos<T>(this T @this, Vector3 new_local_pos)
    where T : Component {
      @this.gameObject.set_local_pos(new_local_pos);
      return @this;
    }

    public static GameObject local_pos(this GameObject @this, Vector3 new_local_pos) {
      @this.set_local_pos(new_local_pos);
      return @this;
    }

    public static GameObject set_local_pos(this GameObject @this, Vector3 new_local_pos) {
      @this.transform.localPosition = new_local_pos;
      return @this;
    }

    public static Vector3 local_pos<T>(this T @this) where T : Component {
      return @this.transform.localPosition;
    }

    public static Vector3 local_pos(this GameObject @this) {
      return @this.transform.localPosition;
    }



    //---------------
    // @local-pos-x
    //---------------


    public static T local_pos_x<T>(this T @this, Func<float, float> x_setter) where T : Component {
      @this.gameObject.set_local_pos_x(x_setter(@this.transform.localPosition.x));
      return @this;
    }


    public static GameObject local_pos_x(this GameObject @this, Func<float, float> x_setter) {
      @this.set_local_pos_x(x_setter(@this.transform.localPosition.x));
      return @this;
    }

    //----------------------------------------

    public static T local_pos_x<T>(this T @this, float new_x) where T : Component {
      @this.gameObject.set_local_pos_x(new_x);
      return @this;
    }

    public static GameObject local_pos_x(this GameObject @this, float new_x) {
      @this.set_local_pos_x(new_x);
      return @this;
    }

    public static GameObject set_local_pos_x(this GameObject @this, float new_local_x) {
      @this.transform.localPosition = new Vector3(
        new_local_x,
        @this.transform.localPosition.y,
        @this.transform.localPosition.z
      );
      return @this;
    }

    //----------------------------------------

    public static float local_pos_x<T>(this T @this) where T : Component {
      return @this.transform.localPosition.x;
    }

    public static float local_pos_x(this GameObject @this) {
      return @this.transform.localPosition.x;
    }


    //---------------
    // @local-pos-y
    public static T local_pos_y<T>(this T @this, Func<float, float> y_setter) where T : Component {
      @this.gameObject.set_local_pos_y(y_setter(@this.transform.localPosition.y));
      return @this;
    }


    public static GameObject local_pos_y(this GameObject @this, Func<float, float> y_setter) {
      @this.set_local_pos_y(y_setter(@this.transform.localPosition.y));
      return @this;
    }

    public static T local_pos_y<T>(this T @this, float new_y) where T : Component {
      @this.gameObject.set_local_pos_y(new_y);
      return @this;
    }

    public static GameObject local_pos_y(this GameObject @this, float new_y) {
      @this.set_local_pos_y(new_y);
      return @this;
    }
    public static void set_local_pos_y(this GameObject @this, float new_local_y) {
      @this.transform.localPosition = new Vector3(
        @this.transform.localPosition.x,
        new_local_y,
        @this.transform.localPosition.z
      );
    }

    public static float local_pos_y<T>(this T @this) where T : Component {
      return @this.transform.localPosition.y;
    }

    public static float local_pos_y(this GameObject @this) {
      return @this.transform.localPosition.y;
    }

    //--- local_z
#if UNITz_EDITOR
    [APIDescriptionEN("Sets the positionz calculation to position.z")]
    [APIExampleCode(@" component.local_pos_z(z=>z * 5);")]
#endif
    public static T local_pos_z<T>(this T @this, Func<float, float> z_setter) where T : Component {
      @this.gameObject.set_local_pos_z(z_setter(@this.transform.localPosition.z));
      return @this;
    }

#if UNITz_EDITOR
    [APIDescriptionEN("Sets the positionz calculation to position.z")]
    [APIExampleCode(@" gameObj.local_pos_z(z=>z * 5); ")]
#endif
    public static GameObject local_pos_z(this GameObject @this, Func<float, float> z_setter) {
      @this.set_local_pos_z(z_setter(@this.transform.localPosition.z));
      return @this;
    }

    public static T local_pos_z<T>(this T @this, float new_z) where T : Component {
      @this.gameObject.set_local_pos_z(new_z);
      return @this;
    }

    public static GameObject local_pos_z(this GameObject @this, float new_z) {
      @this.set_local_pos_z(new_z);
      return @this;
    }
    public static void set_local_pos_z(this GameObject @this, float new_local_z) {
      @this.transform.localPosition = new Vector3(
        @this.transform.localPosition.x,
        @this.transform.localPosition.y,
        new_local_z
      );
    }

    public static float local_pos_z<T>(this T @this) where T : Component {
      return @this.transform.localPosition.z;
    }

    public static float local_pos_z(this GameObject @this) {
      return @this.transform.localPosition.z;
    }


    //------------
    // @position
    //------------
    public static T pos_identity<T>(this T @this) where T : Component {
      @this.transform.position = Vector3.zero;
      return @this;
    }

    public static GameObject pos_identity(this GameObject @this) {
      @this.transform.position = Vector3.zero;
      return @this;
    }

    //----------------------------------------
    public static T pos<T>(this T @this, float x, float y, float z) where T : Component {
      @this.gameObject.set_pos(new Vector3(x, y, z));
      return @this;
    }

    public static GameObject pos(this GameObject @this, float x, float y, float z) {
      @this.set_pos(new Vector3(x, y, z));
      return @this;
    }

    //----------------------------------------

    public static T pos<T>(this T @this, float x, float y) where T : Component {
      @this.gameObject.set_pos(new Vector3(x, y, @this.transform.position.z));
      return @this;
    }

    public static GameObject pos(this GameObject @this, float x, float y) {
      @this.set_pos(new Vector3(x, y, @this.transform.position.z));
      return @this;
    }

    //----------------------------------------

    public static T pos<T>(this T @this, Vector3 new_pos)
    where T : Component {
      @this.gameObject.set_pos(new_pos);
      return @this;
    }

    public static GameObject pos(this GameObject @this, Vector3 new_pos) {
      @this.set_pos(new_pos);
      return @this;
    }

    public static GameObject set_pos(this GameObject @this, Vector3 new_pos) {
      @this.transform.position = new_pos;
      return @this;
    }

    //----------------------------------------

    public static Vector3 pos<T>(this T @this) where T : Component {
      return @this.transform.position;
    }

    public static Vector3 pos(this GameObject @this) {
      return @this.transform.position;
    }

    //--------------
    // @position-x
    //--------------


    public static T pos_x<T>(this T @this, Func<float, float> x_setter) where T : Component {
      @this.gameObject.set_pos_x(x_setter(@this.transform.position.x));
      return @this;
    }


    public static GameObject pos_x(this GameObject @this, Func<float, float> x_setter) {
      @this.set_pos_x(x_setter(@this.transform.position.x));
      return @this;
    }

    //----------------------------------------

    public static T pos_x<T>(this T @this, float new_x) where T : Component {
      @this.gameObject.set_pos_x(new_x);
      return @this;
    }

    public static GameObject pos_x(this GameObject @this, float new_x) {
      @this.set_pos_x(new_x);
      return @this;
    }

    public static GameObject set_pos_x(this GameObject @this, float new_x) {
      @this.transform.position = new Vector3(
        new_x,
        @this.transform.position.y,
        @this.transform.position.z
      );
      return @this;
    }

    //----------------------------------------

    public static float pos_x<T>(this T @this) where T : Component {
      return @this.transform.position.x;
    }

    public static float pos_x(this GameObject @this) {
      return @this.transform.position.x;
    }

    //--------------
    // @position-y
    //--------------

    public static T pos_y<T>(this T @this, Func<float, float> y_setter) where T : Component {
      @this.gameObject.set_pos_y(y_setter(@this.transform.position.y));
      return @this;
    }

    public static GameObject pos_y(this GameObject @this, Func<float, float> y_setter) {
      @this.set_pos_y(y_setter(@this.transform.position.y));
      return @this;
    }


    //----------------------------------------

    public static T pos_y<T>(this T @this, float new_y) where T : Component {
      @this.gameObject.set_pos_y(new_y);
      return @this;
    }
    public static GameObject pos_y(this GameObject @this, float new_y) {
      @this.set_pos_y(new_y);
      return @this;
    }
    public static void set_pos_y(this GameObject @this, float new_y) {
      @this.transform.position = new Vector3(
        @this.transform.position.x,
        new_y,
        @this.transform.position.z
      );
    }


    //----------------------------------------

    public static float pos_y<T>(this T @this) where T : Component {
      return @this.transform.position.y;
    }

    public static float pos_y(this GameObject @this) {
      return @this.transform.position.y;
    }


    //--------------
    // @position-z
    //--------------

#if UNITz_EDITOR
    [APIExampleCode(@" component.pos_z(z=>z * 5);")]
#endif
    public static T pos_z<T>(this T @this, Func<float, float> z_setter) where T : Component {
      @this.gameObject.set_pos_z(z_setter(@this.transform.position.z));
      return @this;
    }

#if UNITz_EDITOR
    [APIExampleCode(@" gameObj.pos_z(z=>z * 5); ")]
#endif
    public static GameObject pos_z(this GameObject @this, Func<float, float> zSetter) {
      @this.set_pos_z(zSetter(@this.transform.position.z));
      return @this;
    }


    //----------------------------------------

    public static T pos_z<T>(this T @this, float new_z) where T : Component {
      @this.gameObject.set_pos_z(new_z);
      return @this;
    }
    public static GameObject pos_z(this GameObject @this, float new_z) {
      @this.set_pos_z(new_z);
      return @this;
    }
    public static void set_pos_z(this GameObject @this, float new_z) {
      @this.transform.position = new Vector3(
        @this.transform.position.x,
        @this.transform.position.y,
        new_z
      );
    }


    //----------------------------------------

    public static float pos_z<T>(this T @this) where T : Component {
      return @this.transform.position.z;
    }

    public static float pos_z(this GameObject @this) {
      return @this.transform.position.z;
    }

    //---------------
    // @local-scale
    //---------------
    public static T local_scale<T>(this T @this, float x, float y) where T : Component {
      @this.gameObject.set_local_scale(new Vector3(x, y, @this.transform.localScale.z));
      return @this;
    }

    public static GameObject local_scale(this GameObject @this, float x, float y) {
      @this.set_local_scale(new Vector3(x, y, @this.transform.localScale.z));
      return @this;
    }

    //----------------------------------------

    public static T local_scale<T>(this T @this, float x, float y, float z) where T : Component {
      @this.gameObject.set_local_scale(new Vector3(x, y, z));
      return @this;
    }

    public static GameObject local_scale(this GameObject @this, float x, float y, float z) {
      @this.set_local_scale(new Vector3(x, y, z));
      return @this;
    }

    //----------------------------------------

    public static T local_scale<T>(this T @this, float xyz) where T : Component {
      @this.gameObject.set_local_scale(Vector3.one * xyz);
      return @this;
    }

    public static GameObject local_scale(this GameObject @this, float xyz) {
      @this.set_local_scale(Vector3.one * xyz);
      return @this;
    }

    //----------------------------------------

    public static T local_scale<T>(this T @this, Vector3 scale) where T : Component {
      @this.gameObject.set_local_scale(scale);
      return @this;
    }

    public static GameObject local_scale(this GameObject @this, Vector3 scale) {
      @this.set_local_scale(scale);
      return @this;
    }

    public static GameObject set_local_scale(this GameObject @this, Vector3 scale) {
      @this.transform.localScale = scale;
      return @this;
    }

    //----------------------------------------

    public static Vector3 local_scale<T>(this T @this) where T : Component {
      return @this.transform.localScale;
    }

    public static Vector3 local_scale(this GameObject @this) {
      return @this.transform.localScale;
    }


    //---------------
    // @local-scale-x
    //---------------

    public static T local_scale_x<T>(this T @this, Func<float, float> x_setter) where T : Component {
      @this.gameObject.set_local_scale_x(x_setter(@this.transform.localScale.x));
      return @this;
    }

    public static GameObject local_scale_x(this GameObject @this, Func<float, float> x_setter) {
      @this.set_local_scale_x(x_setter(@this.transform.localScale.x));
      return @this;
    }

    //----------------------------------------

    public static T local_scale_x<T>(this T @this, float new_x) where T : Component {
      @this.gameObject.set_local_scale_x(new_x);
      return @this;
    }

    public static GameObject local_scale_x(this GameObject @this, float new_x) {
      @this.set_local_scale_x(new_x);
      return @this;
    }

    //----------------------------------------

    public static GameObject set_local_scale_x(this GameObject @this, float new_local_x) {
      @this.transform.localScale = new Vector3(
        new_local_x,
        @this.transform.localScale.y,
        @this.transform.localScale.z
      );
      return @this;
    }

    //----------------------------------------

    public static float local_scale_x<T>(this T @this) where T : Component {
      return @this.transform.localScale.x;
    }

    public static float local_scale_x(this GameObject @this) {
      return @this.transform.localScale.x;
    }


    //---------------
    // @local-scale-y
    //---------------

    public static T local_scale_y<T>(this T @this, Func<float, float> y_setter) where T : Component {
      @this.gameObject.set_local_scale_y(y_setter(@this.transform.localScale.y));
      return @this;
    }


    public static GameObject local_scale_y(this GameObject @this, Func<float, float> y_setter) {
      @this.set_local_scale_y(y_setter(@this.transform.localScale.y));
      return @this;
    }

    //----------------------------------------

    public static T local_scale_y<T>(this T @this, float new_y) where T : Component {
      @this.gameObject.set_local_scale_y(new_y);
      return @this;
    }

    public static GameObject local_scale_y(this GameObject @this, float new_y) {
      @this.set_local_scale_y(new_y);
      return @this;
    }

    //----------------------------------------

    public static GameObject set_local_scale_y(this GameObject @this, float new_local_y) {
      @this.transform.localScale = new Vector3(
        @this.transform.localScale.x,
        new_local_y,
        @this.transform.localScale.z
      );
      return @this;
    }

    //----------------------------------------

    public static float local_scale_y<T>(this T @this) where T : Component {
      return @this.transform.localScale.y;
    }

    public static float local_scale_y(this GameObject @this) {
      return @this.transform.localScale.y;
    }


    //-----------------
    // @local-scale-z
    //-----------------
#if UNITz_EDITOR
    [APIExampleCode(@" component.local_scale_z(z=>z * 5);")]
#endif
    public static T local_scale_z<T>(this T @this, Func<float, float> z_setter) where T : Component {
      @this.gameObject.set_local_scale_z(z_setter(@this.transform.localScale.z));
      return @this;
    }

#if UNITz_EDITOR
    [APIExampleCode(@" gameObj.local_scale_z(z=>z * 5); ")]
#endif
    public static GameObject local_scale_z(this GameObject @this, Func<float, float> z_setter) {
      @this.set_local_scale_z(z_setter(@this.transform.localScale.z));
      return @this;
    }

    //----------------------------------------

    public static T local_scale_z<T>(this T @this, float new_z) where T : Component {
      @this.gameObject.set_local_scale_z(new_z);
      return @this;
    }

    public static GameObject local_scale_z(this GameObject @this, float new_z) {
      @this.set_local_scale_z(new_z);
      return @this;
    }

    //----------------------------------------

    public static GameObject set_local_scale_z(this GameObject @this, float new_local_z) {
      @this.transform.localScale = new Vector3(
        @this.transform.localScale.x,
        @this.transform.localScale.y,
        new_local_z
      );
      return @this;
    }

    //----------------------------------------

    public static float local_scale_z<T>(this T @this) where T : Component {
      return @this.transform.localScale.z;
    }

    public static float local_scale_z(this GameObject @this) {
      return @this.transform.localScale.z;
    }

    public static void set_uniform_scale(this GameObject @this, float scale) {
      @this.transform.localScale = Vector3.one * scale;
    }

    //------------------
    // @local-rotation
    //------------------
    public static T local_rot_identity<T>(this T @this) where T : Component {
      @this.transform.localRotation = Quaternion.identity;
      return @this;
    }

    public static GameObject local_rot_identity(this GameObject @this) {
      @this.transform.localRotation = Quaternion.identity;
      return @this;
    }

    //----------------------------------------

    public static Quaternion local_rot<T>(this T @this) where T : Component {
      return @this.transform.localRotation;
    }

    public static Quaternion local_rot(this GameObject @this) {
      return @this.transform.localRotation;
    }

    public static T local_rot<T>(this T @this, Quaternion local_rot) where T : Component {
      @this.transform.localRotation = local_rot;
      return @this;
    }

    public static GameObject local_rot(this GameObject @this, Quaternion local_rot) {
      @this.transform.localRotation = local_rot;
      return @this;
    }

    //------------
    // @rotation
    //------------
    //----------------------------------------

    public static T rot_identity<T>(this T @this) where T : Component {
      @this.transform.rotation = Quaternion.identity;
      return @this;
    }

    public static GameObject rot_identity(this GameObject @this) {
      @this.transform.rotation = Quaternion.identity;
      return @this;
    }

    //----------------------------------------
    public static Quaternion rot<T>(this T @this) where T : Component {
      return @this.transform.rotation;
    }

    public static Quaternion rot(this GameObject @this) {
      return @this.transform.rotation;
    }

    //----------------------------------------

    public static T rot<T>(this T @this, Quaternion rotation) where T : Component {
      @this.transform.rotation = rotation;
      return @this;
    }

    public static GameObject rot(this GameObject @this, Quaternion rotation) {
      @this.transform.rotation = rotation;
      return @this;
    }


    //----------------------------------------
    public static Vector3 euler_angles<T>(this T @this) where T : Component {
      return @this.transform.eulerAngles;
    }

    public static Vector3 euler_angles(this GameObject @this) {
      return @this.transform.eulerAngles;
    }

    public static T euler_angles<T>(this T @this, Vector3 value) where T : Component {
      @this.transform.eulerAngles = value;
      return @this;
    }

    public static GameObject euler_angles(this GameObject @this, Vector3 value) {
      @this.transform.eulerAngles = value;
      return @this;
    }

    //----------------------------------------

    public static float euler_angles_x<T>(this T @this) where T : Component {
      return @this.transform.eulerAngles.x;
    }

    public static float euler_angles_x(this GameObject @this) {
      return @this.transform.eulerAngles.x;
    }

    public static T euler_angles_x<T>(this T @this, float value) where T : Component {
      @this.gameObject.set_euler_angles_x(value);
      return @this;
    }
    public static GameObject euler_angles_x(this GameObject @this, float new_euler_angles_x) {

      @this.set_euler_angles_x(new_euler_angles_x);
      return @this;
    }

    public static void set_euler_angles_x(this GameObject @this, float new_euler_angles_x) {

      @this.transform.eulerAngles = new Vector3(
        new_euler_angles_x,
        @this.transform.eulerAngles.y,
        @this.transform.eulerAngles.z
      );
    }

    //----------------------------------------

    public static float euler_angles_y<T>(this T @this) where T : Component {
      return @this.transform.eulerAngles.y;
    }

    public static float euler_angles_y(this GameObject @this) {
      return @this.transform.eulerAngles.y;
    }

    public static T euler_angles_y<T>(this T @this, float value) where T : Component {
      @this.gameObject.set_euler_angles_y(value);
      return @this;
    }

    public static GameObject euler_angles_y(this GameObject @this, float new_euler_angles_y) {
      @this.set_euler_angles_y(new_euler_angles_y);
      return @this;
    }

    public static void set_euler_angles_y(this GameObject @this, float new_euler_angles_y) {
      @this.transform.eulerAngles = new Vector3(
        @this.transform.eulerAngles.x,
        new_euler_angles_y,
        @this.transform.eulerAngles.z
      );
    }
    //----------------------------------------

    public static float euler_angles_z<T>(this T @this) where T : Component {
      return @this.transform.eulerAngles.z;
    }

    public static float euler_angles_z(this GameObject @this) {
      return @this.transform.eulerAngles.z;
    }

    public static T euler_angles_z<T>(this T @this, float new_euler_angles_z) where T : Component {
      @this.gameObject.set_euler_angles_z(new_euler_angles_z);
      return @this;
    }

    public static GameObject euler_angles_z(this GameObject @this, float new_euler_angles_z) {
      @this.set_euler_angles_z(new_euler_angles_z);
      return @this;
    }

    public static void set_euler_angles_z(this GameObject @this, float new_euler_angles_z) {
      @this.transform.eulerAngles = new Vector3(
        @this.transform.eulerAngles.x,
        @this.transform.eulerAngles.y,
        new_euler_angles_z
      );
    }
    //--------
    // @find
    //--------


    // public static T children_components<T>(this Component @this, string name)
    //             where T : Component {
    //   var children = @this.GetComponentsInChildren<Transform>();
    //   var length = children.Length;
    //   Transform childTrans = null;
    //   for (int i = 0; i < length; i++) {
    //     if (children[i].name == name) {
    //       childTrans = children[i];
    //       break;
    //     }
    //   }
    //   if (childTrans == null)
    //     return null;
    //   var comp = childTrans.GetComponent<T>();
    //   return comp;
    // }
  }
