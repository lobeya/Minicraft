using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent (typeof(MeshRenderer))]
public class GetAllMeshInformation : MonoBehaviour
{
    private Mesh m_mesh;
    private MeshFilter m_meshFilter;
    private MeshRenderer m_renderer;

    private List<Vector3> vertices = new List<Vector3>();
    private List<int> tris = new List<int>();
    private List<Vector2> uvs=  new List<Vector2>();

    private void Awake()
    {
        m_mesh=new Mesh();
        m_meshFilter= GetComponent<MeshFilter>();
        m_renderer= GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        m_mesh = m_meshFilter.mesh;
        print("\tvertices");
        foreach (Vector3 v in m_mesh.vertices)
        {
            print("vertices" + v);
        }
        print("\ttriangles");
        foreach (int v in m_mesh.triangles)
        {
            print("triangles" + v);
        }
        print("\tuv");
        foreach (Vector2 v in m_mesh.uv)
        {
            print("uv" + v);
        }
    }
}
