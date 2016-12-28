using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
    public InputManager inputManager;
    public Player player;
    public UIManager uiManager;

    void Awake()
    {
        Globals.Init();
    }

	void Start () 
    {
        inputManager = new InputManager();
        uiManager = new UIManager();
	}
	
	void Update () 
    {
        inputManager.Tick();
        uiManager.Tick();
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
