﻿using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using claseJson;

monedas();

static void monedas(){
    var url = $"https://api.coindesk.com/v1/bpi/currentprice.json";
    var request = (HttpWebRequest)WebRequest.Create(url);
    request.Method = "GET";
    request.ContentType = "application/json";
    request.Accept = "application/json";
    try{
        using (WebResponse response = request.GetResponse())
        {
            using (Stream strReader = response.GetResponseStream())
            {
                if (strReader == null) return;
                using (StreamReader objReader = new StreamReader(strReader))
                {
                    string responseBody = objReader.ReadToEnd();
                    //System.Console.WriteLine(responseBody);
                    Root Precios = JsonSerializer.Deserialize<Root>(responseBody);
                    System.Console.WriteLine("CAMBIOS:");
                    System.Console.WriteLine(" -"+Precios.bpi.EUR.description+": "+Precios.bpi.EUR.rate_float);
                    System.Console.WriteLine(" -"+Precios.bpi.GBP.description+": "+Precios.bpi.GBP.rate_float);
                    System.Console.WriteLine(" -"+Precios.bpi.USD.description+": "+Precios.bpi.USD.rate_float);
                    System.Console.WriteLine("Moneda Dolar:");
                    System.Console.WriteLine(" -Simbolo: "+Precios.bpi.USD.symbol);
                    System.Console.WriteLine(" -Descripcion: "+Precios.bpi.USD.description);
                    System.Console.WriteLine(" -Rate: "+Precios.bpi.USD.rate);
                    System.Console.WriteLine(" -Rate float: "+Precios.bpi.USD.rate_float);
                    System.Console.WriteLine(" -Codigo: "+Precios.bpi.USD.code);
                }
            }
        }
    }
    catch (WebException ex){
        Console.WriteLine("Problemas de acceso a la API");
    }
}