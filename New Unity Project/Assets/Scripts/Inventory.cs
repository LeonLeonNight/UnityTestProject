using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    //создаем новый список элементов
    public List<Item> items;
    public GameObject cellContainer;
    public KeyCode showInvent;
    public KeyCode takeInvent;

    public GameObject massageManager;
    public GameObject massage;

    // Start is called before the first frame update
    void Start()
    {
        items = new List<Item>();

        cellContainer.SetActive(false);
        for (var i = 0; i < cellContainer.transform.childCount; i++)
        {
            items.Add(new Item());
        }

    }

    // Update is called once per frame
    void Update()
    {
        ToggelInventory();

        if (Input.GetKeyDown(takeInvent))
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 2f))
            {
                if (hit.collider.GetComponent<Item>())
                {
                    //вызвыли оповещение о подъеме предмета
                    Massage(hit.collider.GetComponent<Item>());
                    //добавили его
                    AddItem(hit.collider.GetComponent<Item>());
                }
            }
        }
    }

    void Massage(Item currentItem)
    {
        //инициализируем новый объект massage
        GameObject msgObj = Instantiate(massage);
        //удочеряем теперь massage к massageManager
        msgObj.transform.SetParent(massageManager.transform);
    }

    void AddUnStackableItem(Item currentItem)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].Id == 0)
            {
                //заносим элемент
                //items[i] = hit.collider.GetComponent<Item>();
                items[i] = currentItem;
                //присваиваем количество объектов придобавлении
                items[i].CountItem = 1;

                //отображаем наши Items
                DisplayItems();
                //удаляем его с экрана
                Destroy(currentItem.gameObject);
                //выходим из цикла
                break;
            }
        }
    }

    void AddStackableItem(Item currentItem)
    {
        //перебираем объекты
        for (int i = 0; i < items.Count; i++)
        {
            //находим с тем же id
            if (items[i].Id == currentItem.Id)
            {
                //увеличиваем +1
                items[i].CountItem++;
                //перерисовываем экран
                DisplayItems();
                //уничтожим объект со сцены
                Destroy(currentItem.gameObject);
                //вышли из метода
                return;
            }
        }
        //если не нашли стакающихся предметов
        AddUnStackableItem(currentItem);
    }

    void AddItem(Item currentItem)
    {
        if (currentItem.isStackable)
        {
            AddStackableItem(currentItem);
        }
        else
        {
            AddUnStackableItem(currentItem);
        }
    }

    void ToggelInventory()
    {
        if (Input.GetKeyDown(showInvent))
        {
            if (cellContainer.activeSelf)
            {
                cellContainer.SetActive(false);
            }
            else
            {
                cellContainer.SetActive(true);
            }
        }
    }

    void DisplayItems()
    {
        //перебор элементов коллекции
        for (int i = 0; i < items.Count; i++)
        {
            //получили доступ к i ячейке
            Transform cell = cellContainer.transform.GetChild(i);
            //получаем доступ к первому наследнику ячейки
            //в нашей иерархии это Icon
            Transform icon = cell.GetChild(0);

            //получаем доступ к первому наследнику Icon
            //в этом случае это Text
            Transform count = icon.GetChild(0);
            //получаем доступ к текстовому полю Text
            Text txt = count.GetComponent<Text>();

            //получили доступ к компоненту Image нашей ячейки
            Image img = icon.GetComponent<Image>();

            if (items[i].Id != 0)
            {
                //передаем ему нужное нам изображение из папки Resources
                img.sprite = Resources.Load<Sprite>(items[i].pathIcon);
                //включим отображение Image
                img.enabled = true;
                //при количестве предмета > 1 отображаем
                if (items[i].CountItem > 1)
                {
                    //отображаем количество объектов
                    txt.text = items[i].CountItem.ToString();
                }
            }
            else
            {
                img.enabled = false;
                img.sprite = null;
                txt.text = null;
            }
        }
    }
}
