using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFloatAnimation : MonoBehaviour
{
    private const float scaleSoftner = 0.1f;

    public float rotationSpeed = 50.0f;
    public float scaleSpeed = 2.0f;
    public float minScale = 0.4f;
    public float maxScale = 0.6f;

    private float currentScale;
    private bool isIncreasing = true;

    private void Start()
    {
        currentScale = minScale;
        transform.localScale = Vector3.one * minScale;
    }

    void Update()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        transform.localScale = Vector3.one * currentScale;
        UpdateScaleData();
    }

    private void UpdateScaleData()
    {
        float scaleAddition = scaleSpeed * scaleSoftner * Time.deltaTime;
        if (isIncreasing)
        {
            if (currentScale < maxScale)
            {
                currentScale += scaleAddition;
            }
            else
            {
                isIncreasing = false;
                currentScale -= scaleAddition;
            }
        }
        else
        {
            if (currentScale > minScale)
            {
                currentScale -= scaleAddition;
            }
            else
            {
                isIncreasing = true;
                currentScale += scaleAddition;
            }
        }
    }
}
