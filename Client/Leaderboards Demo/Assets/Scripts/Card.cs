using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Card : MonoBehaviour
{    
    public int Id;
    public Sprite cardImage {
        get {
            return transform.Find("Image").GetComponent<SpriteRenderer>().sprite;
        }
        set {
            
            transform.Find("Image").GetComponent<SpriteRenderer>().sprite = value;
        }
    }
    public event System.EventHandler<System.EventArgs> onClick;
    private bool _isSelected;
    public bool isSelected {
        get {
            return _isSelected;
            }
        set {         
           _isSelected = value;
        
           Vector3 scaleVector = value ? new Vector3(1.3f, 1.3f, 1.3f) : new Vector3(1,1,1); 
           transform.DOScale(scaleVector, 0.2f);
        }
    }

    private bool _allowsSelection = true;

    [SerializeField]
    public bool allowsSelection
    {
        get { return _allowsSelection;}
        set { _allowsSelection = value;}
    }
      

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
   {
       if (allowsSelection) {
       isSelected = !isSelected;
       if (onClick != null)
       {
           onClick(this, null);
       }
       }
   }

}
