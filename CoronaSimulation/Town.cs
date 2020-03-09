using System;

namespace Entity 
{
    public class Town {
        const double gamma = 0.25;
        private int day { get; set; }
        private int population { get; set; }
        public bool isInfected;

        public Town(int p) {
            this.day = 0;
            this.population = p;
            this.isInfected = false;
        }
        public double infectedPopulation(int time) { //Logistic Func I
            return ((double) population / (1 + Math.Pow(Math.Exp(population - 1), (-1) * gamma * time)));
        }
        public static double virusSpread(double I, double Tr) { //S
            return (I * Tr);
        }

    }
}