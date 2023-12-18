using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spike : Trap
{
    [SerializeField] private Animator _animator;
    private bool _isTrapActive = false;

    //protected override void KillPlayer(IPlayer player)
    //{
    //    if (_isTrapActive)
    //    {
    //        base.KillPlayer(player);
    //    }
    //}


    public void PlayAnimation(string name)
    {
        if (!_isTrapActive)
        {
            _animator.Play(name, 0, 0);
            _isTrapActive = true;
        }
        
    }
}
