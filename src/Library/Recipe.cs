//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;
using System.Text;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

      

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        public void PrintRecipe()
        {
            StringBuilder text = new StringBuilder($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                text.Append($"\n{step.Quantity}g de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time} minutos");
            }
            text.Append($"\nEl costo total de la producción de este alimento es de {GetProductionCost()} pesos"); 
            Console.WriteLine(text);
        }


        /* 
            Como Recipe puede acceder a la información de cada paso, teniendo este a su vez
            la información del subtotal o el total de ese paso, por Expert, la clase más 
            capacitada para calcular el costo completo es la de Recipe.
         */

         public double GetProductionCost()
         {
            double totalCost = 0;
            foreach(Step var in this.steps)
            {
                totalCost += var.SubTotalStep();
            }
            return totalCost;

         }
    }
}