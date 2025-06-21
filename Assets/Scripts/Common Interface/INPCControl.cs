using LKT268.Utils;

namespace LKT268.Interface
{
    /// <summary>
    /// Interface for Npc control
    /// </summary>
    public interface INPCControl
    {
        void AssignFuctionJob(NPCFunctionType _type);
        void AssignWarriorJob(NPCWarriorType _type);
    }
}