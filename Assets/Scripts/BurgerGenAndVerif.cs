using System.Collections;
using System.Collections.Generic;
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
}
