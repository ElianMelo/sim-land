using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float xInput;
    private float yInput;

    [SerializeField]
    private float speed;
    [SerializeField]
    private List<PlayerBodyPart> playerBodyPartList;

    private Rigidbody2D playerRb;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (GameManager.Instance.GetGameState() == GameState.Paused) return;

        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        foreach (var part in playerBodyPartList)
        {
            part.ChangeAnimation(xInput, yInput);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        playerRb.velocity = new Vector2(xInput, yInput).normalized * speed;
    }
}
