using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    private LayerMask layerMask;       
    private Mesh mesh;
    private float fov, viewDistance;
    Vector3 origin;
    float startingAngle;
    int rayCount = 50;
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        origin = Vector3.zero;
    }

    private void Update() {         ///No tengo idea como funciona pero funciona jajaja
        
        float angle = startingAngle;
        float angleIncrease = fov / rayCount;

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewDistance, layerMask);
            if(raycastHit2D.collider == null){
                //No hit
                vertex = origin + GetVectorFromAngle(angle) * viewDistance;
            }
            else{
                //Hit.point
                vertex = raycastHit2D.point;
            }
            vertices[vertexIndex] = vertex;

            if(i > 0){
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }
            
            vertexIndex++;
            angle -= angleIncrease;
        }


        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        mesh.bounds = new Bounds(origin, Vector3.one * 1000f);
    }

    Vector3 GetVectorFromAngle(float angle) {
        //angle = 0 -> 360
        float angleRad = angle * (Mathf.PI/180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    float GetAngleFormVectorFloat(Vector3 dir) {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if(n < 0) n += 360;
        return n;
    }
    public void SetOrigin(Vector3 origin) {
        this.origin = origin;
    }
    public void SetAimDirection(Vector3 aimDirection) {
        startingAngle = GetAngleFormVectorFloat(aimDirection) +  fov / 2f;
    }
    public void SetValues(float radius, float angle, LayerMask layer) {
        viewDistance = radius;
        fov = angle;
        layerMask = layer;
    }

}
