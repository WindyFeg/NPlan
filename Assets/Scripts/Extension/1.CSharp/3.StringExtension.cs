using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


  public static class StringExtension {

    static StringBuilder stringBuilderCache = new StringBuilder(1024);
    static char[] stringConstant ={
            '0','1','2','3','4','5','6','7','8','9',
            'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
            'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
            };

    public static string get_random_string(int len) {
      stringBuilderCache.Clear();
      Random rd = new Random();
      for (int i = 0; i < len; i++) {
        stringBuilderCache.Append(stringConstant[rd.Next(62)]);
      }
      return stringBuilderCache.ToString();
    }

    public static string append(this string @this, params object[] args) {
      // return StringExtension.append(@this, args);

      if (args == null) {
        throw new ArgumentNullException("Append is invalid.");
      }
      stringBuilderCache.Clear();
      int length = args.Length;
      stringBuilderCache.Append(@this);
      for (int i = 0; i < length; i++) {
        stringBuilderCache.Append(args[i]);
      }
      return stringBuilderCache.ToString();
    }

    public static string append(params object[] args) {
      if (args == null) {
        throw new ArgumentNullException("Append is invalid.");
      }
      stringBuilderCache.Clear();
      int length = args.Length;
      for (int i = 0; i < length; i++) {
        stringBuilderCache.Append(args[i]);
      }
      return stringBuilderCache.ToString();
    }

    public static bool is_numeric(string str) {
      if (string.IsNullOrEmpty(str))
        return false;
      for (int i = 0; i < str.Length; i++) {
        if (!char.IsNumber(str[i])) return false;
      }
      return true;
    }


    public static bool contains(this string @this, IEnumerable<string> keys, bool ignoreCase = true) {
      if (!(keys is ICollection<string> array)) {
        array = keys.ToArray();
      }
      if (array.Count == 0 || string.IsNullOrEmpty(@this)) {
        return false;
      }
      return ignoreCase ? array.Any(item => @this.IndexOf(item, StringComparison.InvariantCultureIgnoreCase) >= 0) : array.Any(@this.Contains);
    }

    public static bool is_null_or_empty(this string @this) {
      return string.IsNullOrEmpty(@this);
    }

    public static string replace(this string @this, Regex regex, string replacement) {
      return regex.Replace(@this, replacement);
    }


    public static bool is_trim_null_or_empty(this string @this) {
      return @this == null || string.IsNullOrEmpty(@this.Trim());
    }


    static readonly char[] _cached_split_char_array = { '.' };
    public static string[] split(this string @this, char split_symbol) {
      _cached_split_char_array[0] = split_symbol;
      return @this.Split(_cached_split_char_array);
    }


    public static string split(
      this string @this,
      string[] separator,
      bool remove_empty_entries,
      int sub_string_index
    ) {
      string[] string_arr = null;
      if (remove_empty_entries)
        string_arr = @this.Split(separator, StringSplitOptions.RemoveEmptyEntries);
      else
        string_arr = @this.Split(separator, StringSplitOptions.None);
      string sub_str = string_arr[sub_string_index];
      return sub_str;
    }


    public static string split(this string @this, string[] separator, int count, bool removeEmptyEntries) {
      string[] stringArray = null;
      if (removeEmptyEntries)
        stringArray = @this.Split(separator, count, StringSplitOptions.RemoveEmptyEntries);
      else
        stringArray = @this.Split(separator, count, StringSplitOptions.None);
      return stringArray.ToString();
    }


    public static string[] split(this string @this, string[] separator) {
      string[] stringArray = null;
      stringArray = @this.Split(separator, StringSplitOptions.None);
      return stringArray;
    }

    public static int len(this string @this) {
      if (string.IsNullOrEmpty(@this))
        throw new ArgumentNullException("context is invalid.");
      return @this.Length;
    }



    public static string fill_format(this string @this, params object[] args) {
      return string.Format(@this, args);
    }


    public static StringBuilder builder(this string @this) {
      return new StringBuilder(@this);
    }

    public static StringBuilder add_prefix(this StringBuilder @this, string prefix_str) {
      @this.Insert(0, prefix_str);
      return @this;
    }

    // public static StringBuilder append(this string @this, string to_append) {
    //   return new StringBuilder(@this).Append(to_append);
    // }

    public static float to_float(this string @this, float default_value = 0) {
      return float.TryParse(@this, out var return_val) ? return_val : default_value;
    }

    public static int to_int(this string @this, int default_value = 0) {
      return int.TryParse(@this, out var return_val) ? return_val : default_value;
    }

    public static long to_long(this string @this, long default_value = 0) {
      return long.TryParse(@this, out var return_val) ? return_val : default_value;
    }

    public static double to_double(this string @this, double default_value = 0) {
      return double.TryParse(@this, out var return_val) ? return_val : default_value;
    }



  }
