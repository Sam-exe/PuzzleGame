using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class LineCollision : MonoBehaviour {

    LineRenderer rope;
    Vector3 points;
    Vector2[] points2 = new Vector2[35];

    PolygonCollider2D polygonCollider;

    private void Awake() {
        rope = GetComponent<LineRenderer>();
        polygonCollider = GetComponent<PolygonCollider2D>();
    }
    void getNewPositions()
    {
        for (int i = 0; i < rope.positionCount; i++)
        {
            points = rope.GetPosition(i);
            points2[i] = new Vector2(points.x, points.y);
        }
    }
    private void LateUpdate() { 

        //Get all the positions from the line renderer
        Vector2[] positions = points2;

        //If we have enough points to draw a line
        if (positions.Count() >= 2) {

            //Get the number of line between two points
            int numberOfLines = positions.Length - 1;

            //Make as many paths for each different line as we have lines
            polygonCollider.pathCount = numberOfLines;

            //Get Collider points between two consecutive points
            for (int i = 0; i < numberOfLines; i++) {
                //Get the two next points
                List<Vector2> currentPositions = new List<Vector2> {
                    positions[i],
                    positions[i+1]
                };

                List<Vector2> currentColliderPoints = CalculateColliderPoints(currentPositions);
                polygonCollider.SetPath(i, currentColliderPoints.ConvertAll(p => (Vector2)transform.InverseTransformPoint(p)));
            }
        }
        else {

            polygonCollider.pathCount = 0;
        }
    }

    private List<Vector2> CalculateColliderPoints(List<Vector2> positions) {
        //Get The Width of the Line
        float width = 0.2f;

        // m = (y2 - y1) / (x2 - x1)
        float m = (positions[1].y - positions[0].y) / (positions[1].x - positions[0].x);
        float deltaX = (width / 2f) * (m / Mathf.Pow(m * m + 1, 0.5f));
        float deltaY = (width / 2f) * (1 / Mathf.Pow(1 + m * m, 0.5f));

        //Calculate Vertex Offset from Line Point
        Vector2[] offsets = new Vector2[2];
        offsets[0] = new Vector2(-deltaX, deltaY);
        offsets[1] = new Vector2(deltaX, -deltaY);

        List<Vector2> colliderPoints = new List<Vector2> {
            positions[0] + offsets[0],
            positions[1] + offsets[0],
            positions[1] + offsets[1],
            positions[0] + offsets[1]
        };

        return colliderPoints;
    }
}
