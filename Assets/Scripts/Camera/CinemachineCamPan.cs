using Unity.Cinemachine;
using UnityEngine;
using DG.Tweening;
using LTK268.Manager; // Add DOTween namespace

public class CinemachineCamPan : MonoBehaviour
{
    public int panSpeed = 1; // Speed of camera panning
    public CinemachineFollow cinemachineFollow;
    public float tweenDuration = 0.3f; // Duration for DOTween animation
    public Vector2 panRangeY = new Vector2(4, 20);
    public Vector2 panRangeZ = new Vector2(-15, 12.5f);

    private void Update()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollInput != 0f)
        {
            int direction = scrollInput > 0 ? panSpeed : -panSpeed;
            Vector3 proposedOffset = cinemachineFollow.FollowOffset + new Vector3(0, direction, -direction / 2);

            // Check limits: y <= 20, z <= 20, y >= 0, z >= 0
            if (proposedOffset.y >= panRangeY.x && proposedOffset.y <= panRangeY.y && proposedOffset.z >= panRangeZ.x && proposedOffset.z <= panRangeZ.y)
            {
                PlayerManager.Instance.CameraPanForPlayer(direction, tweenDuration);
                NpcManager.Instance.CameraPanForNpcs(direction, tweenDuration);
                EnemyManager.Instance.CameraPanForEnemies(direction, tweenDuration);

                // Use DOTween to animate the offset
                DOTween.Kill(cinemachineFollow);
                DOTween.To(
                    () => cinemachineFollow.FollowOffset,
                    x => cinemachineFollow.FollowOffset = x,
                    proposedOffset,
                    tweenDuration
                );
            }
            else
            {
                Debug.LogWarning($"Proposed offset {proposedOffset} is out of bounds. Y range: {panRangeY}, Z range: {panRangeZ}");
            }
        }
    }
}
