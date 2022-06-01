using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
public class PlayerController : MonoBehaviour
{
    private float MoveSpeed;
    private float RotateSpeed;
    PhotonView photonView;
    Rigidbody2D rb_player;
    private BumperControl bump_front, bump_back;
    private float HorizontalInput, VerticalInput;

    void Start()
    {
        MoveSpeed = PlayerReference.s_PlayerMoveSpeed;
        RotateSpeed = PlayerReference.s_PlayerRotateSpeed;
        photonView = GetComponent<PhotonView>();
        rb_player = GetComponent<Rigidbody2D>();
        bump_front = transform.Find("Front Bumper").GetComponent<BumperControl>();
        bump_back = transform.Find("Back Bumper").GetComponent<BumperControl>();

        transform.parent = PlayerReference.s_tf_MainCanvas;
        transform.localScale = Vector2.one;
    }
    void Update()
    {
        PlayerReference.s_txt_InfoOne.text = transform.localScale.x.ToString() + " " + transform.localScale.y.ToString();
        PlayerReference.s_txt_InfoTwo.text = GetComponent<RectTransform>().sizeDelta.x.ToString() + " " + GetComponent<RectTransform>().sizeDelta.y.ToString();
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        VerticalInput = Input.GetAxisRaw("Vertical");
        if (bump_front.isOnWall) VerticalInput = Mathf.Min(0, VerticalInput);
        if (bump_back.isOnWall) VerticalInput = Mathf.Max(0, VerticalInput);
    }
    void FixedUpdate()
    {
        if (!photonView.IsMine) return;

        float Rotate = -HorizontalInput * RotateSpeed;
        float NewRotation = transform.rotation.eulerAngles.z + Rotate;
        rb_player.SetRotation(NewRotation);

        float Movement = VerticalInput * MoveSpeed;
        Vector3 MoveVector = transform.up * Movement;
        Vector3 NewPosition = transform.position + MoveVector;
        rb_player.MovePosition(NewPosition);

        rb_player.velocity = Vector2.zero;
        rb_player.angularVelocity = 0;

    }
}
