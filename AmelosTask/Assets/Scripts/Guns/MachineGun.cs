using UnityEngine;
using System.Collections;

public class MachineGun : Gun 
{
    public MachineGun()
    {
        cooldownTimer.Set(0.1f);
        bulletSpeed = 15.0f;
        damage = 10.0f;
    }

    public override void OnShoot(Vector3 position, Vector3 direction)
    {
        if(cooldownTimer.Query())
        {
            CreateBullet(position, direction);
        }
    }

    public override void Tick()
    {
        base.Tick();
    }
}
