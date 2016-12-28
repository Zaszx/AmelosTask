using UnityEngine;
using System.Collections;

public static class Prefabs
{
    public static GameObject bullet;
    public static GameObject touchImage;
    public static GameObject touchVisual;
    static Prefabs()
    {
        bullet = Resources.Load<GameObject>("Prefabs/Bullet");

        touchImage = Resources.Load<GameObject>("Prefabs/TouchImage");
        touchVisual = Resources.Load<GameObject>("Prefabs/TouchVisual");
    }
}
