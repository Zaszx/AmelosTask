using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour 
{
    float cameraDistance;
    Vector3 lastMoveDirection = Vector3.forward;
    float cameraHeight;
    public Gun gun;
    float health;
    const float maxHealth = 100.0f;

	void Start () 
    {
        cameraDistance = 5.0f;
        cameraHeight = 3.0f;
        health = maxHealth;
        gun = new MachineGun();

        Globals.player = this;
	}
	
    public float GetRemainingHealth()
    {
        return health;
    }

	void Update () 
    {
        gun.Tick();
	}

    public void ReceiveDamage(float damage)
    {
        health = health - damage;
        if(health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        SceneManager.LoadScene("gameScene");
    }

    public void Move(Vector2 direction)
    {
        Vector3 moveDirectionTransformed = new Vector3(direction.x, 0, direction.y);
        moveDirectionTransformed = Camera.main.transform.TransformDirection(moveDirectionTransformed);
        moveDirectionTransformed.y = 0;
        lastMoveDirection = moveDirectionTransformed;
        transform.position = transform.position + moveDirectionTransformed * Time.deltaTime;
    }

    public void Shoot(Vector2 direction)
    {
        Vector3 shootDirectionTransformed = new Vector3(direction.x, 0, direction.y);
        shootDirectionTransformed = Camera.main.transform.TransformDirection(shootDirectionTransformed);
        shootDirectionTransformed.y = 0.0f;

        gun.OnShoot(transform.position, shootDirectionTransformed);
    }

    public void UpdateCameraPosition()
    {
        Vector3 newForward = lastMoveDirection;
        newForward.Normalize();
        this.transform.forward = Vector3.Slerp(this.transform.forward, newForward, Time.deltaTime * 5.0f);
        this.transform.forward.Normalize();

        Camera mainCamera = Camera.main;

        Vector3 cameraTargetPosition = transform.position - newForward * cameraDistance + Vector3.up * cameraHeight;
        Vector3 cameraDummyPosition = Vector3.Lerp(mainCamera.transform.position, cameraTargetPosition, Time.deltaTime * 2.0f);
        cameraDummyPosition.y = 0;
        Vector3 playerToDummyPosition = cameraDummyPosition - transform.position;
        mainCamera.transform.position = transform.position + playerToDummyPosition.normalized * cameraDistance + Vector3.up * cameraHeight;

        mainCamera.transform.LookAt(transform);
    }
}
