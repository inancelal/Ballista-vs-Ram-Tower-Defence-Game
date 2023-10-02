using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(TextMeshPro))]
[ExecuteAlways]
public class Coordinate : MonoBehaviour
{
    [SerializeField] Color DefaultColor = Color.black;
    [SerializeField] Color BlockedColor = Color.gray;
    [SerializeField] Color ExploredColor = Color.yellow;
    [SerializeField] Color PathColor = Color.black;

    TextMeshPro label;
    Vector2Int coordinate = new Vector2Int();
    Gridmanager gridmanager;

    void Awake()
    {
        gridmanager = FindObjectOfType<Gridmanager>();
        label = GetComponent<TextMeshPro>();
        DisplayCoordinate();
    }

    void Update()
    {
       if(!Application.isPlaying)
       {
            DisplayCoordinate();
            ObjectCoordinateName();
       }    
       ColorCoordinates();
       ToggleLabels();
    }

    void ToggleLabels()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.enabled;
        }
    }

    void ColorCoordinates()
    {
        if(gridmanager == null){return;}

        Node node = gridmanager.GetNode(coordinate);

        if(node == null){return;}

        if(!node.isWalkable)
        {
            label.color = BlockedColor;
        }
        else if(node.isPath)
        {
            label.color = PathColor;
        }
        else if(node.isExplored)
        {
            label.color = ExploredColor;
        }
        else
        {
            label.color = DefaultColor;
        }
    }

    void DisplayCoordinate()
    {
        coordinate.x = Mathf.RoundToInt(transform.parent.position.x);
        coordinate.y = Mathf.RoundToInt(transform.parent.position.z);

        label.text = coordinate.x + "," + coordinate.y;
    }

    void ObjectCoordinateName()
    {
        transform.parent.name = coordinate.ToString();
    }
}
