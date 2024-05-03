using System.Collections.Generic;
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
                part.ChangeAccessorySO(accessorySO);
                part.ForceLastAnimation();
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
        if (Mathf.Abs(xInput) == 1 && Mathf.Abs(yInput) == 1) { playerRb.velocity = Vector2.zero; return; };
        playerRb.velocity = new Vector2(xInput, yInput).normalized * speed;
    }
}

