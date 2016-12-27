using UnityEngine;
using System.Collections;

public static class Prefabs
{
    public static GameObject bullet;
    static Prefabs()
    {
        bullet = Resources.Load<GameObject>("Prefabs/Bullet");
    }
}
