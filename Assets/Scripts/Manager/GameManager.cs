using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        PoolManager.Instance.Init();

        UIManager.Instance.Init();

        CameraManager.Instance.Init();

        TimeManager.Instance.Init();
    }

}
