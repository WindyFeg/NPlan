using System;
using System.Globalization;


  public static class TypeConversionExtension {

    //------------
    //-- @nums
    //------------

    public static int to_int(this double @this) {
      return (int)Math.Floor(@this);
    }

    public static int to_int(this decimal @this) {
      return (int)Math.Floor(@this);
    }

    public static double to_double(this decimal @this) {
      return (double)@this;
    }

    public static double to_double(this int @this) {
      return @this * 1.0;
    }

    //------------------
    //-- @IConvertible
    //------------------
    public static T convert_to<T>(this IConvertible @this) where T : IConvertible {
      return (T)convert_to(@this, typeof(T));
    }

    public static T try_convert_to<T>(this IConvertible @this, T default_value = default) where T : IConvertible {
      try {
        return (T)convert_to(@this, typeof(T));
      } catch {
        return default_value;
      }
    }

    public static bool try_convert_to<T>(this IConvertible @this, out T result) where T : IConvertible {
      try {
        result = (T)convert_to(@this, typeof(T));
        return true;
      } catch {
        result = default;
        return false;
      }
    }

    public static bool try_convert_to(this IConvertible @this, Type type, out object result) {
      try {
        result = convert_to(@this, type);
        return true;
      } catch {
        result = default;
        return false;
      }
    }
    //
    public static object convert_to(this IConvertible @this, Type type) {
      if (null == @this) {
        return Activator.CreateInstance(type);
      }
      if (type.IsEnum) {
        return Enum.Parse(type, @this.ToString(CultureInfo.InvariantCulture));
      }
      if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>)) {
        var underlyingType = Nullable.GetUnderlyingType(type);
        if (underlyingType != null) {
          return underlyingType.IsEnum ? Enum.Parse(underlyingType, @this.ToString(CultureInfo.CurrentCulture)) : Convert.ChangeType(@this, underlyingType);
        }
      }
      return Convert.ChangeType(@this, type);
    }
  }
