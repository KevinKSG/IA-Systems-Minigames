using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VisionCone : MonoBehaviour
{
    public Material visionConeMaterial;
    public float visionRange;
    public float visionAngle;
    public LayerMask visionObstrutingLayer;
    public int visionConeResolution = 120;
    Mesh visionConeMesh;
    MeshFilter meshFilter;

    // Start is called before the first frame update
    void Start()
    {
        transform.AddComponent<MeshRenderer>().material = visionConeMaterial;
        meshFilter = transform.AddComponent<MeshFilter>();
        visionConeMesh = new Mesh();
        visionAngle *= Mathf.Deg2Rad;
    }

    // Update is called once per frame
    void Update()
    {
        DrawVisionCone();
    }

    void DrawVisionCone()
    {
        int[] triangles = new int[(visionConeResolution - 1) * 3];
        Vector3[] vertices = new Vector3[visionConeResolution + 1];
        vertices[0] = Vector3.zero;
        float currentAngle = -visionAngle / 2;
        float angleIncrement = visionAngle / (visionConeResolution - 1);
        float sine;
        float cosine;

        for(int i=0;i<visionConeResolution;i++)
        {
            sine = Mathf.Sin(currentAngle);
            cosine = Mathf.Cos(currentAngle);
            Vector3 raycastDirection = (transform.forward * cosine) + (transform.right * sine);
            Vector3 vertForward = (Vector3.forward * cosine) + (Vector3.right * sine);
            if(Physics.Raycast(transform.position,raycastDirection,out RaycastHit hit,visionRange,visionObstrutingLayer))
            {
                vertices[i + 1] = vertForward * hit.distance;
            }
            else
            {
                vertices[i + 1] = vertForward * visionRange;
            }

            currentAngle += angleIncrement;
        }
        for(int i=0,j=0;i<triangles.Length;i+=3, j++)
        {
            triangles[i] = 0;
            triangles[i + 1] = j + 1;
            triangles[i + 2] = j + 2;
        }
        visionConeMesh.Clear();
        visionConeMesh.vertices = vertices;
        visionConeMesh.triangles = triangles;
        meshFilter.mesh = visionConeMesh;
    }
}
