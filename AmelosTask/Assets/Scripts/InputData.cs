using UnityEngine;
using System.Collections;

public class InputData
{
    private Bounds allowedArea;
    private float maxIntensity;

    public bool isActive;
    public Vector2 centerLocation;
    public Vector2 currentTouchLocation;
    public Vector2 direction;

    public InputData(Bounds allowedArea, float maxIntensity)
    {
        this.allowedArea = allowedArea;
        this.maxIntensity = maxIntensity;

        Debug.Log("ALLOWED AREA: " + allowedArea);
    }

    public void Tick()
    {
        bool anyRelevantTouchFound = false;
        for(int i = 0; i < Input.touchCount; i++)
        {
            Touch currentTouch = Input.GetTouch(i);
            anyRelevantTouchFound = ProcessTouch(currentTouch.position);
        }

        if(Input.GetKey(KeyCode.Mouse0))
        {
            anyRelevantTouchFound = ProcessTouch(Input.mousePosition);
        }

        isActive = anyRelevantTouchFound;
    }

    private bool ProcessTouch(Vector3 touchPosition)
    {
        //Debug.Log("TOUCH POSITION: " + touchPosition);
        if (allowedArea.Contains(touchPosition))
        {
            if (isActive)
            {
                currentTouchLocation = touchPosition;
                float intensity = Vector2.Distance(currentTouchLocation, centerLocation);
                if (intensity > maxIntensity)
                {
                    Vector2 currentDirection = currentTouchLocation - centerLocation;
                    currentTouchLocation = centerLocation + currentDirection.normalized * maxIntensity;
                }
            }
            else
            {
                centerLocation = touchPosition;
                currentTouchLocation = touchPosition;
            }
            UpdateDirection();
            return true;
        }
        return false;
    }

    private void UpdateDirection()
    {
        direction = currentTouchLocation - centerLocation;
    }


}
