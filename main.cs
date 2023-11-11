using System;
using System.Collections.Generic;

// To execute C#, please define "static void Main" on a class
// named Solution.
enum VehicleType
{
    motorcycle = 1,
    car = 2,
    van = 3
}

enum TypeOfVacancy 
{
    smalVagancy = 1,
    simpleVagancy = 2,
    bigVagancy = 3
}

class Solution
{
    

    static void Main(string[] args)
    {
        Console.WriteLine("Bem vindo ao Estacionamento.");
        Console.WriteLine("Quantas vagas de moto estão disponíveis?");
        int totalMotorcycleParkingLot = int.Parse(Console.ReadLine());
        Console.WriteLine("Quantas vagas de Carro estão disponíveis?");
        int totalCarParkingLot = int.Parse(Console.ReadLine());
        Console.WriteLine("Quantas vagas de Van estão disponíveis?");
        int totalVanParkingLot = int.Parse(Console.ReadLine());

        Console.WriteLine(string.Format("A quantidade de vagas de moto é {0}, a quantidade de vagas de carro é {1}, a quantidade de vagas de van é {2}", totalMotorcycleParkingLot, totalCarParkingLot, totalVanParkingLot));
        

        Parking park = new Parking(totalMotorcycleParkingLot, totalCarParkingLot, totalVanParkingLot);
        string x = "";

        while(x != "0"){
            Console.WriteLine("1) Estacionar moto");
            Console.WriteLine("2) Estacionar carro");
            Console.WriteLine("3) Estacionar van");
            Console.WriteLine("4) Retirar moto");
            Console.WriteLine("5) Retirar carro");
            Console.WriteLine("6) Retirar van");
            Console.WriteLine("7) Quantas vagas Restam?");
            Console.WriteLine("8) Quantas vagas totais há no estacionamento?");
            Console.WriteLine("9) Estacionamento Cheio?");
            Console.WriteLine("10) Estacionamento vazio?");
            Console.WriteLine("11) Quais Categorias estão Cheias?");
            Console.WriteLine("12) Quantas Vagas as Vans Estão Ocupando?");

            x = Console.ReadLine();
            try
            {
                switch(x)
                {
                    case "1":
                        var motorcycle = new Motorcycle(1);
                        park.parking(motorcycle);
                    break;
                    case "2":
                        var car = new Car(1);
                        park.parking(car);
                    break;
                    case "3":
                        var van = new Van(1);
                        park.parking(van);
                    break;
                    case "4":
                        park.remove(VehicleType.motorcycle);
                    break;
                    case "5":
                        park.remove(VehicleType.car);
                    break;
                    case "6": 
                        park.remove(VehicleType.van);
                    break;
                    case "7":
                        var totalRemaning = park.remaningParkingMotorcycleSpaces() + park.remaningParkingSimpleSpaces() + park.remaningParkingBigSpaces();

                        Console.WriteLine(string.Format("A quantidade restante de vagas é de: {0}", totalRemaning));
                    break;
                    case "8":
                        var totalParkLot = park.totalParkingMotorcycleSpaces() + park.totalParkingSimpleSpaces() + park.totalParkingBigSpaces();

                        Console.WriteLine(string.Format("A quantidade Total de vagas é de: {0}", totalParkLot));
                    break;
                    case "9":
                        if (park.isParkingFull())
                        {
                            Console.WriteLine("O estacionamento está lotado (Cheio)!");
                        } else {
                            Console.WriteLine("O estacionamento não está lotado (Cheio)!");
                        }
                    break;

                    case "10":
                        if(park.IsParkingEmpty())
                        {
                            Console.WriteLine("O estacionamento está vazio!");
                        } else {
                            Console.WriteLine("O estacionamento não está vazio");
                        }
                    break;

                    case "11":
                        var arr = park.whichVagancyIsFull();

                        if (Array.Exists(arr, type => type == TypeOfVacancy.smalVagancy))
                        {
                            Console.WriteLine("Todas as vagas de Moto estão ocupadas!");
                        }
                        if (Array.Exists(arr, type => type == TypeOfVacancy.simpleVagancy))
                        {
                            Console.WriteLine("Todas as vagas de Carro estão ocupadas!");
                        }
                        if (Array.Exists(arr, type => type == TypeOfVacancy.bigVagancy))
                        {
                            Console.WriteLine("Todas as vagas de Van estão ocupadas!");
                        }
                    break;

                    case "12":
                        var totalBig = park.howManyBigVaganciesVansAreOccuped();
                        var totalSingle = park.howManySingleVaganciesVansAreOccuped();
                        Console.WriteLine(string.Format("As vans estão ocupando {0} vagas Grandes e {1} vagas Simples!", totalBig, totalSingle));
                    break;

                    case "0":
                    break;
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        Console.WriteLine(x);
        
    }
    public class Vehicle
    {
        public int occupation;
        public TypeOfVacancy vagancy {get; set;}
    }

    public class Motorcycle : Vehicle
    {
        public Motorcycle(int occupation)
        {
            this.occupation = occupation;
        }
    }
    
    public class Car : Vehicle 
    {
        public Car(int occupation)
        {
            this.occupation = occupation;
        }
    }

    public class Van : Vehicle {
        public Van(int occupation)
        {
            this.occupation = occupation;
        }
    }

    
    public class Parking  {
        private readonly int TotalMotorcycleParkingLot;
        private readonly int TotalSimpleParkingLot;
        private readonly int TotalBigParkingLot;
        
        private int RemaningMotorcycleParkingLot {get; set;}
        private int RemaningSimpleParkingLot {get; set;}
        private int RemaningBigParkingLot {get; set;}

        private List<Vehicle> vehicles;

        public Parking(int totalMotorcycleParkingLot, int totalSimpleParkingLot, int totalBigParkingLot){
            this.TotalMotorcycleParkingLot = totalMotorcycleParkingLot;
            this.RemaningMotorcycleParkingLot = totalMotorcycleParkingLot;

            this.TotalSimpleParkingLot = totalSimpleParkingLot;
            this.RemaningSimpleParkingLot = totalSimpleParkingLot;

            this.TotalBigParkingLot = totalBigParkingLot;
            this.RemaningBigParkingLot = totalBigParkingLot;
            this.vehicles = new List<Vehicle>();
        }

        public int remaningParkingMotorcycleSpaces(){
            return RemaningMotorcycleParkingLot;
        }

        public int totalParkingMotorcycleSpaces() {
            return TotalMotorcycleParkingLot;
        }

        public int remaningParkingSimpleSpaces()
        {
            return RemaningSimpleParkingLot;
        }

        public int totalParkingSimpleSpaces()
        {
            return TotalSimpleParkingLot;
        }

        public int remaningParkingBigSpaces()
        {
            return RemaningBigParkingLot;
        }

        public int totalParkingBigSpaces()
        {
            return TotalBigParkingLot;
        }

        public bool isParkingFull()
        {
            return ( RemaningMotorcycleParkingLot == 0 && RemaningSimpleParkingLot == 0 && RemaningBigParkingLot == 0);
        }

        public bool IsParkingEmpty()
        {
            return (RemaningMotorcycleParkingLot == TotalBigParkingLot && RemaningSimpleParkingLot == TotalSimpleParkingLot && RemaningBigParkingLot == TotalBigParkingLot );
        }

        public void parking(Motorcycle motorcycle)
        {
            if (RemaningMotorcycleParkingLot > 0)
            {
                motorcycle.vagancy = TypeOfVacancy.smalVagancy;
                vehicles.Add(motorcycle);
                RemaningMotorcycleParkingLot--;
                return;
            }

            if(RemaningSimpleParkingLot  > 0)
            {
                motorcycle.vagancy = TypeOfVacancy.simpleVagancy;
                vehicles.Add(motorcycle);
                RemaningSimpleParkingLot--;
                return;
            }

            if(RemaningBigParkingLot > 0 )
            {
                motorcycle.vagancy =  TypeOfVacancy.bigVagancy;
                vehicles.Add(motorcycle);
                RemaningBigParkingLot--;
                return;
            }
            throw new Exception("Não é possível Estacionar!");
        }
        public void parking(Car car)
        {
            if(RemaningSimpleParkingLot > 0)
            {
                car.vagancy = TypeOfVacancy.simpleVagancy;
                vehicles.Add(car);
                RemaningSimpleParkingLot--;
                return;
            }

            if(RemaningBigParkingLot > 0)
            {
                car.vagancy = TypeOfVacancy.bigVagancy;
                vehicles.Add(car);
                RemaningBigParkingLot--;
                return;
            }
            throw new Exception("Não é possível Estacionar!");
        }

        public void parking(Van van)
        {
            if(RemaningBigParkingLot > 0)
            {
                van.vagancy = TypeOfVacancy.bigVagancy;
                vehicles.Add(van);
                RemaningBigParkingLot--;
                return;
            }

            if(RemaningSimpleParkingLot - 3 > 0)
            {
                van.vagancy = TypeOfVacancy.simpleVagancy;
                vehicles.Add(van);
                RemaningSimpleParkingLot--;
                return;
            }

            throw new Exception("Não é possível Estacionar!");
        }
        private void freeParkingSpace(Vehicle vehicle)
        {
            switch(vehicle.vagancy)
            {
                case TypeOfVacancy.smalVagancy:
                    this.RemaningMotorcycleParkingLot++;
                break;
                case TypeOfVacancy.simpleVagancy:
                    if (vehicle is Van)
                        this.RemaningSimpleParkingLot += 3;
                    else
                        this.RemaningSimpleParkingLot++;
                break;
                case TypeOfVacancy.bigVagancy:
                    this.RemaningBigParkingLot++;
                break;
            }
        }

        public int howManyBigVaganciesVansAreOccuped()
        {
            var vans = vehicles.FindAll(v => v is Van && v.vagancy == TypeOfVacancy.bigVagancy);

            return vans.Count;
        }
        public int howManySingleVaganciesVansAreOccuped()
        {
            var vans = vehicles.FindAll(v => v is Van && v.vagancy == TypeOfVacancy.simpleVagancy);

            return vans.Count;
        }
        public TypeOfVacancy[] whichVagancyIsFull(){
            List<TypeOfVacancy> result = new List<TypeOfVacancy>();
            if (RemaningMotorcycleParkingLot == 0)
            {
                result.Add(TypeOfVacancy.smalVagancy);
            }
            if (RemaningSimpleParkingLot == 0)
            {
                result.Add(TypeOfVacancy.simpleVagancy);
            }
            if (RemaningBigParkingLot == 0)
            {
                result.Add(TypeOfVacancy.bigVagancy);
            }
            return result.ToArray();
        }
        public void remove(VehicleType vehicle){
            int index;
            switch(vehicle)
            {
                case VehicleType.motorcycle:
                    index = this.vehicles.FindIndex(c => c is Motorcycle);
                    freeParkingSpace(this.vehicles[index]);
                    this.vehicles.RemoveRange(index, 1);
                break;
                case VehicleType.car:
                    index = this.vehicles.FindIndex(c => c is Car);
                    freeParkingSpace(this.vehicles[index]);
                    this.vehicles.RemoveAt(index);
                break;
                case VehicleType.van:
                    index = this.vehicles.FindIndex(c => c is Van);
                    freeParkingSpace(this.vehicles[index]);
                    this.vehicles.RemoveAt(index);
                break;
            }
        }
    }
}

