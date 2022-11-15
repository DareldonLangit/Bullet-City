using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponSelect : MonoBehaviour
{

    public int selectedWeapon;
    public Weapons[] weapons;
    public Text PistolText;
    public Text AssaultText;
    public Text coinsText;
    public Text coinsText2;
    public GameObject Pistolimage;
    public GameObject Assaultimage;

    private void Awake()
    {
        selectedWeapon = PlayerPrefs.GetInt("SelectedWeapon", 0);

        foreach(Weapons c in weapons)
        {
            if(c.price == 0)
            {
                c.isUnlocked = true;
            }
            else
            {
                
                c.isUnlocked = PlayerPrefs.GetInt(c.name, 0) == 0 ? false : true;
            }
        }
        UpdateUI();
    }

    //private void Start()
    //{
    //    PlayerPrefs.SetInt("NumberOfCoins", 75000);
    //    Debug.Log("The Coins: " + PlayerPrefs.GetInt("NumberOfCoins"));

    //}


    public void EquipPistol()
    {


        if (weapons[selectedWeapon].isUnlocked == true)
        {
            selectedWeapon = 1;
            PlayerPrefs.SetInt("SelectedWeapon", selectedWeapon);
            Assaultimage.SetActive(false);
            Pistolimage.SetActive(true);

        }

    }

    public void BuyPistol()
    {
        int coins = PlayerPrefs.GetInt("NumberOfCoins", 0);
        int price = weapons[selectedWeapon].price;

        foreach (Weapons c in weapons)
        {
            if (PlayerPrefs.GetInt("NumberOfCoins", 0) >= price && !c.isUnlocked)
            {
                PlayerPrefs.SetInt("NumberOfCoins", coins - price);
                
                PlayerPrefs.SetInt(weapons[selectedWeapon].name, 1);
                selectedWeapon = 1;
                PlayerPrefs.SetInt("SelectedWeapon", selectedWeapon);
                c.isUnlocked = true;
                PistolText.text = "BOUGHT";
            }
            else
            {
                c.isUnlocked = PlayerPrefs.GetInt(c.name, 0) == 0 ? false : true;
            }
        }
        UpdateUI();
    }

    public void EquipAssault()
    {
        
        if (weapons[selectedWeapon].isUnlocked)
        {
            selectedWeapon = 0;
            PlayerPrefs.SetInt("SelectedWeapon", selectedWeapon);
            Pistolimage.SetActive(false);
            Assaultimage.SetActive(true);
        }
    }

    public void BuyAssault()
    {
        int coins = PlayerPrefs.GetInt("NumberOfCoins", 0);
        int price = weapons[selectedWeapon].price;


        foreach (Weapons c in weapons)
        {
            if (PlayerPrefs.GetInt("NumberOfCoins", 0) >= price && !c.isUnlocked)
            {
                PlayerPrefs.SetInt("NumberOfCoins", coins - price);
                
                PlayerPrefs.SetInt(weapons[selectedWeapon].name, 1);
                selectedWeapon = 0;
                PlayerPrefs.SetInt("SelectedWeapon", selectedWeapon);
                c.isUnlocked = true;
                AssaultText.text = "BOUGHT";
            }
            else
            {
                c.isUnlocked = PlayerPrefs.GetInt(c.name, 0) == 0 ? false : true;
            }
        }
        UpdateUI();
        //skins[selectedWeapon].SetActive(false);
        //selectedWeapon = 0;
        
        //skins[selectedWeapon].SetActive(true);
        /** if (weapons[selectedWeapon].isUnlocked)
        {
            PlayerPrefs.SetInt("SelectedWeapon", selectedWeapon);
        }
        UpdateUI(); **/
    }




    public void UpdateUI()
    {
        coinsText.text = " " + PlayerPrefs.GetInt("NumberOfCoins", 0);
        coinsText2.text = " " + PlayerPrefs.GetInt("NumberOfCoins", 0);
        
        if (weapons[0].isUnlocked)
        {
            AssaultText.text = "BOUGHT";
        }
        if (weapons[1].isUnlocked)
        {
            PistolText.text = "BOUGHT";
        }

        /** if (weapons[selectedWeapon].isUnlocked == true)
         {
             unlockButton.gameObject.SetActive(false);
         }
         else
         {
             unlockButton.GetComponentInChildren<TextMeshProUGUI>().text = "Price: " + weapons[selectedWeapon].price;
             if (PlayerPrefs.GetInt("NumberOfCoins", 0) < weapons[selectedWeapon].price)
             {
                 unlockButton.gameObject.SetActive(true);
                 unlockButton.interactable = false;
             }
             else 
             {
                 unlockButton.gameObject.SetActive(true);
                 unlockButton.interactable = true;
             }
         }**/
    }
    public void Unlock()
    {
        int coins = PlayerPrefs.GetInt("NumberOfCoins", 0);
        int price = weapons[selectedWeapon].price;
        PlayerPrefs.SetInt("NumberOfCoins", coins - price);
        PlayerPrefs.SetInt(weapons[selectedWeapon].name, 1);
        PlayerPrefs.SetInt("SelectedWeapon", selectedWeapon);
        weapons[selectedWeapon].isUnlocked = true;
        UpdateUI();

    }
}
