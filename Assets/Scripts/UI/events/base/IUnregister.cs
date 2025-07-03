using System;
using System.Collections.Generic;
using UnityEngine;

  public interface IUnRegister {
    void unregister();
  }

  public struct CustomUnRegister : IUnRegister {
    //delegated obj
    Action _on_unregister { get; set; }

    public CustomUnRegister(Action on_unregister) {
      _on_unregister = on_unregister;
    }

    //release resrouce
    public void unregister() {
      _on_unregister.Invoke();
      _on_unregister = null;
    }
  }


  //--------------
  // @unregister
  //--------------
  public class UnRegisterOnDestroyTrigger : MonoBehaviour {
    private readonly HashSet<IUnRegister> _unregister = new HashSet<IUnRegister>();

    public void add_unregister(IUnRegister unregister) {
      _unregister.Add(unregister);
    }

    public void remove_unregister(IUnRegister unregister) {
      _unregister.Remove(unregister);
    }

    private void OnDestroy() {
      foreach (var unregister in _unregister) {
        unregister.unregister();
      }

      _unregister.Clear();
    }
  }

  public static class UnRegisterExtension {
    public static IUnRegister unregister_when_game_object_destroyed(
      this IUnRegister unregister, GameObject go
    ) {
      var trigger = go.GetComponent<UnRegisterOnDestroyTrigger>();

      if (!trigger) {
        trigger = go.AddComponent<UnRegisterOnDestroyTrigger>();
      }

      trigger.add_unregister(unregister);

      return unregister;
    }

    public static IUnRegister unregister_when_game_object_destroyed<T>(
        this IUnRegister self, T component) where T : Component {
      return self.unregister_when_game_object_destroyed(component.gameObject);
    }
  }
