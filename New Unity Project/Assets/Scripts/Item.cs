using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    /// <summary>
    /// Id уникального предмета
    /// </summary>
    public int Id;
    /// <summary>
    /// Имя предмета
    /// </summary>
    public string NameItem;

    /// <summary>
    /// Количество
    /// </summary>
    public int CountItem;

    /// <summary>
    /// СтАкающие предмет или нет
    /// </summary>
    public bool isStackable;

    [Multiline(5)]
    public string Description;

    //Изображение предмета и его префаб получим другим способом
    //Будем указывать его из папки Resources, т.е. абсолютным путем

    public string pathIcon;
    public string pathPrefab;
}
