using CatalystSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatalystHandler : MonoBehaviour {

    private SpriteRenderer _spriteRenderer;
    private Catalyst _catalyst;
    private BoxCollider2D _boxCollider;

    public bool PickedUp;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _catalyst = GetComponent<Catalyst>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (PickedUp)
        {
            _boxCollider.enabled = false;
            _spriteRenderer.enabled = false;
        }
        _spriteRenderer.sprite = _catalyst.Icon;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            PickUpCatalyst();
        }
    }

    public void PickUpCatalyst()
    {
        //transform.parent = TempPlayerController.Instance.transform;
        //transform.localPosition = Vector3.one;
        //var tempVessel = TempPlayerController.Instance.CatalystVessel;
        //tempVessel.GetComponent<CatalystHandler>().Drop();
        //TempPlayerController.Instance.Refresh();
        //this.PickedUp = true;
    }

    public void Drop()
    {
        StartCoroutine(Reactivate());
    }
    public IEnumerator Reactivate()
    {
        transform.parent = null;
        PickedUp = false;
        _spriteRenderer.enabled = true;
        transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        _spriteRenderer.color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSeconds(0.75f);
        _spriteRenderer.color = Color.white;
        _boxCollider.enabled = true;
    }
}
