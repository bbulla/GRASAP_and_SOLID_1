namespace Full_GRASP_And_SOLID.Library
{
    public class ProductionCost
    {
        public double GetProductionCost(Recipe recipe)
        {
            double totalCostOfInputs = CalculateTotalCostOfInputs(recipe);
            double totalCostOfEquipment = CalculateTotalCostOfEquipment(recipe);

            return totalCostOfInputs + totalCostOfEquipment;
        }

        private double CalculateTotalCostOfInputs(Recipe recipe)
        {
            double totalCost = 0;
            foreach (Step step in recipe.Steps)
            {
                totalCost += step.Quantity * step.Input.UnitCost;
            }
            return totalCost;
        }

        private double CalculateTotalCostOfEquipment(Recipe recipe)
        {
            double totalCost = 0;
            foreach (Step step in recipe.Steps)
            {
                totalCost += (step.Time / 60.0) * step.Equipment.HourlyCost;
            }
            return totalCost;
        }
    }
}

//Creo esta clase nueva para calcular el costo de producción y así poder seguir el principio SOLID de "Single Responsibility Principle" (Principio de Responsabilidad Única). 
//Esto significa que estoy asignando esta responsabilidad a una clase que está específicamente diseñada para realizar cálculos de costos y no mezclarla con las clases de Equipment, Product, Recipe o Step.