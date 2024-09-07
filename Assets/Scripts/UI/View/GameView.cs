using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameView : View
{
    [SerializeField] SliderBar bossHealth, playerHealth;
    [SerializeField] TMP_Text phaseTxt, phaseFadeTxt;

    public override void Init()
    {
        base.Init();
    }

    public override void OpenView(bool _instant = false, float timeToOpen = 0.2F)
    {
        base.OpenView(_instant, timeToOpen);

        bossHealth.Init(FightManager.Instance.BossEntity.Data.MaxHealth);
        playerHealth.Init(PlayerManager.Instance.PlayerEntity.Data.MaxHealth);

        FightManager.Instance.BossEntity.OnTakeDamage += UpdateBossHealth;
        PlayerManager.Instance.PlayerEntity.OnTakeDamage += UpdatePlayerHealth; // A adapter avec un OnStartFight Dans le fight manager
    }

    public override void CloseView()
    {
        base.CloseView();
    }

    public void UpdatePhase(int newPhase)
    {
        phaseTxt.text = "PHASE " + newPhase;
        phaseFadeTxt.text = "PHASE " + newPhase;
    }

    public void UpdateBossHealth(float newHealth, float duration = .2f)
    {
        bossHealth.SetValueSmooth(newHealth, duration);
    }

    public void UpdateBossHealth(float newHealth)
    {
        bossHealth.SetValueSmooth(newHealth);
    }

    public void UpdatePlayerHealth(float newHealth)
    {
        playerHealth.SetValueSmooth(newHealth);
    }
}
