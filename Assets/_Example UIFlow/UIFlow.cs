//Written with ♥ by Ankit Priyarup
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFlow : MonoBehaviour
{
    public string ID;

    public void CreateChild(string name)
    {
        GameObject gb = new GameObject(name);
        gb.transform.parent = transform;
    }

    public void ClearChilds()
    {
        while (transform.childCount != 0)
        {
            foreach (Transform c in transform)
                DestroyImmediate(c.gameObject);
        }
    }
}