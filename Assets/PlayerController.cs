using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Components;

public class PlayerController : NetworkBehaviour
{
    public float moveSpeed;
    private CharacterController characterController;
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        //Vi gemmer movement inputtet fra tastatur eller kontroller i 2 variabler
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        //Vi sætter movement inputtet sammen til en ny vector
        Vector3 input = new Vector3(horizontal, 0, vertical);
        
        //Vi begrænser vores vektor til en længde på 1, så vi ikke bevæger os hurtigere frem, når vi bevæger os diagonalt
        input = Vector3.ClampMagnitude(input, 1f);

        
        characterController.Move(input * moveSpeed * Time.deltaTime);

        
    }
}