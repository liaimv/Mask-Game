using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioClip buttonClip;
    public AudioSource audioSource;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            GameObject clickedObj = EventSystem.current.currentSelectedGameObject;

            if (clickedObj != null && clickedObj.CompareTag("Button"))
            {
                audioSource.PlayOneShot(buttonClip);
            }
        }
    }
}
