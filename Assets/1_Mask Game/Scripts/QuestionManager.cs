using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.EventSystems;

public class QuestionManager : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public TMP_InputField answerInput;

    public GameObject questionCanvas;
    public GameObject invalidText;

    private int correctAnswer;

    public MaskChanger maskChanger;

    void Awake()
    {
        questionCanvas.SetActive(false);
        invalidText.SetActive(false);
    }

    public void ShowQuestion(MaskChanger data)
    {
        StartCoroutine(GenerateRandomQuestion(data));
    }

    private IEnumerator GenerateRandomQuestion(MaskChanger data)
    {
        yield return new WaitForSeconds(4f);

        int questionType = -1;
        
        while (questionType == -1) //Make sure when a certain color didn't show up, that question doesn't show
        {
            int temp = Random.Range(0, 6);

            switch (temp)
            {
                case 0:
                    questionType = 0;
                    break;
                case 1:
                    if (data.redCount > 0) questionType = 1;
                    break;
                case 2:
                    if (data.yellowCount > 0) questionType = 2;
                    break;
                case 3:
                    if (data.greenCount > 0) questionType = 3;
                    break;
                case 4:
                    if (data.blueCount > 0) questionType = 4;
                    break;
                case 5:
                    if (data.whiteCount > 0) questionType = 5;
                    break;
            }
        }

        switch (questionType)
        {
            case 0:
                questionText.text = "How many times did the mask change color?";
                correctAnswer = data.totalMaskChanges;
                break;

            case 1:
                questionText.text = "How many times did the red mask show?";
                correctAnswer = data.redCount;
                break;

            case 2:
                questionText.text = "How many times did the yellow mask show?";
                correctAnswer = data.yellowCount;
                break;
            case 3:
                questionText.text = "How many times did the green mask show?";
                correctAnswer = data.greenCount;
                break;
            case 4:
                questionText.text = "How many times did the blue mask show?";
                correctAnswer = data.blueCount;
                break;
            case 5:
                questionText.text = "How many times did the white mask show?";
                correctAnswer = data.whiteCount;
                break;
        }

        questionCanvas.SetActive(true);

        answerInput.text = "";
        answerInput.ActivateInputField();
    }

    public void SubmitAnswer()
    {
        int playerAnswer;

        if (!int.TryParse(answerInput.text, out playerAnswer))
        {
            Debug.Log("Not a valid answer.");

            StartCoroutine(InvalidTextDisplay());
            return;
        }

        if (playerAnswer == correctAnswer)
        {
            if (maskChanger.isLevel1)
            {
                SceneManager.LoadScene("Next Scene 1");
            }
            else if (maskChanger.isLevel2)
            {
                SceneManager.LoadScene("Next Scene 2");
            }
            else if (maskChanger.isLevel3)
            {
                SceneManager.LoadScene("Success Scene");
            }

            Debug.Log("Correct!");
        }
        else
        {
            SceneManager.LoadScene("Game Over Scene");
            Debug.Log("False!");
        }
    }

    private IEnumerator InvalidTextDisplay()
    {
        invalidText.SetActive(true);

        yield return new WaitForSeconds(1f);

        invalidText.SetActive(false);
    }
}
