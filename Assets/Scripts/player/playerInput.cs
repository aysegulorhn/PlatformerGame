using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerinput : MonoBehaviour
{
    player player;

    
    void Start()
    {
       player = GetComponent<player>();
        
    }
    void Update()
    {
        // Eðer zýplama butonuna basarsak ve yere deðiyorsak zýplama fonksiyonu çaðýr
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Console.WriteLine("Jump Update");
            player.Jump();
            player.canDoubleJump = true;
            Console.WriteLine("Jump Update");
        }
        // Eðer zýplama butonuna basarsak ve yere deðmiyorsak ve double jump yapabiliyorsak double jump yap
        else if (Input.GetKeyDown(KeyCode.Space) && !player.isGrounded && player.canDoubleJump)
        {
            player.DoubleJump();
            player.canDoubleJump = false;
            Console.WriteLine("Double Jump Update");
        }
    }

}
