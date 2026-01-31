using System.Collections;
using UnityEngine;

public class MaskChanger : MonoBehaviour
{
    //Masks
    public SpriteRenderer maskRenderer;
    public Sprite redMask;
    public Sprite yellowMask;
    public Sprite greenMask;
    public Sprite blueMask;
    public Sprite whiteMask;

    private Sprite[] masks;

    public Animator animator;

    public float minSpeed = 1f;
    public float maxSpeed = 10f;

    void Awake()
    {
        masks = new Sprite[] { redMask, yellowMask, greenMask, blueMask, whiteMask };
        ShowRandomMask();
    }

    private void ShowRandomMask()
    {
        int index = Random.Range(0, masks.Length);
        maskRenderer.sprite = masks[index];
    }

    public void ChangeMask()
    {
        if (Random.value > 0.2f)
        {
            int newIndex;
            do
            {
                newIndex = Random.Range(0, masks.Length);
            } while (masks[newIndex] == maskRenderer.sprite);

            maskRenderer.sprite = masks[newIndex];

            float newSpeed = Random.Range(minSpeed, maxSpeed);
            animator.speed = newSpeed;
        }
    }
}
