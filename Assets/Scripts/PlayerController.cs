using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const string HORIZONTAL_INPUT = "Horizontal";
    private const string VERTICAL_INPUT = "Vertical";

    

    [Header("Player Settings")]
    [SerializeField] private Transform body;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float rotationAngle;
    [Header("Attack Settings")]
    [SerializeField] private Transform attackPoint;
    [SerializeField] private Transform laserPrefab;
    [SerializeField] private float laserSpeed;
    [SerializeField] private int maxAttackTimer;
    [Header("Border Settings")]
    [SerializeField] private int xRange;
    [SerializeField] private int yRange;

    private float attackTimer;
    private float horizontalInput;
    private float verticalInput;

    private Vector3 movementDirection;

    private bool isMove;
    void Start()
    {
        attackTimer = maxAttackTimer;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleAttack();
    }

    #region Movement
    private void HandleMovement()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL_INPUT);
        verticalInput = Input.GetAxis(VERTICAL_INPUT);

        movementDirection = new Vector3(horizontalInput, verticalInput, 0f);
        movementDirection.Normalize();

        if (movementDirection != Vector3.zero)
            isMove = true;
        else
            isMove = false;

        if (isMove)
        {
            transform.Translate(movementDirection * movementSpeed * Time.deltaTime);
        }

        HandleRotation();
        SetBorder();
    }

    private void HandleRotation()
    {
        if (isMove)
        {
            if (Input.GetKey(KeyCode.D))
            {
                rotationAngle = -30f;
                var desiredRotation = Quaternion.Euler(0f, 0f, rotationAngle);
                body.transform.rotation = Quaternion.Slerp(body.transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                rotationAngle = 30f;
                var desiredRotation = Quaternion.Euler(0f, 0f, rotationAngle);
                body.transform.rotation = Quaternion.Slerp(body.transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
            }
        }
        else
        {
            body.transform.rotation = Quaternion.Slerp(body.transform.rotation, Quaternion.identity, rotationSpeed * Time.deltaTime);
        }
    }

    private void SetBorder()
    {
        var maximumX = xRange;
        var minimumX = -xRange;
        var maximumY = yRange;
        var minimumY = 0f;

        if (transform.position.x > maximumX)
        {
            if (transform.position.y > maximumY)
            {
                transform.position = new Vector3(maximumX, maximumY, 0f);
            }
            else if (transform.position.y < minimumY)
            {
                transform.position = new Vector3(maximumX, minimumY, 0f);
            }
            else
                transform.position = new Vector3(maximumX, transform.position.y, 0f);
        }
        else if (transform.position.x < minimumX)
        {
            if (transform.position.y > maximumY)
            {
                transform.position = new Vector3(minimumX, maximumY, 0f);
            }
            else if (transform.position.y < minimumY)
            {
                transform.position = new Vector3(minimumX, minimumY, 0f);
            }
            else
                transform.position = new Vector3(minimumX, transform.position.y, 0f);

        }
        else if (transform.position.y > maximumY)
        {
            transform.position = new Vector3(transform.position.x, maximumY, 0f);
        }
        else if (transform.position.y < minimumY)
        {
            transform.position = new Vector3(transform.position.x, minimumY, 0f);
        }
    }
    #endregion

    #region Attack
    private void HandleAttack()
    {
        attackTimer -= Time.deltaTime;

        if(attackTimer <= 0)
        {
            attackTimer = maxAttackTimer;
            CreateLaser();
        }
    }

    private void CreateLaser()
    {
        var laser = Instantiate(laserPrefab);
        laser.transform.position = attackPoint.position;
        laser.GetComponent<Laser>().SetType(Laser.Types.Player);
        laser.GetComponent<Laser>().Movement(laserSpeed);
    }
    #endregion

}
