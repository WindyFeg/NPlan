using System.Collections.Generic;
using LKT268;
using LKT268.Utils;
using UnityEngine;
using UnityEngine.UI;

public enum JobItemPos
{
    Left,
    Right,
    Center,
    FarLeft,
    FarRight
}

public class JobItemUI : MonoBehaviour
{
    public List<Sprite> jobIcon;
    [Header("Job Item UI")]
    [SerializeField] private Image jobItemIcon;
    public JobItemPos jobItemPos;
    private NPCFunctionType currentJobType;

    public void SetItem(NPCFunctionType jobType)
    {
        this.currentJobType = jobType;
        switch (jobType)
        {
            case NPCFunctionType.Lumber:
                jobItemIcon.img().sprite = jobIcon[0];
                break;
            case NPCFunctionType.Builder:
                jobItemIcon.img().sprite = jobIcon[1];
                break;
            case NPCFunctionType.Farmer:
                jobItemIcon.img().sprite = jobIcon[2];
                break;
            case NPCFunctionType.Blacksmith:
                jobItemIcon.img().sprite = jobIcon[3];
                break;
            case NPCFunctionType.Healer:
                jobItemIcon.img().sprite = jobIcon[4];
                break;
            case NPCFunctionType.Miner:
                jobItemIcon.img().sprite = jobIcon[5];
                break;
            case NPCFunctionType.None:
                jobItemIcon.img().sprite = jobIcon[6];
                break;
        }
    }

    public void MoveToCenter()
    {
        this.jobItemPos = JobItemPos.Center;
    }

    public void MoveToLeft()
    {
        this.jobItemPos = JobItemPos.Left;
    }

    public void MoveToRight()
    {
        this.jobItemPos = JobItemPos.Right;
    }
}
