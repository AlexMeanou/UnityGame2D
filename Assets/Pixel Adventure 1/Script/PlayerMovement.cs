using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask jumpableGround;
    private SpriteRenderer sprite;
    public bool isOver = false;
    public event EventHandler GameOverEvent;

    public Transform KeyBox;

    public Key followingKey;

    private enum MovementState { idle, running, falling, jumping }

    [SerializeField] private AudioSource jumpSoundEffect;

    [SerializeField] private GameObject overScreen;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        this.overScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded()) {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationState();

        if (isOver)
        {
            this.overScreen.SetActive(true);
            // onGameOver();
        }
    }

    private void UpdateAnimationState() {

        MovementState state;

        if (dirX > 0f ){
            state = MovementState.running;
            sprite.flipX = false;
        } else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f) {
            state = MovementState.jumping;
        } else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded() {

        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);

    }

    private void onGameOver() {
        if (GameOverEvent != null)
        {
            GameOverEvent(this, EventArgs.Empty);
        }
    }

}
