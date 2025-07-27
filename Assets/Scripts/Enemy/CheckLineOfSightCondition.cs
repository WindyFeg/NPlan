using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "Check LineOfSight ", story: "Check [Target] with [LoS] Detector", category: "Conditions", id: "ee10b76a79f18f33e758a6734886e9cc")]
public partial class CheckLineOfSightCondition : Condition
{
    [SerializeReference] public BlackboardVariable<GameObject> Target;
    [SerializeReference] public BlackboardVariable<LineOfSightDetector> LoS;

    public override bool IsTrue()
    {
        return LoS.Value.PerformDetection(Target.Value);
    }
}
