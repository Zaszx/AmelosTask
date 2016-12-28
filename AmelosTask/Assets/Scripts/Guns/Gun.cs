using UnityEngine;
using System.Collections;

public abstract class Gun 
{
    protected CooldownTimer cooldownTimer = new CooldownTimer();
    protected float bulletSpeed;
    protected float damage;

    public Gun()
    {

    }

    public abstract void OnShoot(Vector3 position, Vector3 direction);

    public virtual void Tick()
    {
        cooldownTimer.Tick();
    }


}
