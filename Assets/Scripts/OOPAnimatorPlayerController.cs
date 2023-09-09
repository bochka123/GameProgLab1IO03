using UnityEngine;

public class OOPAnimatorPlayerController : MonoBehaviour
{
    private Animator _animator;
    private readonly string[] _animationNames;

    public OOPAnimatorPlayerController()
    {
        _animationNames = new[]
        {
            "IdleForward",
            "IdleRight",
            "IdleLeft",
            "RunRight",
            "RunLeft"
        };
    }
    
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayAnimation(string animationName)
    {
        _animator.Play(animationName);
    }

    public string GetCorrectAnimation(float horizontalInput, Rigidbody2D rb)
    {
        string correctAnimation = string.Empty;
        
        if (horizontalInput > 0 && rb.velocity.y == 0)
        {
            correctAnimation = _animationNames[3];
        }
        else if (horizontalInput < 0 && rb.velocity.y == 0)
        {
            correctAnimation = _animationNames[4];
        }
        else if (horizontalInput > 0 && rb.velocity.y != 0)
        {
            correctAnimation = _animationNames[1];
        }
        else if (horizontalInput < 0 && rb.velocity.y != 0)
        {
            correctAnimation = _animationNames[2];
        }
        else
        {
            correctAnimation = _animationNames[0];
        }

        return correctAnimation;
    }
}
