using CatalystSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBookHandler : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private SpellBook _spellbook;
    private BoxCollider2D _boxCollider;

    public bool PickedUp;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spellbook = GetComponent<SpellBook>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (PickedUp)
        {
            _boxCollider.enabled = false;
            _spriteRenderer.enabled = false;
        }

        _spriteRenderer.sprite = _spellbook.Icon;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PickUpSpellbook();
        }
    }

    public void PickUpSpellbook()
    {
        //transform.parent = TempPlayerController.Instance.transform;
        transform.localPosition = Vector3.zero;
        //var tempVessel = TempPlayerController.Instance.SpellbookVessel;
        //tempVessel.GetComponent<SpellBookHandler>().Drop();
        //TempPlayerController.Instance.Refresh();
        PickedUp = true;
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
        transform.localScale = new Vector3(.6f, .6f, .6f);
        _spriteRenderer.color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSeconds(0.75f);
        _spriteRenderer.color = Color.white;
        _boxCollider.enabled = true;
    }
}
