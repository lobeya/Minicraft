using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class Chunk : MonoBehaviour
{
    Mesh m_mesh;
    MeshFilter m_filter;
    MeshRenderer m_renderer;
    [SerializeField]private Material m_material;
    List<Vector3> vertices = new List<Vector3>();
    List<int> triangles = new List<int>();
    List<Vector2> uvs = new List<Vector2>();
    int vertexIndex = 0;

    bool[,,] voxelMap = new bool[VoxelData.chunkWidth, VoxelData.chunkHeight, VoxelData.chunkWidth];

    private void Awake()
    {
        m_mesh=new Mesh();
        m_filter=GetComponent<MeshFilter>();
        m_renderer=GetComponent<MeshRenderer>();
        m_renderer.material = m_material;
    }

    private void Start()
    {
        PopulateVoxelMap();
        CreateMeshData();
        //AddVoxelDataToChunk(transform.position);
        CreateMesh();
        
    }
    #region ������Api ����
    void MathfFloorToIntExample()
    {
        Debug.Log(Mathf.FloorToInt(10.0F));  // Prints  10
        Debug.Log(Mathf.FloorToInt(10.2F));  // Prints  10
        Debug.Log(Mathf.FloorToInt(10.7F));  // Prints  10
        Debug.Log(Mathf.FloorToInt(-10.0F)); // Prints -10
        Debug.Log(Mathf.FloorToInt(-10.2F)); // Prints -11
        Debug.Log(Mathf.FloorToInt(-10.7F)); // Prints -11
    }
    #endregion

    /// <summary>
    /// ���������λ����Ϣ����һ��boolֵ
    /// </summary>
    /// <param name="pos">�����λ����Ϣ</param>
    /// <returns>λ����Ϣ</returns>
    bool CheckVoxel(Vector3 pos)
    {
        int x = Mathf.FloorToInt(pos.x);
        int y = Mathf.FloorToInt(pos.y);
        int z = Mathf.FloorToInt(pos.z);
        if(x<0|| y<0 || z < 0 || x > VoxelData.chunkWidth - 1 || y > VoxelData.chunkHeight - 1 || z > VoxelData.chunkWidth - 1)
        {
            return false;
        }
        return voxelMap[x, y, z];
    }

    /// <summary>
    /// ������ؾ���
    /// </summary>
    void PopulateVoxelMap()
    {
        for (int y = 0; y < VoxelData.chunkWidth; y++)
        {
            for (int x = 0; x < VoxelData.chunkHeight; x++)
            {
                for (int z = 0; z < VoxelData.chunkWidth; z++)
                {
                    voxelMap[y, x, z] = true;
                }
            }
        }
    }


    /// <summary>
    /// ����һ�����ڲ��Ե�5x5����
    /// </summary>
    private void CreateMeshData()
    {
        for (int y = 0; y < VoxelData.chunkWidth; y++)
        {
            for (int x = 0; x < VoxelData.chunkHeight; x++)
            {
                for (int z = 0; z < VoxelData.chunkWidth; z++)
                {
                    AddVoxelDataToChunk(new Vector3(x, y, z));
                }
            }
        }
    }
    /// <summary>
    /// Ϊ������Ӷ�����Ϣ�Լ�λ����Ϣ
    /// </summary>
    /// <param name="pos">�������ɵ�λ��</param>
    void AddVoxelDataToChunk(Vector3 pos)
    {
        
        for (int p = 0; p < 6; p++)
        {
            if (!CheckVoxel(pos + VoxelData.faceCheeks[p]))
            {
                /*for (int i = 0; i < 6; i++)
                {
                    int trangleIndex = VoxelData.voxelTris[p, i];
                    vertices.Add(VoxelData.voxelVerts[trangleIndex] + pos);
                    triangles.Add(vertexIndex);
                    //HACK:�޸�cs32
                    uvs.Add(VoxelData.voxelUvs[i]);
                    vertexIndex++;
                }*/
                    //�ع�
                    for (int y = 0; y < 4; y++)
                    {
                        vertices.Add(pos + VoxelData.voxelVerts[VoxelData.voxelTris[p, y]]);
                    }
                    for (int z = 0; z < 4; z++)
                    {
                        uvs.Add(VoxelData.voxelUvs[z]);
                    }
                    /*uvs.Add(VoxelData.voxelUvs[0]);
                    uvs.Add(VoxelData.voxelUvs[1]);
                    uvs.Add(VoxelData.voxelUvs[2]);
                    uvs.Add(VoxelData.voxelUvs[3]);*/
                    triangles.Add(vertexIndex);
                    triangles.Add(vertexIndex + 1);
                    triangles.Add(vertexIndex + 2);
                    triangles.Add(vertexIndex + 2);
                    triangles.Add(vertexIndex + 1);
                    triangles.Add(vertexIndex + 3);
                    vertexIndex += 4;
            }
            
        }
    }

    /// <summary>
    /// Ϊ���ɵķ�����ɫ
    /// </summary>
    void CreateMesh()
    {
        m_mesh.vertices = vertices.ToArray();
        m_mesh.triangles = triangles.ToArray();
        m_mesh.uv = uvs.ToArray();
        m_mesh.RecalculateNormals();
        m_filter.mesh = m_mesh;
    }

}
