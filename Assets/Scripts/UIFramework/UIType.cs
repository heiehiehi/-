using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIType : MonoBehaviour
{
    public string Name { get; private set; }
    public string Path { get; private set; }
    // Start is called before the first frame update
    public UIType(string path)
    {
        Path = path;
        Name = path.Substring(path.LastIndexOf('/') + 1);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
