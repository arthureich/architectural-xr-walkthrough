using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(CharacterController))]
public class FootstepSound_Debug : MonoBehaviour
{
    public AudioClip[] footstepClips;
    public float stepDelay = 0.5f;

    private AudioSource audioSource;
    private CharacterController controller;
    private float stepTimer = 0f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        bool grounded = controller.isGrounded;
        float speed = controller.velocity.magnitude;

        // DEBUG no console
        Debug.Log($"Grounded: {grounded}, Speed: {speed:F2}");

        // Toca som ao andar
        if (grounded && speed > 0.2f)
        {
            stepTimer -= Time.deltaTime;
            if (stepTimer <= 0f)
            {
                PlayFootstep();
                stepTimer = stepDelay;
            }
        }
        else
        {
            stepTimer = 0f;
        }

        // TESTE: Pressionar T para tocar um som
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("TOCANDO SOM MANUAL COM T");
            PlayFootstep();
        }
    }

    void PlayFootstep()
    {
        if (footstepClips.Length > 0)
        {
            int index = Random.Range(0, footstepClips.Length);
            audioSource.PlayOneShot(footstepClips[index]);
            Debug.Log($"Som de passo tocado: {footstepClips[index].name}");
        }
        else
        {
            Debug.LogWarning("Nenhum som de passo atribuído!");
        }
    }
}
