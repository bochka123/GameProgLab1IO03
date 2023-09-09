using UnityEngine;

public class OOPPlayerController : MonoBehaviour
{
    private OOPCharacter _character;
    private OOPAnimatorPlayerController _animatorPlayerController;
    public float speed = 5f;
    public float jumpForce = 10f;

    private void Start()
    {
        _character = GetComponent<OOPCharacter>();
        _animatorPlayerController = GetComponent<OOPAnimatorPlayerController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _character.Jump(jumpForce);
        }
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        _character.Move(moveHorizontal * speed);
        
        _animatorPlayerController.PlayAnimation(_animatorPlayerController.GetCorrectAnimation(moveHorizontal, _character.Rb));
    }
}
