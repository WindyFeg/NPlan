using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using LKT268.Model.CommonBase;
using System.Xml.Schema;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "NPC Range Detector", story: "[NPC] [UpdateDetector] and detect [Object] and get [ObjectModel]", category: "Action", id: "1167330c883563c2e81aa867017da88f")]
public partial class NpcRangeDetectorAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> NPC;
    [SerializeReference] public BlackboardVariable<EntityController> UpdateDetector;
    [SerializeReference] public BlackboardVariable<GameObject> Object;
    [SerializeReference] public BlackboardVariable<ObjectBase> ObjectModel;
    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        Object.Value = UpdateDetector.Value.UpdateDetector();
        ObjectModel.Value = Object.Value.GetComponent<ObjectBase>();
        return ObjectModel.Value == null ? Status.Failure : Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

