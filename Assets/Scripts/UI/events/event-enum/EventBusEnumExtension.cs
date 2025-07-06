
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using LTK268;

public static class EventBusEnumExtension {

    // ------------------
    // -- @EventManager
    // ------------------
    // -----------------------------------
    // -----------------
    // -- @zero-params
    // -----------------
    // public static void add_event_listener(
    //   this object @this,
    //   int event_id,
    //   Action callback,
    //   EventChannel ec = EventChannel.global
    // ) {
    //   EventBusEnum events = EventManager.Instance?.get_channel(ec);
    //   events?.register(event_id, callback);
    // }
    //
    // public static void remove_event_listener(
    //         this object listener,
    //         int event_id,
    //         Action callback,
    //         EventChannel ec = EventChannel.global
    //       ) {
    //   EventBusEnum events = EventManager.Instance?.get_channel(ec);
    //   events?.unregister(event_id, callback);
    // }
    //
    // public static void notify_event(
    //     this object sender,
    //     int event_id,
    //     EventChannel ec = EventChannel.global
    //   ) {
    //   EventBusEnum events = EventManager.Instance?.get_channel(ec);
    //   events?.notify(event_id);
    // }
    //
    // // -----------------
    // // -- @one-params
    // // -----------------
    // public static void add_event_listener<TParams1>(
    //   this object @this,
    //   int event_id,
    //   Action<TParams1> callback,
    //   EventChannel ec = EventChannel.global
    // ) {
    //   EventBusEnum events = EventManager.Instance?.get_channel(ec);
    //   events?.register(event_id, callback);
    // }
    //
    // public static void remove_event_listener<TParams1>(
    //         this object listener,
    //         int event_id,
    //         Action<TParams1> callback,
    //         EventChannel ec = EventChannel.global
    //       ) {
    //   EventBusEnum events = EventManager.Instance?.get_channel(ec);
    //   events?.unregister<TParams1>(event_id, callback);
    // }
    //
    // public static void notify_event<TParams1>(
    //     this object sender,
    //     int event_id,
    //     TParams1 p1,
    //     EventChannel ec = EventChannel.global
    //   ) {
    //   EventBusEnum events = EventManager.Instance?.get_channel(ec);
    //   events?.notify(event_id, p1);
    // }
    //
    // // ----------------
    // // -- @two-params
    // // ----------------
    // public static void add_event_listener<TParams1, TParams2>(
    //   this object @this,
    //   int event_id,
    //   Action<TParams1, TParams2> callback,
    //   EventChannel ec = EventChannel.global
    // ) {
    //   EventBusEnum events = EventManager.Instance?.get_channel(ec);
    //   events?.register(event_id, callback);
    // }
    //
    // public static void remove_event_listener<TParams1, TParams2>(
    //         this object listener,
    //         int event_id,
    //         Action<TParams1, TParams2> callback,
    //         EventChannel ec = EventChannel.global
    //       ) {
    //   EventBusEnum events = EventManager.Instance?.get_channel(ec);
    //   events?.unregister<TParams1, TParams2>(event_id, callback);
    // }
    //
    // public static void notify_event<TParams1, TParams2>(
    //     this object sender,
    //     int event_id,
    //     TParams1 p1,
    //     TParams2 p2,
    //     EventChannel ec = EventChannel.global
    //   ) {
    //   EventBusEnum events = EventManager.Instance?.get_channel(ec);
    //   events?.notify(event_id, p1, p2);
    // }
    //
    // // ------------------
    // // -- @three-params
    // // ------------------
    // public static void add_event_listener<TParams1, TParams2, TParams3>(
    //   this object @this,
    //   int event_id,
    //   Action<TParams1, TParams2, TParams3> callback,
    //   EventChannel ec = EventChannel.global
    // ) {
    //   EventBusEnum events = EventManager.Instance?.get_channel(ec);
    //   events?.register(event_id, callback);
    // }
    //
    // public static void remove_event_listener<TParams1, TParams2, TParams3>(
    //         this object listener,
    //         int event_id,
    //         Action<TParams1, TParams2, TParams3> callback,
    //         EventChannel ec = EventChannel.global
    //       ) {
    //   EventBusEnum events = EventManager.Instance?.get_channel(ec);
    //   events?.unregister<TParams1, TParams2, TParams3>(event_id, callback);
    // }
    //
    // public static void notify_event<TParams1, TParams2, TParams3>(
    //     this object sender,
    //     int event_id,
    //     TParams1 p1,
    //     TParams2 p2,
    //     TParams3 p3,
    //     EventChannel ec = EventChannel.global
    //   ) {
    //   EventBusEnum events = EventManager.Instance?.get_channel(ec);
    //   events?.notify(event_id, p1, p2, p3);
    // }
    //
    // // ------------------
    // // -- @four-params
    // // ------------------
    // public static void add_event_listener<TParams1, TParams2, TParams3, TParams4>(
    //   this object @this,
    //   int event_id,
    //   Action<TParams1, TParams2, TParams3, TParams4> callback,
    //   EventChannel ec = EventChannel.global
    // ) {
    //   EventBusEnum events = EventManager.Instance?.get_channel(ec);
    //   events?.register(event_id, callback);
    // }
    //
    // public static void remove_event_listener<TParams1, TParams2, TParams3, TParams4>(
    //         this object listener,
    //         int event_id,
    //         Action<TParams1, TParams2, TParams3, TParams4> callback,
    //         EventChannel ec = EventChannel.global
    //       ) {
    //   EventBusEnum events = EventManager.Instance?.get_channel(ec);
    //   events?.unregister<TParams1, TParams2, TParams3, TParams4>(event_id, callback);
    // }
    //
    // public static void notify_event<TParams1, TParams2, TParams3, TParams4>(
    //     this object sender,
    //     int event_id,
    //     TParams1 p1,
    //     TParams2 p2,
    //     TParams3 p3,
    //     TParams4 p4,
    //     EventChannel ec = EventChannel.global
    //   ) {
    //   EventBusEnum events = EventManager.Instance?.get_channel(ec);
    //   events?.notify(event_id, p1, p2, p3, p4);
    // }


