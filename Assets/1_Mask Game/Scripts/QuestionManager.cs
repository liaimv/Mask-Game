using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class QuestionManager : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public TMP_InputField answerInput;

    public GameObject questionCanvas;

    private int correctAnswer;

    void Awake()
    {
        questionCanvas.SetActive(false);
    }

    public void ShowQuestion(MaskChanger data)
    {
        StartCoroutine(GenerateRandomQuestion(data));
    }

    private IEnumerator GenerateRandomQuestion(MaskChanger data)
    {
        yield return new WaitForSeconds(4f);

        int questionType = Random.Range(0, 6);

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
            //SceneManager.LoadScene("GameOver");
            Debug.Log("Not a valid answer.");
            return;
        }

        if (playerAnswer == correctAnswer)
        {
            //SceneManager.LoadScene("Success");
            Debug.Log("Correct!");
        }
        else
        {
            //SceneManager.LoadScene("GameOver");
            Debug.Log("False!");
        }
    }
}
