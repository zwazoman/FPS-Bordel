
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    #region PlayerMain Link
    [SerializeField] PlayerMain _main;
    #endregion

    [Header("Base Stats")]

    [SerializeField] public float baseSpeed;
    [SerializeField] public float maxhealth;
    [SerializeField] public float baseJumpForce;



    [HideInInspector] public float speed;
    [HideInInspector] public float health;
    [HideInInspector] public float jumpForce;

    //public void Apply
    private void Awake()
    {
        if (_main == null)
            TryGetComponent(out _main);

        health = maxhealth;

        speed = baseSpeed;
        jumpForce = baseJumpForce;
    }

    public void ApplyDamage(float damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
            Die();
    }

    public void ApplyHeal(float healAmount)
    {
        health += healAmount;

        if(health >= maxhealth)
            health = maxhealth;
    }

    void Die()
    {
        print("Die");
    }


}
