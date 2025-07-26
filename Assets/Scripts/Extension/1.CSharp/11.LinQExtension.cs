using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

#if UNITY_EDITOR

  public static class LinqExtension {

    // Return the first item when the list is of length one and otherwise returns default
    public static TSource only_or_default<TSource>(this IEnumerable<TSource> source) {
      // aclf.assert.is_not_null(source);

      if (source.Count() > 1) {
        return default(TSource);
      }

      return source.FirstOrDefault();
    }
  }

#endif
