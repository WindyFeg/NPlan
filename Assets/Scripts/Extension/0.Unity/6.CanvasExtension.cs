using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


  public static class CanvasExtension {
    public static RectTransform rt(this Canvas @this) {
      return @this.GetComponent<RectTransform>();
    }

    public static CanvasScaler cs(this Canvas @this) {
      return @this.GetComponent<CanvasScaler>();
    }

    //--------
    // @size
    //--------
    public static float width(this Canvas @this) {
      RectTransform canvas_rt = @this.GetComponent<RectTransform>();
      return @this.get_rect_width();
    }

    public static float get_rect_width(this Canvas @this) {
      RectTransform canvas_rt = @this.GetComponent<RectTransform>();
      return canvas_rt.rect.width;
    }

    //----------------------------------------
    public static float height(this Canvas @this) {
      RectTransform canvas_rt = @this.GetComponent<RectTransform>();
      return @this.get_rect_height();
    }
    public static float get_rect_height(this Canvas @this) {
      RectTransform canvas_rt = @this.GetComponent<RectTransform>();
      return canvas_rt.rect.height;
    }

    public static float get_portrait_width_in_rt(this Canvas @this) {
      Rect rect = @this.rt().rect;
      return rect.width < rect.height ? rect.width : rect.height;
    }

    public static float get_portrait_height_in_rt(this Canvas @this) {
      Rect rect = @this.rt().rect;
      return rect.width < rect.height ? rect.height : rect.width;
    }

    public static float get_landscape_width_in_rt(this Canvas @this) {
      Rect rect = @this.rt().rect;
      return rect.width >= rect.height ? rect.width : rect.height;
    }

    public static float get_landscape_height_in_rt(this Canvas @this) {
      Rect rect = @this.rt().rect;
      return rect.width >= rect.height ? rect.height : rect.width;
    }

    public static float get_scale_of_screen_size_to_ref_resolution(this Canvas @this) {
      Vector2 scalerRefResolution = @this.cs().referenceResolution;
      float scalerMatchWidthOrHeight = @this.cs().matchWidthOrHeight;
      float a = Mathf.Pow(Screen.width / scalerRefResolution.x,
          1f - scalerMatchWidthOrHeight);
      float b = Mathf.Pow(Screen.height / scalerRefResolution.y,
          scalerMatchWidthOrHeight);
      return a * b;
    }

    public static void log_pixel_adjust_rect(this Canvas @this) {
      RectTransform rt = @this.GetComponent<RectTransform>();
      Rect rect = RectTransformUtility.PixelAdjustRect(rt, @this);
      Debug.Log($@"
      canvasPixelAdjustRect
      sizeDelta: {rt.sizeDelta}
      x: {rect.x} 
      y: {rect.y}
      w/h: {rect.width / rect.height}
    ");
    }

    public static Vector3 get_screen_to_world_on_plane_distance(this Canvas @this,
        Vector3 point) {
      point.z = @this.planeDistance;
      return Camera.main.ScreenToWorldPoint(point);
    }
  }
