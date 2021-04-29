using UnityEngine;
using UnityEditor;
using System.IO;

[CustomEditor (typeof(AsteroidSpawner))]
public class AsteroidSpawnerEditor : Editor
{
    string path;
    string assetpath;
    string filename;

    void OnEnable()
    {
        path = Application.dataPath + "/Asteroid";
        assetpath = "Assets/Asteroid/";
        filename = "asteroid_" + System.DateTime.Now.Ticks.ToString();
    }

    public override void OnInspectorGUI()
    {
        AsteroidSpawner astSpawner = (AsteroidSpawner) target;
        DrawDefaultInspector();

        if (GUILayout.Button("Create Asteroid"))
        {
            if (astSpawner.asteroid != null)
            {
                DestroyImmediate(ProcAsteroid.asteroid);
                DestroyImmediate(astSpawner.asteroid);
            }

            astSpawner.CreateAsteroid();
        }

        if (astSpawner.asteroid && GUILayout.Button("Save Asteroid"))
        {
            System.IO.Directory.CreateDirectory(path);
            Mesh mesh = astSpawner.asteroid.GetComponent<MeshFilter>().sharedMesh;
            AssetDatabase.CreateAsset(mesh, assetpath + mesh.name + ".asset");
            AssetDatabase.SaveAssets();

            PrefabUtility.SaveAsPrefabAsset(astSpawner.asteroid, assetpath + filename + ".prefab");

            DestroyImmediate(ProcAsteroid.asteroid);
            DestroyImmediate(astSpawner.asteroid);
        }
    }
}
