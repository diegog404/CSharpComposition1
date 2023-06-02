using CSharpComposition1.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpComposition1.Entities
{
    internal class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }

        //associação com Department
        public Department Department { get; set; }

        //associação com uma lista de HourContract por serem varios contratos
        public List<HourContract> Contracts { get; set; } = new List<HourContract>();

        public Worker()
        {

        }

        public Worker(string name, WorkerLevel level, double baseSalary, Department department)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        //recebe como parâmetro um contrato que será adicionado a lista
        public void AddContract(HourContract contract)
        {
            Contracts.Add(contract);
        }

        public void removeContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }

        public double Income(int year, int month)
        {
            //recebe o salario base, pois o funcionario sempre terá esse salário no mês
            double sum = BaseSalary;

            //a soma vai receber o total value de cada contrato na lista, baseado no mês e ano escolhido
            foreach(HourContract contract in Contracts)
            {
                if(contract.Date.Year == year && contract.Date.Month == month)
                {
                    sum += contract.TotalValue();
                }
            }

            return sum;
        }
    }
}
