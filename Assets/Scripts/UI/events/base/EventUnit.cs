using System;
using System.Collections.Generic;
using aclf;
using UnityEngine;


  //----------
  // @eventS
  //----------
  // public class UnitEvents {
  //    static UnitEvents mGlobalEvents = new UnitEvents();
  //
  //   public static T Get<T>() where T : IEventUnit {
  //     return mGlobalEvents.GetEvent<T>();
  //   }
  //
  //
  //   public static void register<T>() where T : IEventUnit, new() {
  //     mGlobalEvents.AddEvent<T>();
  //   }
  //
  //    Dictionary<Type, IEventUnit> mTypeEvents = new Dictionary<Type, IEventUnit>();
  //
  //   public void AddEvent<T>() where T : IEventUnit, new() {
  //     mTypeEvents.Add(typeof(T), new T());
  //   }
  //
  //   public T GetEvent<T>() where T : IEventUnit {
  //     IEventUnit e;
  //
  //     if (mTypeEvents.TryGetValue(typeof(T), out e)) {
  //       return (T)e;
  //     }
  //
  //     return default;
  //   }
  //
  //   public T GetOrAddEvent<T>() where T : IEventUnit, new() {
  //     var eType = typeof(T);
  //     if (mTypeEvents.TryGetValue(eType, out var e)) {
  //       return (T)e;
  //     }
  //
  //     var p1 = new T();
  //     mTypeEvents.Add(eType, p1);
  //     return p1;
  //   }
  // }

  //-----------------------
  // @a_event-zero params
  //-----------------------

  //public class EventUnit : IEventUnit {
  //  Action _on_event = () => { };

  //  public IUnRegister register(Action on_event) {
  //    this._on_event += on_event;
  //    return new CustomUnRegister(() => { unregister(on_event); });
  //  }

  //  public void unregister(Action on_event) {
  //    _on_event -= on_event;
  //  }

  //  public void notify() {
  //    _on_event?.Invoke();
  //  }
  //}

  //--------------
  // @zero-param
  //--------------
  public class EventUnit : IEventUnit {
    public List<KeyValuePair<Action, int>> callbacks = new List<KeyValuePair<Action, int>>();

    public IUnRegister register(Action callback, int priority = 100) {

      this.callbacks.Add(new KeyValuePair<Action, int>(callback, priority));

      utils.algo.sort_by_descend(this.callbacks, cb => cb.Value, 0, this.callbacks.Count - 1);

      return new CustomUnRegister(() => { unregister(callback); });
    }

    public void unregister(Action input_callback) {
      // Collect the items to be removed
      List<KeyValuePair<Action, int>> clone = new List<KeyValuePair<Action, int>>();
      foreach (var cb in this.callbacks) {
        if (ReferenceEquals(cb.Key, input_callback)) {
          clone.Add(cb);
        }
      }

      foreach (var cb in clone) {
        this.callbacks.Remove(cb);
      }

    }

    public void notify() {

      // use for-each loop may leads to this 
      // [ERROR]: c# collection was modified; enumeration operation may not execute
      // [REASON]: cannot enumerate a collection in a foreach block and modify the collection in the same block. As it may register and deregister events to dict constantly
      //  [SOLUTION]: get back to a plain old index iteration, starting from the end of the collection
      // foreach (var cb in clone) {
      //   cb.Key?.Invoke();
      // }

      for (int i = 0; i < this.callbacks.Count; i++) {
        this.callbacks[i].Key?.Invoke();
      }
    }

    public bool has_action(Action input_action) {
      foreach (var cb in this.callbacks) {
        if (ReferenceEquals(cb.Key, input_action)) {
          return true;
        }
      }

      return false;
    }


    public void debug(string event_name) {


    }

  }



  //---------------------
  // @a_event-one param
  //---------------------
  //public class EventUnit<TParam1> : IEventUnit {
  //  Action<TParam1> _on_event = (p1) => { };

  //  public IUnRegister register(Action<TParam1> on_event) {
  //    _on_event += on_event;
  //    return new CustomUnRegister(() => { unregister(on_event); });
  //  }

  //  public void unregister(Action<TParam1> on_event) {
  //    _on_event -= on_event;
  //  }

  //  public void notify(TParam1 p1) {
  //    _on_event?.Invoke(p1);
  //  }
  //}

  public class EventUnit<TParam1> : IEventUnit {

    public List<KeyValuePair<Action<TParam1>, int>> callbacks =
      new List<KeyValuePair<Action<TParam1>, int>>();

    public IUnRegister register(Action<TParam1> callback, int priority = 100) {

      this.callbacks.Add(new KeyValuePair<Action<TParam1>, int>(callback, priority));

      utils.algo.sort_by_descend(this.callbacks, cb => cb.Value, 0, this.callbacks.Count - 1);

      return new CustomUnRegister(() => { unregister(callback); });
    }

    public void unregister(Action<TParam1> input_callback) {

      // Collect the items to be removed
      List<KeyValuePair<Action<TParam1>, int>> clone =
        new List<KeyValuePair<Action<TParam1>, int>>();

      foreach (var cb in this.callbacks) {
        if (ReferenceEquals(cb.Key, input_callback)) {
          clone.Add(cb);
        }
      }

      foreach (var cb in clone) {
        this.callbacks.Remove(cb);
      }
    }

    public void notify(TParam1 p1) {


      // use for-each loop may leads to this 
      // [ERROR]: c# collection was modified; enumeration operation may not execute
      // [REASON]: cannot enumerate a collection in a foreach block and modify the collection in the same block. As it may register and deregister events to dict constantly
      // [SOLUTION]: get back to a plain old index iteration, starting from the end of the collection
      //foreach (var cb in this.callbacks) {
      //  cb.Key?.Invoke(p1);
      //}

      for (int i = 0; i < this.callbacks.Count; i++) {
        this.callbacks[i].Key?.Invoke(p1);
      }
    }

    public bool has_action(Action<TParam1> input_action) {
      foreach (var cb in this.callbacks) {
        if (ReferenceEquals(cb.Key, input_action)) {
          return true;
        }
      }

      return false;
    }

    public void debug(string event_name) {

    }
  }

  //---------------------
  // @a_event-two param
  //---------------------
  //public class EventUnit<TParam1, TParam2> : IEventUnit {
  //  Action<TParam1, TParam2> _on_event = (p1, p2) => { };

  //  public IUnRegister register(Action<TParam1, TParam2> on_event) {
  //    _on_event += on_event;
  //    return new CustomUnRegister(() => { unregister(on_event); });
  //  }

  //  public void unregister(Action<TParam1, TParam2> on_event) {
  //    _on_event -= on_event;
  //  }

  //  public void notify(TParam1 p1, TParam2 p2) {
  //    _on_event?.Invoke(p1, p2);
  //  }
  //}

  public class EventUnit<TParam1, TParam2> : IEventUnit {

    public List<KeyValuePair<Action<TParam1, TParam2>, int>> callbacks =
      new List<KeyValuePair<Action<TParam1, TParam2>, int>>();

    public IUnRegister register(Action<TParam1, TParam2> callback, int priority = 100) {

      this.callbacks.Add(new KeyValuePair<Action<TParam1, TParam2>, int>(callback, priority));

      utils.algo.sort_by_descend(this.callbacks, cb => cb.Value, 0, this.callbacks.Count - 1);

      return new CustomUnRegister(() => { unregister(callback); });

    }

    public void unregister(Action<TParam1, TParam2> input_callback) {
      // Collect the items to be removed
      List<KeyValuePair<Action<TParam1, TParam2>, int>> clone =
        new List<KeyValuePair<Action<TParam1, TParam2>, int>>();

      foreach (var cb in this.callbacks) {
        if (ReferenceEquals(cb.Key, input_callback)) {
          clone.Add(cb);
        }
      }

      foreach (var cb in clone) {
        this.callbacks.Remove(cb);
      }
    }

    public void notify(TParam1 p1, TParam2 p2) {

      // use for-each loop may leads to this 
      // [ERROR]: c# collection was modified; enumeration operation may not execute
      // [REASON]: cannot enumerate a collection in a foreach block and modify the collection in the same block. As it may register and deregister events to dict constantly
      // [SOLUTION]: get back to a plain old index iteration, starting from the end of the collection
      //foreach (var cb in this.callbacks) {
      //  cb.Key?.Invoke(p1, p2);
      //}

      for (int i = 0; i < this.callbacks.Count; i++) {
        this.callbacks[i].Key?.Invoke(p1, p2);
      }


    }

    public bool has_action(Action<TParam1, TParam2> input_action) {
      foreach (var cb in this.callbacks) {
        if (ReferenceEquals(cb.Key, input_action)) {
          return true;
        }
      }

      return false;
    }

    public void debug(string event_name) {

    }

  }

  //-----------------------
  // @a_event-three param
  //-----------------------
  //public class EventUnit<TParam1, TParam2, TParam3> : IEventUnit {
  //  Action<TParam1, TParam2, TParam3> _on_event = (p1, p2, p3) => { };

  //  public IUnRegister register(Action<TParam1, TParam2, TParam3> on_event) {
  //    _on_event += on_event;
  //    return new CustomUnRegister(() => { unregister(on_event); });
  //  }

  //  public void unregister(Action<TParam1, TParam2, TParam3> on_event) {
  //    _on_event -= on_event;
  //  }

  //  public void notify(TParam1 p1, TParam2 p2, TParam3 p3) {
  //    _on_event?.Invoke(p1, p2, p3);
  //  }
  //}

  public class EventUnit<TParam1, TParam2, TParam3> : IEventUnit {

    public List<KeyValuePair<Action<TParam1, TParam2, TParam3>, int>> callbacks =
      new List<KeyValuePair<Action<TParam1, TParam2, TParam3>, int>>();

    public IUnRegister register(Action<TParam1, TParam2, TParam3> callback, int priority = 100) {

      this.callbacks.Add(new KeyValuePair<Action<TParam1, TParam2, TParam3>, int>(callback, priority));

      utils.algo.sort_by_descend(this.callbacks, cb => cb.Value, 0, this.callbacks.Count - 1);

      return new CustomUnRegister(() => { unregister(callback); });
    }

    public void unregister(Action<TParam1, TParam2, TParam3> input_callback) {
      // Collect the items to be removed
      List<KeyValuePair<Action<TParam1, TParam2, TParam3>, int>> clone =
        new List<KeyValuePair<Action<TParam1, TParam2, TParam3>, int>>();

      foreach (var cb in this.callbacks) {
        if (ReferenceEquals(cb.Key, input_callback)) {
          clone.Add(cb);
        }
      }

      foreach (var cb in clone) {
        this.callbacks.Remove(cb);
      }
    }

    public void notify(TParam1 p1, TParam2 p2, TParam3 p3) {

      // use for-each loop may leads to this 
      // [ERROR]: c# collection was modified; enumeration operation may not execute
      // [REASON]: cannot enumerate a collection in a foreach block and modify the collection in the same block. As it may register and deregister events to dict constantly
      // [SOLUTION]: get back to a plain old index iteration, starting from the end of the collection
      // foreach (var cb in this.callbacks) {
      //   cb.Key?.Invoke(p1, p2, p3);
      // }

      for (int i = 0; i < this.callbacks.Count; i++) {
        this.callbacks[i].Key?.Invoke(p1, p2, p3);
      }
    }

    public bool has_action(Action<TParam1, TParam2, TParam3> input_action) {
      foreach (var cb in this.callbacks) {
        if (ReferenceEquals(cb.Key, input_action)) {
          return true;
        }
      }

      return false;
    }

    public void debug(string event_name) {

    }
  }


  //-----------------------
  // @a_event-four params
  //-----------------------
  //public class EventUnit<TParam1, TParam2, TParam3, TParam4> : IEventUnit {
  //  Action<TParam1, TParam2, TParam3, TParam4> _on_event = (p1, p2, p3, p4) => { };

  //  public IUnRegister register(Action<TParam1, TParam2, TParam3, TParam4> on_event) {
  //    _on_event += on_event;
  //    return new CustomUnRegister(() => { unregister(on_event); });
  //  }

  //  public void unregister(Action<TParam1, TParam2, TParam3, TParam4> on_event) {
  //    _on_event -= on_event;
  //  }

  //  public void notify(TParam1 p1, TParam2 p2, TParam3 p3, TParam4 p4) {
  //    _on_event?.Invoke(p1, p2, p3, p4);
  //  }
  //}

  public class EventUnit<TParam1, TParam2, TParam3, TParam4> : IEventUnit {

    public List<KeyValuePair<Action<TParam1, TParam2, TParam3, TParam4>, int>> callbacks =
      new List<KeyValuePair<Action<TParam1, TParam2, TParam3, TParam4>, int>>();

    public IUnRegister register(
      Action<TParam1, TParam2, TParam3, TParam4> callback,
      int priority = 100
    ) {

      this.callbacks.Add(
        new KeyValuePair<Action<TParam1, TParam2, TParam3, TParam4>, int>(callback, priority)
      );

      utils.algo.sort_by_descend(this.callbacks, cb => cb.Value, 0, this.callbacks.Count - 1);

      return new CustomUnRegister(() => { unregister(callback); });
    }

    public void unregister(Action<TParam1, TParam2, TParam3, TParam4> input_callback) {

      // Collect the items to be removed
      List<KeyValuePair<Action<TParam1, TParam2, TParam3, TParam4>, int>> clone =
        new List<KeyValuePair<Action<TParam1, TParam2, TParam3, TParam4>, int>>();

      foreach (var cb in this.callbacks) {
        if (ReferenceEquals(cb.Key, input_callback)) {
          clone.Add(cb);
        }
      }

      foreach (var cb in clone) {
        this.callbacks.Remove(cb);
      }
    }

    public void notify(TParam1 p1, TParam2 p2, TParam3 p3, TParam4 p4) {

      // use for-each loop may leads to this 
      // [ERROR]: c# collection was modified; enumeration operation may not execute
      // [REASON]: cannot enumerate a collection in a foreach block and modify the collection in the same block. As it may register and deregister events to dict constantly
      // [SOLUTION]: get back to a plain old index iteration, starting from the end of the collection
      // foreach (var cb in this.callbacks) {
      //   cb.Key?.Invoke(p1, p2, p3, p4);
      // }

      for (int i = 0; i < this.callbacks.Count; i++) {
        this.callbacks[i].Key?.Invoke(p1, p2, p3, p4);
      }


    }

    public void debug(string event_name) {


    }

    public bool has_action(Action<TParam1, TParam2, TParam3, TParam4> input_action) {
      foreach (var cb in this.callbacks) {
        if (ReferenceEquals(cb.Key, input_action)) {
          return true;
        }
      }

      return false;
    }

  }

  //--------------
  // @deregisters
  //--------------
  // public interface IUnRegister {
  //   void unregister();
  // }
  // public struct CustomUnRegister : IUnRegister {
  //   //delegated obj
  //   Action _on_unregister { get; set; }
  //
  //   public CustomUnRegister(Action on_unregister) {
  //     _on_unregister = on_unregister;
  //   }
  //
  //   //release resrouce
  //   public void unregister() {
  //     _on_unregister.Invoke();
  //     _on_unregister = null;
  //   }
  // }