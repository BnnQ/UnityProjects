using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor.Animations;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Sprite ProjectileSprite;
    public int ProjectileDirection;
    public float ProjectileSpeed = 1f;
    public int ShootingRate = 3;

    private ProjectileFactory projectileFactory;
    private Vector2 projectileSpeed;

    // Start is called before the first frame update
    void Start()
    {
        projectileFactory = ProjectileFactory.GetFactory(ProjectileSprite);
        projectileSpeed = Vector2.one;
        projectileSpeed.x *= ProjectileSpeed;
        
        InvokeRepeating(nameof(ShootProjectile), 0, ShootingRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [CanBeNull] private GameObject previousProjectile;
    void ShootProjectile()
    {
        if (previousProjectile is not null)
            Destroy(previousProjectile);
        
        previousProjectile = projectileFactory.SpawnProjectile(transform.position, (ProjectileDirection == -1 ? Vector2.left : Vector2.right) * projectileSpeed);
    }
    
}
