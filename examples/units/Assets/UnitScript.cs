using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitScript : MonoBehaviour
{
    NavMeshAgent nma;
    GameManager gameManager;

    // The below are all of the stuff that populates the UI (and makes the units
    // individual).
    public string characterName;
    public float health = 100;
    public float magic = 100;
    public float gold = 0;

    // We will use this setting to determine behavior between the units when they
    // "interact". We tell units to interact by clicking on a second one when
    // (when one is already selected).
    public string actionMode = "";

    public Renderer bodyRenderer;

    public Color unselectedColor;
    public Color selectedColor;

    private void OnEnable()
    {
        GameManager.TimeToCelebrate += Celebrate;
    }

    private void OnDisable()
    {
        GameManager.TimeToCelebrate -= Celebrate;
    }

    void Celebrate()
    {
        bodyRenderer.material.color = new Color(Random.value, Random.value, Random.value);
    }

    // Start is called before the first frame update
    void Start()
    {
        nma = gameObject.GetComponent<NavMeshAgent>();

        GameObject gmObj = GameObject.Find("GameManagerObject");
        gameManager = gmObj.GetComponent<GameManager>();


        unselectedColor = bodyRenderer.material.color;

        transform.Rotate(0, Random.Range(0, 360), 0, Space.World);

        GameManager.instance.units.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.selectedUnit == this)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                UnitScript closest = FindClosestUnit();
                if (closest != null)
                {
                    GameManager.instance.DestroyUnit(closest);
                }
            }
        }
    }

    UnitScript FindClosestUnit()
    {
        float closestUnitDistance = float.PositiveInfinity;
        UnitScript closestUnit = null;
        foreach (UnitScript unit in GameManager.instance.units)
        {
            if (unit != this)
            {
                float d = Vector3.Distance(this.transform.position, unit.transform.position);
                if (d < closestUnitDistance)
                {
                    closestUnitDistance = d;
                    closestUnit = unit;
                }
            }
        }
        return closestUnit;
    }

    public void GoToPoint(Vector3 point)
    {
        nma.SetDestination(point);
    }

    private void OnDestroy()
    {
        GameManager.instance.units.Remove(this);
    }
}
