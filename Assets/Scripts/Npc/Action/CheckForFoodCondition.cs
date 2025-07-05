using LKT268.Model.CommonBase;
using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "Check for Food", story: "Check if [Object] is [FoodObject]", category: "Variable Conditions", id: "937c774bc70201b41e7e995a78450e11")]
public partial class CheckForFoodCondition : Condition
{
    [SerializeReference] public BlackboardVariable<GameObject> Object;
    public override bool IsTrue()
    {
        var obj = Object.Value;

        if (obj == null)
            return false;

        var objFood = obj.GetComponent<FoodBase>();
        return objFood != null && objFood.GetType() == typeof(FoodBase);
    }

    public override void OnStart()
    {
    }

    public override void OnEnd()
    {
    }
}
