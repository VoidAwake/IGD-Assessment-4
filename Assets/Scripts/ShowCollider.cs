using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShowCollider : MonoBehaviour
{
    private BoxCollider2D collider;

    protected void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        highlightAroundCollider(collider, Color.yellow, Color.red, 0.1f);
    }

    void highlightAroundCollider(BoxCollider2D collider, Color beginColor, Color endColor, float hightlightSize = 0.3f)
    {
        //1. Create new Line Renderer
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        // if (lineRenderer == null)
        // {
        //     lineRenderer = gameObject.AddComponent<LineRenderer>();

        // }

        // //2. Assign Material to the new Line Renderer
        // lineRenderer.material = new Material((Shader) Shader.Find("Particles/Additive"));

        float zPos = 10f;//Since this is 2D. Make sure it is in the front
        
        //3. Get the points from the PolygonCollider2D
        List<Vector2> colliderPoints = new List<Vector2>();

        colliderPoints.Add(new Vector2( collider.size.x / 2,  collider.size.y / 2));
        colliderPoints.Add(new Vector2(-collider.size.x / 2,  collider.size.y / 2));
        colliderPoints.Add(new Vector2( collider.size.x / 2, -collider.size.y / 2));
        colliderPoints.Add(new Vector2(-collider.size.x / 2, -collider.size.y / 2));

        //Set color and width
        lineRenderer.SetColors(beginColor, endColor);
        lineRenderer.SetWidth(hightlightSize, hightlightSize);

        //4. Convert local to world points
        for (int i = 0; i < colliderPoints.Count; i++)
        {
            Debug.Log(colliderPoints[i]);
            colliderPoints[i] = transform.TransformPoint(colliderPoints[i]);
        }

        //5. Set the SetVertexCount of the LineRenderer to the Length of the points
        lineRenderer.SetVertexCount(colliderPoints.Count + 1);
        for (int i = 0; i < colliderPoints.Count; i++)
        {
            //6. Draw the  line
            Vector3 finalLine = colliderPoints[i];
            finalLine.z = zPos;
            lineRenderer.SetPosition(i, finalLine);

            //7. Check if this is the last loop. Now Close the Line drawn
            if (i == (colliderPoints.Count - 1))
            {
                finalLine = colliderPoints[0];
                finalLine.z = zPos;
                lineRenderer.SetPosition(colliderPoints.Count, finalLine);
            }
        }
    }
}