using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimator : MonoBehaviour
{
    private Animator _animator;
    private InputReader _inputReader;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _inputReader = GetComponent<InputReader>();
    }

    private void OnEnable()
    {
        _inputReader.JumpAnimating += PlayJumpAnimation;
        _inputReader.RunAnimating += PlayRunAnimation;
    }

    private void OnDisable()
    {
        _inputReader.JumpAnimating -= PlayJumpAnimation;
        _inputReader.RunAnimating -= PlayRunAnimation;
    }

    private void PlayJumpAnimation(string animation)
    {
        _animator.SetTrigger(animation);
    }

    private void PlayRunAnimation(string animation, bool state)
    {
        _animator.SetBool(animation, state);
    }
}