    // -----------------
    // -- @zero-params
    // -----------------
    public static void SubcribeEvent(
      this object @this,
      int event_id,
      Action callback,
      int priority = 100,
      EventChannel ec = EventChannel.global
    ) {
      EventBusEnum events = ZEventManager.Instance?.get_channel(ec);
      events?.register(event_id, callback, priority);
    }

    public static void off(
      this object listener,
      int event_id,
      Action callback,
      EventChannel ec = EventChannel.global
    ) {
      EventBusEnum events = ZEventManager.Instance?.get_channel(ec);
      events?.unregister(event_id, callback);
    }

    public static void emit(
        this object sender,
        int event_id,
        EventChannel ec = EventChannel.global
      ) {
      EventBusEnum events = ZEventManager.Instance?.get_channel(ec);
      events?.notify(event_id);
    }


    public static bool has_action(
        this object sender,
        int event_id,
        Action callback,
        EventChannel ec = EventChannel.global
      ) {
      EventBusEnum events = ZEventManager.Instance?.get_channel(ec);

      if (events == null) {
        return false;
      }
      return events.has_action(event_id, callback);
    }

    public static void event_debug(
      this object @this,
      string event_name,
      int key,
      EventChannel ec = EventChannel.global
    ) {
      EventBusEnum events = ZEventManager.Instance?.get_channel(ec);
      events?.debug(event_name, key);
    }


    // ---------------
    // -- @one-param
    // ---------------
    public static void SubcribeEvent<TParam1>(
      this object @this,
      int event_id,
      Action<TParam1> callback,
      int priority = 100,
      EventChannel ec = EventChannel.global
    ) {
      Debug.Log($"Is {@this} Null?: {@this == null}");
      EventBusEnum events = ZEventManager.Instance?.get_channel(ec);
      events?.register(event_id, callback, priority);
    }

    public static void off<TParam1>(
      this object listener,
      int event_id,
      Action<TParam1> callback,
      EventChannel ec = EventChannel.global
    ) {
      EventBusEnum events = ZEventManager.Instance?.get_channel(ec);
      events?.unregister<TParam1>(event_id, callback);
    }

    public static void emit<TParam1>(
      this object sender,
      int event_id,
      TParam1 p1,
      EventChannel ec = EventChannel.global
    ) {
      EventBusEnum events = ZEventManager.Instance?.get_channel(ec);
      events?.notify(event_id, p1);
    }

    public static bool has_action<TParam1>(
       this object sender,
       int event_id,
       Action<TParam1> callback,
       EventChannel ec = EventChannel.global
     ) {
      EventBusEnum events = ZEventManager.Instance?.get_channel(ec);

      if (events == null) {
        return false;
      }
      return events.has_action(event_id, callback);
    }


    // -----------------
    // -- @two-params
    // -----------------
    public static void SubcribeEvent<TParam1, TParam2>(
      this object @this,
      int event_id,
      Action<TParam1, TParam2> callback,
      int priority = 100,
      EventChannel ec = EventChannel.global
    ) {
      EventBusEnum events = ZEventManager.Instance?.get_channel(ec);
      events?.register(event_id, callback, priority);
    }

