using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioClip buttonClip;
    public AudioSource buttonSource;
    public AudioSource mainSource;

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
                buttonSource.PlayOneShot(buttonClip);
            }
        }

        if (Data.onLevel1 || Data.onStart)
        {
            mainSource.pitch = 0.9f;
        }
        else if (Data.onLevel2)
        {
            mainSource.pitch = 1f;
        }
        else if (Data.onLevel3)
        {
            mainSource.pitch = 1.1f;
        }
    }
}
