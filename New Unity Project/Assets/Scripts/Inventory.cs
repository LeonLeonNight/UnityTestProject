﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //создаем новый список элементов
    public List<Item> items;
    // Start is called before the first frame update
    void Start()
    {
        items = new List<Item>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
