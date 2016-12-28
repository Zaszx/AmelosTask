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

    public GameObject touchImage;
    public GameObject touchVisual;

    public InputData(Bounds allowedArea, float maxIntensity)
    {
        this.allowedArea = allowedArea;
        this.maxIntensity = maxIntensity;

        touchImage = GameObject.Instantiate(Prefabs.touchImage);
        touchImage.transform.parent = Globals.canvas.transform;

        touchVisual = GameObject.Instantiate(Prefabs.touchVisual);
        touchVisual.transform.parent = Globals.canvas.transform;
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

        UpdateVisual();
    }

    private void UpdateVisual()
    {
        if(isActive)
        {
            RectTransform touchImageTransform = touchImage.GetComponent<RectTransform>();
            touchImageTransform.position = centerLocation;
            touchImage.SetActive(true);

            Vector2 currentDirection = currentTouchLocation - centerLocation;
            Vector2 touchLocationVisual = centerLocation + currentDirection * 20.0f;
            RectTransform touchVisualTransform = touchVisual.GetComponent<RectTransform>();
            touchVisualTransform.position = touchLocationVisual;
            touchVisual.SetActive(true);
        }
        else
        {
            touchImage.SetActive(false);
            touchVisual.SetActive(false);
        }
    }

    private bool ProcessTouch(Vector3 touchPosition)
    {
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
