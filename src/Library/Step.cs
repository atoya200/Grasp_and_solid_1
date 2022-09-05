//-------------------------------------------------------------------------------
// <copyright file="Step.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------------

namespace Full_GRASP_And_SOLID.Library
{
    public class Step
    {
        public Step(Product input, double quantity, Equipment equipment, int time)
        {
            this.Quantity = quantity;
            this.Input = input;
            this.Time = time;
            this.Equipment = equipment;
        }

        public Product Input { get; set; }

        public double Quantity { get; set; }

        public int Time { get; set; }

        public Equipment Equipment { get; set; }

        /* 
            Step conoce a Equipment y conoce al Producto, entonces conoce
            la cantidad de proudctos así como su precio unitario; en el caso del equipamiento, 
            sabe cuanto cuesta usarlo po una hora. Por ende, por Expert puede calcular un subtotal
            de cuanto cuesta ese paso, sumando el precio de la materia prima y el costo de usar
            el equipo.  
         */

        public double SubTotalStep()
        {
            /*
            Considerando que el tiempo esta en minutos, se debe de dividir ese valor por 60.
            Para así pasarlo a horas y operar en las mismas unidades de tiempo. 
            Considerando que en las recetas las cantidad suelen estar en gramos o en mL (depende el caso),
            habría que convertir esos gramos o mL a Kg y a L, para poder operar mejor.
            Esto ser haría dividiendo por 1000
            
            */
            return (Input.UnitCost/1000) * Quantity + (Time / 60) * Equipment.HourlyCost;
        }
    }
}