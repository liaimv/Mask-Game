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

    public Animator armAnimator;
    public Animator camAnimator;
    public Animator leftCurtainAnimator;
    public Animator rightCurtainAnimator;

    public Animator applauseAudioAnimator;
    public AudioSource applauseSource;
    public AudioSource maskSource;
    public AudioSource armSource;

    public float minSpeed = 1f;
    public float maxSpeed = 10f;

    public int minFanMoves;
    public int maxFanMoves;
    private int maskChangeLimit;

    public bool isLevel1 = false;
    public bool isLevel2 = false;
    public bool isLevel3 = false;

    public int totalArmMovement;
    public int totalMaskChanges = 0;
    public int redCount, yellowCount, greenCount, blueCount, whiteCount;

    public QuestionManager questionManager;

    void Awake()
    {
        if (isLevel1)
        {
            masks = new Sprite[] { redMask, yellowMask, blueMask };
            SetMask(Random.Range(0, masks.Length));
        }
        else if (isLevel2)
        {
            masks = new Sprite[] { redMask, yellowMask, greenMask, blueMask };
            SetMask(Random.Range(0, masks.Length));
        }
        else if (isLevel3)
        {
            masks = new Sprite[] { redMask, yellowMask, greenMask, blueMask, whiteMask };
            SetMask(Random.Range(0, masks.Length));
        }

        maskChangeLimit = Random.Range(minFanMoves, maxFanMoves);

        redCount = yellowCount = greenCount = blueCount = whiteCount = 0;
    }

    public void ChangeMask()
    {
        totalArmMovement++;

        if (totalArmMovement >= maskChangeLimit)
        {
            armAnimator.enabled = false;

            StartCoroutine(ApplauseAudioEnable());

            camAnimator.SetTrigger("End");
            leftCurtainAnimator.SetTrigger("End");
            rightCurtainAnimator.SetTrigger("End");

            questionManager.ShowQuestion(this);
            return;
        }

        float randomValue;
        if (isLevel1)
        {
            randomValue = 0f;
        }
        else if (isLevel2)
        {
            randomValue = 0.05f;
        }
        else {
            randomValue = 0.1f;
        }

        if (Random.value > randomValue)
        {
            totalMaskChanges++;

            maskSource.PlayOneShot(maskSource.clip);

            int newIndex;
            do
            {
                newIndex = Random.Range(0, masks.Length);
            } while (masks[newIndex] == maskRenderer.sprite);

            maskRenderer.sprite = masks[newIndex];

            SetMask(newIndex);
        }
        else
        {
            armSource.PlayOneShot(armSource.clip);
        }

            float newSpeed = Random.Range(minSpeed, maxSpeed);
        armAnimator.speed = newSpeed;
    }

    private IEnumerator ApplauseAudioEnable()
    {
        yield return new WaitForSeconds(1f);

        applauseSource.Play();
        applauseAudioAnimator.SetTrigger("FadeOut");
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
