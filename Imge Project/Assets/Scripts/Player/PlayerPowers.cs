using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPowers : MonoBehaviour
{
    // List of Player`s powers
    private List<PowerUpInteractable.Power> listPowers;
    private Shooting weapons;
    private PlayerHealth _health;
    private Enemy[] _enemies;
    [SerializeField] private GameObject vendingMachine;
    [SerializeField] private Image dashImage;
    [SerializeField] private Image invisibilityImage;
    [SerializeField] private Image fadedDashImage;
    [SerializeField] private Image fadedInvisibilityImage;


    void Start()
    {
        listPowers = new List<PowerUpInteractable.Power>();
        _health = FindObjectOfType<PlayerHealth>().GetComponent<PlayerHealth>();
        invisibilityImage.enabled = false;
        fadedDashImage.enabled = false;
        fadedInvisibilityImage.enabled = false;
    }

    public void addPower(PowerUpInteractable.Power power)
    {
        if (!listPowers.Contains(power))
        {
            listPowers.Add(power);
            switch (power)
            {
                case PowerUpInteractable.Power.MoreDamage:
                    addDamage();
                    break;
                case PowerUpInteractable.Power.MoreHealth:
                    addHealth();
                    break;
                case PowerUpInteractable.Power.Dash:
                    dashImage.enabled = true;
                    fadedDashImage.enabled = true;
                    break;
                case PowerUpInteractable.Power.Invisibility:
                    invisibilityImage.enabled = true;
                    fadedInvisibilityImage.enabled = true;
                    break;
            }
        }
    }

    public void removePower(PowerUpInteractable.Power power)
    {
        if (listPowers.Contains(power)) listPowers.Remove(power);
        fadedInvisibilityImage.enabled = false;
    }

    public bool hasPower(PowerUpInteractable.Power power)
    {
        return listPowers.Contains(power);
    }

    private void addHealth()
    {
        _health.currentHealth = 8;
        _health.maxHealth = 8;
    }

    private void addDamage()
    {
        weapons = FindObjectOfType<Shooting>();
        weapons.damage = (int)(1.5 * weapons.damage);
    }

    public IEnumerator becomeInvisible()
    {
        _enemies = FindObjectsOfType<Enemy>();
        invisibilityImage.enabled = false;
        for (int i = 0; i < _enemies.Length; i++)
        {
            _enemies[i].playerInvisible = true;
            _enemies[i].Stop();
        }

        yield return new WaitForSeconds(8);
        for (int i = 0; i < _enemies.Length; i++)
        {
            _enemies[i].WalkAgain();
            _enemies[i].playerInvisible = false;
        }
        removePower(PowerUpInteractable.Power.Invisibility);
        vendingMachine.GetComponent<BoxCollider>().enabled = true;
    }
}
