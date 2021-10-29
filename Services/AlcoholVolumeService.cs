using System;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;

namespace Services
{
    public class AlcoholVolumeService
    {
        public string Calculate(Somebody alguien)
        {
            //Definimos nuestras variables e inicializmos otras que ocuparemos mas adelante.
            
            var _bebida = alguien.Bebida.ToLower();
            var _cantidad = alguien.Cantidad;
            var _peso = alguien.Peso;

            var ml = 0;
            var apml = 0;

            //Aqui condicionamos para que la bebida sea una de las que conocemos sus mililitros y su grado tambien se asigna para ser usados mas adelante

            switch (_bebida)
            {
                case "cerveza": ml = 330; apml = 5; break;
                case "vino": ml = 100; apml = 12; break;
                case "cava": ml = 100; apml = 12; break;
                case "vermu": ml = 70; apml = 17; break;
                case "licor": ml = 45; apml = 23; break;
                case "brandy": ml = 45; apml = 38; break;
                case "combinado": ml = 50; apml = 38; break;

                case null: return ("No se recibio el valor de la bebida");
                default: return ("Bebida invalida");

            }
            //Calcular el totoal de alcohol consumido
            var totalconsumido = _cantidad*ml;

            //calcula el total de alcohol por cerveza consumido
            
            var totalporbebida = (apml*totalconsumido)/100;

            //Calcular alcohol que pasa directo a la sangre

            var alcoholasangre = (15*totalporbebida)/100;

            //Calcular masa de etanol en sangre

            var etanolensangre = 0.789*alcoholasangre;

            //calcular volumen de la sangre

            var volumensangre = (8*_peso)/100;

            //calcular alcoholemia

            var alcoholemia = etanolensangre/volumensangre;

            //Definimos si pued eviajar o no.
            
            if(alcoholemia>0.8)
            {
                return ($"Tu volumen en alcohol en la sangre es de {alcoholemia.ToString("F")}. Por lo que no estas en condiciones para conducir");
            }
            return ($"Tu volumen en alcohol en la sangre es de {alcoholemia.ToString("F")}. Buen viaje");



            
        }
    }
}