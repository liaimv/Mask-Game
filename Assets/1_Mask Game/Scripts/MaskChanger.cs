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

    public Animator armAnimator;
    public Animator camAnimator;
    public Animator leftCurtainAnimator;
    public Animator rightCurtainAnimator;

    public float minSpeed = 1f;
    public float maxSpeed = 10f;

    public int minFanMoves;
    public int maxFanMoves;
    private int maskChangeLimit;

    public int totalArmMovement;
    public int totalMaskChanges = 0;
    public int redCount, yellowCount, greenCount, blueCount, whiteCount;

    public QuestionManager questionManager;

    void Awake()
    {
        masks = new Sprite[] { redMask, yellowMask, greenMask, blueMask, whiteMask };
        SetMask(Random.Range(0, masks.Length));

        maskChangeLimit = Random.Range(minFanMoves, maxFanMoves);
    }

    public void ChangeMask()
    {
        totalArmMovement++;

        if (totalArmMovement >= maskChangeLimit)
        {
            armAnimator.enabled = false;

            camAnimator.SetTrigger("End");
            leftCurtainAnimator.SetTrigger("End");
            rightCurtainAnimator.SetTrigger("End");

            questionManager.ShowQuestion(this);
            return;
        }

        if (Random.value > 0.2f)
        {
            totalMaskChanges++;

            int newIndex;
            do
            {
                newIndex = Random.Range(0, masks.Length);
            } while (masks[newIndex] == maskRenderer.sprite);

            maskRenderer.sprite = masks[newIndex];

            SetMask(newIndex);
        }

        float newSpeed = Random.Range(minSpeed, maxSpeed);
        armAnimator.speed = newSpeed;
    }

    private void SetMask(int index)
    {
        maskRenderer.sprite = masks[index];

        if (masks[index] == redMask) redCount++;
        else if (masks[index] == yellowMask) yellowCount++;
        else if (masks[index] == greenMask) greenCount++;
        else if (masks[index] == blueMask) blueCount++;
        else if (masks[index] == whiteMask) whiteCount++;
    }
}
