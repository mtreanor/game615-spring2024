using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Camera cam;

    public UnitScript selectedUnit;

    public GameObject selectedUnitPanel;
    public TMP_Text unitNameText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // This if checks that the left mouse button was pressed.
        if (Input.GetMouseButton(0))
        {
            // This 'ScreenPointToRay' function converts a screen position to a world (3d) ray
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            // See the below 'out' in front of the parameter hit. This is a way that Unity/C#
            // allows the Physics.Raycast function to 'stuff' a bunch of useful information
            // inside of the 'hit' variable.
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, float.PositiveInfinity))
            {
                // If we get in here, it means that the raycast collided with something.
                // 'hit' now has this useful info:
                //      - collider (because we get access to tghe gameObject
                //      - point (the position the raycast hit
                //      - the "layer" that the gameObject we hit is on
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
                {
                    selectedUnit.GoToPoint(hit.point);
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
        unitNameText.text = selectedUnit.characterName;
    }
}
