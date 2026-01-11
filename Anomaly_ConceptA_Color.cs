using UnityEngine;
using System.Collections.Generic;

public class ExplodedViewInteractable : MonoBehaviour
{
    [Header("Explosion Settings")]
    [Tooltip("Distance multiplier for the explosion effect")]
    public float explosionDistance = 2f;
    
    [Tooltip("Speed of the explosion/collapse animation")]
    public float animationSpeed = 5f;

    private bool isExploded = false;
    private Dictionary<Transform, Vector3> originalPositions = new Dictionary<Transform, Vector3>();

    void Start()
    {
        // Store original local positions of all child objects
        foreach (Transform child in transform)
        {
            originalPositions[child] = child.localPosition;
        }
    }

    void OnMouseDown()
    {
        // Toggle explosion state on click
        isExploded = !isExploded;
    }

    void Update()
    {
        // Smoothly animate each child to its target position
        foreach (Transform child in transform)
        {
            if (!originalPositions.ContainsKey(child)) continue;

            Vector3 originalPos = originalPositions[child];
            Vector3 targetPos;

            if (isExploded)
            {
                // Calculate exploded position: move away from center along local direction
                Vector3 direction = originalPos.normalized;
                targetPos = originalPos + (direction * explosionDistance);
            }
            else
            {
                // Return to original position
                targetPos = originalPos;
            }

            // Smoothly interpolate to target position
            child.localPosition = Vector3.Lerp(
                child.localPosition, 
                targetPos, 
                Time.deltaTime * animationSpeed
            );
        }
    }
}