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

        

        Camera mainCamera = Camera.main;

        //Vi gemmer retningen, som kameraet vender, så vi altid kan bevæge os i den retning, kameraet vender
        Vector3 forward = mainCamera.transform.forward;
        Vector3 right = mainCamera.transform.right;

        //Vi sætter y-retningen til 0, så vi ikke bevæger os op eller ned, når kameraet kigger op eller ned

        //Vi normaliserer vektoren, så vi altid bevæger os lige langt uanset hvor vi kigger hen
        forward.Normalize();
        right.Normalize();

        //Vi kombinerer retningen vores kamera vender med vores moveInput, så vi bevæger os i den retning, vi kigger
        Vector3 moveDirection = forward * input.z + right*input.x;

        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);






    }
}