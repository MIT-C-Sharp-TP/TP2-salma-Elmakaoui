
using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static event Action Collected;

    [SerializeField] private float rotationSpeed = 90f;
    [SerializeField] private GameObject collectEffect;

    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (collectEffect != null)
            Instantiate(
                collectEffect,
                transform.position,
                Quaternion.identity
            );

        Collected?.Invoke();
        Destroy(gameObject);
    }
}
