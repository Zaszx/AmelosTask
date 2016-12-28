using UnityEngine;
using System.Collections;

public class InputManager
{
    public InputData movementInput;
    public InputData shootInput;

    public InputManager()
    {
        const float maxIntensity = 2.0f;
        Bounds movementBounds = new Bounds(new Vector3(Screen.width * 0.25f, Screen.height * 0.5f, 0), new Vector3(Screen.width * 0.5f, Screen.height, 100));
        movementInput = new InputData(movementBounds, maxIntensity);
        Bounds shootBounds = new Bounds(new Vector3(Screen.width * 0.75f, Screen.height * 0.5f, 0), new Vector3(Screen.width * 0.5f, Screen.height, 100));
        shootInput = new InputData(shootBounds, maxIntensity);
    }

    public void Tick()
    {
        movementInput.Tick();
        shootInput.Tick();
    }
}
