using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveRnD : MonoBehaviour
{
    private MeshFilter meshFilter;

    private void Awake()
    {
        TryGetComponent(out meshFilter);
    }

    private void Update()
    {
        Vector3[] vertices = meshFilter.mesh.vertices;
        for (int i = 0; i < vertices.Length; ++i)
        {
            vertices[i].y = WaveManager.Instance.GetWaveHeight(transform.position.x + vertices[i].x + vertices[i].z);
        }

        meshFilter.mesh.vertices = vertices;
        meshFilter.mesh.RecalculateNormals();
    }
}
