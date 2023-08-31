using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundaries : MonoBehaviour
{
    public Camera Camera;
    public float Thickness = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        // Create top collider
        var top = new GameObject("Top");
        top.transform.parent = transform;
        var topCollider = top.AddComponent<BoxCollider2D>();
        topCollider.size = new Vector2(Camera.aspect * 2f * Camera.orthographicSize + Thickness * 2f, Thickness);
        top.transform.position = new Vector3(0f, Camera.orthographicSize + Thickness / 2f, 0f);

        // Create bottom collider
        var bottom = new GameObject("Bottom");
        bottom.transform.parent = transform;
        var bottomCollider = bottom.AddComponent<BoxCollider2D>();
        bottomCollider.size = new Vector2(Camera.aspect * 2f * Camera.orthographicSize + Thickness * 2f, Thickness);
        bottom.transform.position = new Vector3(0f, -Camera.orthographicSize - Thickness / 2f, 0f);

        // Create left collider
        var left = new GameObject("Left");
        left.transform.parent = transform;
        var leftCollider = left.AddComponent<BoxCollider2D>();
        leftCollider.size = new Vector2(Thickness, Camera.orthographicSize * 2f + Thickness * 2f);
        left.transform.position = new Vector3(-Camera.aspect * Camera.orthographicSize - Thickness / 2f, 0f, 0f);

        // Create right collider
        var right = new GameObject("Right");
        right.transform.parent = transform;
        var rightCollider = right.AddComponent<BoxCollider2D>();
        rightCollider.size = new Vector2(Thickness, Camera.orthographicSize * 2f + Thickness * 2f);
        right.transform.position = new Vector3(Camera.aspect * Camera.orthographicSize + Thickness / 2f, 0f, 0f);
    } 
    
}
