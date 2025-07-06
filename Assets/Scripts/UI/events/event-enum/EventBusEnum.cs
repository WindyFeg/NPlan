using System;
using System.Collections.Generic;
using LKT268;
using LKT268.Utils;

public class EventBusEnum {
    public static readonly EventBusEnum Global = new EventBusEnum();

    // readonly Dictionary<int, IEventUnit> events_dict = 
    //   new Dictionary<int, IEventUnit>();


    /// <summary>
    /// The outer [int] represents the EventBusEnumID.<br/>
    /// The inner [int] indicates the number of parameters supported by this EventBusEnumID.<br/>
    /// Each variation in the number of parameters for an EventBusEnumID is implemented separately. <br/>
    /// This approach eliminates the need to create a unique class for each event invocation from scripts that use the event bus. 
    /// For example, if we have the same event with two variations—one with no 
    /// parameters and one with two parameters—we would otherwise need to declare two separate classes for each version.<br/>
    /// </summary>
    readonly Dictionary<int, Dictionary<int, IEventUnit>> events_dict =
      new Dictionary<int, Dictionary<int, IEventUnit>>();

    public EventBusEnum() { }


    // public IUnRegister register<T>(T key, Action<int, object[]> callback) where T : IConvertible {
    //   var kv = key.ToInt32(null);
    //
    //   if (events_dict.TryGetValue(kv, out var e)) {
    //     var event_unit = e.As<EventUnit<int,object[]>>();
    //     return event_unit.register(callback);
    //   } else {
    //     var event_unit = new EventUnit<int, object[]>();
    //     events_dict.Add(kv, event_unit);
    //     return event_unit.register(callback);
    //   }
    // }
    //
    //
    // public void unregister<T>(T key, Action<int, object[]> callback) where T : IConvertible {
    //   var kv = key.ToInt32(null);
    //
    //   if (events_dict.TryGetValue(kv, out var e)) {
    //     e.As<EventUnit<int, object[]>>()?.unregister(callback);
    //   }
    // }
    //
    // public void unregister<T>(T key) where T : IConvertible {
    //   var kv = key.ToInt32(null);
    //
    //   if (events_dict.ContainsKey(kv)) {
    //     events_dict.Remove(kv);
    //   }
    // }
    //
    // public void unregister_all() {
    //   events_dict.Clear();
    // }
    //
    // public void notify<T>(T key, params object[] args) where T : IConvertible {
    //   var kv = key.ToInt32(null);
    //
    //   if (events_dict.TryGetValue(kv, out var e)) {
    //     e.As<EventUnit<int, object[]>>().notify(kv, args);
    //   }
    // }

    public enum params_cnt : int {
      zero = 0, one, two, three, four
    }
    //----------------
    //-- @zero-params
    //----------------
    public IUnRegister register(int key, Action callback, int priority = 100) {

      if (events_dict.TryGetValue(key, out var inner_events_dict)) {
        if (!inner_events_dict.ContainsKey((int)params_cnt.zero)) {
          inner_events_dict[(int)params_cnt.zero] = new EventUnit();
        }
        var event_unit = inner_events_dict[(int)params_cnt.zero].As<EventUnit>();
        return event_unit.register(callback, priority);
      } else {

        var event_unit = new EventUnit();

        var new_sub_events_dict = new Dictionary<int, IEventUnit>();
        new_sub_events_dict.Add((int)params_cnt.zero, event_unit);
        events_dict.Add(key, new_sub_events_dict);

        return event_unit.register(callback, priority);
      }

    }


    public void unregister(int key, Action callback) {
      if (events_dict.TryGetValue(key, out var sub_events_dict)) {

        if (!sub_events_dict.ContainsKey((int)params_cnt.zero)) {
          // //LTK268Log.LogInfo("this event key {0} have no listener for case {1} params",
          //     key, (int)params_cnt.zero);
          return;
        }

        sub_events_dict[(int)params_cnt.zero]
          .As<EventUnit>()?
          .unregister(callback);
      }
    }

    public void notify(int key) {

      if (!events_dict.ContainsKey(key)) {
        ////LTK268Log.LogInfo("No listeners for this event key : {0}", key);
        return;
      }

      if (events_dict.TryGetValue(key, out var sub_events_dict)) {

        if (!sub_events_dict.ContainsKey((int)params_cnt.zero)) {
          ////LTK268Log.LogInfo("this event key {0} have no listener for case {1} params",
           //   key, (int)params_cnt.zero);
          return;
        }

        sub_events_dict[(int)params_cnt.zero].As<EventUnit>()?.notify();
      }
    }

