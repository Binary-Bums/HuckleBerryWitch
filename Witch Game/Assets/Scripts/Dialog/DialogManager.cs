using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField] Button continueButton;
    public Text nameText, dialogText;
    private Queue<string> sentences = new();

    private void Awake() {
        continueButton.onClick.AddListener(Continue);

        EventToggle.SendDialog += StartDialog;

        gameObject.SetActive(false);
    }

    private void OnEnable() {
        Time.timeScale = 0;
    }

    private void OnDisable() {
        Time.timeScale = 1;
    }

    public void StartDialog(Dialog dialog)
    {
        gameObject.SetActive(true);

        nameText.text = dialog.characterName;

        sentences.Clear();

        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialog();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogText.text = sentence;
    }

    void EndDialog()
    {
        gameObject.SetActive(false);
    }

    private void Continue()
    {
        if(sentences.Count >= 1)
        {
            DisplayNextSentence();
        } else {
            EndDialog();
        }
    }

    
}
