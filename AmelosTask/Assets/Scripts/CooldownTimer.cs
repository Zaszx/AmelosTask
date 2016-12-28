using UnityEngine;
using System.Collections;

public class CooldownTimer 
{
    float cooldown;
    float timeSinceLastAction;
    bool isReady;

    public CooldownTimer()
    {

    }

    public void Set(float cooldown)
    {
        this.cooldown = cooldown;
        isReady = true;
        timeSinceLastAction = 0.0f;
    }

    public void Tick()
    {
        if(isReady == false)
        {
            timeSinceLastAction = timeSinceLastAction + Time.deltaTime;
            if(timeSinceLastAction >= cooldown)
            {
                isReady = true;
                timeSinceLastAction = 0.0f;
            }
        }
    }

    public bool Query()
    {
        bool result = isReady;
        isReady = false;
        return result;
    }
}