    public bool has_action(int key, Action input_action) {

      if (!events_dict.ContainsKey(key)) {
        ////LTK268Log.LogInfo("No listeners for this event key : {0}", key);
        return false;
      }

      if (events_dict.TryGetValue(key, out var sub_events_dict)) {

        if (!sub_events_dict.ContainsKey((int)params_cnt.zero)) {
          ////LTK268Log.LogInfo("this event key {0} have no listener for case {1} params",
            //  key, (int)params_cnt.zero);
          return false;
        }

        return sub_events_dict[(int)params_cnt.zero]
          .As<EventUnit>()
          .has_action(input_action)
        ;
      }

      return false;
    }

    //---------------
    //-- @one-params
    //---------------
    public IUnRegister register<TParams1>(
      int key, Action<TParams1> callback, int priority = 100
    ) {
      if (events_dict.TryGetValue(key, out var sub_events_dict)) {
        if (!sub_events_dict.ContainsKey((int)params_cnt.one)) {
          sub_events_dict[(int)params_cnt.one] = new EventUnit<TParams1>();
        }

        var event_unit = sub_events_dict[(int)params_cnt.one]
          .As<EventUnit<TParams1>>();
        return event_unit.register(callback, priority); 
      } else {
        var event_unit = new EventUnit<TParams1>();
        var new_sub_events_dict = new Dictionary<int, IEventUnit>();
        new_sub_events_dict.Add((int)params_cnt.one, event_unit);
        events_dict.Add(key, new_sub_events_dict);
        return event_unit.register(callback, priority);
      }
    }

    public void unregister<TParams1>(int key, Action<TParams1> callback) {

      if (events_dict.TryGetValue(key, out var sub_events_dict)) {

        if (!sub_events_dict.ContainsKey((int)params_cnt.one)) {
          ////LTK268Log.LogInfo("this event key {0} have no listener for case {1} params",
            //  key, (int)params_cnt.one);
          return;
        }

        sub_events_dict[(int)params_cnt.one].As<EventUnit<TParams1>>()?
          .unregister(callback);
      }
    }

    public void notify<TParams1>(int key, TParams1 p1) {

      if (!events_dict.ContainsKey(key)) {
       // //LTK268Log.LogInfo("No listeners for this event key : {0}", key);
        return;
      }

      if (events_dict.TryGetValue(key, out var sub_events_dict)) {

        if (!sub_events_dict.ContainsKey((int)params_cnt.one)) {
          ////LTK268Log.LogInfo("this event key {0} have no listener for case {1} params",
             // key, (int)params_cnt.one);
          return;
        }

        sub_events_dict[(int)params_cnt.one].As<EventUnit<TParams1>>()?
          .notify(p1);
      }
    }

    public bool has_action<TParam1>(int key, Action<TParam1> input_action) {

      if (!events_dict.ContainsKey(key)) {
        ////LTK268Log.LogInfo("No listeners for this event key : {0}", key);
        return false;
      }

      if (events_dict.TryGetValue(key, out var sub_events_dict)) {

        if (!sub_events_dict.ContainsKey((int)params_cnt.one)) {
         // //LTK268Log.LogInfo("this event key {0} have no listener for case {1} params",
             // key, (int)params_cnt.one);
          return false;
        }

        return sub_events_dict[(int)params_cnt.one]
          .As<EventUnit<TParam1>>()
          .has_action(input_action)
        ;
      }

      return false;
    }

    //---------------
    //-- @two-params
    //---------------
    public IUnRegister register<TParams1, TParams2>(
      int key, Action<TParams1, TParams2> callback, int priority = 100
    ) {

      if (events_dict.TryGetValue(key, out var sub_events_dict)) {
        if (!sub_events_dict.ContainsKey((int)params_cnt.two)) {
          sub_events_dict[(int)params_cnt.two] =
            new EventUnit<TParams1, TParams2>();
        }

        var event_unit = sub_events_dict[(int)params_cnt.two]
          .As<EventUnit<TParams1, TParams2>>();
        return event_unit.register(callback, priority);
      } else {
        var event_unit = new EventUnit<TParams1, TParams2>();
        var new_sub_events_dict = new Dictionary<int, IEventUnit>();
        new_sub_events_dict.Add((int)params_cnt.two, event_unit);
        events_dict.Add(key, new_sub_events_dict);
        return event_unit.register(callback, priority);
      }
    }

