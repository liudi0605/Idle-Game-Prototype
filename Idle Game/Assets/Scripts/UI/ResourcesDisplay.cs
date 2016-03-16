﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ResourcesDisplay : MonoBehaviour
{
    private ResourceDisplay[] resources;
    private PlayerResources playerResources;
    void Awake()
    {
        this.resources = new ResourceDisplay[(int)EResourceCategory.Size];
    }

    void Start()
    {
        GameObject UIPrefab = GameObject.FindGameObjectWithTag("ServiceLocator").GetComponent<ServiceLocator>().GameObjectManager.Get("Resource UI");
        SpriteManager spriteManager = GameObject.FindGameObjectWithTag("ServiceLocator").GetComponent<ServiceLocator>().SpriteManager;
        Transform myTransform = transform;

        this.playerResources = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerResources>();
        this.playerResources.PayDelegate += this.UpdateResourceNumber;

        for (int resourceCategoryIndex = 0; resourceCategoryIndex < (int)EResourceCategory.Size; resourceCategoryIndex++)
        {
            GameObject UIGameObject = Instantiate(UIPrefab);
            RectTransform rectTransform = (RectTransform)UIGameObject.transform;
            ResourceDisplay resourceDisplay = UIGameObject.GetComponent<ResourceDisplay>();

            EResourceCategory resourceCategory = (EResourceCategory)resourceCategoryIndex;
            Sprite resourceImage = spriteManager.Get(resourceCategory.ToString());
            int resourceNumber = playerResources.GetResourceNumber(resourceCategory);

            this.resources[resourceCategoryIndex] = resourceDisplay;

            UIGameObject.transform.SetParent(myTransform);
            rectTransform.SetPosition(new Vector3(0.0f, 64.0f * resourceCategoryIndex, 0.0f));

            resourceDisplay.Initialize();
            resourceDisplay.SetResourceImage(resourceImage);
            resourceDisplay.SetResourceText(resourceNumber);
        }
    }

    private void UpdateResourceNumber()
    {
        for (int resourceCategoryIndex = 0; resourceCategoryIndex < (int)EResourceCategory.Size; resourceCategoryIndex++)
        {
            EResourceCategory resourceCategory = (EResourceCategory)resourceCategoryIndex;
            int resourceNumber = playerResources.GetResourceNumber(resourceCategory);

            this.resources[resourceCategoryIndex].SetResourceText(resourceNumber);
        }
    }
}
