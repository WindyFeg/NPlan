using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Range Detector", story: "Update [Rangedetector] and assign [Target]", category: "Action", id: "422b6d107bb119babf616a41919ea16b")]
public partial class RangeDetectorAction : Action
{
    [SerializeReference] public BlackboardVariable<RangeDetector> Rangedetector;
    [SerializeReference] public BlackboardVariable<GameObject> Target;

    protected override Status OnUpdate()
    {
        Target.Value = Rangedetector.Value.UpdateDetector();
        return Target.Value == null ? Status.Failure : Status.Success;
    }
}

