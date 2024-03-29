﻿using Pizza.Admin.Factory;
using Pizza.Interface.Service;
using Pizza.Model.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizza.Admin
{
    public class Application
    {
        private readonly IPizzaOrderService pizzaService;

        public Application(IPizzaOrderService pizzaService)
        {
            this.pizzaService = pizzaService;
        }

        public async Task Run(string[] args)
        {
            char keyPress;
            do
            {
                Console.WriteLine(" 1. Add Large Pizza to Orders");
                Console.WriteLine(" 2. Add Small Pizza to Orders");
                Console.WriteLine(" 3. Add Two Small Pizza to Orders");
                Console.WriteLine(" 4. Get All");
                Console.WriteLine(" 5. Get All With Details");
                Console.WriteLine(" 6. Get All For Harrison");
                Console.WriteLine(" 7. Give Johns To Ringos");
                Console.WriteLine(" 8. Get Count");
                Console.WriteLine(" 9. AllWithTime");
                Console.WriteLine(" q. Get Stats");
                ;

                Console.WriteLine(" 0. Exit");
                keyPress = Console.ReadKey().KeyChar;

                switch (keyPress)
                {
                    case '1':
                        await pizzaService.AddOrder(LargePizzaFactory.Create());
                        break;

                    case '2':
                        await pizzaService.AddOrder(SmallPizzaFactory.Create());
                        break;

                    case '3':
                        await pizzaService.AddMultipleOrder(new List<PizzaOrderDTO>() { SmallPizzaFactory.Create(), SmallPizzaFactory.Create() });
                        break;

                    case '4':
                        var allPizzas = await pizzaService.GetAll();

                        foreach (var item in allPizzas)
                        {
                            Console.WriteLine($" Base {item.BaseType} {item.SauceType} {item.SizeInCM} ");
                        }

                        break;
                    case '5':
                        var allPizzasWithDetails = await pizzaService.GetAllWithDetails();

                        foreach (var item in allPizzasWithDetails)
                        {
                            Console.WriteLine($" Base: {item.BaseType} SauceType: {item.SauceType} Size: {item.SizeInCM}cm Created: {item.Created}  LastModified: {item.LastModified}  ");
                        }
                        break;

                    case '6':
                        var allPizzasForHarrision = await pizzaService.GetAllForHarrison();

                        foreach (var item in allPizzasForHarrision)
                        {
                            Console.WriteLine($" Base: {item.BaseType} SauceType: {item.SauceType} Size: {item.SizeInCM}cm For: {item.GivenName} {item.SurName}  ");
                        }
                        break;

                    case '7':
                        await pizzaService.GiveJohnsToRingos();
                        break;
                    case '8':
                        Console.WriteLine($" John Lennon: {  await pizzaService.GetPizzaOrderCountBySurName("Lennon") }");
                        Console.WriteLine($" Paul Mccartney: {  await pizzaService.GetPizzaOrderCountBySurName("Mccartney") }");
                        Console.WriteLine($" George Harrison: {  await pizzaService.GetPizzaOrderCountBySurName("Harrison") }");
                        Console.WriteLine($" Ringo Starr: {  await pizzaService.GetPizzaOrderCountBySurName("Starr") }");
                        break;

                    case '9':
                        var allWithTime = await pizzaService.GetAllWithTime();
                        foreach (var item in allWithTime)
                        {
                            Console.WriteLine($" Base: {item.BaseType} SauceType: {item.SauceType} Size: {item.SizeInCM}cm For:  {item.HowOld.ToString()}min {item.HowOldHours}hours  ");
                        }
                        break;

                    case 'q':
                        var pizzaOrderStats = await pizzaService.GetPizzaOrderStats();
                        foreach (var item in pizzaOrderStats)
                        {
                            Console.WriteLine($" Base: {item.BaseType} SauceType: {item.SauceType} Size: {item.SizeInCM}cm For: TotalOrders  {item.TotalOrders}  ");
                        }
                        break;
                    default:
                        break;
                }
            } while (keyPress != 0);
        }
    }
}