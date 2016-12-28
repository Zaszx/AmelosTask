using UnityEngine;
using System.Collections;

public class ShotGun : Gun
{
    public ShotGun()
    {
        cooldownTimer.Set(0.5f);
        bulletSpeed = 5.0f;
        damage = 20.0f;
    }

    public override void OnShoot(Vector3 position, Vector3 direction)
    {
        if (cooldownTimer.Query())
        {
            for (int i = -1; i <= 1; i++ )
            {
                Vector3 currentDirection = Quaternion.Euler(0, i * 10, 0) * direction;
                CreateBullet(position, currentDirection);

            }
        }
    }

    public override void Tick()
    {
        base.Tick();
    }
}
