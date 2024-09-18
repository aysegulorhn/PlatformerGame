using System;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    Rigidbody2D body2D;

    [Tooltip("Karakterin ne kadar hızlı gideceğini belirler.")]
    [Range(0, 20)]
    public float playerSpeed;

    [Tooltip("Karakterin ne kadar yükseğe zıplayacağını belirler.")]
    [Range(0, 5)]
    public float jumpHeight = 3f;

    [Tooltip("Zıplama süresi")]
    public float jumpDuration = 0.5f;

    internal bool canDoubleJump;

    bool facingRight = true;

    [Tooltip("Karakterin yere değip değmediğini kontrol eder.")]
    public bool isGrounded = false;

    [Tooltip("Yerin ne olduğunu belirler")]
    public LayerMask groundLayer;

    void Start()
    {
        body2D = GetComponent<Rigidbody2D>();
        body2D.gravityScale = 5;
        body2D.freezeRotation = true;
    }

    void FixedUpdate()
    {
        // Hareket etme
        float h = Input.GetAxis("Horizontal");
        body2D.velocity = new Vector2(h * playerSpeed, body2D.velocity.y);

        Flip(h);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            // Zıplama hareketini DoTween ile yap
            transform.DOMoveY(transform.position.y + jumpHeight, jumpDuration)
                .OnComplete(() => isGrounded = false); // Zıplama tamamlandığında isGrounded'ı false yap
            canDoubleJump = true;
            Debug.Log("Jump Function Called");
        }
    }

    public void DoubleJump()
    {
        if (canDoubleJump)
        {
            transform.DOMoveY(transform.position.y + jumpHeight, jumpDuration)
                .OnComplete(() => canDoubleJump = false);
            Debug.Log("Double Jump Function Called");
        }
    }

    void Flip(float h)
    {
        if (h > 0 && !facingRight || h < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector2 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            isGrounded = true;
            Debug.Log("Grounded");
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            isGrounded = false;
            Debug.Log("Not Grounded");
        }
    }
}
