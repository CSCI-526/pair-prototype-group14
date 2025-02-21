using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerMovement : MonoBehaviour
{
    public TextMeshProUGUI moveText;   
    [SerializeField] private bool isRepeatedMovement = false;
    [SerializeField] private float moveDuration = 0.1f;
    [SerializeField] private float gridSize = 1f;

    [SerializeField] private float xBounds = 11;
    [SerializeField] private float yBounds = 2;

    [SerializeField] public int movesLeft = 0;
    [SerializeField] public int movesPerWave = 5;

    private float startXPos;
    private float startYPos;
    private bool isMoving;

    void Start()
    {
        startXPos = transform.position.x;
        startYPos = transform.position.y;
        UpdateMoveUI();
    }

    void Update()
    {
        if (!isMoving)
        {
            System.Func<KeyCode, bool> inputFunction;
            if (isRepeatedMovement)
            {
                inputFunction = Input.GetKey;
            }
            else
            {
                inputFunction = Input.GetKeyDown;
            }

            // if (!(math.abs(transform.position.x - startXPos) >= xBounds || math.abs(transform.position.y - startYPos) >= yBounds))
            // {
            //     yield return null;
            // }
            if (movesLeft > 0 && GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                if (inputFunction(KeyCode.UpArrow))
                {
                    if ((transform.position.y - startYPos) < yBounds)
                    {
                        StartCoroutine(Move(Vector2.up));
                    }
                }
                else if (inputFunction(KeyCode.DownArrow))
                {
                    if ((startYPos - transform.position.y) < yBounds)
                    {
                        StartCoroutine(Move(Vector2.down));
                    }
                }
                else if (inputFunction(KeyCode.LeftArrow))
                {
                    if ((startXPos - transform.position.x) < xBounds)
                    {
                        StartCoroutine(Move(Vector2.left));
                    }
                }
                else if (inputFunction(KeyCode.RightArrow))
                {
                    if ((transform.position.x - startXPos) < xBounds)
                    {
                        StartCoroutine(Move(Vector2.right));
                    }
                }
            }
        }
    }


    private IEnumerator Move(Vector2 direction)
    {
        isMoving = true;
        movesLeft--;
        UpdateMoveUI();

        Vector2 startPos = transform.position;
        Vector2 endPos = startPos + (direction * gridSize);

        float elapsedTime = 0;
        while (elapsedTime < moveDuration)
        {
            elapsedTime += Time.deltaTime;
            float percent = elapsedTime / moveDuration;
            transform.position = Vector2.Lerp(startPos, endPos, percent);
            yield return null;
        }

        transform.position = endPos;

        isMoving = false;
    }

    public void addMoves()
    {
        movesLeft = movesPerWave;
        UpdateMoveUI();
    }

    public void resetMoves()
    {
        movesLeft = 0;
        UpdateMoveUI();
    }

    public void UpdateMoveUI()
    {
        if (moveText !=null)
        {
            moveText.text ="Moves Left: " + movesLeft;
        }
    }
}
