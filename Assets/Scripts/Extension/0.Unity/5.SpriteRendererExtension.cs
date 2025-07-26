using System.Collections;
using System.Collections.Generic;
using UnityEngine;



  public static class SpriteRendererExtension {
    // size - only work if 'draw-mode=sliced' in editor
    public static SpriteRenderer size_x(this SpriteRenderer @this, float new_size_x) {
      @this.set_size_x(new_size_x);
      return @this;
    }

    public static SpriteRenderer set_size_x(this SpriteRenderer @this, float new_size_x) {
      @this.size = new Vector2(new_size_x, @this.size.y);
      return @this;
    }

    //----------------------------------------

    public static SpriteRenderer size_y(this SpriteRenderer @this, float new_size_y) {
      @this.set_size_y(new_size_y);
      return @this;
    }
    public static SpriteRenderer set_size_y(this SpriteRenderer @this, float new_size_y) {
      @this.size = new Vector2(@this.size.x, new_size_y);
      return @this;
    }

    //----------------------------------------

    public static SpriteRenderer alpha(this SpriteRenderer @this, float new_alpha) {
      @this.set_alpha(new_alpha);
      return @this;
    }

    public static SpriteRenderer set_alpha(this SpriteRenderer @this, float new_alpha) {
      @this.color = new Color(@this.color.r, @this.color.g, @this.color.b, new_alpha);
      return @this;
    }

    //----------------------------------------
    public static SpriteRenderer sprite(this SpriteRenderer @this, Texture2D tex, float pixel_per_unit = 10f) {
      Sprite sprite = Sprite.Create(
        tex,
        new Rect(0.0f, 0.0f, tex.width, tex.height),
        new Vector2(0.5f, 0.5f),
        pixel_per_unit,
        1,
        SpriteMeshType.FullRect
      );
      @this.sprite = sprite;
      return @this;
    }

    public static SpriteRenderer sprite(this SpriteRenderer @this,
        Texture2D tex,
        Vector4 new_border,
        float pixel_per_unit = 10f
    ) {
      // x = left, y = bottom, z = right, w = top
      // Vector4 new_border = new Vector4(
      //     44, 44, 44, 44
      //   );

      Sprite sprite = Sprite.Create(
        tex,
        new Rect(0.0f, 0.0f, tex.width, tex.height),
        new Vector2(0.5f, 0.5f),
        pixel_per_unit,
        1,
        SpriteMeshType.FullRect,
        new_border
      );
      @this.sprite = sprite;
      return @this;
    }
  }
