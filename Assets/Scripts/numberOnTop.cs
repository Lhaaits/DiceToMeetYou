using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class numberOnTop : MonoBehaviour
{
    public int topNumber;

    public int bottomNumber;

    // Update is called once per frame
    void Update()
    {
        Transform[] children = GetComponentsInChildren<Transform>();
        var transforms = children.ToList();
        transforms.Remove(this.transform);
        transforms.Sort((transform1, transform2) => (int)Math.Round(transform2.position.y - transform1.position.y));
        var topName = transforms[0].name;
        var bottomName = transforms[transforms.Count - 1].name;
        topNumber = Int32.Parse(topName.Substring(topName.Length - 1, 1));
        bottomNumber = Int32.Parse(topName.Substring(bottomName.Length - 1, 1));
    }
}