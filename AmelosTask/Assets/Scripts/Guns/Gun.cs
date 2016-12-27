using UnityEngine;
using System.Collections;

public abstract class Gun 
{
    protected float shootCooldown;
    protected float timeSinceLastShoot;
    protected bool isReadyToShoot;
    protected float bulletSpeed;
    protected float damage;

    public Gun()
    {
        isReadyToShoot = true;
    }

    public abstract void OnShoot(Vector3 position, Vector3 direction);

    public virtual void Tick()
    {
        if(isReadyToShoot == false)
        {
            timeSinceLastShoot = timeSinceLastShoot + Time.deltaTime;
            if(timeSinceLastShoot > shootCooldown)
            {
                isReadyToShoot = true;
                timeSinceLastShoot = 0.0f;
            }
        }
    }


}
