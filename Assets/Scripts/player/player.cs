using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class player : MonoBehaviour
{
    //Rigidbody2D
    Rigidbody2D body2D;
    //Bu var'lar karakterin h�z�n� ve z�plamas�n� belirler
    [Tooltip("Karakterin ne kadar h�zl� gidece�ini belirler.")]
    [Range(0, 20)]
    public float playerSpeed;
    
    //Z�plama
    [Tooltip("Karakterin ne kadar y�kse�e z�playaca��n� belirler.")]
    [Range(0, 1500)]
    public float jumpPower;

    [Tooltip("Karakterin 2. z�plamada ne kadar y�kse�e z�playaca��n� belirler.")]
    [Range(0, 30)]
    public float doubleJumpPower;
   internal bool canDoubleJump;

    //Karakteri d�nd�rme
    bool facingRight = true;

    //Yeri bulma
    [Tooltip("Karakterin yere de�ip de�medi�ini kontrol eder.")]
    public bool isGrounded = true;
    Transform groundCheck;
    const float GrounCheckRadius = 0.2f;
    [Tooltip("Yerin ne oldu�unu belirler")]
    public LayerMask groundLayer;

    void Start()
    {
        body2D = GetComponent<Rigidbody2D>();
        body2D.gravityScale = 5;
        body2D.freezeRotation = true;
        body2D.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        //Grouncheki bulma
        groundCheck = transform.Find("GroundCheck");
    }
    


    // Framerateden ba��ms�z olarak �al���r.Fizik ile ilgili kodlar� buraya yaz�n�z.
    void FixedUpdate()
    { 
        //Yere de�iyor muyuz diye kontrol eder
        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, GrounCheckRadius, groundLayer);
        //Haraket etme
        float h = Input.GetAxis("Horizontal");
        body2D.velocity = new Vector2(h * playerSpeed, body2D.velocity.y);

        Flip(h);
    }
   public void Jump()
    {
        //Rigidbody ye dikey y�nde  g�� ekle
        body2D.AddForce(new Vector2(0, jumpPower));
        Console.WriteLine("Jump Function");

    } 
    public void DoubleJump()
    {
        //Rigidbody ye dikey y�nde ani bir g�� ekle
        body2D.AddForce(new Vector2(0, doubleJumpPower),ForceMode2D.Impulse);
        Console.WriteLine("Double Jump Function");
    }
    void Flip(float h)
    {
        if(h>0 && !facingRight || h<0 && facingRight)
        {
            facingRight = !facingRight;
            Vector2 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }


}
