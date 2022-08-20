using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponActions : MonoBehaviour
{
    public GameObject[] Weapons;

    public int CurrentWeaponIndex;

    public GameObject CurrentWeapon;

    public AudioClip[] WeaponSounds;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject weapon in Weapons)
        {
            weapon.SetActive(false); 
        }
        CurrentWeapon = Weapons[0];
        CurrentWeapon.SetActive(true);
    }

    public void ChangeIndex(int value)
    {
        CurrentWeaponIndex += (value);
    }

    public void ShowCurrentWeapon()
    {
        if (CurrentWeaponIndex > Weapons.Length - 1)
            CurrentWeaponIndex = 0;
        
        if (CurrentWeaponIndex < 0)
            CurrentWeaponIndex = Weapons.Length-1;
        foreach (GameObject weapon in Weapons)
        {
            if(weapon.activeInHierarchy)                 
                weapon.SetActive(false);
        }
        CurrentWeapon = Weapons[CurrentWeaponIndex];         
        CurrentWeapon.SetActive(true);
    }

    public void PlaySound(AudioClip clip)
    {
        GetComponent<AudioSource>().PlayOneShot(clip);
    } 
    
    // Update is called once per frame
    void Update()
    {
        ShowCurrentWeapon(); 
    }
}
