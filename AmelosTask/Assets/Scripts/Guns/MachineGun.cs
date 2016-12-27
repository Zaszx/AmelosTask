﻿using UnityEngine;
using System.Collections;

public class MachineGun : Gun 
{

    public MachineGun()
    {
        shootCooldown = 0.1f;
        bulletSpeed = 5.0f;
        damage = 10.0f;
    }

    public override void OnShoot(Vector3 position, Vector3 direction)
    {
        if(isReadyToShoot)
        {
            Bullet newBullet = GameObject.Instantiate(Prefabs.bullet).GetComponent<Bullet>();
            newBullet.damage = damage;
            newBullet.transform.position = position + direction.normalized;
            newBullet.transform.forward = direction.normalized;
            newBullet.GetComponent<Rigidbody>().velocity = direction.normalized * bulletSpeed;
            newBullet.transform.parent = Globals.bulletsParentObject.transform;
            isReadyToShoot = false;
        }
    }

    public override void Tick()
    {
        base.Tick();
    }
}