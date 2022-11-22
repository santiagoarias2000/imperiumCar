using imperiumCar2.Data.Emun;
using imperiumCar2.Models;

namespace imperiunCar2.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var ServiceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = ServiceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();


                if (!context.CarBrands.Any())
                {
                    context.CarBrands.AddRange(new List<CarBrands>()
                   {
                        new CarBrands()
                        {
                            NameBrands = "BMW"
                        },
                        new CarBrands()
                        {
                            NameBrands = "Audi"
                        },
                        new CarBrands()
                        {

                            NameBrands = "Mercedes"
                        },
                        new CarBrands()
                        {

                            NameBrands = "Mazda"
                        },
                        new CarBrands()
                        {

                            NameBrands = "Toyota"
                        },  
                        new CarBrands()
                        {

                            NameBrands = "Nissan"
                        },
                        });
                    context.SaveChanges();
                }


                if (!context.TypesPersons.Any())
                {
                    context.TypesPersons.AddRange(new List<TypesPersons>()
                   {
                        new TypesPersons()
                        {
                            TypePersonName = "Cliente"

                        },
                        new TypesPersons()
                        {
                            TypePersonName = "Empleado"
                        },


                        });
                    context.SaveChanges();
                }






                if (!context.Persons.Any())
                {
                    context.Persons.AddRange(new List<Persons>()
                   {
                        new Persons()
                        {
                            Document ="1007434562",
                            Name ="Juan",
                            LastName = "Martinez",
                            PhoneNumber ="3132453476",
                            IdTypePerson= 1,

                        },

                        new Persons()
                        {
                            Document = "1002328376",
                            Name = "Santiago",
                            LastName = "Arias",
                            PhoneNumber = "3164448635",
                            IdTypePerson= 2,

                        },

                        new Persons()
                        {
                            Document ="100500935",
                            Name ="Nicolas",
                            LastName = "Mancilla",
                            PhoneNumber ="3152329812",
                            IdTypePerson = 1,
                        },

                        new Persons()
                        {
                            Document ="10046529854",
                            Name ="Alejandro",
                            LastName = "Cubides",
                            PhoneNumber ="3134562934",
                            IdTypePerson = 1,
                        },
                        new Persons()
                        {
                            Document ="10071923496",
                            Name ="Daniel",
                            LastName = "Barreto",
                            PhoneNumber ="3134560298",
                            IdTypePerson = 1,
                        },
                         new Persons()
                        {
                            Document ="10073482934",
                            Name ="Andres",
                            LastName = "Suarez",
                            PhoneNumber ="3208359287",
                            IdTypePerson = 1,
                        },

                        });
                    context.SaveChanges();
                }



                if (!context.Vehicle.Any())
                {
                    context.Vehicle.AddRange(new List<Vehicles>()
                   {
                        new Vehicles()
                        {
                            Imagen="",
                            Description="Carro deportivo de traccion trasera",
                            PriceBuy = 80000000,
                            PriceSale = 115000000,
                            ModelYear = "2020", 
                            //LLave foranea
                            IdCarsBrands = 1,
                            LicensePlate="ADS-234",
                            Sure = true,
                            TechnicalMechanical = true,
                            //TypesCars = enum
                            TypesCars = TypesCars.SportCar
                        },
                          new Vehicles()
                        {
                            Imagen="",
                            Description="Carro familiar traccion delantera",
                            PriceBuy = 85000000,
                            PriceSale = 12000000,
                            ModelYear = "2020", 
                            //LLave foranea
                            IdCarsBrands = 1,
                            LicensePlate="ASD-434",
                            Sure = true,
                            TechnicalMechanical = true,
                            //TypesCars = enum
                            TypesCars = TypesCars.Coupe
                        },
                            new Vehicles()
                        {
                            Imagen="",
                            Description="Camioneta platon pequeño",
                            PriceBuy = 6000000,
                            PriceSale = 80000000,
                            ModelYear = "2018",
                            IdCarsBrands = 1,
                            LicensePlate="rts-224",
                            Sure = true,
                            TechnicalMechanical = true,
                            TypesCars = TypesCars.SUV
                        },

                             new Vehicles()
                        {
                            Imagen="",
                            Description="Carro deportivo traccion delantera",
                            PriceBuy = 12000000,
                            PriceSale = 150000000,
                            ModelYear = "2021",
                            IdCarsBrands = 1,
                            LicensePlate="otr-454",
                            Sure = true,
                            TechnicalMechanical = true,
                            TypesCars = TypesCars.SUV
                        },

                        new Vehicles()
                        {
                            Imagen="",
                            Description="Carro todo terreno",
                            PriceBuy = 95000000,
                            PriceSale = 130000000,
                            ModelYear = "2019",
                            IdCarsBrands = 1,
                            LicensePlate="ujr-485",
                            Sure = true,
                            TechnicalMechanical = true,
                            TypesCars = TypesCars.SUV
                        },

                        new Vehicles()
                        {
                            Imagen="",
                            Description="Carro familiar con frenos rbs",
                            PriceBuy = 70000000,
                            PriceSale = 90000000,
                            ModelYear = "2016",
                            IdCarsBrands = 1,
                            LicensePlate="qmr-193",
                            Sure = true,
                            TechnicalMechanical = true,
                            TypesCars = TypesCars.SUV
                        },

                        });
                    context.SaveChanges();
                }


                if (!context.Contracts.Any())
                {
                    context.Contracts.AddRange(new List<Contracts>()
                   {
                        new Contracts()
                        {
                            SaleValue = 115000000,
                            Description="Venta de camioneta",
                            IdPersons = 1,
                            IdVehicle = 3,
                            TypesContracts = TypesContracts.Closed

                        },
                        new Contracts()
                        {
                            SaleValue = 115000000,
                            Description="Venta de carro",
                            IdPersons = 1,
                            IdVehicle = 1,
                            TypesContracts = TypesContracts.Open

                        },

                          new Contracts()
                        {
                            SaleValue = 150000000,
                            Description="Venta de carro",
                            IdPersons = 2,
                            IdVehicle = 5,
                            TypesContracts = TypesContracts.Open

                        },
                          new Contracts()
                        {
                            SaleValue = 130000000,
                            Description="Venta de camioneta ",
                            IdPersons = 5,
                            IdVehicle = 4,
                            TypesContracts = TypesContracts.Open

                        },
                          new Contracts()
                        {
                            SaleValue = 9000000,
                            Description="Venta de carro",
                            IdPersons = 3,
                            IdVehicle = 6,
                            TypesContracts = TypesContracts.Open

                        },

                           new Contracts()
                        {
                            SaleValue = 130000000,
                            Description="Venta de carro",
                            IdPersons = 5,
                            IdVehicle = 6,
                            TypesContracts = TypesContracts.Open

                        },

                        });
                    context.SaveChanges();

                    if (!context.Transfers.Any())
                    {
                        context.Transfers.AddRange(new List<Transfers>()
                   {
                        new Transfers()
                        {
                            ValueTrans = 12312,
                            IdVehicle = 1
                        },
                        new Transfers()
                        {
                            ValueTrans = 12342,
                            IdVehicle = 2
                        },
                        new Transfers()
                        {
                            ValueTrans = 13421,
                            IdVehicle = 3
                        },
                         new Transfers()
                        {
                            ValueTrans = 12987,
                            IdVehicle = 4
                        },
                          new Transfers()
                        {
                            ValueTrans = 12451,
                            IdVehicle = 5
                        },
                           new Transfers()
                        {
                            ValueTrans = 12765,
                            IdVehicle = 6
                        },
                        });
                        context.SaveChanges();
                    }
                }
            }

        }
    }
}
