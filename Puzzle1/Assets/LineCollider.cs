
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UnityEngine;

public class LineCollider : MonoBehaviour
{
    LineRenderer rope;
    EdgeCollider2D edgeCollider;
    BoxCollider2D boxCollider;
    Vector3 points;
    Vector2[] points2 = new Vector2[35];

    private void Start()
    {
        edgeCollider = this.gameObject.GetComponent<EdgeCollider2D>();
        rope = this.gameObject.GetComponent<LineRenderer>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        getNewPositions();

        edgeCollider.points = points2;
    }

    private void Update()
    {
        getNewPositions();
        edgeCollider.offset = new Vector2(-transform.position.x, -transform.position.y);
        edgeCollider.points = points2;
    }

    void getNewPositions()
    {
        for (int i = 0; i < rope.positionCount; i++)
        {
            points = rope.GetPosition(i);
            points2[i] = new Vector2(points.x, points.y);
            
        }
    }
}