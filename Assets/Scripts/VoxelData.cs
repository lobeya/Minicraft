using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 静态类仅用于储存方块顶点信息
/// </summary>
public static class VoxelData
{
    public static readonly int chunkWidth = 15;
    public static readonly int chunkHeight = 15;


    //三角形的添加需要是顺时针才能保证外部可见如果是逆时针则为内部可见
    /// <summary>
    /// 顶点信息
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
    /// 根据顶点信息组成的三角形的有序顶点
    /// </summary>
    public static readonly int[,] voxelTris = new int[6, 4]
    {
        //自己写错的
        /*{3,7,2,2,7,6 },     //top
        {0,4,1,1,4,5 },     //bottom
        { 0,3,1,1,3,2},     //front
        {7,4,6,6,4,5 },     //back
        {4,7,0,0,7,3 },     //left
        {2,6,1,1,6,5 }      //right*/
        //程序优化减少每个面的顶点
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
        //优化
        /*new Vector2(1.0f,0.0f),
        new Vector2(0.0f,1.0f),*/
        new Vector2(1.0f,1.0f)
    };

}