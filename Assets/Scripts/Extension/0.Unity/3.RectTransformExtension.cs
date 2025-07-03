using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum AnchorPresets {
  TopLeft = 0,
  TopCenter,
  TopRight,

  MiddleLeft,
  MiddleCenter,
  MiddleRight,

  BottomLeft,
  BottonCenter,
  BottomRight,
}

public enum RectTransformAnchorHorizontal {
  left,
  center,
  right,
  stretch
}

public enum RectTransformAnchorVertical {
  top,
  middle,
  bottom,
  stretch
}

public static class RectTransformExtensions {

  public static RectTransform anchor_min_x(this RectTransform @this, float new_x) {
    @this.set_anchor_min_x(new_x); return @this;
  }

  public static void set_anchor_min_x(this RectTransform rt, float new_x) {
    rt.anchorMin = new Vector2(
      new_x,
      rt.anchorMin.y
    );
  }

  public static void set_anchor_min_y(this RectTransform rt, float new_y) {
    rt.anchorMin = new Vector2(
      rt.anchorMin.x,
      new_y
    );
  }

  public static void set_anchor_max_x(this RectTransform rt, float new_x) {
    rt.anchorMax = new Vector2(
      new_x,
      rt.anchorMax.y
    );
  }

  public static void set_anchor_max_y(this RectTransform rt, float new_y) {
    rt.anchorMax = new Vector2(
      rt.anchorMax.x,
      new_y
    );
  }

  public static void set_anchor_presets(this RectTransform rt, AnchorPresets ap) {
    float[] top_left = { 0, 1f, 0, 1f };
    float[] top_center = { 0.5f, 1f, 0.5f, 1f };
    float[] top_right = { 1f, 1f, 1f, 1f };

    float[] middle_left = { 0, 0.5f, 0, 0.5f };
    float[] middle_center = { 0.5f, 0.5f, 0.5f, 0.5f };
    float[] middle_right = { 1f, 0.5f, 1f, 0.5f };

    float[] bottom_left = { 0, 0, 0, 0 };
    float[] bottom_center = { 0.5f, 0, 0.5f, 0 };
    float[] bottom_right = { 1f, 0, 1f, 0 };
    //
    float[][] table = {
      top_left, top_center, top_right,
      middle_left, middle_center, middle_right,
      bottom_left, bottom_center, bottom_right
    };
    int enum_id = (int)(ap);
    int id = 0;
    rt.anchorMin = new Vector2(table[enum_id][id++], table[enum_id][id++]);
    rt.anchorMax = new Vector2(table[enum_id][id++], table[enum_id][id]);
  }

  public static void set_anchor_preset(
      this RectTransform rt,
      RectTransformAnchorHorizontal anchor_horizontal,
      RectTransformAnchorVertical anchor_vertical
      ) {
    float anchor_min_x =
      anchor_horizontal == RectTransformAnchorHorizontal.left ? 0 :
      anchor_horizontal == RectTransformAnchorHorizontal.center ? 0.5f :
      anchor_horizontal == RectTransformAnchorHorizontal.right ? 1 :
      0;
    float anchor_min_y =
        anchor_vertical == RectTransformAnchorVertical.top ? 1 :
        anchor_vertical == RectTransformAnchorVertical.middle ? 0.5f :
        anchor_vertical == RectTransformAnchorVertical.bottom ? 0 :
        0;
    float anchor_max_x =
        anchor_horizontal == RectTransformAnchorHorizontal.left ? 0 :
        anchor_horizontal == RectTransformAnchorHorizontal.center ? 0.5f :
        anchor_horizontal == RectTransformAnchorHorizontal.right ? 1 :
        1;
    float anchor_max_y =
        anchor_vertical == RectTransformAnchorVertical.top ? 1 :
        anchor_vertical == RectTransformAnchorVertical.middle ? 0.5f :
        anchor_vertical == RectTransformAnchorVertical.bottom ? 0 :
        1;
    float pivot_x =
        anchor_horizontal == RectTransformAnchorHorizontal.left ? 0 :
        anchor_horizontal == RectTransformAnchorHorizontal.center ? 0.5f :
        anchor_horizontal == RectTransformAnchorHorizontal.right ? 1 :
        0.5f;
    float pivot_y =
        anchor_vertical == RectTransformAnchorVertical.top ? 1 :
        anchor_vertical == RectTransformAnchorVertical.middle ? 0.5f :
        anchor_vertical == RectTransformAnchorVertical.bottom ? 0 :
        0.5f;
    rt.anchorMin = new Vector2(anchor_min_x, anchor_min_y);
    rt.anchorMax = new Vector2(anchor_max_x, anchor_max_y);
    rt.pivot = new Vector2(pivot_x, pivot_y);
  }