    public static void off<TParam1, TParam2>(
      this object listener,
      int event_id,
      Action<TParam1, TParam2> callback,
      EventChannel ec = EventChannel.global
    ) {
      EventBusEnum events = ZEventManager.Instance?.get_channel(ec);
      events?.unregister<TParam1, TParam2>(event_id, callback);
    }

    public static void emit<TParam1, TParam2>(
      this object sender,
      int event_id,
      TParam1 p1, TParam2 p2,
      EventChannel ec = EventChannel.global
    ) {
      EventBusEnum events = ZEventManager.Instance?.get_channel(ec);
      events?.notify(event_id, p1, p2);
    }

    public static bool has_action<TParam1, TParam2>(
      this object sender,
      int event_id,
      Action<TParam1, TParam2> callback,
      EventChannel ec = EventChannel.global
    ) {
      EventBusEnum events = ZEventManager.Instance?.get_channel(ec);

      if (events == null) {
        return false;
      }
      return events.has_action(event_id, callback);
    }


    // -----------------
    // -- @three-params
    // -----------------
    public static void on<TParam1, TParam2, TParam3>(
      this object @this,
      int event_id,
      Action<TParam1, TParam2, TParam3> callback,
      int priority = 100,
      EventChannel ec = EventChannel.global
    ) {
      EventBusEnum events = ZEventManager.Instance?.get_channel(ec);
      events?.register(event_id, callback, priority);
    }

    public static void off<TParam1, TParam2, TParam3>(
            this object listener,
            int event_id,
            Action<TParam1, TParam2, TParam3> callback,
            EventChannel ec = EventChannel.global
          ) {
      EventBusEnum events = ZEventManager.Instance?.get_channel(ec);
      events?.unregister<TParam1, TParam2, TParam3>(event_id, callback);
    }

    public static void emit<TParam1, TParam2, TParam3>(
        this object sender,
        int event_id,
        TParam1 p1, TParam2 p2, TParam3 p3,
        EventChannel ec = EventChannel.global
      ) {
      EventBusEnum events = ZEventManager.Instance?.get_channel(ec);
      events?.notify(event_id, p1, p2, p3);
    }

    public static bool has_action<TParam1, TParam2, TParam3>(
       this object sender,
       int event_id,
       Action<TParam1, TParam2, TParam3> callback,
       EventChannel ec = EventChannel.global
     ) {
      EventBusEnum events = ZEventManager.Instance?.get_channel(ec);

      if (events == null) {
        return false;
      }
      return events.has_action(event_id, callback);
    }


    // -----------------
    // -- @four-params
    // -----------------
    public static void on<TParam1, TParam2, TParam3, TParam4>(
      this object @this,
      int event_id,
      Action<TParam1, TParam2, TParam3, TParam4> callback,
      int priority = 100,
      EventChannel ec = EventChannel.global
    ) {
      EventBusEnum events = ZEventManager.Instance?.get_channel(ec);
      events?.register(event_id, callback, priority);
    }

    public static void off<TParam1, TParam2, TParam3, TParam4>(
            this object listener,
            int event_id,
            Action<TParam1, TParam2, TParam3, TParam4> callback,
            EventChannel ec = EventChannel.global
          ) {
      EventBusEnum events = ZEventManager.Instance?.get_channel(ec);
      events?.unregister<TParam1, TParam2, TParam3, TParam4>(event_id, callback);
    }

    public static void emit<TParam1, TParam2, TParam3, TParam4>(
        this object sender,
        int event_id,
        TParam1 p1, TParam2 p2, TParam3 p3, TParam4 p4,
        EventChannel ec = EventChannel.global
      ) {
      EventBusEnum events = ZEventManager.Instance?.get_channel(ec);
      events?.notify(event_id, p1, p2, p3, p4);
    }

    public static bool has_action<TParam1, TParam2, TParam3, TParam4>(
       this object sender,
       int event_id,
       Action<TParam1, TParam2, TParam3, TParam4> callback,
       EventChannel ec = EventChannel.global
     ) {
      EventBusEnum events = ZEventManager.Instance?.get_channel(ec);

      if (events == null) {
        return false;
      }
      return events.has_action(event_id, callback);
    }





    // ------------------
    // -- @ZenejectEventManager
    // ------------------
    // -----------------------------------
    // -----------------
    // -- @zero-params
    // -----------------
    public static void add_event_listener(
      this object @this,
      int event_id,
      Action callback,
      EventChannel ec = EventChannel.global
    ) {
      EventBusEnum events = ZEventManager.Instance?.get_channel(ec);
      events?.register(event_id, callback);
    }

    public static void remove_event_listener(
            this object listener,
            int event_id,
            Action callback,
            EventChannel ec = EventChannel.global
          ) {
      EventBusEnum events = ZEventManager.Instance?.get_channel(ec);
      events?.unregister(event_id, callback);
    }

