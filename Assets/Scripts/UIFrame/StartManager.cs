using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManager : MonoBehaviour
{
    PanlManager panlManager;
    private void Awake()
    {
        panlManager = new PanlManager();
    }
    // Start is called before the first frame update
    void Start()
    {
        panlManager.Push(new StartPanel());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
