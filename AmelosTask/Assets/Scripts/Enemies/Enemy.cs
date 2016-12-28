using UnityEngine;
using System.Collections;
using System.Timers;

public abstract class Enemy : MonoBehaviour 
{
    public float health;
    public bool hasSeenPlayer;
    protected float damage;
    protected float speed;
    protected CooldownTimer cooldownTimer = new CooldownTimer();
    protected float seeDistance;

    public virtual void Start()
    {
        hasSeenPlayer = false;
    }

	public virtual void ReceiveDamage(float damage)
    {
        health = health - damage;
        if(health < 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        GameObject.Destroy(this.gameObject);
    }

    public virtual void Update()
    {
        if(hasSeenPlayer == false)
        {
            float distanceToPlayer = Vector3.Distance(Globals.player.transform.position, transform.position);
            if (distanceToPlayer < seeDistance)
            {
                Ray rayToPlayer = new Ray(transform.position, Globals.player.transform.position - transform.position);
                RaycastHit hitInfo = new RaycastHit();
                bool rayHitsAnything = Physics.Raycast(rayToPlayer, out hitInfo);
                if (rayHitsAnything)
                {
                    if (hitInfo.collider.gameObject.GetComponent<Player>() != null)
                    {
                        hasSeenPlayer = true;
                    }
                }
            }
        }
        cooldownTimer.Tick();
    }

    public abstract void Attack();
}