  //----------------
  //-- @anchor-pos
  //----------------
  public static Vector3 apos(this RectTransform @this) {
    return @this.anchoredPosition3D;
  }

  public static RectTransform apos(this RectTransform @this, Vector3 new_apos) {
     @this.anchoredPosition3D = new_apos;
     return @this;
  }

  //------------------
  //-- @anchor-pos-x
  //------------------
  public static float apos_x(this RectTransform @this) {
    return @this.anchoredPosition3D.x;
  }

  public static RectTransform apos_x(this RectTransform @this, float new_x) {
     @this.set_pos_x(new_x);
     return @this;
  }

  public static void set_pos_x(this RectTransform rt, float new_x) {
    rt.anchoredPosition3D = new Vector3(
      new_x,
      rt.anchoredPosition3D.y,
      rt.anchoredPosition3D.z
    );
  }

  //------------------
  //-- @anchor-pos-y
  //------------------
  public static float apos_y(this RectTransform @this) {
    return @this.anchoredPosition3D.y;
  }

  public static RectTransform apos_y(this RectTransform @this, float new_y) {
     @this.set_pos_y(new_y);
     return @this;
  }

  public static void set_pos_y(this RectTransform rt, float new_y) {
    rt.anchoredPosition3D = new Vector3(
      rt.anchoredPosition3D.x,
      new_y,
      rt.anchoredPosition3D.z
    );
  }

  //------------------
  //-- @anchor-pos-z
  //------------------
  public static float apos_z(this RectTransform @this) {
    return @this.anchoredPosition3D.z;
  }

  public static RectTransform apos_z(this RectTransform @this, float new_z) {
     @this.set_pos_z(new_z);
     return @this;
  }

  public static void set_pos_z(this RectTransform rt, float new_z) {
    rt.anchoredPosition3D = new Vector3(
      rt.anchoredPosition3D.x,
      rt.anchoredPosition3D.y,
      new_z
    );
  }

  public static void set_left(this RectTransform rt, float x) {
    rt.offsetMin = new Vector2(x, rt.offsetMin.y);
  }

  public static void set_right(this RectTransform rt, float x) {
    rt.offsetMax = new Vector2(-x, rt.offsetMax.y);
  }

  public static void set_bottom(this RectTransform rt, float y) {
    rt.offsetMin = new Vector2(rt.offsetMin.x, y);
  }

  public static void set_top(this RectTransform rt, float y) {
    rt.offsetMax = new Vector2(rt.offsetMax.x, -y);
  }

  public static void set_width(this RectTransform rt, float w) {
    rt.sizeDelta = new Vector2(w, rt.sizeDelta.y);
  }

  public static void set_height(this RectTransform rt, float h) {
    rt.sizeDelta = new Vector2(rt.sizeDelta.x, h);
  }

  public static float get_width_in_screen_space(this RectTransform rt) {
    return (float)(rt.anchorMax.x - rt.anchorMin.x) * Screen.width;
  }

  public static float get_height_in_screen_space(this RectTransform rt) {
    return (float)(rt.anchorMax.y - rt.anchorMin.y) * Screen.height;
  }

  public static float get_width_in_world_space(this RectTransform rt) {
    var worldCorners = new Vector3[4];
    rt.GetWorldCorners(worldCorners);
    return worldCorners[2].x - worldCorners[1].x;
  }

  public static float get_height_in_world_space(this RectTransform rt) {
    var worldCorners = new Vector3[4];
    rt.GetWorldCorners(worldCorners);
    return worldCorners[1].y - worldCorners[0].y;
  }


  //--------------
  //-- @distance
  //--------------

  public static Vector3 diff_from(this RectTransform @this, RectTransform target) {
    return diff_to(@this, target) * -1.0f;
  }

  public static Vector3 diff_to(this RectTransform @this, RectTransform target) {
    return @this.anchoredPosition3D - target.anchoredPosition3D;
  }


