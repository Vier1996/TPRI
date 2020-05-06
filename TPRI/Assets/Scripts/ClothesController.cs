using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesController : MonoBehaviour
{
    [SerializeField] private Material mat1;
    [SerializeField] private Material mat2;
    [SerializeField] private Material mat3;
    [SerializeField] private string path;
    [SerializeField] private GameObject model;
    [SerializeField] private GameObject model2;

    private bool pair = false;
    private MeshRenderer obj;
    private MeshRenderer obj2;
    void Start()
    {
        if (model2 != null)
            pair = true;
        
        PlayerPrefs.SetInt(_ResourceKeys.Money, 500);
        obj = model.GetComponent<MeshRenderer>();
        try
        {
            obj2 = model2.GetComponent<MeshRenderer>();
        }
        catch (UnassignedReferenceException)
        {
        }

        Recycler();
    }
    
    void Update()
    {
        Recycler();
    }

    private void Recycler()
    {
        if (PlayerPrefs.GetInt(path + 1) == 1)
        {
            obj.materials[0].color = mat1.color;
            try
            {
                obj2.materials[0].color = mat1.color;
            }
            catch (NullReferenceException)
            {
            }
        }

        if (PlayerPrefs.GetInt(path + 2) == 1)
        {
            obj.materials[0].color = mat2.color;
            try
            {
                obj2.materials[0].color = mat2.color;
            }
            catch (NullReferenceException)
            {
            }
        }
        if (PlayerPrefs.GetInt(path + 3) == 1)
        {
            obj.materials[0].color = mat3.color;
            try
            {
                obj2.materials[0].color = mat3.color;
            }
            catch (NullReferenceException)
            {
            }
        }
    }
}
