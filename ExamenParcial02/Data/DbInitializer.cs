using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HotelAGC.Models;

namespace HotelAGC.Data
{
    public static class DbInitializer
    {
        public static void Initialize(HotelContext context)
        {
            context.Database.EnsureCreated();

            // Look for any customers.
            if (context.Customers.Any())
            {
                return;   // DB has been seeded
            }

        //Customers
            var customers = new Customer[]
            {
                new Customer { CustomerTitle = "Ing.", CustomerForenames = "Alejandro", CustomerSurnames = "Garcia Cortes",
                    CustomerDOB = DateTime.Parse("1995-03-11"), CustomerAddressStreet = "Monterrey 24", CustomerAddressTown = "Zacatecas",
                    CustomerAddressCounty = "Guadalupe", CustomerAddressPostalCode = "98615", CustomerHomePhone = "492 926 5614",
                    CustomerWorkPhone = null, CustomerMobilePhone = "492 650 8190", CustomerEmail = "alejandroGC@gmail.com" },
                new Customer { CustomerTitle = "Lic.", CustomerForenames = "Diana", CustomerSurnames = "Escareño Luna",
                    CustomerDOB = DateTime.Parse("1993-11-20"), CustomerAddressStreet = "Fuentes 51", CustomerAddressTown = "Aguascalientes",
                    CustomerAddressCounty = "Aguascalientes", CustomerAddressPostalCode = "97995", CustomerHomePhone = "449 443 8096",
                    CustomerWorkPhone = "449 162 9831", CustomerMobilePhone = "449 210 8716", CustomerEmail = "dianaEL@gmail.com" },
                new Customer { CustomerTitle = "Ing.", CustomerForenames = "Carlos", CustomerSurnames = "Gonzalez Beltran",
                    CustomerDOB = DateTime.Parse("1980-01-10"), CustomerAddressStreet = "Gardenias 14", CustomerAddressTown = "Zacatecas",
                    CustomerAddressCounty = "Fresnillo", CustomerAddressPostalCode = "96005", CustomerHomePhone = "493 102 6176",
                    CustomerWorkPhone = null, CustomerMobilePhone = "493 110 7685", CustomerEmail = "carlosGB@gmail.com" },
                new Customer { CustomerTitle = "Dr.", CustomerForenames = "Celina", CustomerSurnames = "Reyes Delgado",
                    CustomerDOB = DateTime.Parse("1987-08-12"), CustomerAddressStreet = "12Octubre 56", CustomerAddressTown = "Zacatecas",
                    CustomerAddressCounty = "Guadalupe", CustomerAddressPostalCode = "98618", CustomerHomePhone = "492 187 7726",
                    CustomerWorkPhone = "492 901 7165", CustomerMobilePhone = "492 173 7862", CustomerEmail = null }
            };

            foreach (Customer ia in customers)
            {
                context.Customers.Add(ia);
            }
            context.SaveChanges();

        //Guest
            var guests = new Guest[]
            {
                new Guest { GuestTitle = "Ing.", GuestForenames = "Alejandro", GuestSurnames = "Garcia Cortes", GuestDOB = DateTime.Parse("1995-03-11"),
                    GuestAddressStreet = "Monterrey 24", GuestAddressTown = "Zacatecas", GuestAddressCounty = "Guadalupe", GuestAddressPostalCode = "98615",
                    GuestContactPhone = "492 650 8190" },
                new Guest { GuestTitle = "Sra.", GuestForenames = "Martha", GuestSurnames = "Escareño Perez", GuestDOB = DateTime.Parse("1991-06-01"),
                    GuestAddressStreet = "Gonzales Ortega 113", GuestAddressTown = "Zacatecas", GuestAddressCounty = "Guadalupe", GuestAddressPostalCode = "98256",
                    GuestContactPhone = "492 662 5410" },
                new Guest { GuestTitle = "Sr.", GuestForenames = "Ernesto", GuestSurnames = "Baez Beltran", GuestDOB = DateTime.Parse("1979-12-28"),
                    GuestAddressStreet = "Condesa 23", GuestAddressTown = "Zacatecas", GuestAddressCounty = "Fresnillo", GuestAddressPostalCode = "96700",
                    GuestContactPhone = "493 675 1273" },
                new Guest { GuestTitle = "Dr.", GuestForenames = "Celina", GuestSurnames = "Reyes Delgado", GuestDOB = DateTime.Parse("1987-08-12"),
                    GuestAddressStreet = "12Octubre 56", GuestAddressTown = "Zacatecas", GuestAddressCounty = "Guadalupe", GuestAddressPostalCode = "98618",
                    GuestContactPhone = "492 173 7862" }
            };

            foreach (Guest ib in guests)
            {
                context.Guests.Add(ib);
            }
            context.SaveChanges();
    
        //Booking
            var bookings = new Booking[]
            {
                new Booking { DateBookingMade = DateTime.Parse("2019-10-01"), TimeBookingMade = DateTime.Parse("11:02:13"),
                    BookedStartDate = DateTime.Parse("2019-10-11"), BookedEndDate =DateTime.Parse("2019-10-21"), TotalPaymentDueDate = DateTime.Parse("2019-11-11"), 
                    TotalPaymentDueAmount = 300, TotalPaymentMadeOn = DateTime.Parse("2019-10-30"), BookingComments = null, 
                    CustomerID = customers.Single(c => c.CustomerForenames == "Alejandro").CustomerID
                    },
                new Booking { DateBookingMade = DateTime.Parse("2019-12-22"), TimeBookingMade = DateTime.Parse("09:12:43"),
                    BookedStartDate = DateTime.Parse("2019-12-25"), BookedEndDate =DateTime.Parse("2020-01-07"), TotalPaymentDueDate = DateTime.Parse("2020-01-25"),
                    TotalPaymentDueAmount = 0, TotalPaymentMadeOn = DateTime.Parse("2019-12-22"), BookingComments = "La reservacion se pago el dia que fue realizada",
                    CustomerID = customers.Single(c => c.CustomerForenames == "Diana").CustomerID 
                    },
                new Booking { DateBookingMade = DateTime.Parse("2020-02-14"), TimeBookingMade = DateTime.Parse("08:32:13"),
                    BookedStartDate = DateTime.Parse("2020-03-03"), BookedEndDate =DateTime.Parse("2020-03-15"), TotalPaymentDueDate = DateTime.Parse("2020-04-03"),
                    TotalPaymentDueAmount = 700, TotalPaymentMadeOn = DateTime.Parse("2020-03-03"), BookingComments = "La reservacion se pago el dia que finalizo",
                    CustomerID = customers.Single(c => c.CustomerForenames == "Carlos").CustomerID
                    },
                new Booking { DateBookingMade = DateTime.Parse("2020-04-23"), TimeBookingMade = DateTime.Parse("12:47:53"),
                    BookedStartDate = DateTime.Parse("2020-04-30"), BookedEndDate =DateTime.Parse("2020-05-08"), TotalPaymentDueDate = DateTime.Parse("2020-05-30"),
                    TotalPaymentDueAmount = 500, TotalPaymentMadeOn = DateTime.Parse("2020-05-13"), BookingComments = null,
                    CustomerID = customers.Single(c => c.CustomerForenames == "Celina").CustomerID
                    }
            };

            foreach (Booking ic in bookings)
            {
                context.Bookings.Add(ic);
            }
            context.SaveChanges();

        //RoomType
            var roomtypes = new RoomType[]
            {
                new RoomType {roomType = roomType.Individual},
                new RoomType {roomType = roomType.Doble},
                new RoomType {roomType = roomType.Cuadruple},
                new RoomType {roomType = roomType.JuniorSuite},
                new RoomType {roomType = roomType.Suite},
                new RoomType {roomType = roomType.GranSuite}
            };

            foreach (RoomType id in roomtypes)
            {
                context.RoomTypes.Add(id);
            }
            context.SaveChanges();

        //RoomBand
            var roombands = new RoomBand[]
            {
                new RoomBand {BandDesc = "A"},
                new RoomBand {BandDesc = "AA"},
                new RoomBand {BandDesc = "AAA"},
                new RoomBand {BandDesc = "AAAA"},
                new RoomBand {BandDesc = "AAAAA"}
            };

            foreach (RoomBand ie in roombands)
            {
                context.RoomBands.Add(ie);
            }
            context.SaveChanges();

        //RoomPrice
            var roomprices = new RoomPrice[]
            {
                new RoomPrice {roomPrice = 500},
                new RoomPrice {roomPrice = 1000},
                new RoomPrice {roomPrice = 1800},
                new RoomPrice {roomPrice = 2000},
                new RoomPrice {roomPrice = 2400}
            };

            foreach (RoomPrice ig in roomprices)
            {
                context.RoomPrices.Add(ig);
            }
            context.SaveChanges();

        //Room
            var rooms = new Room[]
            {
                new Room {Floor = "2", AdditionalNotes = "Habitacion: Individual - Precio: $500 por dia",
                    RoomTypeID = roomtypes.Single( c => c.roomType == roomType.Individual).RoomTypeID,
                    RoomBandID = roombands.Single( i => i.BandDesc == "A").RoomBandID,
                    RoomPriceID = roomprices.Single( s => s.roomPrice == 500).RoomPriceID
                },
                new Room {Floor = "3", AdditionalNotes = "Habitacion: Doble - Precio: $1000 por dia",
                    RoomTypeID = roomtypes.Single( c => c.roomType == roomType.Doble).RoomTypeID,
                    RoomBandID = roombands.Single( i => i.BandDesc == "AA").RoomBandID,
                    RoomPriceID = roomprices.Single( s => s.roomPrice == 1000).RoomPriceID
                },
                new Room {Floor = "4", AdditionalNotes = "Habitacion: Cuadruple - Precio: $1800 por dia",
                    RoomTypeID = roomtypes.Single( c => c.roomType == roomType.Cuadruple).RoomTypeID,
                    RoomBandID = roombands.Single( i => i.BandDesc == "AAAA").RoomBandID,
                    RoomPriceID = roomprices.Single( s => s.roomPrice == 1800).RoomPriceID
                },
                new Room {Floor = "6", AdditionalNotes = "Habitacion: Suite - Precio: $2400 por dia",
                    RoomTypeID = roomtypes.Single( c => c.roomType == roomType.Suite).RoomTypeID,
                    RoomBandID = roombands.Single( i => i.BandDesc == "AAAAA").RoomBandID,
                    RoomPriceID = roomprices.Single( s => s.roomPrice == 2400).RoomPriceID
                } 
            };

            foreach (Room ih in rooms)
            {
                context.Rooms.Add(ih);
            }
            context.SaveChanges();
        
        //BookingRoom
            var bookingsrooms = new BookingRoom[]
            {
                new BookingRoom { 
                    BookingID = bookings.Single(c => c.DateBookingMade == DateTime.Parse("2019-10-01")).BookingID,
                    RoomID = rooms.Single(i => i.Floor == "2").RoomID,
                    GuestID = guests.Single(s => s.GuestForenames == "Alejandro").GuestID
                },
                new BookingRoom { 
                    BookingID = bookings.Single(c => c.DateBookingMade == DateTime.Parse("2019-12-22")).BookingID,
                    RoomID = rooms.Single(i => i.Floor == "3").RoomID,
                    GuestID = guests.Single(s => s.GuestForenames == "Martha").GuestID
                },
                new BookingRoom { 
                    BookingID = bookings.Single(c => c.DateBookingMade == DateTime.Parse("2020-02-14")).BookingID,
                    RoomID = rooms.Single(i => i.Floor == "4").RoomID,
                    GuestID = guests.Single(s => s.GuestForenames == "Ernesto").GuestID
                },
                new BookingRoom { 
                    BookingID = bookings.Single(c => c.DateBookingMade == DateTime.Parse("2020-04-23")).BookingID,
                    RoomID = rooms.Single(i => i.Floor == "6").RoomID,
                    GuestID = guests.Single(s => s.GuestForenames == "Celina").GuestID
                }
            };

            foreach (BookingRoom i in bookingsrooms)
            {
                context.BookingsRooms.Add(i);
            }
            context.SaveChanges();

            foreach (BookingRoom ix in bookingsrooms)
            {
                var bookingroomInDataBase = context.BookingsRooms.Where(
                    z =>
                            z.Booking.BookingID == ix.BookingID &&
                            z.Room.RoomID == ix.RoomID &&
                            z.Guest.GuestID == ix.GuestID).SingleOrDefault();
                if (bookingroomInDataBase == null)
                {
                    context.BookingsRooms.Add(ix);
                }
            }
            context.SaveChanges();

        //PaymentMethod
            var paymentmethods = new PaymentMethod[]
            {
                new PaymentMethod {paymentMethod = "Efectivo"},
                new PaymentMethod {paymentMethod = "Tarjeta de Credito o Debito"},
                new PaymentMethod {paymentMethod = "Transferencia Bancaria"},
                new PaymentMethod {paymentMethod = "Paypal"}
            };

            foreach (PaymentMethod ip in paymentmethods)
            {
                context.PaymentMethods.Add(ip);
            }
            context.SaveChanges();

        //Payment
            var payments = new Payment[]
            {
                new Payment {PaymentAmount = 6000, PaymentComments = "Pago saldado totalmente",
                    BookingID = bookings.Single(c => c.DateBookingMade == DateTime.Parse("2019-10-01")).BookingID,
                    CustomerID = customers.Single(i => i.CustomerForenames == "Alejandro").CustomerID,
                    PaymentMethodID = paymentmethods.Single(s => s.paymentMethod == "Efectivo").PaymentMethodID
                    },
                new Payment {PaymentAmount = 5000, PaymentComments = "Pago saldado totalmente",
                    BookingID = bookings.Single(c => c.DateBookingMade == DateTime.Parse("2019-12-22")).BookingID,
                    CustomerID = customers.Single(i => i.CustomerForenames == "Diana").CustomerID,
                    PaymentMethodID = paymentmethods.Single(s => s.paymentMethod == "Transferencia Bancaria").PaymentMethodID
                    },
                new Payment {PaymentAmount = 10000, PaymentComments = "Pago saldado parcialmente",
                    BookingID = bookings.Single(c => c.DateBookingMade == DateTime.Parse("2020-02-14")).BookingID,
                    CustomerID = customers.Single(i => i.CustomerForenames == "Carlos").CustomerID,
                    PaymentMethodID = paymentmethods.Single(s => s.paymentMethod == "Efectivo").PaymentMethodID
                    },
                new Payment {PaymentAmount = 6000, PaymentComments = "Pago saldado totalmente",
                    BookingID = bookings.Single(c => c.DateBookingMade == DateTime.Parse("2020-04-23")).BookingID,
                    CustomerID = customers.Single(i => i.CustomerForenames == "Celina").CustomerID,
                    PaymentMethodID = paymentmethods.Single(s => s.paymentMethod == "Paypal").PaymentMethodID
                    }
            };

            foreach (Payment iq in payments)
            {
                context.Payments.Add(iq);
            }
            context.SaveChanges();
            
        //FacilitieList
            var facilitielists = new FacilitieList[]
            {
                new FacilitieList {FacilityDesc = "(1)Cama individual - (1)TV - Telefono - Refrigerador - Microondas - Internet - Cafetera - Otros muebles"},
                new FacilitieList {FacilityDesc = "(2)Cama individual - (1)TV - Telefono - Refrigerador - Microondas - Internet - Cafetera - Plancha - Otros muebles"},
                new FacilitieList {FacilityDesc = "(4)Cama individual - (2)TV - Telefono - Refrigerador - Microondas - Internet - Cafetera - Plancha - Otros muebles"},
                new FacilitieList {FacilityDesc = "(2)Cama matrimonial - (2)TV - Telefono - (1)Computadora - Refrigerador - Microondas - Internet - Cafetera - Plancha - Jacuzzi - Otros muebles"},
                new FacilitieList {FacilityDesc = "(2)Cama matrimonial - (1)TV - Telefono - (1)Computadora- Refrigerador - Microondas - Internet - Cafetera - Plancha - Otros muebles"},
                new FacilitieList {FacilityDesc = "(2)Cama king-size - (2)TV - Telefono - (2)Computadora - Refrigerador - Microondas - Internet - Cafetera - Plancha,  Jacuzzi - Alberca - Otros muebles"}
            };

            foreach (FacilitieList io in facilitielists)
            {
                context.FacilitieLists.Add(io);
            }
            context.SaveChanges();

        //RoomFacilities
            var roomsfacilities = new RoomFacilities[]
            {
                new RoomFacilities {FacilityDetails = "Incluye servicios basicos",
                RoomID = rooms.Single(c => c.Floor == "2").RoomID,
                FacilityID = facilitielists.Single(s => s.FacilityDesc == "(1)Cama individual - (1)TV - Telefono - Refrigerador - Microondas - Internet - Cafetera - Otros muebles").FacilityID,
                },
                new RoomFacilities {FacilityDetails = "Incluye servicios basicos",
                RoomID = rooms.Single(c => c.Floor == "3").RoomID,
                FacilityID = facilitielists.Single(s => s.FacilityDesc == "(2)Cama individual - (1)TV - Telefono - Refrigerador - Microondas - Internet - Cafetera - Plancha - Otros muebles").FacilityID,
                },
                new RoomFacilities {FacilityDetails = "Incluye servicios basicos + extra",
                RoomID = rooms.Single(c => c.Floor == "4").RoomID,
                FacilityID = facilitielists.Single(s => s.FacilityDesc == "(4)Cama individual - (2)TV - Telefono - Refrigerador - Microondas - Internet - Cafetera - Plancha - Otros muebles").FacilityID,
                },
                new RoomFacilities {FacilityDetails = "Incluye servicios basicos + extra",
                RoomID = rooms.Single(c => c.Floor == "6").RoomID,
                FacilityID = facilitielists.Single(s => s.FacilityDesc == "(2)Cama matrimonial - (2)TV - Telefono - (1)Computadora - Refrigerador - Microondas - Internet - Cafetera - Plancha - Jacuzzi - Otros muebles").FacilityID
                }
            };

            foreach (RoomFacilities im in roomsfacilities)
            {
                context.RoomsFacilities.Add(im);
            }
            context.SaveChanges();

            foreach (RoomFacilities ir in roomsfacilities)
            {
                var roomfacilitiesInDataBase = context.RoomsFacilities.Where(
                    w =>
                            w.Room.RoomID == ir.RoomID &&
                            w.FacilitieList.FacilityID == ir.FacilityID).SingleOrDefault();
                if (roomfacilitiesInDataBase == null)
                {
                    context.RoomsFacilities.Add(ir);
                }
            }
            context.SaveChanges();
        }
    }
}