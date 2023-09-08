using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class ProjectileFactory
{
    private Sprite projectileSprite;
    private ProjectileFactory(Sprite projectileSprite)
    {
        this.projectileSprite = projectileSprite;
    }
    
    public static ProjectileFactory GetFactory(Sprite projectileSprite)
    {
        return new ProjectileFactory(projectileSprite);
    }
    
    public GameObject SpawnProjectile(Vector3 position, Vector2 direction)
    {
        var projectile = new GameObject($"Projectile{Guid.NewGuid()}");
        
        var spriteRenderer = projectile.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = projectileSprite;
        spriteRenderer.sortingOrder = 2;

        var circleCollider = projectile.AddComponent<CircleCollider2D>();
        circleCollider.isTrigger = true;
        circleCollider.offset = Vector2.zero;
        
        var rigidBody = projectile.AddComponent<Rigidbody2D>();
        rigidBody.bodyType = RigidbodyType2D.Kinematic;
        rigidBody.velocity = direction;
        
        projectile.transform.position = position;
        projectile.tag = "DeadZone";
        projectile.SetActive(true);
        return projectile;
    }
    
}
