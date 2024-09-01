using BaseTemplate.Behaviours;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] Canvas mainCanvas;

    public Canvas MainCanvas { get => mainCanvas; }

    public void Init()
    {
    }
}
