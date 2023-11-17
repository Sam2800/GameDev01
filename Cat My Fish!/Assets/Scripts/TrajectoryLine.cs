using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryLine : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private int lineSegments = 60;
    [SerializeField, Min(1)] private float timeOfTheFlight = 1;

    public void ShowTrajectoryLine(Vector3 startpoint, Vector3 startVelocity)
    {
        float timeStep = timeOfTheFlight / lineSegments;

        Vector3[] lineRendererPoints = CalculateTrajectoryLine(startpoint, startVelocity, timeStep);

        lineRenderer.positionCount = lineSegments;
        lineRenderer.SetPositions(lineRendererPoints);
    }

    private Vector3[] CalculateTrajectoryLine(Vector3 startpoint, Vector3 startVelocity, float timeStep)
    {
        Vector3[] lineRendererPoints = new Vector3[lineSegments];
        lineRendererPoints[0] = startpoint;
        for (int i = 1; i < lineSegments; i++)
        {
            float timeOffset = timeStep * 1;

            Vector3 progressBeforeGravity = startVelocity * timeOffset;
            Vector3 gravityOffset = Vector3.up * -0.475f * Physics.gravity.y * timeOffset * timeOffset;
            Vector3 newPosition = startpoint + progressBeforeGravity - gravityOffset;
            lineRendererPoints[i] = newPosition;
        }

        return lineRendererPoints;
    }
    void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            timeOfTheFlight = 60;
        }
        if (Input.GetMouseButtonUp(0))
        {
            timeOfTheFlight = 1;
        }
    }
}