    public void unregister<TParams1, TParams2>(
      int key, Action<TParams1, TParams2> callback
    ) {
      if (events_dict.TryGetValue(key, out var sub_events_dict)) {

        if (!sub_events_dict.ContainsKey((int)params_cnt.two)) {
          ////LTK268Log.LogInfo("this event key {0} have no listener for case {1} params",
             // key, (int)params_cnt.two);
          return;
        }
        sub_events_dict[(int)params_cnt.two]
          .As<EventUnit<TParams1, TParams2>>()?
          .unregister(callback);
      }
    }

    public void notify<TParams1, TParams2>(int key, TParams1 p1, TParams2 p2) {
      if (!events_dict.ContainsKey(key)) {
        ////LTK268Log.LogInfo("No listeners for this event key : {0}", key);
        return;
      }

      if (events_dict.TryGetValue(key, out var sub_events_dict)) {

        if (!sub_events_dict.ContainsKey((int)params_cnt.two)) {
          //LTK268Log.LogInfo("this event key {0} have no listener for case {1} params",
            //  key, (int)params_cnt.two);
          return;
        }
        sub_events_dict[(int)params_cnt.two]
          .As<EventUnit<TParams1, TParams2>>()?
          .notify(p1, p2);
      }
    }

    public bool has_action<TParam1, TParam2>(int key, Action<TParam1, TParam2> input_action) {

      if (!events_dict.ContainsKey(key)) {
        //LTK268Log.LogInfo("No listeners for this event key : {0}", key);
        return false;
      }

      if (events_dict.TryGetValue(key, out var sub_events_dict)) {

        if (!sub_events_dict.ContainsKey((int)params_cnt.two)) {
          //LTK268Log.LogInfo("this event key {0} have no listener for case {1} params",
              //key, (int)params_cnt.two);
          return false;
        }

        return sub_events_dict[(int)params_cnt.two]
          .As<EventUnit<TParam1, TParam2>>()
          .has_action(input_action)
        ;
      }

      return false;
    }

    //------------------
    //-- @three-params
    //------------------
    public IUnRegister register<TParams1, TParams2, TParams3>(
      int key, Action<TParams1, TParams2, TParams3> callback,
      int priority = 100
    ) {

      if (events_dict.TryGetValue(key, out var sub_events_dict)) {

        if (!sub_events_dict.ContainsKey((int)params_cnt.three)) {
          sub_events_dict[(int)params_cnt.three] =
            new EventUnit<TParams1, TParams2, TParams3>();
        }

        var event_unit = sub_events_dict[(int)params_cnt.three]
          .As<EventUnit<TParams1, TParams2, TParams3>>();
        return event_unit.register(callback, priority);
      } else {
        var event_unit = new EventUnit<TParams1, TParams2, TParams3>();
        //
        var new_sub_events_dict = new Dictionary<int, IEventUnit>();
        new_sub_events_dict.Add((int)params_cnt.three, event_unit);
        events_dict.Add(key, new_sub_events_dict);
        //
        return event_unit.register(callback, priority);
      }
    }

    public void unregister<TParams1, TParams2, TParams3>(
      int key, Action<TParams1, TParams2, TParams3> callback
    ) {

      if (events_dict.TryGetValue(key, out var sub_events_dict)) {

        if (!sub_events_dict.ContainsKey((int)params_cnt.three)) {
          //LTK268Log.LogInfo("this event key {0} have no listener for case {1} params",
            //  key, (int)params_cnt.three);
          return;
        }

        sub_events_dict[(int)params_cnt.three]
          .As<EventUnit<TParams1, TParams2, TParams3>>()?
          .unregister(callback);
      }
    }

    public void notify<TParams1, TParams2, TParams3>(
        int key,
        TParams1 p1,
        TParams2 p2,
        TParams3 p3
      ) {
      if (!events_dict.ContainsKey(key)) {
        //LTK268Log.LogInfo("No listeners for this event key : {0}", key);
        return;
      }

      if (events_dict.TryGetValue(key, out var sub_events_dict)) {

        if (!sub_events_dict.ContainsKey((int)params_cnt.three)) {
          //LTK268Log.LogInfo("this event key {0} have no listener for case {1} params",
             // key, (int)params_cnt.three);
          return;
        }

        sub_events_dict[(int)params_cnt.three].As<EventUnit<TParams1, TParams2, TParams3>>()?
          .notify(p1, p2, p3);
      }
    }

