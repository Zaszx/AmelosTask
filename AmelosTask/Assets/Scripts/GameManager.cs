using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
    public InputManager inputManager;
    public Player player;

    void Awake()
    {
        Globals.Init();
    }

	void Start () 
    {
        inputManager = new InputManager();

	}
	
	void Update () 
    {
        inputManager.Tick();
        if(inputManager.movementInput.isActive)
        {
            player.Move(inputManager.movementInput.direction);
            player.UpdateCameraPosition();
        }
        if(inputManager.shootInput.isActive)
        {
            player.Shoot(inputManager.shootInput.direction);
        }
	}
}
