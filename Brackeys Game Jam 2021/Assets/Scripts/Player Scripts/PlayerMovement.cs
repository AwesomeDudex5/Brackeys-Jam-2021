using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : DirectPlayerAnimationControl
{

    //public Animator anim;

    Vector2 InputVector;
    Vector3 MousePosition;

    [SerializeField]
    private bool rotateTowardMouse;
    private bool canMove = true;

    /*  Will have to play around with these values  */
    [Header("Camera Stats")]
    [SerializeField]
    private float cameraZoomDistance;
    [SerializeField]
    private float cameraOffset;
    [SerializeField]
    private float cameraRotation;

    [Header("Movement Stats")]
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float rotationSpeed;

    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        cam.transform.eulerAngles = new Vector3(cameraRotation, 0f, 0f);
        GameManager.current.onPlayerDied += StopAndDie;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {
            InputVector.x = Input.GetAxisRaw("Horizontal");
            InputVector.y = Input.GetAxisRaw("Vertical");

            controller.SetFloat(X_LABEL, InputVector.x);
            controller.SetFloat(Y_LABEL, InputVector.y);

        }

        MousePosition = Input.mousePosition;



    }

    private void FixedUpdate()
    {
        setCameraFollow();

        Vector3 targetVector = new Vector3(InputVector.x, 0, InputVector.y);
        Vector3 movementVector = MoveTowardTarget(targetVector);

        if (!rotateTowardMouse)
        {
            RotateTowardMovementVector(movementVector);
        }
        if (rotateTowardMouse)
        {
            RotateFromMouseVector();
        }

    }

    private void setCameraFollow()
    {
        Vector3 followVector = new Vector3(this.transform.position.x, cameraZoomDistance, this.transform.position.z + cameraOffset);
        cam.transform.position = followVector;

    }

    private void RotateFromMouseVector()
    {
        Ray ray = cam.ScreenPointToRay(MousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance: 300f))
        {
            var target = hitInfo.point;
            target.y = transform.position.y;

            transform.LookAt(target);

            /* var lookPos = target - transform.position;
             lookPos.y =transform.position.y;
             var rotation = Quaternion.LookRotation(lookPos);
             transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
             */

        }
    }

    private Vector3 MoveTowardTarget(Vector3 targetVector)
    {
        float speed = movementSpeed * Time.deltaTime;

        targetVector = Quaternion.Euler(0, cam.gameObject.transform.rotation.eulerAngles.y, 0) * targetVector;
        Vector3 targetPosition = transform.position + targetVector * speed;
        transform.position = targetPosition;

        return targetVector;
    }

    private void RotateTowardMovementVector(Vector3 movementDirection)
    {
        if (movementDirection.magnitude == 0) { return; }
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(movementDirection), rotationSpeed);
    }

    public void StopAndDie()
    {
        AudioManager.instance.playSound("Player Got Hit");
        GameManager.current.onPlayerDied -= StopAndDie;
        StartCoroutine(playStopAndDie());
    }

    IEnumerator playStopAndDie()
    {
        canMove = false;
        controller.SetTrigger("Death");
        yield return new WaitForSeconds(3.5f);
        Destroy(this.gameObject);
    }

}
