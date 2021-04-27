using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyweightCapsuleSpawner : MonoBehaviour
{
    public GameObject capsulePrefab;
    public ObjectData[] dataArr;

    // Start is called before the first frame update
    void Start()
    {
        for (int x = 0; x < 100; x+=2)
        {
            for (int y = 0; y < 100; y+=2)
            {
                var variant = Random.Range(0, 4);
                var shaderMat = dataArr[variant].shaderMat;
                var capsule = Instantiate(capsulePrefab);
                var renderer = capsule.GetComponent<Renderer>();
                renderer.material = shaderMat;
                capsule.transform.position = new Vector3(x, y, 0);
                capsule.GetComponent<FlyweightCapsuleProperties>().data = dataArr[variant];
            }
        }
    }

}
