using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderProjection : MonoBehaviour
{

    public int renderPoints = 50;
    public float pointDistance = 0.1f;
    public LayerMask colliders;
    private Color mainColor = new Color(.5f, .5f, .5f, .3f);
    private Color hitColor = new Color(0f, 1f, 0f, .3f);

    LineRenderer lineRenderer;
    PlayerController playerController;


    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        playerController= GetComponent<PlayerController>();

        lineRenderer.startColor = mainColor;
        lineRenderer.endColor = mainColor;
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.positionCount = renderPoints;
        List<Vector3> points = new List<Vector3>();
        Vector3 launchPosition = playerController.LaunchPoint.position;
        Vector3 projectileVelocity = playerController.LaunchPoint.up * playerController.projectileForce;

        lineRenderer.startColor = mainColor;
        lineRenderer.endColor = mainColor;

        for (float distance = 0; distance < renderPoints; distance += pointDistance)
        {
            
            Vector3 point = launchPosition + distance * projectileVelocity;
            point.y = launchPosition.y + projectileVelocity.y * distance + Physics.gravity.y / 2f * distance * distance;
            points.Add(point);

            if (Physics.OverlapSphere(point, 2, colliders).Length > 0) {
                lineRenderer.positionCount = points.Count;
                lineRenderer.startColor = hitColor;
                lineRenderer.endColor = hitColor;
                break;
            }
        }

        lineRenderer.SetPositions(points.ToArray());

    }
}
