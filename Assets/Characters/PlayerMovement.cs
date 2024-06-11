using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float normalSpeed = 5f;
    public float fastSpeed = 10f;
    public float rotationSpeed = 200f;
    public Animator playerAnimator;

    public Image staminaBar;
    public float stamina;
    public float maxStamina;
    public float runCost;

    void Start()
    {
        stamina = maxStamina;
    }

    void Update()
    {
        float horizontal = -Input.GetAxis("Vertical");
        float vertical = Input.GetAxis("Horizontal");
        bool running = Input.GetKey(KeyCode.LeftShift);
        float speed = running ? fastSpeed : normalSpeed;
        Vector3 movement = new Vector3(horizontal, 0f, vertical) * speed * Time.deltaTime;

        // Check if running and there is enough stamina
        if (running && stamina > 0)
        {
            stamina -= runCost * Time.deltaTime;
        }
        else if (stamina < maxStamina)
        {
            // Regenerate stamina if not running
            stamina += (runCost / 2) * Time.deltaTime;
        }

        // Clamp stamina to ensure it stays within the range [0, maxStamina]
        stamina = Mathf.Clamp(stamina, 0f, maxStamina);

        // Update the stamina bar
        UpdateStaminaBar();

        // Move the player
        transform.Translate(movement);

        float rotationInput = Input.GetAxis("Rotate");
        transform.Rotate(Vector3.up, rotationInput * rotationSpeed * Time.deltaTime);

        if (movement.magnitude > 0)
        {
            playerAnimator.SetBool("Walk", true);

            if (running && stamina > 0)
            {
                playerAnimator.SetBool("Run", true);
            }
            else
            {
                playerAnimator.SetBool("Run", false);
            }
        }
        else
        {
            playerAnimator.SetBool("Walk", false);
            playerAnimator.SetBool("Run", false);
        }
    }

    void UpdateStaminaBar()
    {
        // Calculate the fill amount for the stamina bar based on current stamina
        float fillAmount = stamina / maxStamina;
        staminaBar.fillAmount = fillAmount;
    }
}
