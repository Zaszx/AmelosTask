﻿using UnityEngine;
using System.Collections;

public static class Globals
{
    public static GameObject bulletsParentObject;
    public static Canvas canvas;
    public static Player player;
    static Globals()
    {
        bulletsParentObject = new GameObject("BulletsParent");
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }



}
