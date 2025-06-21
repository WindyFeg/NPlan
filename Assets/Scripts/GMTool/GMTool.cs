using LKT268.Model.CommonBase;
using LKT268.Utils;
using UnityEngine;

public class GMTool : MonoBehaviour
{
    public NpcModel npcModel;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            npcModel.AssignFunctionJob(NPCFunctionType.Blacksmith);
            LTK268Log.LogEntity(npcModel);
        }


        if (Input.GetKeyDown(KeyCode.J))
        {
            npcModel.AssignWarriorJob(NPCWarriorType.Archer);
            LTK268Log.LogEntity(npcModel);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            npcModel.CureSickness();
            LTK268Log.LogEntity(npcModel);
        }
    }
}
