using LTK268.Model.CommonBase;
using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "Check max hold Item", story: "if number of holding object in [Model] is greater than x", category: "Conditions", id: "96629be4b3fcac34a020d383217bb642")]
public partial class CheckMaxHoldItemCondition : Condition
{
    [SerializeReference] public BlackboardVariable<NpcModel> Model;

    public override bool IsTrue()
    {
        var _model = Model.Value;
        return _model.HoldItems.Count < _model.MaxNumberOfHoldItems;
    }

    public override void OnStart()
    {
    }

    public override void OnEnd()
    {
    }
}
