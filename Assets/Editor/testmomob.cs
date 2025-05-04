// Assets/Editor/ExampleEditorScript.cs
using UnityEditor;
using UnityEngine;

public class ExampleEditorScript
{
    [MenuItem("Tools/Hello Editor")]
    public static void Hello()
    {
        Debug.Log("Hello from Editor script!");
    }
}