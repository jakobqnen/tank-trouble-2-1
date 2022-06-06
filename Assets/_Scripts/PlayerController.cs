using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    private float MoveSpeed;
    private float RotateSpeed;
    PhotonView pho_Player;
    Rigidbody2D rb_Player;
    Image img_Player;
    Image img_Turret;
    private BumperControl bump_Front, bump_Back;
    private float HorizontalInput, VerticalInput;

    private int PowerUpIndex; // class later?
    void Start()
    {
        MoveSpeed = PlayerReference.s_PlayerMoveSpeed;
        RotateSpeed = PlayerReference.s_PlayerRotateSpeed;
        pho_Player = GetComponent<PhotonView>();
        rb_Player = GetComponent<Rigidbody2D>();
        img_Player = GetComponent<Image>();
        img_Turret = transform.Find("Turret").GetComponent<Image>();
        bump_Front = transform.Find("Front Bumper").GetComponent<BumperControl>();
        bump_Back = transform.Find("Back Bumper").GetComponent<BumperControl>();

        transform.parent = PlayerReference.s_tf_MainCanvas;
        transform.localScale = Vector2.one;

        print(pho_Player.ControllerActorNr);
        img_Player.color = PlayerReference.s_clr_Players[pho_Player.ControllerActorNr - 1];

        pho_Player.RPC("UpdateTurretColor", RpcTarget.All);
    }
    void Update()
    {
        //PlayerReference.s_txt_InfoOne.text = ;
        //PlayerReference.s_txt_InfoTwo.text = ;
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        VerticalInput = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Jump") && pho_Player.IsMine)
        {
            int newPowerUpIndex = (PowerUpIndex + 1) % PlayerReference.s_spr_Turrets.Length;
            pho_Player.RPC("SetPowerUpTo", RpcTarget.All, newPowerUpIndex);
        }
        if (bump_Front.isOnWall) VerticalInput = Mathf.Min(0, VerticalInput); // Don't move forward when front is on wall
        if (bump_Back.isOnWall) VerticalInput = Mathf.Max(0, VerticalInput); // Don't move backward when back is on wall
    }
    void FixedUpdate()
    {
        if (!pho_Player.IsMine) return;

        float Rotate = -HorizontalInput * RotateSpeed;
        float NewRotation = transform.rotation.eulerAngles.z + Rotate;
        rb_Player.SetRotation(NewRotation);

        float Movement = VerticalInput * MoveSpeed;
        Vector3 MoveVector = transform.up * Movement;
        Vector3 NewPosition = transform.position + MoveVector;
        rb_Player.MovePosition(NewPosition);

        rb_Player.velocity = Vector2.zero;
        rb_Player.angularVelocity = 0;

    }
    [PunRPC]
    void SetPowerUpTo(int index)
    {
        PowerUpIndex = index;
        img_Turret.sprite = PlayerReference.s_spr_Turrets[PowerUpIndex];
    }

    [PunRPC]
    void UpdateTurretColor()
    {
        img_Turret.color = img_Player.color;
    }
}
