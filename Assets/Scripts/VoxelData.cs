using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ��̬������ڴ��淽�鶥����Ϣ
/// </summary>
public static class VoxelData
{
    public static readonly int chunkWidth = 15;
    public static readonly int chunkHeight = 15;


    //�����ε������Ҫ��˳ʱ����ܱ�֤�ⲿ�ɼ��������ʱ����Ϊ�ڲ��ɼ�
    /// <summary>
    /// ������Ϣ
    /// </summary>
    public static readonly Vector3[] voxelVerts = new Vector3[8]
    {
        new Vector3(0.0f,0.0f,0.0f),
        new Vector3(1.0f,0.0f,0.0f),
        new Vector3(1.0f,1.0f,0.0f),
        new Vector3(0.0f,1.0f,0.0f),
        new Vector3(0.0f,0.0f,1.0f),
        new Vector3(1.0f,0.0f,1.0f),
        new Vector3(1.0f,1.0f,1.0f),
        new Vector3(0.0f,1.0f,1.0f),
    };

    public static readonly Vector3[] faceCheeks = new Vector3[6]
    {
        new Vector3 (0.0f,0.0f,-1.0f),
        new Vector3 (0.0f,0.0f,1.0f),
        new Vector3 (0.0f,1.0f,0.0f),
        new Vector3 (0.0f,-1.0f,0.0f),
        new Vector3 (-1.0f,0.0f,0.0f),
        new Vector3 (1.0f,0.0f,0.0f),
    };


    /// <summary>
    /// ���ݶ�����Ϣ��ɵ������ε����򶥵�
    /// </summary>
    public static readonly int[,] voxelTris = new int[6, 4]
    {
        //�Լ�д���
        /*{3,7,2,2,7,6 },     //top
        {0,4,1,1,4,5 },     //bottom
        { 0,3,1,1,3,2},     //front
        {7,4,6,6,4,5 },     //back
        {4,7,0,0,7,3 },     //left
        {2,6,1,1,6,5 }      //right*/
        //�����Ż�����ÿ����Ķ���
        /*{0,3,1,1,3,2 },//back
        {5,6,4,4,6,7 },//front
        {3,7,2,2,7,6 },//top
        {1,5,0,0,5,4 },//bottom
        {4,7,0,0,7,3 },//left
        {1,2,5,5,2,6 }//right*/

        {0,3,1,2 },//back
        {5,6,4,7 },//front
        {3,7,2,6 },//top
        {1,5,0,4 },//bottom
        {4,7,0,3 },//left
        {1,2,5,6 }//right
    };
    public static readonly Vector2[] voxelUvs = new Vector2[4]
    {
        new Vector2(0.0f,0.0f),
        new Vector2(0.0f,1.0f),
        new Vector2(1.0f,0.0f),
        //�Ż�
        /*new Vector2(1.0f,0.0f),
        new Vector2(0.0f,1.0f),*/
        new Vector2(1.0f,1.0f)
    };

}