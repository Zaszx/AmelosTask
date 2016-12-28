using UnityEngine;
using System.Collections;

public class Crate : MonoBehaviour 
{
    public GunType gunType;

    void OnTriggerEnter(Collider collidedObject)
    {
        if(collidedObject.gameObject.GetComponent<Player>() != null)
        {
            Globals.player.gun = CreateGun();
        }
        GameObject.Destroy(this.gameObject);
    }

    Gun CreateGun()
    {
        switch(gunType)
        {
            case GunType.MachineGun:
                return new MachineGun();
            case GunType.ShotGun:
                return new ShotGun();
        }
        return new MachineGun();
    }
}
