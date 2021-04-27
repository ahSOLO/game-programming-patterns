using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "objData", menuName = "Object Data", order = 51)]
public class ObjectData : ScriptableObject
{
    public Material shaderMat;
    [SerializeField] private string name;
    [SerializeField] private string prop1;
    [SerializeField] private string prop2;
    [SerializeField] private string prop3;
    [SerializeField] private string prop4;
    [SerializeField] private string prop5;
    [SerializeField] private string prop6;
}
