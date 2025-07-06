using Unity.Cinemachine;
using UnityEngine;
using DG.Tweening;
using LTK268.Manager; // Add DOTween namespace

public class CinemachineCamPan : MonoBehaviour
{
    public float panSpeed = 20f; // Speed of camera panning
    private Vector3 initialPosition;
    public CinemachineFollow cinemachineFollow;
    public float tweenDuration = 0.3f; // Duration for DOTween animation

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollInput != 0f)
        {
            int direction = scrollInput > 0 ? 1 : -1;
            Vector3 proposedOffset = cinemachineFollow.FollowOffset + new Vector3(0, direction, -direction / 2);

            // Check limits: y <= 20, z <= 20, y >= 0, z >= 0
            if (proposedOffset.y >= 2 && proposedOffset.y <= 22 && proposedOffset.z >= -7.5 && proposedOffset.z <= 12.5)
            {
                if (direction > 0)
                {
                    Debug.Log("Panning Up");
                    PlayerManager.Instance.PlayerModel.transform.DORotate(
                        new Vector3(5, 0, 0), // Rotate 1 degree on X, 0 on Y, 0 on Z
                        tweenDuration,
                        RotateMode.LocalAxisAdd // Add this rotation to the current local rotation
                    ).SetEase(Ease.InOutQuad);
                }
                else
                {
                    Debug.Log("Panning Down");
                    PlayerManager.Instance.PlayerModel.transform.DORotate(
                        new Vector3(-5, 0, 0), // Rotate 1 degree on X, 0 on Y, 0 on Z
                        tweenDuration,
                        RotateMode.LocalAxisAdd // Add this rotation to the current local rotation
                    ).SetEase(Ease.InOutQuad);
                }

                // Use DOTween to animate the offset
                DOTween.Kill(cinemachineFollow); // Kill any previous tweens on this target
                DOTween.To(
                    () => cinemachineFollow.FollowOffset,
                    x => cinemachineFollow.FollowOffset = x,
                    proposedOffset,
                    tweenDuration
                );

                // Vector3 playerProposedOffset = new Vector3(direction / 2, 0, 0);
                // PlayerManager.Instance.transform.DOr(
                //     PlayerManager.Instance.transform.position + playerProposedOffset,
                //     tweenDuration
                // ).SetEase(Ease.InOutQuad);
            }


        }
    }
}
