using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.GraphicsBuffer;

public class ShowInstructions : MonoBehaviour
{
    public GameObject instruction;

    private void Start()
    {
        instruction.SetActive(false);
    }

    public void DisplayInstructions()
    {
        instruction.SetActive(!instruction.activeSelf);
        EventSystem.current.SetSelectedGameObject(null);
    }
}
