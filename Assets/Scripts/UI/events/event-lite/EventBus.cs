using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum EventBusID {
  None = 0,
  OnOrientationChange,
  OnGameInitFinish,
  OnGameStart,
  OnGameWin,
  OnGameLose,
  OnGameOver,
  OnGamePaused,
  OnGameResume,
  OnSceneChanged,
  OnIntroScene,
  OnIngameScene,
  OnOutroScene,
  OnVisitStore,
}


  public class EventLiteBus {
    Dictionary<EventBusID, Action<object>> _listeners =
      new Dictionary<EventBusID, Action<object>>();

    //-----------------
    //-- @constructor
    //-----------------
    public EventLiteBus() { }

    //-------------
    //-- @helpers
    //-------------
    public void add_event_listener(EventBusID eventID, Action<object> callback) {
      // checking params
      // Utils.Assert(callback != null,
      //     "AddListener, event {0}, callback = null !!",
      //     eventID.ToString());
      // Utils.Assert(eventID != EventBusID.None, "RegisterListener, event = None !!");

      // check if listener exist in distionary
      if (_listeners.ContainsKey(eventID)) {
        // add callback to our collection
        _listeners[eventID] += callback;
        // Debug.Log("Contain keyyyyyy");
      } else {
        // add new key-value pair
        _listeners.Add(eventID, null);
        _listeners[eventID] += callback;
      }
    }

    public void remove_event_listener(EventBusID eventID, Action<object> callback) {
      // checking params
      // Utils.Assert(callback != null,
      //     "RemoveListener, event {0}, callback = null !!",
      //     eventID.ToString());
      // Utils.Assert(eventID != EventBusID.None, "AddListener, event = None !!");

      if (_listeners.ContainsKey(eventID)) {
        _listeners[eventID] -= callback;
      } else {
        //log.warn("RemoveListener, not found key : " + eventID);
      }
    }

    /// Posts the event. This will notify all listener that register for this event
    public void notify_event(EventBusID eventID, object param = null) {
      if (!_listeners.ContainsKey(eventID)) {
        //log.info("No listeners for this event : {0}", eventID);
        return;
      }

      // posting event
      var callbacks = _listeners[eventID];
      // if there's no listener remain, then do nothing
      if (callbacks != null) {
        callbacks(param);
      } else {
        //log.info(
        //  "PostEvent {0}, but no listener remain, Remove this key",
        //  eventID
       // );
        _listeners.Remove(eventID);
      }
    }

    public void clear_all_listeners() {
      _listeners.Clear();
    }
  }

  public static class EventBusExtension {
    /// Use for registering with EventsManager
    // public static void add_event_listener(this MonoBehaviour listener,
    //   EventBusID eventID,
    //   Action<object> callback) {
    //   EventManager.Instance?.event_bus?.add_event_listener(eventID, callback);
    // }
    //
    // public static void remove_event_listener(this MonoBehaviour listener,
    //     EventBusID eventID,
    //     Action<object> callback) {
    //   EventManager.Instance?.event_bus?.remove_event_listener(eventID, callback);
    // }
    //
    // /// Post event with param
    // public static void notify_event(this MonoBehaviour sender,
    //     EventBusID eventID,
    //     object param) {
    //   EventManager.Instance?.event_bus?.notify_event(eventID, param);
    // }

    /// Post event with no param (param = null)
    // public static void notify_event(this MonoBehaviour sender, EventBusID eventID) {
    //   EventManager.Instance?.event_bus?.notify_event(eventID, null);
    // }

    //-------------------
    //-- @generic-types
    //-------------------
    // public static void add_event_listener<T>(this T listener,
    //   EventBusID eventID,
    //   Action<object> callback) {
    //   EventManager.Instance?.event_bus?.add_event_listener(eventID, callback);
    // }
    // public static void remove_event_listener<T>(this T listener,
    //     EventBusID eventID,
    //     Action<object> callback) {
    //   EventManager.Instance?.event_bus?.remove_event_listener(eventID, callback);
    // }
    //
    // /// Post event with param
    // public static void notify_event<T>(this T sender,
    //     EventBusID eventID,
    //     object param) {
    //   EventManager.Instance?.event_bus?.notify_event(eventID, param);
    // }
    //
    // /// Post event with no param (param = null)
    // public static void notify_event<T>(this T sender, EventBusID eventID) {
    //   EventManager.Instance?.event_bus?.notify_event(eventID, null);
    // }
  }