    public bool has_action<TParam1, TParam2, TParam3>(
      int key, Action<TParam1, TParam2, TParam3> input_action
    ) {

      if (!events_dict.ContainsKey(key)) {

        return false;
      }

      if (events_dict.TryGetValue(key, out var sub_events_dict)) {

        if (!sub_events_dict.ContainsKey((int)params_cnt.three)) {

          return false;
        }

        return sub_events_dict[(int)params_cnt.three]
          .As<EventUnit<TParam1, TParam2, TParam3>>()
          .has_action(input_action)
        ;
      }

      return false;
    }

    //-----------------
    //-- @four-params
    //-----------------
    public IUnRegister register<TParams1, TParams2, TParams3, TParams4>(
      int key, Action<TParams1, TParams2, TParams3, TParams4> callback,
      int priority = 100
    ) {

      if (events_dict.TryGetValue(key, out var sub_events_dict)) {

        if (!sub_events_dict.ContainsKey((int)params_cnt.four)) {
          sub_events_dict[(int)params_cnt.four] =
            new EventUnit<TParams1, TParams2, TParams3, TParams4>();
        }

        var event_unit = sub_events_dict[(int)params_cnt.four]
          .As<EventUnit<TParams1, TParams2, TParams3, TParams4>>();
        return event_unit.register(callback, priority);

      } else {
        var event_unit = new EventUnit<TParams1, TParams2, TParams3, TParams4>();
        var new_sub_events_dict = new Dictionary<int, IEventUnit>();
        new_sub_events_dict.Add((int)params_cnt.four, event_unit);
        events_dict.Add(key, new_sub_events_dict);
        return event_unit.register(callback, priority);
      }
    }

    public void unregister<TParams1, TParams2, TParams3, TParams4>(
      int key, Action<TParams1, TParams2, TParams3, TParams4> callback
    ) {

      if (events_dict.TryGetValue(key, out var sub_events_dict)) {

        if (!sub_events_dict.ContainsKey((int)params_cnt.three)) {
          //LTK268Log.LogInfo("this event key {0} have no listener for case {1} params",
             // key, (int)params_cnt.four);
          return;
        }

        sub_events_dict[(int)params_cnt.four]
          .As<EventUnit<TParams1, TParams2, TParams3, TParams4>>()?
          .unregister(callback);
      }
    }

    public void notify<TParams1, TParams2, TParams3, TParams4>(
        int key,
        TParams1 p1,
        TParams2 p2,
        TParams3 p3,
        TParams4 p4
      ) {
      if (!events_dict.ContainsKey(key)) {
        //LTK268Log.LogInfo("No listeners for this event key : {0}", key);
        return;
      }


      if (events_dict.TryGetValue(key, out var sub_events_dict)) {

        if (!sub_events_dict.ContainsKey((int)params_cnt.three)) {
          //LTK268Log.LogInfo("this event key {0} have no listener for case {1} params",
          //   key, (int)params_cnt.four);
          return;
        }

        sub_events_dict[(int)params_cnt.four]
          .As<EventUnit<TParams1, TParams2, TParams3, TParams4>>()?
          .notify(p1, p2, p3, p4);
      }
    }

    public bool has_action<TParam1, TParam2, TParam3, TParam4>(
         int key, Action<TParam1, TParam2, TParam3, TParam4> input_action
       ) {

      if (!events_dict.ContainsKey(key)) {
        //LTK268Log.LogInfo("No listeners for this event key : {0}", key);
        return false;
      }

      if (events_dict.TryGetValue(key, out var sub_events_dict)) {

        if (!sub_events_dict.ContainsKey((int)params_cnt.four)) {
          //LTK268Log.LogInfo("this event key {0} have no listener for case {1} params",
           //   key, (int)params_cnt.four);
          return false;
        }

        return sub_events_dict[(int)params_cnt.four]
          .As<EventUnit<TParam1, TParam2, TParam3, TParam4>>()
          .has_action(input_action)
        ;
      }

      return false;
    }


    //-------------
    //-- @helpers
    //-------------
    public void debug(string event_name, int key) {

      if (!events_dict.ContainsKey(key)) {
        return;
      }
      var inner_events_dict = events_dict[key];

      int len = Enum.GetValues(typeof(params_cnt)).Length;

      foreach (params_cnt param_cnt in Enum.GetValues(typeof(params_cnt))) {
        if (!inner_events_dict.ContainsKey((int)param_cnt)) {
          continue;
        }

        var tmp = inner_events_dict[(int)param_cnt].As<IEventUnit>();
        tmp.debug(event_name);

      }

     // aclf.//LTK268Log.LogInfo("--------endregion@[event-{0}]--------", event_name);

    }

    //----------------
    //-- @unregister
    //----------------
    public void unregister_all() {
      events_dict.Clear();
    }
  }