using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnAnimatorEvent()
    {
        _animator.SetInteger("ChangingCondition", Random.Range(1, 4));
    }
}
