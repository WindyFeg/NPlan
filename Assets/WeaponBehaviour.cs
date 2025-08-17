using UnityEngine;
using LTK268.Model.CommonBase;
using LTK268.Utils;

public class WeaponBehaviour : MonoBehaviour
{
    [SerializeField] private Animator weaponAnimator;

    private HumanBase ownerModel;
    private WeaponObject weaponObject;

    private void OnTriggerEnter(Collider other) {
        Debug.Log($"Weapon trigger with: {other.name}");

        if (other.CompareTag("Player") || other.CompareTag("NPC"))
        {
            return;
        }

        if (weaponAnimator != null && weaponAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack_down"))
        {
            if (other.TryGetComponent(out EntityBase entity))
            {
                if (ownerModel == null || weaponObject == null)
                {
                    Debug.LogError("Owner model or weapon object is not set.");
                    return;
                }

                if (entity.EntityType != EntityType.Player && entity.EntityType != EntityType.NPC)
                {
                    int damage = weaponObject.Damage;
                    entity.TakeDamage(damage);
                    Debug.Log($"Entity {entity.Name} took {damage} damage from {weaponObject.Name}.");
                }
            }
        }
    }

    public void SetWeaponProperties(HumanBase ownerModel, WeaponObject weaponObject) {
        this.ownerModel = ownerModel;
        this.weaponObject = weaponObject;
        if (ownerModel == null || weaponObject == null) {
            Debug.LogError("Owner model or weapon object is not set.");
            return;
        }
    }
}
