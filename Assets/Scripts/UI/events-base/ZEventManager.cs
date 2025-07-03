using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  public enum EventChannel {
    global,
    second,
    third,
    quad
  }

  // set this script excution order on project settings at top
  // and drop into scene context child
  public class ZEventManager : MonoBehaviour, IEventManager {

    Dictionary<EventChannel, EventBusEnum> channels_dict =
      new Dictionary<EventChannel, EventBusEnum>();

    public EventBusEnum global, second, third, quad;
    public static ZEventManager Instance;

    //---------------
    //-- @lifecycle
    //---------------
    public void Awake() {
      Instance = this;

      global = new EventBusEnum();
      second = new EventBusEnum();
      third = new EventBusEnum();
      quad = new EventBusEnum();

      channels_dict.Add(EventChannel.global, global);
      channels_dict.Add(EventChannel.second, second);
      channels_dict.Add(EventChannel.third, third);
      channels_dict.Add(EventChannel.quad, quad);

    }

    public void set_instance() {
      Instance = this;
    }

    public EventBusEnum get_channel(EventChannel ec) {
      if (channels_dict.TryGetValue(ec, out var e))
        return e;
      return null;
    }
  }
