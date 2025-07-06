using System.Collections;
using System.Collections.Generic;
using LKT268;
using UnityEngine;
using UnityEngine.UI;


  public static class GraphicExtension {

    //---------
    // @color
    //---------

    public static Color html_str_to_color(this string html_string) {

      var flag = ColorUtility.TryParseHtmlString(
        html_string,
        out var rgb_color
      );
      return flag ? rgb_color : Color.black;
      // to convert back to html string
      //       Color newCol = Color.red;
      // string htmlValue = ColorUtility.ToHtmlStringRGBA(newCol);
    }


    public static T color_alpha<T>(this T @this, float alpha) where T : Graphic {
      var color = @this.color;
      color.a = alpha;
      @this.color = color;
      return @this;
    }

    //---------
    // @image
    //---------
    public static Image fill_amount(this Image @this, float new_val) {
      @this.fillAmount = new_val;
      return @this;
    }

    public static Image set_fill_amount(this Image @this, float new_val) {
      @this.fillAmount = new_val;
      return @this;
    }

    public static Image set_tex(this Image @this, Texture2D tex) {
      @this.set_sprite_from_tex(tex);
      return @this;
    }
    public static Image set_tex_without_resize(this Image @this, Texture2D tex) {
      @this.sprite = Sprite.Create(tex,
          new Rect(0.0f, 0.0f, tex.width, tex.height),
          new Vector2(0.5f, 0.5f),
          100.0f);
      return @this;
    }

    public static void set_sprite_from_tex(this Image @this, Texture2D tex) {
      Sprite sprite = Sprite.Create(tex,
          new Rect(0.0f, 0.0f, tex.width, tex.height),
          new Vector2(0.5f, 0.5f),
          100.0f);
      @this.sprite = sprite;
      @this.rt().sizeDelta = new Vector2(tex.width, tex.height);
    }

    //-------------
    // @raw-image
    //-------------
    public static void tex(this RawImage @this, Texture2D tex) {
      @this.texture = tex;
      @this.rt().sizeDelta = new Vector2(tex.width, tex.height);
    }

    public static void set_tex_without_resize(this RawImage @this, Texture2D tex) {
      @this.texture = tex;
    }

    //-------------------------
    //-- @particle-system/@ps
    //-------------------------
    public static void change_color_but_keep_alpha(this ParticleSystem @this, Color new_color) {
      new_color.a = @this.main.startColor.color.a;

      var main_module = @this.main;
      main_module.startColor = new ParticleSystem.MinMaxGradient(new_color);
    }

    public static void max_particles(this ParticleSystem @this, int value) {
      var main = @this.main;
      main.maxParticles = value;
    }
#if UNITY_EDITOR
    //--------
    // fonts
    //--------
    // public static Font load_default_main_asset(this Font @this, string file_path) {
    //   if (@this == null ) {
    //     return file_path.load_main_asset() as Font;
    //   }
    //   return @this;
    // }

    //-------------
    // @Texture2D
    //-------------
    // public static Texture2D load_default_main_asset(this Texture2D @this, string file_path) {
    //   if (@this != null) return @this;
    //   //
    //   @this = file_path.load_main_asset() as Texture2D;
    //   return @this;
    // }

#endif
  }
