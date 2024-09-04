using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public TMP_Text Text;
    Sequence _tween;

    public void InitSmall(float amount, bool isCrit = false)
    {
        Text.alpha = 1;
        Text.transform.localPosition = Vector3.zero;
        Text.transform.localScale = Vector3.one;
        Text.text = amount.ToString();

        if (isCrit) Text.color = ColorManager.Instance.Yellow;
        else Text.color = ColorManager.Instance.Grey;

        if (_tween.IsActive()) _tween.Kill();

        _tween = DOTween.Sequence();

        _tween
            .Join(Text.transform.DOPunchScale(new Vector3(1.2f, 1.2f, 1.2f), .1f))
            .Append(Text.transform.DOLocalMoveY(.5f, .5f)).SetEase(Ease.InQuad)
            .Append(Text.DOFade(0, .2f));
    }
}
