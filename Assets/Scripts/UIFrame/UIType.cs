using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIType
{
    private string path;
    private string name;
    public string Name { get => name; }
    public string Path { get => path; }
    // Start is called before the first frame update
    public UIType(string ui_path,string ui_name)
    {
        path = ui_path;
        name = ui_name;
    }
}
