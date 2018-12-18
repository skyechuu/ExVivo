using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] Transform camera;
    
    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;
    [SerializeField] float sprintSpeed;

    private CharacterController cc;
    private Animator animator;

    void Awake()
    {
        cc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        var forward = camera.forward * InputManager.KeyboardY;
        var strafe = camera.right * InputManager.KeyboardX;

        animator.SetFloat("H", InputManager.KeyboardX);
        animator.SetFloat("V", InputManager.KeyboardY);
        var move = forward + strafe;
        move = move.normalized * runSpeed * Time.deltaTime;


        cc.SimpleMove(move);
        animator.SetFloat("Speed", cc.velocity.magnitude/2);

        Debug.Log(cc.isGrounded);
        //RotatePlayer();

    }

    void RotatePlayer()
    {
        var dir = cc.velocity.normalized;
        if(dir.magnitude > 0.01f)
            transform.rotation = Quaternion.LookRotation(dir);
    }
}
