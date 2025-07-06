using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LKT268.EventID {

  public enum Game : int
  {
    None = 0,
    OnNPCInteract = 1,
    OnObjectInOfRange = 2,
    OnObjectOutOfRange = 3,
    OnOpenJobList = 4,
    OnCloseJobList = 5,
    OnSwipeLeftJobList = 6,
    OnSwipeRightJobList = 7,

  }

  public enum UI : int {
    OnOrientationChange = 100,
  }

  public enum Screen: int {

  }


}