    public static void notify_event(
        this object sender,
        int event_id,
        EventChannel ec = EventChannel.global
      ) {
      EventBusEnum events = ZEventManager.Instance?.get_channel(ec);
      events?.notify(event_id);
    }

    // -----------------
    // -- @one-params
    // -----------------
    public static void add_event_listener<TParams1>(
      this object @this,
      int event_id,
      Action<TParams1> callback,
      EventChannel ec = EventChannel.global
    ) {
      EventBusEnum events = ZEventManager.Instance?.get_channel(ec);
      events?.register(event_id, callback);
    }

    public static void remove_event_listener<TParams1>(
            this object listener,
            int event_id,
            Action<TParams1> callback,
            EventChannel ec = EventChannel.global
          ) {
      EventBusEnum events = ZEventManager.Instance?.get_channel(ec);
      events?.unregister<TParams1>(event_id, callback);
    }

    public static void notify_event<TParams1>(
        this object sender,
        int event_id,
        TParams1 p1,
        EventChannel ec = EventChannel.global
      ) {
      EventBusEnum events = ZEventManager.Instance?.get_channel(ec);
      events?.notify(event_id, p1);
    }

    // ----------------
    // -- @two-params
    // ----------------
    public static void add_event_listener<TParams1, TParams2>(
      this object @this,
      int event_id,
      Action<TParams1, TParams2> callback,
      EventChannel ec = EventChannel.global
    ) {
      EventBusEnum events = ZEventManager.Instance?.get_channel(ec);
      events?.register(event_id, callback);
    }

    public static void remove_event_listener<TParams1, TParams2>(
            this object listener,
            int event_id,
            Action<TParams1, TParams2> callback,
            EventChannel ec = EventChannel.global
          ) {
      EventBusEnum events = ZEventManager.Instance?.get_channel(ec);
      events?.unregister<TParams1, TParams2>(event_id, callback);
    }

    public static void notify_event<TParams1, TParams2>(
        this object sender,
        int event_id,
        TParams1 p1,
        TParams2 p2,
        EventChannel ec = EventChannel.global
      ) {
      EventBusEnum events = ZEventManager.Instance?.get_channel(ec);
      events?.notify(event_id, p1, p2);
    }

    // ------------------
    // -- @three-params
    // ------------------
    public static void add_event_listener<TParams1, TParams2, TParams3>(
      this object @this,
      int event_id,
      Action<TParams1, TParams2, TParams3> callback,
      EventChannel ec = EventChannel.global
    ) {
      EventBusEnum events = ZEventManager.Instance?.get_channel(ec);
      events?.register(event_id, callback);
    }

    public static void remove_event_listener<TParams1, TParams2, TParams3>(
            this object listener,
            int event_id,
            Action<TParams1, TParams2, TParams3> callback,
            EventChannel ec = EventChannel.global
          ) {
      EventBusEnum events = ZEventManager.Instance?.get_channel(ec);
      events?.unregister<TParams1, TParams2, TParams3>(event_id, callback);
    }

    public static void notify_event<TParams1, TParams2, TParams3>(
        this object sender,
        int event_id,
        TParams1 p1,
        TParams2 p2,
        TParams3 p3,
        EventChannel ec = EventChannel.global
      ) {
      EventBusEnum events = ZEventManager.Instance?.get_channel(ec);
      events?.notify(event_id, p1, p2, p3);
    }

    // ------------------
    // -- @four-params
    // ------------------
    public static void add_event_listener<TParams1, TParams2, TParams3, TParams4>(
      this object @this,
      int event_id,
      Action<TParams1, TParams2, TParams3, TParams4> callback,
      EventChannel ec = EventChannel.global
    ) {
      EventBusEnum events = ZEventManager.Instance?.get_channel(ec);
      events?.register(event_id, callback);
    }

    public static void remove_event_listener<TParams1, TParams2, TParams3, TParams4>(
            this object listener,
            int event_id,
            Action<TParams1, TParams2, TParams3, TParams4> callback,
            EventChannel ec = EventChannel.global
          ) {
      EventBusEnum events = ZEventManager.Instance?.get_channel(ec);
      events?.unregister<TParams1, TParams2, TParams3, TParams4>(event_id, callback);
    }

    public static void notify_event<TParams1, TParams2, TParams3, TParams4>(
        this object sender,
        int event_id,
        TParams1 p1,
        TParams2 p2,
        TParams3 p3,
        TParams4 p4,
        EventChannel ec = EventChannel.global
      ) {
      EventBusEnum events = ZEventManager.Instance?.get_channel(ec);
      events?.notify(event_id, p1, p2, p3, p4);
    }
  }