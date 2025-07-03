#if UNITY_EDITOR

    using System.Diagnostics;
    using System.IO;
  using System.Runtime.Serialization.Formatters.Binary;
  using System.Text;
    using LKT268.Utils;

    public static class IOExtension {


    public static string create_dir_if_not_exists(this string dir_full_path) {
      if (!Directory.Exists(dir_full_path)) {
        Directory.CreateDirectory(dir_full_path);
      }
      return dir_full_path;
    }

    public static void create_dir_from_path(string path, string dir_name) {
      var fullPath = Path.Combine(path, dir_name);
      var dir = new DirectoryInfo(fullPath);
      if (!dir.Exists) {
        dir.Create();
        LTK268Log.LogInfo("Path:" + path + "Folder is created ");
      }
    }



    public static void del_dir_if_exists(this string dir_full_path) {
      if (Directory.Exists(dir_full_path)) {
        Directory.Delete(dir_full_path, true);
      }
    }


    public static void empty_dir_if_exists(this string dir_full_path) {
      if (Directory.Exists(dir_full_path)) {
        Directory.Delete(dir_full_path, true);
      }

      Directory.CreateDirectory(dir_full_path);
    }


    public static bool del_file_if_exists(this string file_full_path) {
      if (File.Exists(file_full_path)) {
        File.Delete(file_full_path);
        return true;
      }

      return false;
    }



    public static string combine_path(this string @this, string to_combine_path) {
      return Path.Combine(@this, to_combine_path);
    }

    public static string get_file_name(this string file_path) {
      return Path.GetFileName(file_path);
    }



    public static string get_file_name_without_extend(this string file_path) {
      return Path.GetFileNameWithoutExtension(file_path);
    }


    public static string get_file_extend_name(this string file_path) {
      return Path.GetExtension(file_path);
    }



    public static string get_dir_path(this string path) {
      if (string.IsNullOrEmpty(path)) {
        return string.Empty;
      }

      return Path.GetDirectoryName(path);
    }

    public static string get_dir_last_name(this string path) {
      if (!Directory.Exists(path)) return string.Empty;
      return new DirectoryInfo(path).Name;
    }

    public static bool is_dir(this string path) {
      return Directory.Exists(path);
    }

    public static bool is_file(this string path) {
      return File.Exists(path);
    }


    public static void copy_to_file(
        this Stream @this,
        string dest,
        int bufferSize = 1024 * 8 * 1024
      ) {
      using (var fsWrite = new FileStream(dest, FileMode.OpenOrCreate, FileAccess.ReadWrite)) {
        byte[] buf = new byte[bufferSize];
        int len;
        while ((len = @this.Read(buf, 0, buf.Length)) != 0) {
          fsWrite.Write(buf, 0, len);
        }
      }
    }

    public static void copy_file_to_dir(
        string scr_file_name,
        string folder_path,
        bool overwrite = true) {

      if (File.Exists(scr_file_name)) {
        var file_name = Path.GetDirectoryName(scr_file_name);
        if (!Directory.Exists(folder_path)) {
          Directory.CreateDirectory(folder_path);
        }
        var dest_file_name = Path.Combine(folder_path, file_name);
        File.Copy(scr_file_name, dest_file_name, overwrite);
      }
    }

    public static void copy_file(
        string src_file_name,
        string dest_file_name,
        bool overwrite = true) {

      if (File.Exists(src_file_name)) {
        var directory = Path.GetDirectoryName(dest_file_name);
        if (!Directory.Exists(directory)) {
          Directory.CreateDirectory(directory);
        }
        File.Copy(src_file_name, dest_file_name, overwrite);
      }
    }

    public static void copy_dir(string source, string target) {
      DirectoryInfo diSource = new DirectoryInfo(source);
      DirectoryInfo diTarget = new DirectoryInfo(target);
      copy_directory_recursively(diSource, diTarget);
    }

    public static void copy_directory_recursively(
        DirectoryInfo source,
        DirectoryInfo target) {
      Directory.CreateDirectory(target.FullName);
      //copy all files to new location
      foreach (FileInfo fi in source.GetFiles()) {
        fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
      }
      //Recursively copy all sub-items
      foreach (DirectoryInfo di_source_sub_dir in source.GetDirectories()) {
        DirectoryInfo next_target_sub_dir =
            target.CreateSubdirectory(di_source_sub_dir.Name);
        copy_directory_recursively(di_source_sub_dir, next_target_sub_dir);
      }
    }
    public static void rename_file(
        string old_file_full_path,
        string new_file_namewith_extension) {
      if (!File.Exists(old_file_full_path)) {
        using (FileStream fs = File.Create(old_file_full_path)) { }
      }
      var dir_path = Path.GetDirectoryName(old_file_full_path);
      var new_file_name = Path.Combine(dir_path, new_file_namewith_extension);
      if (File.Exists(new_file_name))
        File.Delete(new_file_name);
      File.Move(old_file_full_path, new_file_name);
    }

    //--------
    // @read
    //--------
    public static string read_text_file_content(string folder_path, string file_name) {
      if (!Directory.Exists(folder_path))
        throw new IOException("ReadTextFileContent folder path not exist !" + folder_path);
      return read_text_file_content(Path.Combine(folder_path, file_name));
    }
    static UTF8Encoding utf8Encoding = new UTF8Encoding(false);
    public static string read_text_file_content(string file_full_path) {
      if (!File.Exists(file_full_path))
        throw new IOException("ReadTextFileContent path not exist !" + file_full_path);
      string result = string.Empty;
      using (FileStream stream = File.Open(file_full_path, FileMode.Open)) {
        using (StreamReader reader = new StreamReader(stream, utf8Encoding)) {
          result.append(reader.ReadToEnd());
        }
      }
      return result;
    }


    //---------
    // @write
    //---------
    public static void append_write_text_file(
        string file_path,
        string file_name,
        string context) {
      if (!Directory.Exists(file_path))
        Directory.CreateDirectory(file_path);

      using (FileStream stream = new FileStream(
          Path.Combine(file_path, file_name), FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite)
      ) {
        stream.Position = stream.Length;
        using (StreamWriter writer = new StreamWriter(stream, utf8Encoding)) {
          writer.WriteLine(context);
          writer.Flush();
        }
      }

    }

    public static void append_write_text_file(string file_full_path, string context) {
      var folder_path = Path.GetDirectoryName(file_full_path);
      if (!Directory.Exists(folder_path))
        Directory.CreateDirectory(folder_path);

      using (FileStream stream = new FileStream(
        file_full_path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite)
      ) {
        stream.Position = stream.Length;
        using (StreamWriter writer = new StreamWriter(stream, utf8Encoding)) {
          writer.WriteLine(context);
          writer.Flush();
        }
      }
    }
    public static void write_text_file(
      string file_path,
      string file_name,
      string context,
      bool append = false
    ) {
      if (!Directory.Exists(file_path))
        Directory.CreateDirectory(file_path);

      using (FileStream stream = File.Open(
          Path.Combine(file_path, file_name), FileMode.OpenOrCreate
          , FileAccess.ReadWrite, FileShare.ReadWrite)
      ) {
        if (append)
          stream.Position = stream.Length;

        using (StreamWriter writer = new StreamWriter(stream, utf8Encoding)) {
          writer.WriteLine(context);
          writer.Flush();
        }
      }
    }

    public static void write_text_file(
      string file_full_path,
      string context,
      bool append = false
    ) {
      var folder_path = Path.GetDirectoryName(file_full_path);
      if (!Directory.Exists(folder_path))
        Directory.CreateDirectory(folder_path);

      using (FileStream stream = File.Open(
        file_full_path, FileMode.OpenOrCreate,
        FileAccess.ReadWrite, FileShare.ReadWrite)
      ) {
        if (append)
          stream.Position = stream.Length;

        using (StreamWriter writer = new StreamWriter(stream, utf8Encoding)) {
          writer.WriteLine(context);
          writer.Flush();
        }
      }
    }

    public static void overwrite_text_file(
      string file_path,
      string file_name,
      string context
    ) {
      if (!Directory.Exists(file_path))
        Directory.CreateDirectory(file_path);

      var file_full_path = Path.Combine(file_path, file_name);

      using (FileStream stream = File.Open(
            file_full_path,
            FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite)
          ) {
        stream.Seek(0, SeekOrigin.Begin);
        stream.SetLength(0);
        using (StreamWriter writer = new StreamWriter(stream, utf8Encoding)) {
          writer.WriteLine(context);
          writer.Flush();
        }
      }
    }

    public static void overwrite_text_file(
        string file_full_path,
        string context) {
      var folder_path = Path.GetDirectoryName(file_full_path);
      if (!Directory.Exists(folder_path))
        Directory.CreateDirectory(folder_path);
      using (FileStream stream = File.Open(
            file_full_path, 
            FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite)
          ) {
        stream.Seek(0, SeekOrigin.Begin);
        stream.SetLength(0);
        using (StreamWriter writer = new StreamWriter(stream, utf8Encoding)) {
          writer.WriteLine(context);
          writer.Flush();
        }
      }
    }


  }

#endif
