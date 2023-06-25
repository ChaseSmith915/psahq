using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterButton : MonoBehaviour
{
    [SerializeField] private Button btn;
    [SerializeField] private string character;
    void Start()
    {
        btn.onClick.AddListener(setCharacter);
    }

    private void setCharacter()
    {
        GlobalVariables.Instance.characterChoice = character;
    }
}
