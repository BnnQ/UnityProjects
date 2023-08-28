using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundaries : MonoBehaviour
{
    public Camera cam;
    public float thickness = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
// Create top collider
        GameObject top = new GameObject("Top");
        top.transform.parent = transform;
        BoxCollider2D topCollider = top.AddComponent<BoxCollider2D>();
        topCollider.size = new Vector2(cam.aspect * 2f * cam.orthographicSize + thickness * 2f, thickness);
        top.transform.position = new Vector3(0f, cam.orthographicSize + thickness / 2f, 0f);

        // Create bottom collider
        GameObject bottom = new GameObject("Bottom");
        bottom.transform.parent = transform;
        BoxCollider2D bottomCollider = bottom.AddComponent<BoxCollider2D>();
        bottomCollider.size = new Vector2(cam.aspect * 2f * cam.orthographicSize + thickness * 2f, thickness);
        bottom.transform.position = new Vector3(0f, -cam.orthographicSize - thickness / 2f, 0f);

        // Create left collider
        GameObject left = new GameObject("Left");
        left.transform.parent = transform;
        BoxCollider2D leftCollider = left.AddComponent<BoxCollider2D>();
        leftCollider.size = new Vector2(thickness, cam.orthographicSize * 2f + thickness * 2f);
        left.transform.position = new Vector3(-cam.aspect * cam.orthographicSize - thickness / 2f, 0f, 0f);

        // Create right collider
        GameObject right = new GameObject("Right");
        right.transform.parent = transform;
        BoxCollider2D rightCollider = right.AddComponent<BoxCollider2D>();
        rightCollider.size = new Vector2(thickness, cam.orthographicSize * 2f + thickness * 2f);
        right.transform.position = new Vector3(cam.aspect * cam.orthographicSize + thickness / 2f, 0f, 0f);
    } 

    // Update is called once per frame
    void Update()
    {
        
    }
}
