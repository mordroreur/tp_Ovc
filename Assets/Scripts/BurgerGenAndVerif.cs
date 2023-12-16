using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class BurgerGenAndVerif : MonoBehaviour
{

    enum Ingredient
    {
        PainBas,
        PainHaut,
        Steak,
        Salade,
        Tomates,
        Fromage
    }

    public GameObject[] _prefabsIngredients;
    public Transform _baseBurger;
    private Ingredient[] _burger;
    private int _burgerSize;

    // Start is called before the first frame update
    void Start()
    {
        GenerateBurger();
        InstanciateBurger();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateBurger()
    {
        _burgerSize = Random.Range(4, 9);
        _burger = new Ingredient[_burgerSize];
        _burger[0] = Ingredient.PainBas;
        for(int i = 1; i < _burgerSize - 1; ++i)
        {
            _burger[i] = (Ingredient) Random.Range(2, System.Enum.GetValues(typeof(Ingredient)).Length);
        }
        _burger[_burgerSize - 1] = Ingredient.PainHaut;
    }

    void InstanciateBurger()
    {
        Transform previousIngredient = _baseBurger;
        foreach(Ingredient i in _burger)
        {
            previousIngredient = Instantiate(_prefabsIngredients[(int)i], previousIngredient).transform;
            previousIngredient = previousIngredient.GetChild(0);
        }
    }

    public void VerifyBurger(GameObject plateau)
    {
        GameObject nextPose = plateau.GetComponent<Transform>().Find("NextPose").gameObject;
        GameObject ingredient;
        Ingredient[] burgerDansPlateau = new Ingredient[100];
        int size = 0;

        while(nextPose.transform.childCount > 0)
        {
            ingredient = nextPose.transform.GetChild(0).gameObject;
            burgerDansPlateau[size++] = (Ingredient)ingredient.GetComponent<IngredientId>().GetId();
            nextPose = ingredient.transform.GetChild(0).gameObject;
        }

        if(_burger.SequenceEqual(burgerDansPlateau))
        {
            Debug.Log("gg");
        }
        else
        {
            Debug.Log("t'es une merde");
        }
    }
}
