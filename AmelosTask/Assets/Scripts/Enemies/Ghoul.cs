using UnityEngine;
using System.Collections;

public class Ghoul : Enemy 
{
    protected const float attackDistance = 2.0f;

    public override void Start()
    {
        base.Start();

        health = 50.0f;
        damage = 10.0f;
        speed = 3.0f;

        cooldownTimer.Set(0.1f);
    }


    public override void Update()
    {
        base.Update();

        if(hasSeenPlayer)
        {
            Vector3 vectorToPlayer = Globals.player.transform.position - transform.position;
            transform.forward = vectorToPlayer.normalized;
            float distanceToPlayer = Vector3.Distance(transform.position, Globals.player.transform.position);
            if(distanceToPlayer < attackDistance)
            {
                Attack();
            }
            else
            {
                transform.position += vectorToPlayer.normalized * speed * Time.deltaTime;
            }
        }
    }

    public override void Attack()
    {
        if(cooldownTimer.Query())
        {
            Globals.player.ReceiveDamage(damage);
        }
    }
}
