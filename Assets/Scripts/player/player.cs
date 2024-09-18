using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class player : MonoBehaviour
{
    //Rigidbody2D
    Rigidbody2D body2D;
    //Bu var'lar karakterin hýzýný ve zýplamasýný belirler
    [Tooltip("Karakterin ne kadar hýzlý gideceðini belirler.")]
    [Range(0, 20)]
    public float playerSpeed;
    
    //Zýplama
    [Tooltip("Karakterin ne kadar yükseðe zýplayacaðýný belirler.")]
    [Range(0, 1500)]
    public float jumpPower;

    [Tooltip("Karakterin 2. zýplamada ne kadar yükseðe zýplayacaðýný belirler.")]
    [Range(0, 30)]
    public float doubleJumpPower;
   internal bool canDoubleJump;

    //Karakteri döndürme
    bool facingRight = true;

    //Yeri bulma
    [Tooltip("Karakterin yere deðip deðmediðini kontrol eder.")]
    public bool isGrounded = true;
    Transform groundCheck;
    const float GrounCheckRadius = 0.2f;
    [Tooltip("Yerin ne olduðunu belirler")]
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
    


    // Framerateden baðýmsýz olarak çalýþýr.Fizik ile ilgili kodlarý buraya yazýnýz.
    void FixedUpdate()
    { 
        //Yere deðiyor muyuz diye kontrol eder
        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, GrounCheckRadius, groundLayer);
        //Haraket etme
        float h = Input.GetAxis("Horizontal");
        body2D.velocity = new Vector2(h * playerSpeed, body2D.velocity.y);

        Flip(h);
    }
   public void Jump()
    {
        //Rigidbody ye dikey yönde  güç ekle
        body2D.AddForce(new Vector2(0, jumpPower));
        Console.WriteLine("Jump Function");

    } 
    public void DoubleJump()
    {
        //Rigidbody ye dikey yönde ani bir güç ekle
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
