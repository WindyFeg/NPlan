using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


  public static class CSharpObjectExtension {


    public static T self<T>(this T self, Action<T> on_do) {
      on_do?.Invoke(self);
      return self;
    }

    public static T self<T>(this T self, Func<T, T> onDo) {
      return onDo.Invoke(self);
    }


    public static bool is_null<T>(this T @this) where T : class {
      //return null == @this;
      return ReferenceEquals(null,@this) == true;
    }

    public static bool is_not_null<T>(this T @this) where T : class {
      //return null != @this;
      return ReferenceEquals(null,@this) == false;
    }



    public static T As<T>(this object @this) where T : class {
      return @this as T;
    }

  }

