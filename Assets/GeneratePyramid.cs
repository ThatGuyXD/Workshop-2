using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class GeneratePyramid : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // First we'll get the MeshFilter attached to this game object, in the
        // same way that we got the MeshRenderer component last week.
        var meshFilter = GetComponent<MeshFilter>();

        // Now we can create a cube mesh and assign it to the mesh filter.
        meshFilter.mesh = CreateMesh();
    }

    private Mesh CreateMesh()
    {
        // Step 0: Create the mesh object. This contains various data structures
        // that allow us to define complex 3D objects. Recommended reading:
        // - https://docs.unity3d.com/ScriptReference/Mesh.html
        var mesh = new Mesh
        {
            name = "Pyramid"
        };

        // Step 1: Define the vertices. These are "points" in 3D space that
        // allow us to construct 3D geometry. For everyone's sanity, we have
        // ordered them such that consecutive chunks of three vertices represent
        // individual triangles. This does not have to be the case though, and
        // depends on the way the mesh surface itself is defined (step 3).
        mesh.SetVertices(new[]
        {
            // Front triangle
            new Vector3(0f,1f,0f), new Vector3(-1f,-1f,1f), new Vector3(1f,-1f,1f),
            // Right triange
            new Vector3(0f,1f,0f), new Vector3(1f,-1f,1f), new Vector3(1f,-1f,-1f),
            // Back triangle
            new Vector3(0f,1f,0f), new Vector3(1f,-1f,-1f), new Vector3(-1f,-1f,-1f),
            // Left triangle
            new Vector3(0f,1f,0f), new Vector3(-1f,-1f,-1f), new Vector3(-1f,-1f,1f),
            // Bottom
            new Vector3(-1f,-1f,-1f), new Vector3(1f,-1f,1f), new Vector3(-1f,-1f,1f),

            new Vector3(-1f,-1f,-1f), new Vector3(1f,-1f,-1f), new Vector3(1f,-1f,1f),
        });

        // Step 2: Define the vertex colours. There is a one-to-one index
        // mapping between the vertices defined above and these colours below,
        // so the length of both arrays must be the same.
        mesh.SetColors(new[]
        {
            // Front triangle
            Color.red,Color.red,Color.red,
            // Right triangle
            Color.blue,Color.blue,Color.blue,
            // Back triangle
            Color.green,Color.green,Color.green,
            // Left triangle
            Color.yellow,Color.yellow,Color.yellow,
            // Bottom
            Color.grey,Color.grey,Color.grey,
            Color.grey,Color.grey,Color.grey,
        });

        // Step 3: Define the indices. The indices "connect" vertices together
        // in order to define the triangles that represent the mesh surface.
        // The indices are simply an integer array whereby consecutive chunks
        // of 3 integers represent individual triangles as index mappings. For
        // example: [2, 3, 9] defines a single triangle composed of the points
        // vertices[2], vertices[3], vertices[9] (and the respective colours).
        //
        // Luckily for us this is easy to automate because we already ordered
        // the above vertex and colour arrays just like this! We only need to
        // generate a range of integers from 0 to the # of vertices - 1:
        var indices = Enumerable.Range(0, mesh.vertices.Length).ToArray();
        mesh.SetIndices(indices, MeshTopology.Triangles, 0);

        // Note that the topology argument specifies that we are in fact
        // defining *triangles* in our indices array. It is also possible to
        // define the mesh surface using quads (MeshTopology.Quads).

        return mesh;
    }
}
