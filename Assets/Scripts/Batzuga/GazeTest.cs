using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeTest : MonoBehaviour
{
    private Renderer _renderer;
    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GazeEnter()
    {
        _renderer.material.color = Color.red;
    }

    public void GazeExit()
    {
        _renderer.material.color = Color.green;
    }
}
