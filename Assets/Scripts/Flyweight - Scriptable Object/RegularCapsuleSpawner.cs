using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularCapsuleSpawner : MonoBehaviour
{
    public GameObject[] capsulePrefabs;
    public string[] names;
    public string[] prop1;
    public string[] prop2;
    public string[] prop3;
    public string[] prop4;
    public string[] prop5;
    public string[] prop6;

    // Start is called before the first frame update
    void Start()
    {
        for (int x = 0; x < 100; x+=2)
        {
            for (int y = 0; y < 100; y+=2)
            {
                var variant = Random.Range(0, 4);
                var capsule = Instantiate(capsulePrefabs[variant]);
                var capsuleProperties = capsule.GetComponent<CapsuleProperties>();

                capsuleProperties.name = names[variant];
                capsuleProperties.prop1 = prop1[variant];
                capsuleProperties.prop2 = prop2[variant];
                capsuleProperties.prop3 = prop3[variant];
                capsuleProperties.prop4 = prop4[variant];
                capsuleProperties.prop5 = prop5[variant];
                capsuleProperties.prop6 = prop6[variant];

                capsule.transform.position = new Vector3(x, y, 0);
            }
        }
    }

}
