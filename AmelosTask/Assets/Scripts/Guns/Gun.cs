using UnityEngine;
using System.Collections;

public enum GunType
{
    MachineGun,
    ShotGun,
}
public abstract class Gun 
{
    protected CooldownTimer cooldownTimer = new CooldownTimer();
    protected float bulletSpeed;
    protected float damage;

    public Gun()
    {

    }

    public virtual void CreateBullet(Vector3 position, Vector3 direction)
    {
        Bullet newBullet = GameObject.Instantiate(Prefabs.bullet).GetComponent<Bullet>();
        newBullet.damage = damage;
        newBullet.transform.position = position + direction.normalized;
        newBullet.transform.forward = direction.normalized;
        newBullet.GetComponent<Rigidbody>().velocity = direction.normalized * bulletSpeed;
        newBullet.transform.parent = Globals.bulletsParentObject.transform;
    }

    public abstract void OnShoot(Vector3 position, Vector3 direction);

    public virtual void Tick()
    {
        cooldownTimer.Tick();
    }


}
