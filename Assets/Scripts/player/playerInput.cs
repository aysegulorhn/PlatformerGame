using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Player player;

    void Update()
    {
        // Eğer zıplama butonuna basarsak, zıplama veya double jump işlemini gerçekleştir
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (player.isGrounded)
            {
                Debug.Log("Jump Update");
                player.Jump();
                player.canDoubleJump = true;
            }
            else if (player.canDoubleJump)
            {
                Debug.Log("Double Jump Update");
                player.DoubleJump();
                player.canDoubleJump = false;
            }
        }
    }
}