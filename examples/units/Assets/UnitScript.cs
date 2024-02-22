using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitScript : MonoBehaviour
{
    NavMeshAgent nma;
    GameManager gameManager;

    public string characterName;

    public Renderer bodyRenderer;

    public Color unselectedColor;
    public Color selectedColor;

    // Start is called before the first frame update
    void Start()
    {
        nma = gameObject.GetComponent<NavMeshAgent>();

        GameObject gmObj = GameObject.Find("GameManagerObject");
        gameManager = gmObj.GetComponent<GameManager>();

        unselectedColor = bodyRenderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GoToPoint(Vector3 point)
    {
        nma.SetDestination(point);
    }

    public void OnMouseDown()
    {
        gameManager.SelectUnit(this);
    }
}
