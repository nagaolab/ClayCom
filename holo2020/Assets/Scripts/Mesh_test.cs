using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;

public class Mesh_test : MonoBehaviour
{
    // Start is called before the first frame update
    public Material material;
    Mesh mesh;
    void Start()
    {
      List<string[]> obj_str_save = new List<string[]>();
      StreamReader sr = new StreamReader(@"C:\Users\nagao\Desktop\bunny_point_only.obj", Encoding.GetEncoding("Shift_JIS"));

      // string str = sr.ReadToEnd();
      while (sr.Peek() != -1)
            {
              String[] arr = sr.ReadLine().Split(' ');
              String[] save = new String[3];
              if(arr[0] == "v"){
                  save[0] = arr[1];
                  save[1] = arr[2];
                  save[2] = arr[3];
                  obj_str_save.Add(save);
              }
            }

        sr.Close();
        Vector3[] Enpty_vertices = new Vector3[obj_str_save.Count];
        int[] indices = new int[Enpty_vertices.Length];
        for(int i = 0;i < obj_str_save.Count;i++){
            Enpty_vertices[i] = new Vector3(Convert.ToSingle(obj_str_save[i][0]),Convert.ToSingle(obj_str_save[i][1]),Convert.ToSingle(obj_str_save[i][2]));
            indices[i] = i;
        }
        mesh = new Mesh();
        mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
        GameObject Enpty = this.transform.gameObject;
        Enpty.AddComponent<MeshFilter>();
        MeshRenderer Enpty_mesh_renderer = Enpty.AddComponent<MeshRenderer>();
        // MeshCollider Enpty_Mesh_col = Enpty.AddComponent<MeshCollider>();
        // Enpty_Mesh_col.convex = true;
        Color32[] colors = new Color32[Enpty_vertices.Length];
        mesh.Clear();
        mesh.vertices = Enpty_vertices;
        mesh.colors32 = colors;
        mesh.SetIndices(indices, MeshTopology.Points, 0);
        Enpty_mesh_renderer.material = material;
        Enpty.GetComponent<MeshFilter>().mesh = mesh;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
