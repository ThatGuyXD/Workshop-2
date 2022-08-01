using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GenerateCone : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] int numSides;
    void Start()
    {
        // First we'll get the MeshFilter attached to this game object, in the
        // same way that we got the MeshRenderer component last week.
        var meshFilter = GetComponent<MeshFilter>();

        // Now we can create a cube mesh and assign it to the mesh filter.
        meshFilter.mesh = CreateMesh();
    }

    // Update is called once per frame
    private Mesh CreateMesh()
    {

        var mesh = new Mesh
        {
            name = "Pyramid"
        };

        List<Color> colors = new List<Color>();
        Vector3[] vertices = new Vector3[numSides+2];
        vertices[0] = new Vector3(0f, 1f, 0f);
        

        for(int i = 1; i < numSides; i++)
        {
            float angle = (360 / numSides) * Mathf.Deg2Rad;
            vertices[i] = new Vector3(Mathf.Cos(angle), -1f, Mathf.Sin(angle));
        }
            

        mesh.SetVertices(vertices);


        mesh.SetColors(colors);

        int[] indices = new int[numSides];
        
        mesh.SetIndices(indices, MeshTopology.Triangles, 0);

        return mesh;
    }
}
