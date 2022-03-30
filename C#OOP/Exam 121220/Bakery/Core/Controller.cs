﻿using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private List<IBakedFood> bakedFoods;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private decimal totalIncome = 0;

        public Controller()
        {
            bakedFoods = new List<IBakedFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            if (type == "Tea")
            {
                drinks.Add(new Tea(name, portion, brand));
            }
            if (type == "Water")
            {
                drinks.Add(new Water(name, portion,brand));
            }
            return $"Added {name} ({brand}) to the drink menu";
        }

        public string AddFood(string type, string name, decimal price)
        {
            if (type == "Bread")
            {
                bakedFoods.Add(new Bread(name, price));
            }
            else if (type == "Cake")
            {
                bakedFoods.Add(new Cake(name, price));
            }
            return $"Added {name} ({type}) to the menu";

        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            if (type == "InsideTable")
            {
                tables.Add(new InsideTable(tableNumber, capacity));
            }
            if (type == "OutsideTable")
            {
                tables.Add(new OutsideTable(tableNumber, capacity));
            }
            return $"Added table number {tableNumber} in the bakery";
        }

        public string GetFreeTablesInfo()
        {
            List<ITable> freeTables = tables.Where(x => x.IsReserved == false).ToList();
            var sb = new StringBuilder();
            foreach (var freeTable in freeTables)
            {
                 sb.AppendLine(freeTable.GetFreeTableInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return $"Total income: {totalIncome:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            decimal tableBill = table.GetBill();
            totalIncome += tableBill;
            table.Clear();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {tableBill:f2}");
            return sb.ToString().TrimEnd();

        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            if (table == null )
            {
                return $"Could not find table {tableNumber}";
            }
            IDrink drink = drinks.FirstOrDefault(x => x.Name == drinkName && x.Brand == drinkBrand);
            if (drink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }
            table.OrderDrink(drink);
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";

        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            if (table == null )
            {
                return $"Could not find table {tableNumber}";
            }
            IBakedFood food = bakedFoods.FirstOrDefault(x => x.Name == foodName);
            if (food == null)
            {
                return $"No {foodName} in the menu";
            }
            table.OrderFood(food);
            return $"Table {tableNumber} ordered {foodName}";

        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = tables.FirstOrDefault(x=>x.IsReserved==false && x.Capacity>=numberOfPeople);
            if (table==null)
            {
                return $"No available table for {numberOfPeople} people";
            }
            table.Reserve(numberOfPeople);
            return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";
        }
    }
}
