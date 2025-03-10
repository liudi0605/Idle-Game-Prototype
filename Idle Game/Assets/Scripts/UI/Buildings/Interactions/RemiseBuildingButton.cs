﻿using UnityEngine;
using UnityEngine.UI;

public class RemiseBuildingButton : MonoBehaviour
{
    #region Unity Methods
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            ServiceContainer.Instance.GameObjectReferencesArrayInScene.Get("[PLAYER]", EGameObjectReferences.Rest).GetComponent<PlayerBuildingsManager>().RemiseSelectedBuilding();
        });
    }
    #endregion
}