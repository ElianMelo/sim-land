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
        InventoryAccessoryBoard.OnItemEquipped += OnItemEquipped;
    }

    private void OnDestroy()
    {
        InventoryAccessoryBoard.OnItemEquipped -= OnItemEquipped;
    }

    public void OnItemEquipped(AccessorySO accessorySO)
    {
        foreach (var part in playerBodyPartList)
        {
            if(part.GetBodyPartType() == accessorySO.type)
            {
                part.ChangePlayerBodyPartSO(accessorySO.playerBodyPartSO);
            }
        }
    }

    void Update()
    {
        if (GameManager.Instance.GetGameState() == GameState.Paused) return;

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            InterfaceManager.Instance.OpenInventory();
        }

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
