using BaseTemplate.Behaviours;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoSingleton<PlayerManager>
{
    public PlayerMovement PlayerMovement;
    public PlayerAttack PlayerAttack;
    public PlayerBlock PlayerBlock;
    public PlayerAnimator PlayerAnimator;
    public PlayerEntity PlayerEntity;
}
