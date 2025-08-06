using Data;
using System;
using System.Linq;

namespace Web.Models.EmailTemplates
{
    public class CroatianEmailTemplates
    {
        public static string OrderConfirmationTemplate(Order order)
        {
            return $@"
<html>
<head>
    <style>
        body {{
            font-family: Arial, sans-serif;
            color: #333;
            background-color: #f8f8f8;
            margin: 0;
            padding: 0;
        }}
        .container {{
            width: 100%;
            padding: 20px;
            box-sizing: border-box;
        }}
        .header {{
            background: linear-gradient(135deg, #dc3545 0%, #c82333 100%);
            color: white;
            padding: 30px 20px;
            text-align: center;
            border-radius: 8px 8px 0 0;
        }}
        .header h1 {{
            margin: 0;
            font-size: 28px;
        }}
        .order-details {{
            background-color: #ffffff;
            padding: 30px 20px;
            border-radius: 0 0 8px 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            margin-bottom: 20px;
        }}
        .order-details h2 {{
            color: #dc3545;
            font-size: 24px;
            margin-bottom: 20px;
        }}
        .order-details p {{
            font-size: 16px;
            line-height: 1.6;
            margin: 8px 0;
        }}
        .order-table {{
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
            background: white;
        }}
        .order-table th, .order-table td {{
            padding: 12px;
            text-align: left;
            border: 1px solid #ddd;
        }}
        .order-table th {{
            background-color: #dc3545;
            color: white;
        }}
        .order-summary {{
            margin-top: 20px;
            font-size: 16px;
            background: #f8f9fa;
            padding: 20px;
            border-radius: 8px;
        }}
        .order-summary strong {{
            color: #dc3545;
        }}
        .footer {{
            margin-top: 30px;
            padding: 20px;
            background: #f8f9fa;
            border-radius: 8px;
            text-align: center;
            font-size: 14px;
            color: #666;
        }}
        .company-info {{
            margin-top: 15px;
            font-size: 12px;
            color: #888;
        }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h1>NALLAN.HR</h1>
            <p>Hvala vam na kupovini!</p>
        </div>

        <div class='order-details'>
            <h2>Poštovani/a {order.CustomerName},</h2>
            <p>Hvala vam što ste odabrali NALLAN.HR za svoju kupovinu. Vaša narudžba je uspješno zaprimljena i uskoro će biti obrađena.</p>
            
            <p><strong>Broj narudžbe:</strong> {order.OrderId}</p>
            <p><strong>Datum narudžbe:</strong> {order.OrderDate:dd.MM.yyyy HH:mm}</p>
            <p><strong>Način plaćanja:</strong> {(order.PaymentType == "CORVUSPAY" ? "Kartično plaćanje" : "Plaćanje pouzećem")}</p>
        </div>

        <h3>Detalji narudžbe:</h3>
        <table class='order-table'>
            <thead>
                <tr>
                    <th>Proizvod</th>
                    <th>Šifra</th>
                    <th>Veličina</th>
                    <th>Cijena</th>
                    <th>Količina</th>
                    <th>Ukupno</th>
                </tr>
            </thead>
            <tbody>
                {string.Join("", order.OrderItems.Select(item => $@"
                    <tr>
                        <td>{item.ProductName}</td>
                        <td>{item.ProductCode}</td>
                        <td>{item.Size}</td>
                        <td>{item.Price:F2} €</td>
                        <td>{item.Quantity}</td>
                        <td>{(item.Price * item.Quantity):F2} €</td>
                    </tr>
                "))}
            </tbody>
        </table>

        <div class='order-summary'>
            <p><strong>Međuzbroj: </strong>{order.TotalPrice:F2} €</p>
            <p><strong>Dostava: </strong>{(order.TransportFee == 0 ? "Besplatno" : $"{order.TransportFee:F2} €")}</p>
            <p><strong>Ukupno: </strong>{(order.TotalPrice + order.TransportFee):F2} €</p>
        </div>

        <div class='order-details'>
            <h3>Podaci za dostavu:</h3>
            <p><strong>Ime:</strong> {order.CustomerName}</p>
            <p><strong>Adresa:</strong> {order.ShippingAddress}</p>
            <p><strong>Grad:</strong> {order.ShippingCity}</p>
            <p><strong>Poštanski broj:</strong> {order.ShippingPostalCode}</p>
            <p><strong>Država:</strong> {order.ShipingCountry}</p>
            <p><strong>Telefon:</strong> {order.PhoneNumber}</p>
        </div>

        <div class='footer'>
            <p><strong>Dostava:</strong> Vaša narudžba će biti dostavljena putem GLS kurirske službe u roku od 2-5 radnih dana.</p>
            <p><strong>Praćenje pošiljke:</strong> Dobit ćete SMS/email obavještenje s brojem za praćenje kada pošiljka bude otpremljena.</p>
            <p>Za sva pitanja kontaktirajte nas na <strong>hello@nallan.hr</strong> ili <strong>+385 989 968 721</strong></p>
            
            <div class='company-info'>
                <p><strong>Gianna Shoes d.o.o.</strong><br>
                Samoborska cesta 145, 10000 Zagreb, Hrvatska<br>
                OIB: 27743781662 | Trgovački sud u Zagrebu<br>
                www.nallan.hr</p>
            </div>
        </div>
    </div>
</body>
</html>";
        }

        public static string InternalOrderNotificationTemplate(Order order)
        {
            return $@"
<html>
<head>
    <style>
        body {{
            font-family: Arial, sans-serif;
            color: #333;
            background-color: #f8f8f8;
            margin: 0;
            padding: 0;
        }}
        .container {{
            width: 100%;
            padding: 20px;
            box-sizing: border-box;
        }}
        .header {{
            background: #dc3545;
            color: white;
            padding: 20px;
            text-align: center;
        }}
        .order-details {{
            background-color: #ffffff;
            padding: 20px;
            margin: 20px 0;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }}
        .order-table {{
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }}
        .order-table th, .order-table td {{
            padding: 10px;
            text-align: left;
            border: 1px solid #ddd;
        }}
        .order-table th {{
            background-color: #f4f4f4;
            color: #333;
        }}
        .urgent {{
            background: #fff3cd;
            border: 1px solid #ffeaa7;
            padding: 15px;
            border-radius: 5px;
            margin: 15px 0;
        }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h1>Nova narudžba - NALLAN.HR</h1>
            <p>Zaprimljena je nova narudžba #{order.OrderId}</p>
        </div>

        <div class='order-details'>
            <h2>Detalji kupca</h2>
            <p><strong>Ime:</strong> {order.CustomerName}</p>
            <p><strong>Email:</strong> {order.CustomerEmail}</p>
            <p><strong>Telefon:</strong> {order.PhoneNumber}</p>
            <p><strong>Adresa:</strong> {order.ShippingAddress}, {order.ShippingCity} {order.ShippingPostalCode}</p>
            <p><strong>Država:</strong> {order.ShipingCountry}</p>
            <p><strong>Način plaćanja:</strong> {(order.PaymentType == "CORVUSPAY" ? "Kartično plaćanje" : "Plaćanje pouzećem")}</p>
            <p><strong>Datum narudžbe:</strong> {order.OrderDate:dd.MM.yyyy HH:mm}</p>
            {(order.PaymentType == "CORVUSPAY" ? $"<p><strong>ID transakcije:</strong> {order.TransactionId}</p>" : "")}
        </div>

        {(order.PaymentType == "CORVUSPAY" ?
            "<div class='urgent'><strong>NAPOMENA:</strong> Ova narudžba je plaćena karticom - prioritetno procesirati!</div>" :
            "")}

        <h3>Stavke narudžbe:</h3>
        <table class='order-table'>
            <thead>
                <tr>
                    <th>Proizvod</th>
                    <th>Šifra</th>
                    <th>Veličina</th>
                    <th>Cijena</th>
                    <th>Količina</th>
                    <th>Ukupno</th>
                    <th>GTN</th>
                </tr>
            </thead>
            <tbody>
                {string.Join("", order.OrderItems.Select(item => $@"
                    <tr>
                        <td>{item.ProductName}</td>
                        <td>{item.ProductCode}</td>
                        <td>{item.Size}</td>
                        <td>{item.Price:F2} €</td>
                        <td>{item.Quantity}</td>
                        <td>{(item.Price * item.Quantity):F2} €</td>
                        <td>{item.GTN}</td>
                    </tr>
                "))}
            </tbody>
        </table>

        <div class='order-details'>
            <p><strong>Međuzbroj:</strong> {order.TotalPrice:F2} €</p>
            <p><strong>Dostava:</strong> {order.TransportFee:F2} €</p>
            <p><strong>UKUPNO:</strong> {(order.TotalPrice + order.TransportFee):F2} €</p>
        </div>

        <div class='order-details'>
            <h3>Sljedeći koraci:</h3>
            <ol>
                <li>Provjeri dostupnost artikala</li>
                <li>Pripremi pošiljku</li>
                <li>Generiraj GLS naljepnicu</li>
                <li>Pošalji klijentu tracking broj</li>
            </ol>
        </div>
    </div>
</body>
</html>";
        }
    }
}