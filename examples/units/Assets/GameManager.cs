using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    public static Action TimeToCelebrate;
    public static Action<int> ScoreUpdated;

    public static GameManager instance;

    int score = 0;

    // Create a list
    public List<UnitScript> units = new List<UnitScript>();

    public Camera cam;

    public UnitScript selectedUnit = null;

    public GameObject selectedUnitPanel;
    public TMP_Text unitNameText;

    public MeterScript healthMeter;
    public MeterScript magicMeter;
    public MeterScript goldMeter;

    public ToggleGroup selectActionButtonGroup;

    void OnEnable()
    {
        if (GameManager.instance != null)
        {
            Destroy(this);
        }
        else
        {
            GameManager.instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            GameManager.TimeToCelebrate?.Invoke();
        }

        // This if checks that the left mouse button was pressed, and the second part
        // of this checks to see that the the mouse isn't over a UI element. The purpose
        // for this was that the lines below were making it so the click on buttons
        // never worked (because they turned off the UI element before the click was
        // recognized by the button).
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            // This 'ScreenPointToRay' function converts a screen position to a world (3d) ray
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            // See the below 'out' in front of the parameter hit. This is a way that Unity/C#
            // allows the Physics.Raycast function to 'stuff' a bunch of useful information
            // inside of the 'hit' variable.
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, float.PositiveInfinity) )
            {
                // If we get in here, it means that the raycast collided with something.
                // 'hit' now has this useful info:
                //      - collider (because we get access to the gameObject through that
                //      - point (the position the raycast hit
                //      - the "layer" that the gameObject we hit is on
                //
                // Check to see that thing we hit was a unit
                if (hit.collider.CompareTag("unit"))
                {
                    // If we don't have a selectedUnit, select the thing we clicked on
                    if (selectedUnit == null)
                    {
                        SelectUnit(hit.collider.gameObject.GetComponent<UnitScript>());
                    }
                    else if (hit.collider.gameObject != selectedUnit.gameObject)
                    {
                        // We we get in here, it means that we had a selected unit already, so
                        // tell them to move in front of the the unit we clicked on.
                        Vector3 inFrontOfClickedOnUnit = hit.collider.gameObject.transform.position + hit.collider.gameObject.transform.forward * 2;
                        selectedUnit.GoToPoint(inFrontOfClickedOnUnit);
                    }
                }
                else
                {
                    // If we get in here, it means we clicked on something other than
                    // a unit. If that thing is on the layer "Ground", tell the selected unit
                    // to move there.
                    if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
                    {
                        selectedUnit.GoToPoint(hit.point);
                    }
                }
            }
            else
            {
                // If the raycast didn't collide with anything, deselect the unit.
                if (selectedUnit != null)
                {
                    selectedUnit.bodyRenderer.material.color = selectedUnit.unselectedColor;
                }
                selectedUnit = null;
                // Turn off the UI.
                selectedUnitPanel.SetActive(false);
            }
        }
    }

    public void SelectUnit(UnitScript unit)
    {
        if (selectedUnit != null)
        {
            // Deselect the previously selected unit.
            selectedUnit.bodyRenderer.material.color = selectedUnit.unselectedColor;
        }

        // Set the currently selected unit to be the unit passed in to this function (that's the whole point!).
        selectedUnit = unit;
        selectedUnit.bodyRenderer.material.color = selectedUnit.selectedColor;

        // Update the UI and make sure it is active (visible).
        selectedUnitPanel.SetActive(true);
        healthMeter.SetMeter(selectedUnit.health);
        magicMeter.SetMeter(selectedUnit.magic);
        goldMeter.SetMeter(selectedUnit.gold);
        unitNameText.text = selectedUnit.characterName;
        // Set the toggle group to reflect the newly selected unit's 'actionMode'.
        foreach (Toggle toggle in selectActionButtonGroup.GetComponentsInChildren<Toggle>())
        {
            if (selectedUnit.actionMode == toggle.GetComponentInChildren<TMP_Text>().text)
            {
                toggle.Select();
            }
        }
    }

    public void SetActionButtonClicked()
    {
        // 'selectActionButtonGroup' is the parent object that all of the toggle
        // buttons have a reference to (see the Toggle inspector, there's a place
        // to be a 'group'. Through the selectActionButtonGroup we can loop through
        // all of the currently selected Toggle buttons (which there should only
        // ever be one). Set the actionMode string of the UnitScript to the text
        // field of the button (which is only accessible via the child object).
        foreach (Toggle toggle in selectActionButtonGroup.ActiveToggles())
        {
            selectedUnit.actionMode = toggle.GetComponentInChildren<TMP_Text>().text;
        }
    }

    public void DestroyUnit(UnitScript unit)
    {
        Destroy(unit.gameObject);
        score++;
        GameManager.ScoreUpdated?.Invoke(score);
    }

}
