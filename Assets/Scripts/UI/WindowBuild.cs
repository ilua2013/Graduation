using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowBuild : MonoBehaviour
{
    private Construction _building;

    private void Awake()
    {
        _building = GetComponentInParent<Construction>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            _building.BuildTower(0);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            _building.BuildTower(1);
    }
}
