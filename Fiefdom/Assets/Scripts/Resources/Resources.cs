using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Resources
{
    public class Resource
    {
        //Pseudo
        //tooltip
        //3d image

        public string name;
        public int quantity;
        public Sprite thumbnail;


        public Resource()
        {
            name = "";
            quantity = 0;
        }

        public Resource(string name, int quantity)
        {
            this.name = name;
            this.quantity = quantity;
        }
    }

    public class BuildingMaterial : Resource
    {
        public BuildingMaterialType type;

        public BuildingMaterial() : base()
        {

        }
    }

    public class Food : Resource
    {
        public Quality quality;

        public Food() : base()
        {

        }

        public Food(Quality quality) : base()
        {
            this.quality = quality;
        }
    }

    public class Drink : Resource
    {
        public Quality quality;
        public int abv;
        public DrinkCategory category;
        public FoodType type;

        public Drink() : base()
        {

        }

        public Drink(Quality quality, int abv) : base()
        {
            this.quality = quality;
            this.abv = abv;
        }
    }


    public enum BuildingMaterialType
    {
        Wood, Stone, Straw, Brick, Iron
    }

    public enum Quality
    {
        blank, Terrible, VeryLow, Low, Okay, High, VeryHigh, Perfect
    }

    public enum FoodCategory
    {
        blank, Fruit, Vegetable
    }

    public enum FoodType
    {
        blank
    }

    public enum DrinkCategory
    {
        blank, Juice, Beer, Wine, Cider
    }


    public static class Res
    {
        public static Reference r;

        public static void Initialize()
        {
            r = GameObject.Find("GameManager").GetComponent<Reference>();
        }

        public static BuildingMaterial Wood(int quantity)
        {
            BuildingMaterial wood = new BuildingMaterial();
            wood.name = "Wood";
            wood.quantity = quantity;
            wood.thumbnail = r.TN_Wood;
            wood.type = BuildingMaterialType.Wood;

            return wood;
        }

        public static BuildingMaterial Stone(int quantity)
        {
            BuildingMaterial stone = new BuildingMaterial();
            stone.name = "Stone";
            stone.quantity = quantity;
            stone.thumbnail = r.TN_Stone;
            stone.type = BuildingMaterialType.Stone;

            return stone;
        }
        
        public static BuildingMaterial Straw(int quantity)
        {
            BuildingMaterial straw = new BuildingMaterial();
            straw.name = "Straw";
            straw.quantity = quantity;
            straw.thumbnail = r.TN_Straw;
            straw.type = BuildingMaterialType.Straw;

            return straw;
        }

        public static BuildingMaterial Brick(int quantity)
        {
            BuildingMaterial brick = new BuildingMaterial();
            brick.name = "Brick";
            brick.quantity = quantity;
            brick.thumbnail = r.TN_Brick;
            brick.type = BuildingMaterialType.Brick;

            return brick;
        }

        public static BuildingMaterial Iron(int quantity)
        {
            BuildingMaterial iron = new BuildingMaterial();
            iron.name = "Iron";
            iron.quantity = quantity;
            iron.thumbnail = r.TN_Iron;
            iron.type = BuildingMaterialType.Iron;

            return iron;
        }


        public static Drink Beer(int quantity, Quality quality, int abv, FoodType type)
        {
            Drink beer = new Drink();
            beer.name = "Beer";
            beer.quantity = quantity;
            beer.quality = quality;
            beer.abv = abv;
            beer.category = DrinkCategory.Beer;
            beer.type = type;
            beer.thumbnail = r.TN_Beer;

            return beer;
        }
    }
}
