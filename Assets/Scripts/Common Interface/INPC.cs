using LKT268.Utils;

namespace LKT268.Interface
{
    /// <summary>
    /// Interface for Npc control
    /// </summary>
    public interface INPCControl
    {
        /// <summary>
        /// Assign job for jobless NPC
        /// </summary>
        /// <param name="_type">Functional Type</param>
        void AssignFunctionJob(NPCFunctionType _type);

        /// <summary>
        /// Assign job for jobless NPC
        /// </summary>
        /// <param name="_type">Warrior Type</param>
        void AssignWarriorJob(NPCWarriorType _type);
    }

    public interface INPCCommonChecking
    {
        /// <summary>
        /// Use to check if that NPC is an Functional NPC()
        /// </summary>
        /// <returns></returns>
        public bool IsFunctionNPC();
        /// <summary>
        /// Use to check if that NPC is an Warrior NPC()
        /// </summary>
        /// <returns></returns>
        public bool IsWarriorNPC();
    }

    public interface INPC : INPCControl, INPCCommonChecking { }
}