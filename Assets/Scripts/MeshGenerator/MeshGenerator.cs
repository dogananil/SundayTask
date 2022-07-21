using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Rendering;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class MeshGenerator : MonoBehaviour
{
    List<Vector3> verticesOrder = new List<Vector3>();
    [SerializeField] private Sprite _levelSprite;
    private MeshFilter _meshFilter;


    private void Awake()
    {
        _meshFilter = GetComponent<MeshFilter>();
    }
    private void Start()
    {
        CreateMesh();
    }
    private void CreateMesh( )
    {

        GetVerticesOrder(_levelSprite.vertices);
        int[] triangles = Enumerable.Range(0, verticesOrder.Count).ToArray();
        UpdateMesh(verticesOrder.ToArray(), triangles);

    }
    private List<Vector3> GetCircleVertices(float radius, float offsetAngle, Vector2 location)
    {
        List<Vector3> circleVertices = new List<Vector3>();

        int edges = 24;
        float pieceOfCircle = (2 * Mathf.PI) / edges;
        float angle = 0.0f;
        float x, z, y;
        for (int i = 0; i < edges; i++)
        {

            x = radius * Mathf.Cos(angle) * Mathf.Cos(offsetAngle);
            z = radius * Mathf.Sin(angle);
            y = radius * Mathf.Cos(angle) * Mathf.Sin(offsetAngle);

            circleVertices.Add(new Vector3(x + 10f * location.x, y + 10f * location.y, z));




            angle += pieceOfCircle;
        }
        return circleVertices;
    }
    private void GetVerticesOrder(Vector2[] svgVertices)
    {
        List<List<Vector3>> circleList = new List<List<Vector3>>();

        float angle = 0;
        for (int i = 0; i < svgVertices.Length; i++)
        {

            if (i % 2 == 0)
            {

                float tan = (svgVertices[i + 1].y - svgVertices[i].y) / (svgVertices[i + 1].x - svgVertices[i].x);
                angle = Mathf.Atan(tan);
                continue;
            }
            circleList.Add(GetCircleVertices(1f, angle, svgVertices[i]));

        }
        for (int i = 0; i < circleList.Count - 1; i++)
        {
            CalculateVerticesOrderBetweenCircles(circleList[i], circleList[i + 1]);
        }
    }
    private void CalculateVerticesOrderBetweenCircles(List<Vector3> prevCircle, List<Vector3> nextCircle)
    {

        for (int i = 0; i < prevCircle.Count; i++)
        {
            if (i == 0)
            {
                verticesOrder.Add(nextCircle[i]);
                verticesOrder.Add(prevCircle[i]);
                verticesOrder.Add(nextCircle[i + 1]);
                verticesOrder.Add(nextCircle[i]);
                verticesOrder.Add(prevCircle[prevCircle.Count - 1]);
                verticesOrder.Add(prevCircle[i]);
            }
            else if (i != 0 && i != prevCircle.Count - 1)
            {
                verticesOrder.Add(nextCircle[i]);
                verticesOrder.Add(prevCircle[i - 1]);
                verticesOrder.Add(prevCircle[i]);

                verticesOrder.Add(nextCircle[i]);
                verticesOrder.Add(prevCircle[i]);
                verticesOrder.Add(nextCircle[i + 1]);

            }
            else
            {
                verticesOrder.Add(nextCircle[i]);
                verticesOrder.Add(prevCircle[i - 1]);
                verticesOrder.Add(prevCircle[i]);

                verticesOrder.Add(nextCircle[i]);
                verticesOrder.Add(prevCircle[i]);
                verticesOrder.Add(nextCircle[0]);
            }

        }





    }
    private void UpdateMesh(Vector3[] vertices, int[] triangles)
    {
        var dataArray = Mesh.AllocateWritableMeshData(1);
        var data = dataArray[0];
        data.SetVertexBufferParams(vertices.Length,
            new VertexAttributeDescriptor(VertexAttribute.Position),
            new VertexAttributeDescriptor(VertexAttribute.Normal, stream: 1));
        data.SetIndexBufferParams(triangles.Length, IndexFormat.UInt16);
        var ib = data.GetIndexData<ushort>();
        for (ushort i = 0; i < ib.Length; ++i)
            ib[i] = i;
        data.subMeshCount = 1;
        data.SetSubMesh(0, new SubMeshDescriptor(0, ib.Length));

        Mesh newMesh = new Mesh();
        newMesh.name = "TubeMesh" + vertices.Length;
        //newMesh.Clear();

        Mesh.ApplyAndDisposeWritableMeshData(dataArray, newMesh);
        

        newMesh.vertices = vertices;
        newMesh.triangles = triangles;
        newMesh.RecalculateNormals();
        newMesh.RecalculateBounds();
        _meshFilter.mesh = newMesh;



        
        
      
    }
}