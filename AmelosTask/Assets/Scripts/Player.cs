using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
    float cameraDistance = 3.0f;
    Vector3 lastMoveDirection = Vector3.forward;
    float cameraHeight = 3.0f;

	void Start () 
    {
	
	}
	
	void Update () 
    {

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
        Debug.Log("SHOOT " + direction);
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
