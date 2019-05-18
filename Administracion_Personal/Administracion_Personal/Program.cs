using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admimistracion_Personal
{
    class Program
    {
        static void Main(string[] args){
            List<Empleados> Personas = new List<Empleados>();
            int contador = 1;
            //------------------------------AGREGAR EMPLEADOS
            Console.WriteLine("-----Ingrese la cantidad de empleados: ");
            int cant_Per = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < cant_Per; i++){
                Console.WriteLine("-----Ingrese los datos del empleado [" + contador + "]: ");
                Console.WriteLine("-----Ingrese el nombre: ");
                string n_emp = Convert.ToString(Console.ReadLine());
                Console.WriteLine("-----Ingrese el apellido: ");
                string a_emp = Convert.ToString(Console.ReadLine());
                Console.WriteLine("-----Ingrese la fecha de ingreso: ");
                string f_emp = Convert.ToString(Console.ReadLine());
                Console.WriteLine("-----Ingrese el sueldo: ");
                double s_emp = Convert.ToDouble(Console.ReadLine());
                string c_emp = "";

                Personas.Add(new Empleados() { nombre = n_emp, apellido = a_emp, F_Ingreso = f_emp, sueldo_Base = s_emp, cargo = c_emp });
                
            }
            //------------------------------MOSTRAR EMPLEADOS
            for (int i = 0; i < cant_Per; i++) {
                Console.WriteLine(Personas[i].ToString());
            }
            Console.WriteLine("Cantidad de empleados: "+ Personas.Count);
            //------------------------------BUSCAR EMPLEADOS
            Console.WriteLine("--Escriba el nombre completo: ");
            string nom_bus = Convert.ToString(Console.ReadLine());
            String[] partes_nom = nom_bus.Split(' ');

            if (Personas.Exists(x => x.nombre == partes_nom[0]) == true && Personas.Exists(x => x.apellido == partes_nom[1]) == true){
                Console.WriteLine(Personas.Where(x => x.nombre == partes_nom[0]).FirstOrDefault()); //Busco el contacto
            }
            else Console.WriteLine("--No exite el empleado");
            //------------------------------ELIMINAR EMPLEADOS
            Console.WriteLine("--Escriba el nombre completo: ");
            string nom_elim = Convert.ToString(Console.ReadLine());
            partes_nom = nom_elim.Split(' ');

            if (Personas.Exists(x => x.nombre == partes_nom[0]) == true && Personas.Exists(x => x.apellido == partes_nom[1]) == true){
                Personas.Remove(Personas.Where(x => x.nombre == partes_nom[0]).FirstOrDefault()); //Busco el contacto
            }
            else Console.WriteLine("--No exite el empleado");
            Console.ReadKey();
        }
        public struct Empleados
        {
            public string nombre;
            public string apellido;
            public string F_Ingreso;
            public double sueldo_Base;
            public string cargo;

            //Constructor de la estrucutura 
            public Empleados(string _nom, string _ape, string _Fech, double _sueldo, string _cargo){
                nombre = _nom;
                apellido = _ape;
                F_Ingreso = _Fech;
                sueldo_Base = _sueldo;
                cargo = _cargo;
            }
            //Funcion para mostrar en pantalla los empleados
            public override String ToString(){
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("--- Nombre: {0}, Apellido: {1}, Fecha de Ingreso: {2}, Sueldo Base: {3},  Cargo: {4}", nombre, apellido, F_Ingreso, sueldo_Base, cargo);
                return (sb.ToString());
            }

        }
        //enum Trabajo{Aux="Auxiliar", Adm="Administrativo", Ing="Ingeniero", Esp="Especialista", Inv="Investigador"};
        enum Trabajo { Aux, Adm, Ing, Esp, Inv };
    }
}
