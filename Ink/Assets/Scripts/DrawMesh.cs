using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DrawMesh : MonoBehaviour
{
    public Camera m_camera;
    public GameObject brush;

    LineRenderer currentLineRenderer;

    Vector2 lastPos;

    private void Update()
    {
        Drawing();
    }

    void Drawing()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CreateBrush();
        }
        else if (Input.GetKey(KeyCode.Mouse0))
        {
            PointToMousePos();
        }
        else
        {
            currentLineRenderer = null;
        }
    }

    void CreateBrush()
    {
        GameObject brushInstance = Instantiate(brush);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();

        //because you gotta have 2 points to start a line renderer, 
        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);

        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);

    }

    void AddAPoint(Vector2 pointPos)
    {
        currentLineRenderer.positionCount++;
        int positionIndex = currentLineRenderer.positionCount - 1;
        currentLineRenderer.SetPosition(positionIndex, pointPos);
    }

    void PointToMousePos()
    {
        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
        if (lastPos != mousePos)
        {
            AddAPoint(mousePos);
            lastPos = mousePos;
        }
    }
}

// Alternate way (but it resets the screen if mouse is pressed again)
//private Mesh mesh;
//private Vector3 lastMousePosition;

//public float lineThickness;
//public float minDistance;


//private void Update()
//{
//    // If mouse button is pressed
//    if (Input.GetMouseButtonDown(0))
//    {
//        mesh = new Mesh();

//        Vector3[] vertices = new Vector3[4];
//        Vector2[] uv = new Vector2[4];
//        int[] triangles = new int[6];

//        vertices[0] = GetMouseWorldPosition();
//        vertices[1] = GetMouseWorldPosition();
//        vertices[2] = GetMouseWorldPosition();
//        vertices[3] = GetMouseWorldPosition();

//        uv[0] = Vector2.zero;
//        uv[1] = Vector2.zero;
//        uv[2] = Vector2.zero;
//        uv[3] = Vector2.zero;

//        triangles[0] = 0;
//        triangles[1] = 3;
//        triangles[2] = 1;

//        triangles[3] = 1;
//        triangles[4] = 3;
//        triangles[5] = 2;

//        mesh.vertices = vertices;
//        mesh.uv = uv;
//        mesh.triangles = triangles;
//        mesh.MarkDynamic();

//        GetComponent<MeshFilter>().mesh = mesh;

//        lastMousePosition = GetMouseWorldPosition();
//    }


//    // If mouse button if held down
//    if (Input.GetMouseButton(0))
//    {
//        if (Vector2.Distance(GetMouseWorldPosition(), lastMousePosition) > minDistance)
//        {
//            Vector3[] vertices = new Vector3[mesh.vertices.Length + 2];
//            Vector2[] uv = new Vector2[mesh.uv.Length + 2];
//            int[] triangles = new int[mesh.triangles.Length + 6];

//            mesh.vertices.CopyTo(vertices, 0);
//            mesh.uv.CopyTo(uv, 0);
//            mesh.triangles.CopyTo(triangles, 0);

//            int vIndex = vertices.Length - 4;
//            int vIndex0 = vIndex + 0;   // The old vertex 1
//            int vIndex1 = vIndex + 1;   // The old vertex 2
//            int vIndex2 = vIndex + 2;   // The new vertex 1
//            int vIndex3 = vIndex + 3;   // The new vertex 2

//            // To get the upwards and downwards vectors, we will use a cross product between the forward and the normal vector

//            Vector3 mouseForwardVector = (GetMouseWorldPosition() - lastMousePosition).normalized;
//            Vector3 normal2D = new Vector3(0, 0, -1f);

//            Vector3 nextVertexUp = GetMouseWorldPosition() + Vector3.Cross(mouseForwardVector, normal2D) * lineThickness;
//            Vector3 nextVertexDown = GetMouseWorldPosition() + Vector3.Cross(mouseForwardVector, -1f * normal2D) * lineThickness;

//            vertices[vIndex2] = nextVertexUp;
//            vertices[vIndex3] = nextVertexDown;

//            uv[vIndex2] = Vector2.zero;
//            uv[vIndex3] = Vector2.zero;

//            int tIndex = triangles.Length - 6;

//            triangles[tIndex + 0] = vIndex0;
//            triangles[tIndex + 1] = vIndex2;
//            triangles[tIndex + 2] = vIndex1;

//            triangles[tIndex + 3] = vIndex1;
//            triangles[tIndex + 4] = vIndex2;
//            triangles[tIndex + 5] = vIndex3;

//            mesh.vertices = vertices;
//            mesh.uv = uv;
//            mesh.triangles = triangles;

//            lastMousePosition = GetMouseWorldPosition();
//        }
//    }

//}


//Vector3 GetMouseWorldPosition()
//{
//    Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
//    vec.z = 0;
//    return vec;
//}

//Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
//{
//    Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
//    return worldPosition;
//}


