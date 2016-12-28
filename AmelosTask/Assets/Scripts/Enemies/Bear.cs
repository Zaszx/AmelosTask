using UnityEngine;
using System.Collections;

public class Bear : Enemy
{
    public override void Start()
    {
        base.Start();

        health = 50.0f;
        damage = 40.0f;
        speed = 1.0f;
        seeDistance = 20.0f;
        attackDistance = 2.0f;

        cooldownTimer.Set(0.5f);
    }


    public override void Update()
    {
        base.Update();

        if (hasSeenPlayer)
        {
            Vector3 vectorToPlayer = Globals.player.transform.position - transform.position;
            transform.forward = vectorToPlayer.normalized;
            float distanceToPlayer = Vector3.Distance(transform.position, Globals.player.transform.position);
            if (distanceToPlayer < attackDistance)
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
        if (cooldownTimer.Query())
        {
            Globals.player.ReceiveDamage(damage);
        }
    }
}
