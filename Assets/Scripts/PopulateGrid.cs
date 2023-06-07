using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateGrid : MonoBehaviour
{
    public GameObject itemPrefab;

    private HttpClient client = new HttpClient();

    void Start()
    {
        List<Character> list = client.FetchCharacters();

        foreach (Character item in list) 
        {
            GameObject go = AddChild(itemPrefab);
            go.GetComponent<CharacterItem>().Set(item);
        }
    }

    private GameObject AddChild(GameObject prefab)
    {
        GameObject go = Instantiate(prefab, Vector3.zero, Quaternion.identity);
        if (go != null)
        {
            Transform transform = go.transform;

            transform.SetParent(gameObject.transform);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.localScale = Vector3.one;
            go.layer = gameObject.layer;

            go.GetComponent<RectTransform>().sizeDelta = 
                prefab.GetComponent<RectTransform>().sizeDelta;
        }
        go.GetComponent<RectTransform>().anchoredPosition = 
            prefab.GetComponent<RectTransform>().anchoredPosition;

        return go;
    }
}
