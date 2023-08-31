using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OnGroundWatcher : MonoBehaviour
{
    [Header("Ground Watcher Settings")]
    public LayerMask GroundLayer;

    public Transform BottomObjectPoint;
    public float CheckRadius = 1f;

    [Header("Animation Settings")] public Animator Animator;
    public bool IsGrounded;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var colliders = Physics2D.OverlapCircleAll(BottomObjectPoint.position, CheckRadius, GroundLayer);
        IsGrounded = colliders.Any();
        Animator.SetBool(nameof(IsGrounded), IsGrounded);
    }
    
}
