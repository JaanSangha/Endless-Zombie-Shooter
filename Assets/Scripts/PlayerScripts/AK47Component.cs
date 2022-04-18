using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47Component : WeaponComponent
{
    Vector3 hitLocation;
    public Rigidbody bulletPrefab;

    protected override void FireWeapon()
    {

        if (weaponStats.bulletsInClip > 0 && !isReloading && !weaponHolder.playerController.isRunning)
        {
            base.FireWeapon();
            if(firingEffect)
            {
                firingEffect.Play();
            }
            Ray screenRay = mainCamera.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2, 0));

            Rigidbody p = Instantiate(bulletPrefab, transform.position, transform.rotation);
            p.velocity = transform.forward * 4;
           // Instantiate(bulletPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            if (Physics.Raycast(screenRay, out RaycastHit hit, weaponStats.fireDistance, weaponStats.weaponHitLayers))
            {
                hitLocation = hit.point;

                DealDamage(hit);
                Vector3 hitDirection = hit.point - mainCamera.transform.position;
                Debug.DrawRay(mainCamera.transform.position, hitDirection.normalized * weaponStats.fireDistance, Color.red, 1);
            }
            print("Bullet Count: " + weaponStats.bulletsInClip);
        }
        else if(weaponStats.bulletsInClip <= 0)
        {
            weaponHolder.StartReloading();
        }
    }

    void DealDamage(RaycastHit hitinfo)
    {
        IDamageable damageable = hitinfo.collider.GetComponent<IDamageable>();
        damageable?.TakeDamage((weaponStats.damage));
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(hitLocation, 0.2f);
    }
}
