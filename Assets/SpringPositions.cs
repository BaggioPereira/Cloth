using UnityEngine;
using System.Collections;

public class SpringPositions : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject plane = GameObject.Find("Plane");
        Mesh mesh = plane.GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        for(int i = 0; i < vertices.Length; i++)
        {
            GameObject newGo = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            newGo.name = "Spring" + i;
            newGo.transform.position = new Vector3(vertices[i].x, vertices[i].y, vertices[i].z);
        }
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
