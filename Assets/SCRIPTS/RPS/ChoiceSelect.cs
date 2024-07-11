using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceSelect : MonoBehaviour
{
  [SerializeField] Choices buttonChoice;
  [SerializeField] bool isPlayer;

  public void ChoiceSelected()
  {
    GameManager.instance.Select(buttonChoice, isPlayer);
  }
}
