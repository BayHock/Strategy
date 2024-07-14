using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    private readonly string FolderRus = "Russian";
    private string path;
    private int currentNode = 0;
    private int buttonClicked;
    private Node[] nd;
    private Dialogue dialogue;
    private bool dialogueEnd = false;
    private const int min = 0;
    private string textMark;
    private bool triggerColor = false;

    private CharacteristicsGameplay.IconsGame iconsGame = new(10000, 8000, 1000, 30, 60, 25);

    [Header("XMLFiles")]
    [SerializeField] private string fileDialogue;

    [Header("TextParametrs")]
    [SerializeField] private TMP_Text TextMoney;
    [SerializeField] private TMP_Text TextFood;
    [SerializeField] private TMP_Text TextArmy;
    [SerializeField] private TMP_Text TextHappiness;
    [SerializeField] private TMP_Text TextReligion;
    [SerializeField] private TMP_Text TextOrder;

    [Header("MainText")]
    [SerializeField] private TMP_Text textDialogue;

    [Header("AnswerText")]
    [SerializeField] private TMP_Text firstAnswer;
    [SerializeField] private TMP_Text secondAnswer;
    [SerializeField] private TMP_Text thirdAnswer;

    [Header("AnswerButton")]
    [SerializeField] private Button firstButton;
    [SerializeField] private Button secondButton;
    [SerializeField] private Button thirdButton;

    [Header("TimeFadeColorText")]
    [SerializeField] private float timeText = 0.0f;

    [Header("Audio Letters")]
    [SerializeField] private AudioSource audioLetter;
    [SerializeField] private AudioSource audioLetterSpace;

    private void Start()
    {
        LoadDialogue();

        nd = dialogue.nodes;

        textDialogue.text = null;
        firstAnswer.text = null;
        secondAnswer.text = null;
        thirdAnswer.text = null;

        StartCoroutine(MainTextAnimation());
        firstButton.onClick.AddListener(But1);
        secondButton.onClick.AddListener(But2);
        thirdButton.onClick.AddListener(But3);
    }

    private void Update()
    {
        MinCheck();
        OutputParametrs();
    }

    private void OutputParametrs()
    {
        TextMoney.text = iconsGame.Money.ToString();
        TextFood.text = iconsGame.Food.ToString();
        TextArmy.text = iconsGame.Army.ToString();
        TextHappiness.text = iconsGame.Happiness.ToString();
        TextReligion.text = iconsGame.Religion.ToString();
        TextOrder.text = iconsGame.Order.ToString();
    }
    private void LoadDialogue()
    {
        Debug.Log(GetPath());
        dialogue = XML.Deserialize<Dialogue>(GetPath());
    }
    private void But1()
    {
        Debug.Log("Нажата первая кнопка");
        buttonClicked = 0;
        AnswerClicked(0);
    }
    private void But2()
    {
        Debug.Log("Нажата вторая кнопка");
        buttonClicked = 1;
        AnswerClicked(1);
    }
    private void But3()
    {
        Debug.Log("Нажата третья кнопка");
        buttonClicked = 2;
        AnswerClicked(2);
    }

    private void MinCheck()
    {
        if (iconsGame.Happiness <= min)
        {
            iconsGame.Happiness = min;
        }
        if (iconsGame.Religion <= min)
        {
            iconsGame.Religion = min;
        }
        if (iconsGame.Order <= min)
        {
            iconsGame.Order = min;
        }
    }
    private void SummationCharacteristics(int numBut)
    {
        iconsGame.Money += int.Parse(nd[currentNode].answers[numBut].moneyGame);
        iconsGame.Food += int.Parse(nd[currentNode].answers[numBut].foodGame);
        iconsGame.Army += int.Parse(nd[currentNode].answers[numBut].armyGame);
        iconsGame.Happiness += int.Parse(nd[currentNode].answers[numBut].happinessGame);
        iconsGame.Religion += int.Parse(nd[currentNode].answers[numBut].religionGame);
        iconsGame.Order += int.Parse(nd[currentNode].answers[numBut].orderGame);
    }
    private void EndDialogue(int numBut)
    {
        if (iconsGame.Money <= 0 || iconsGame.Food <= 0 || iconsGame.Army <= 0 || iconsGame.Happiness >= 100 || iconsGame.Religion >= 100 || iconsGame.Order >= 100)
        {
            SceneManager.LoadScene("EndGame");
        }
        else
        {
            if (nd[currentNode].answers[numBut].end != true) return;
            dialogueEnd = true;
            Debug.Log("Dialogue to end");
            SceneManager.LoadScene("HappyEnd");
        }
    }

    private void AnswerClicked(int numberButton)
    {
        triggerColor = false;
        SummationCharacteristics(numberButton);
        EndDialogue(numberButton);

        textDialogue.text = null;
        firstAnswer.text = null;
        secondAnswer.text = null;
        thirdAnswer.text = null;

        currentNode = nd[currentNode].answers[numberButton].nextNode;
        StartCoroutine(MainTextAnimation());
    }

    private string GetPath()
    {
        return path = Application.streamingAssetsPath + "/" + FolderRus + "/" + fileDialogue + ".xml";
    }

    public void ChangeColorDifferent(int numBut)
    {
        if (triggerColor)
        {
            if (int.Parse(nd[currentNode].answers[numBut].moneyGame) < 0)
            {
                TextMoney.color = Color.Lerp(Color.white, Color.red, timeText);
            }
            else if (int.Parse(nd[currentNode].answers[numBut].moneyGame) > 0)
            {
                TextMoney.color = Color.Lerp(Color.white, Color.green, timeText);
            }

            if (int.Parse(nd[currentNode].answers[numBut].foodGame) < 0)
            {
                TextFood.color = Color.Lerp(Color.white, Color.red, timeText);
            }
            else if (int.Parse(nd[currentNode].answers[numBut].foodGame) > 0)
            {
                TextFood.color = Color.Lerp(Color.white, Color.green, timeText);
            }

            if (int.Parse(nd[currentNode].answers[numBut].armyGame) < 0)
            {
                TextArmy.color = Color.Lerp(Color.white, Color.red, timeText);
            }
            else if (int.Parse(nd[currentNode].answers[numBut].armyGame) > 0)
            {
                TextArmy.color = Color.Lerp(Color.white, Color.green, timeText);
            }

            if (int.Parse(nd[currentNode].answers[numBut].happinessGame) > 0)
            {
                TextHappiness.color = Color.Lerp(Color.white, Color.red, timeText);
            }
            else if (int.Parse(nd[currentNode].answers[numBut].happinessGame) < 0)
            {
                TextHappiness.color = Color.Lerp(Color.white, Color.green, timeText);
            }

            if (int.Parse(nd[currentNode].answers[numBut].religionGame) > 0)
            {
                TextReligion.color = Color.Lerp(Color.white, Color.red, timeText);
            }
            else if (int.Parse(nd[currentNode].answers[numBut].religionGame) < 0)
            {
                TextReligion.color = Color.Lerp(Color.white, Color.green, timeText);
            }

            if (int.Parse(nd[currentNode].answers[numBut].orderGame) > 0)
            {
                TextOrder.color = Color.Lerp(Color.white, Color.red, timeText);
            }
            else if (int.Parse(nd[currentNode].answers[numBut].orderGame) < 0)
            {
                TextOrder.color = Color.Lerp(Color.white, Color.green, timeText);
            }
        }
    }

    public void ChangeDefaulColor()
    {
        TextMoney.color = Color.white;
        TextArmy.color = Color.white;
        TextFood.color = Color.white;
        TextHappiness.color = Color.white;
        TextReligion.color = Color.white;
        TextOrder.color = Color.white;
    }

    private IEnumerator MainTextAnimation()
    {
        foreach (var value in nd[currentNode].mainText)
        {
            firstButton.interactable = false;
            secondButton.interactable = false;
            thirdButton.interactable = false;

            textDialogue.text += value;
            textMark = value.ToString();
            


            if (textMark == (".").ToString() || textMark == (",").ToString() || textMark == ("!").ToString() || textMark == ("?").ToString())
            {
                audioLetter.Play();
                yield return new WaitForSeconds(0.08f);
            }
            else if (textMark == (" ").ToString())
            {
                audioLetterSpace.Play();
                yield return new WaitForSeconds(0.08f);
            }
            else
            {
                audioLetter.Play();
                yield return new WaitForSeconds(0.05f);
            }

        }
        yield return StartCoroutine(FirstAnswerAnimation());
        yield return StartCoroutine(SecondAnswerAnimation());
        yield return StartCoroutine(ThirdAnswerAnimation());
        firstButton.interactable = true;
        secondButton.interactable = true;
        thirdButton.interactable = true;
    }
    private IEnumerator FirstAnswerAnimation()
    {
        foreach (var value in nd[currentNode].answers[0].textAnswer)
        {
            firstAnswer.text += value;
            textMark = value.ToString();

            if (textMark == (".").ToString() || textMark == (",").ToString() || textMark == ("!").ToString() || textMark == ("?").ToString())
            {
                audioLetter.Play();
                yield return new WaitForSeconds(0.08f);
            }
            else if (textMark == (" ").ToString())
            {
                audioLetterSpace.Play();
                yield return new WaitForSeconds(0.08f);
            }
            else
            {
                audioLetter.Play();
                yield return new WaitForSeconds(0.05f);
            }
        }
    }
    private IEnumerator SecondAnswerAnimation()
    {
        foreach (var value in nd[currentNode].answers[1].textAnswer)
        {
            secondAnswer.text += value;
            textMark = value.ToString();

            if (textMark == (".").ToString() || textMark == (",").ToString() || textMark == ("!").ToString() || textMark == ("?").ToString())
            {
                audioLetter.Play();
                yield return new WaitForSeconds(0.08f);
            }
            else if (textMark == (" ").ToString())
            {
                audioLetterSpace.Play();
                yield return new WaitForSeconds(0.08f);
            }
            else
            {
                audioLetter.Play();
                yield return new WaitForSeconds(0.05f);
            }
        }
    }
    private IEnumerator ThirdAnswerAnimation()
    {
        foreach (var value in nd[currentNode].answers[2].textAnswer)
        {
            thirdAnswer.text += value;
            textMark = value.ToString();

            if (textMark == (".").ToString() || textMark == (",").ToString() || textMark == ("!").ToString() || textMark == ("?").ToString())
            {
                audioLetter.Play();
                yield return new WaitForSeconds(0.08f);
            }
            else if (textMark == (" ").ToString())
            {
                audioLetterSpace.Play();
                yield return new WaitForSeconds(0.08f);
            }
            else
            {
                audioLetter.Play();
                yield return new WaitForSeconds(0.05f);
            }
        }
        triggerColor = true;
    }
}