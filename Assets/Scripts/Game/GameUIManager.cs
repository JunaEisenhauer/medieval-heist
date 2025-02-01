using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    public MoneyUI moneyUi;
    public SprintUI sprintUi;

    private static GameUIManager instance;

    public static GameUIManager Instance()
    {
        return instance;
    }

    private void Awake()
    {
        instance = this;
    }
}
