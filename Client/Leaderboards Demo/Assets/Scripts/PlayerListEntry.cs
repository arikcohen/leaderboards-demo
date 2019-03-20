using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerListEntry : MonoBehaviour
{
    // Start is called before the first frame update

    public string Name
    {
        get
        {
            return transform.Find("Name").GetComponent<TextMeshProUGUI>().text;
        }
        set
        {
            transform.Find("Name").GetComponent<TextMeshProUGUI>().text = value;
        }
    }

    private bool _isSelected;
    public bool

    IsSelected
    {

        get { return _isSelected; }
        set
        {
            _isSelected = value;
            Color newCol;
            if (value)
                ColorUtility.TryParseHtmlString("#02C50050", out newCol);
            else
                ColorUtility.TryParseHtmlString("#0028C580", out newCol);

            transform.GetComponent<Image>().color = newCol;
        }

    }



    private string _bucket;
    public string Bucket
    {
        get { return _bucket; }
        set
        {
            _bucket = value;
            transform.Find("Bucket").GetComponent<TextMeshProUGUI>().text = "Bucket: " + value;
        }
    }

    public event System.EventHandler<System.EventArgs> onClick;

    void OnMouseDown()
    {
        if (onClick != null)
        {
            onClick(this, null);
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
