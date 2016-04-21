 // C#
 // SplitMeshIntoTriangles.cs
 using UnityEngine;
 using System.Collections;

 public class CuttingMesh : MonoBehaviour
 {
     void Start()
     {
         Mesh mesh = gameObject.GetComponent<MeshFilter>().mesh;
         MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
         splitMesh(mesh, meshRenderer);
         Destroy(gameObject);
     }

     void splitMesh(Mesh msh, MeshRenderer mshRen)
     {
         for (int i = 0; i < msh.subMeshCount; i++)
         {
             int[] indices = msh.GetTriangles(i);
             for (int j = 0; j < indices.Length; j += 3)
             {
                 Vector3[] newVerts = new Vector3[3];
                 Vector3[] newNormals = new Vector3[3];
                 Vector2[] newUvs = new Vector2[3];
                 for (int k =0; k<3 ; k++)
                 {
                     int index = indices[j + k];
                     newVerts[k] = msh.vertices[index];
                     newUvs[k] = msh.uv[index];
                     newNormals[k] = msh.normals[index];
                 }
                 Mesh mesh = new Mesh();
                 mesh.vertices = newVerts;
                 mesh.normals = newNormals;
                 mesh.uv = newUvs;

                 mesh.triangles = new int[] { 0, 1, 2, 2, 1, 0 };
                 GameObject newGO = new GameObject("Triangle " + (j / 3));
                 newGO.transform.position = transform.position;
                 newGO.transform.rotation = transform.rotation;
                 newGO.AddComponent<MeshRenderer>().material = mshRen.materials[i];
                 newGO.AddComponent<MeshFilter>().mesh = mesh;
                 newGO.AddComponent<BoxCollider>();
             }
         }
     }
 }