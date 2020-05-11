using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    float speed;
    float screenHalfWidthInWorldUnits;
    public Vector2 speedMinMax;
    public Material mat;
    Color color;

    void Start()
    {
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + gameObject.transform.localScale.y*2;
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent());
    }
    void Update()
    {
        color = new Color(Mathf.Lerp(0f, 1f, Difficulty.GetDifficultyPercent()), 1 - Mathf.Lerp(0, 1, Difficulty.GetDifficultyPercent()), 0);
        mat.SetColor("_Color", color);
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if (transform.position.y < -screenHalfWidthInWorldUnits)
        {
            Destroy(gameObject);
        }
    }
}