  public static void log_rect(this RectTransform rt) {
    Rect rect = rt.rect;
    Debug.Log($@"
      rect info
      width: {rect.width}
      height: {rect.height}
      sizeDelta: {rt.sizeDelta}
      x: {rect.x} 
      y: {rect.y}
      w/h: {rect.width / rect.height}
    ");
  }

  // corners means positions of all anchors of recttransform 
  // [botLeft, topLeft, topRight, bottomRight]

  public static void log_world_corners(this RectTransform rt) {
    Vector3[] worldCorners = get_corners_in_world_space(rt);
    Debug.Log($@"
      RectTransform world corners
      botLeft: {worldCorners[0]}
      topLeft: {worldCorners[1]}
      topRight: {worldCorners[2]}
      bottomRight: {worldCorners[3]}
    ");
  }

  public static Vector3[] get_corners_in_world_space(this RectTransform rt) {
    var worldCorners = new Vector3[4];
    rt.GetWorldCorners(worldCorners);
    return worldCorners;
  }

  public static void log_corners_in_screen(this RectTransform rt) {
    Vector3[] screenCorners = get_corners_in_screen_space(rt);
    if (screenCorners == null) {
      Debug.Log("not found screen corners");
      return;
    }
    Debug.Log($@"
      RectTransform screen corners
      botLeft: {screenCorners[0]}
      topLeft: {screenCorners[1]}
      topRight: {screenCorners[2]}
      bottomRight: {screenCorners[3]}
    ");
  }

  public static Vector3[] get_corners_in_screen_space(this RectTransform rt,
      bool cutDecimals = false) {
    Camera cam = GameObject.Find("Main Camera")?.GetComponent<Camera>();
    if (cam == null) 
      cam = GameObject.Find("main-camera")?.GetComponent<Camera>();

    if (cam == null) return null;
    var worldCorners = new Vector3[4];
    var screenCorners = new Vector3[4];
    rt.GetWorldCorners(worldCorners);
    for (int i = 0; i < 4; i++) {
      // Debug.Log($"corner {i} in worlds: {worldCorners[i]}");
      screenCorners[i] = cam.WorldToScreenPoint(worldCorners[i]);
      if (cutDecimals) {
        screenCorners[i].x = (int)screenCorners[i].x;
        screenCorners[i].y = (int)screenCorners[i].y;
      }
    }
    return screenCorners;
  }

  public static void log_corners_from_screen_to_local(this RectTransform rt) {
    List<Vector3> localCorners = get_corners_from_screen_to_local_list(rt);
    if (localCorners == null) {
      Debug.Log("not found local corners");
      return;
    }
    Debug.Log($@"
      RectTransform from screen to local corners
      botLeft: {localCorners[0]}
      topLeft: {localCorners[1]}
      topRight: {localCorners[2]}
      bottomRight: {localCorners[3]}
    ");
  }

  public static List<Vector3> get_corners_from_screen_to_local_list(this RectTransform rt) {
    Camera cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    if (cam == null) return null;
    Vector3[] screenCorners = get_corners_in_screen_space(rt);
    if (screenCorners == null) return null;
    var output = new List<Vector3>();
    foreach (Vector3 corner in screenCorners) {
      Vector2 tmp = Vector2.zero;
      RectTransformUtility.ScreenPointToLocalPointInRectangle(rt, corner, cam, out tmp);
      output.Add(tmp);
    }
    return output;
  }


  public static bool is_in(this RectTransform rt, RectTransform container_rt) {
    Rect rec = container_rt.rect;
    Vector2 scale = container_rt.transform.localScale;
    float left = container_rt.anchoredPosition.x - rec.width / 2 * scale.x;
    float right = container_rt.anchoredPosition.x + rec.width / 2 * scale.x;
    float top = container_rt.anchoredPosition.y + rec.height / 2 * scale.y;
    float bottom = container_rt.anchoredPosition.y - rec.height / 2 * scale.y;
    if (rt.anchoredPosition.x < left) return false;
    if (rt.anchoredPosition.x > right) return false;
    if (rt.anchoredPosition.y > top) return false;
    if (rt.anchoredPosition.y < bottom) return false;
    return true;
  }

  public static void set_luna_custom_size(this RectTransform rt, float width, float height) {
    float new_x = width >= 0 ? width : rt.sizeDelta.x;
    float new_y = height >= 0 ? height : rt.sizeDelta.y;
    rt.sizeDelta = new Vector2(new_x, new_y);
  }

}
