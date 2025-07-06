using System;
using System.Collections.Generic;
using LTK268;

public class EventBusString {
    public static readonly EventBusString Global = new EventBusString();

    readonly Dictionary<string, IEventUnit> events_dict =
      new Dictionary<string, IEventUnit>(50);

    public EventBusString() { }


    public IUnRegister register(string key, Action on_event) {

      if (events_dict.TryGetValue(key, out var e)) {
        var event_unit = e.As<EventUnit>();
        return event_unit.register(on_event);
      } else {
        var event_unit = new EventUnit();
        events_dict.Add(key, event_unit);
        return event_unit.register(on_event);
      }
    }

    public void unregister(string key, Action on_event) {


      if (events_dict.TryGetValue(key, out var e)) {
        e.As<EventUnit>()?.unregister(on_event);
      }
    }

    public void notify(string key) {
      if (events_dict.TryGetValue(key, out var e)) {
        e.As<EventUnit>().notify();
      }
    }

    //---------
    //-- @one
    //---------
    public IUnRegister register<T>(string key, Action<T> on_event) {

      if (events_dict.TryGetValue(key, out var e)) {
        var event_unit = e.As<EventUnit<T>>();
        return event_unit.register(on_event);
      } else {
        var event_unit = new EventUnit<T>();
        events_dict.Add(key, event_unit);
        return event_unit.register(on_event);
      }
    }

    public void unregister<T>(string key, Action<T> on_event) {
      if (events_dict.TryGetValue(key, out var e)) {
        e.As<EventUnit<T>>()?.unregister(on_event);
      }
    }

    public void notify<T>(string key, T args) {
      if (events_dict.TryGetValue(key, out var e)) {
        e.As<EventUnit<T>>().notify(args);
      }
    }

    public void unregister_all() {
      events_dict.Clear();
    }



  }

