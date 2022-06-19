﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_9
{
    internal static class MenuService
    {
        static public bool TryGetMenuTotalSum(Menu menu, PriceCurrent priceCurrent, Course course, 
                                              out decimal menuTotalPrice)
        // find the total price for a given menu (one copy of all dishes)
        {
            menuTotalPrice = 0.0m; // what if "default" is not zero? :) We need zero
            for (int i = 0; i < menu.Length; i++)
            {
                if (!TryGetDishPrice(menu[i], priceCurrent, course, out decimal sumPrice))
                {
                    return false;
                }
                menuTotalPrice += sumPrice;
            }
            return true;
        }

        static public bool TryGetDishPrice(Dish dish, PriceCurrent priceCurrent, Course course, 
                                           out decimal sumPrice)
            // find the total price of a given dish
        {
            sumPrice = 0.0m; // what if "default" is not zero? :) We need zero
            foreach (string key in dish.keys)
            {
                if (!priceCurrent.TryGetProductPrice(key, out decimal productPrice))
                {
                    return false;
                }
                // dish[key] is the weight of the dish with the name "key"
                // product prices are for 1 kg, weights are in grams, so we divide by 1000
                sumPrice += ((productPrice * dish[key] / course.GetCourse(Course.currentCurrency)) / 1000m);
            }
            return true;
        }

        static public string PrintListOfDishesWithPrices(Menu menu, PriceCurrent priceCurrent, Course course, 
                                                         out decimal menuTotalPrice)
        {
            string result = "";
            menuTotalPrice = 0.0m;
            for (int i = 0; i < menu.Length; i++)
            {
                if (!TryGetDishPrice(menu[i], priceCurrent, course, out decimal sumPrice))
                {
                    return "";
                }
                menuTotalPrice += sumPrice;
                result += $"{menu[i].GetDishName()} -- {sumPrice:f2} {Course.currentCurrency}\r\n";
            }
            return result;
        }
    }
}
