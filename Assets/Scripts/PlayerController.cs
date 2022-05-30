using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float MoveSpeed;

    [SerializeField]
    float RotateSpeed;
    PhotonView photonView;
    Rigidbody2D rb_player;
    [SerializeField]
    private BumperControl bump_front, bump_back;
    float HorizontalInput, VerticalInput;

    void Start()
    {
        photonView = GetComponent<PhotonView>();
        rb_player = GetComponent<Rigidbody2D>();
        transform.parent = PlayerManager.s_tf_MainCanvas;
        transform.localScale = Vector2.one;
    }
    void Update()
    {
        PlayerManager.s_txt_InfoOne.text = transform.localScale.x.ToString() + " " + transform.localScale.y.ToString();
        PlayerManager.s_txt_InfoTwo.text = GetComponent<RectTransform>().sizeDelta.x.ToString() + " " + GetComponent<RectTransform>().sizeDelta.y.ToString();
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
