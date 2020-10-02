using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Distance_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start(){
      GameObject point_cloud = GameObject.Find("point_cloud");
      GameObject point_cloud_data = point_cloud.transform.Find("default").gameObject;
      Mesh point_cloud_mesh = point_cloud_data.GetComponent<MeshFilter>().mesh;
      point_cloud_mesh.SetIndices(point_cloud_mesh.GetIndices(0),MeshTopology.Points,0);
      // GameObject master = GameObject.Find("master_data");
      // GameObject master_data = master.transform.Find("default").gameObject;
      // Mesh master_data_mesh = master_data.GetComponent<MeshFilter>().mesh;
      // master_data_mesh.SetIndices(master_data_mesh.GetIndices(0),MeshTopology.Points,0);
      Dis_Manager();

    }
    public void Dis_Manager()
    {
        GameObject point_cloud = GameObject.Find("point_cloud");
        GameObject point_cloud_data = point_cloud.transform.Find("default").gameObject;
        GameObject master = GameObject.Find("master_data");
        GameObject master_data = master.transform.Find("default").gameObject;
        Mesh point_cloud_mesh = point_cloud_data.GetComponent<MeshFilter>().mesh;
        Mesh master_data_mesh = master_data.GetComponent<MeshFilter>().mesh;
        master_data_mesh.SetIndices(master_data_mesh.GetIndices(0),MeshTopology.Triangles,0);
        point_cloud_mesh.SetIndices(point_cloud_mesh.GetIndices(0),MeshTopology.Triangles,0);
        point_cloud_data.AddComponent<MeshCollider>();
        master_data.AddComponent<MeshCollider>();
        MeshCollider point_cloud_col = point_cloud_data.GetComponent<MeshCollider>();
        MeshCollider master_data_col = master_data.GetComponent<MeshCollider>();
        point_cloud_col.convex = true;
        master_data_col.convex = true;

        Matrix4x4 master_data_matrix = master_data.transform.localToWorldMatrix;
        Vector3[] master_data_vertices = master_data_mesh.vertices;
        List<float> master_dis_save = new List<float>();
        float Max_dis = -10000;
        foreach(Vector3 vertex in master_data_vertices){
          Vector3 vec = master_data_matrix.MultiplyPoint3x4(vertex);
          float dis = Vector3.Distance(vec,point_cloud_col.ClosestPoint(vec));
          // Debug.Log(vec + " " + point_cloud_col.ClosestPoint(vec) + " " + dis);
          master_dis_save.Add(dis);
          if(dis > Max_dis){
            Max_dis = dis;
          }
        }
        Color[] master_mesh_colors = new Color[master_data_vertices.Length];
        for(int i = 0;i < master_mesh_colors.Length;i++){
          if(master_dis_save[i] == 0f){
            master_mesh_colors[i] = new Color(1.0f,0.0f,0.0f,0.0f);
          }
          else{
            master_mesh_colors[i] = new Color(0.0f, 1.0f * (1.0f - master_dis_save[i] / Max_dis), 1.0f * (master_dis_save[i] / Max_dis), 0.5f);
          }

        }
        master_data_mesh.colors = master_mesh_colors;
        master_data_mesh.SetIndices(master_data_mesh.GetIndices(0),MeshTopology.Points,0);
        point_cloud.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
