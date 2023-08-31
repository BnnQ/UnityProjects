using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public abstract class ChestBase : MonoBehaviour
{
    public Transform CoinSpawnPoint;
    public int NumberOfCoinsInside = 1;
    public Animator Animator;

    [Header("Coin Settings")]
    public AnimatorController CoinAnimatorController;
    public Sprite CoinSprite;

    protected bool IsChestOpened = false;
    protected void OpenChest()
    {
        IsChestOpened = true;
        Animator.SetBool(nameof(IsChestOpened), IsChestOpened);
        
        for (var i = 1; i <= NumberOfCoinsInside; i++)
        {
            var coin = new GameObject($"ChestCoin{i}");
            var spriteRenderer = coin.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = CoinSprite;
            spriteRenderer.sortingOrder = 2;

            var animator = coin.AddComponent<Animator>();
            animator.runtimeAnimatorController = CoinAnimatorController;

            var boxCollider = coin.AddComponent<BoxCollider2D>();
            boxCollider.isTrigger = true;
            boxCollider.size = new Vector2(1, 1);
            boxCollider.offset = Vector2.zero;
            
            coin.transform.position = CoinSpawnPoint.position;
            coin.tag = "Coin";
            coin.SetActive(true);
        }
    }
    
}
