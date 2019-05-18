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
            //------------------------------AGREGAR EMPLEADOS
            Agregar_Emp(Personas);        
            
            //------------------------------MOSTRAR EMPLEADOS
            Console.WriteLine("\n----------EMPLEADOS: \n");
            for (int i = 0; i < Personas.Count; i++) {
                Console.WriteLine(Personas[i].ToString());
            }
            Console.WriteLine("Cantidad de empleados: "+ Personas.Count);
            //------------------------------BUSCAR EMPLEADOS
            Buscar_Emp(Personas);
            
            //------------------------------ELIMINAR EMPLEADOS
            Eliminar_Emp(Personas);
            
            Console.ReadKey();
        }
        public struct Empleados
        {
            public string nombre;
            public string apellido;
            public string F_Nac;
            public string Est_Civil;
            public string Genero;
            public string F_Ingreso;
            public double sueldo_Base;
            public string cargo;

            //Constructor de la estrucutura 
            public Empleados(string _nom, string _ape, string _FechN, string _Est, string _G ,string _FechI, double _sueldo, string _cargo){
                nombre = _nom;
                apellido = _ape;
                F_Nac = _FechN;
                Est_Civil = _Est;
                Genero = _G;
                F_Ingreso = _FechI;
                sueldo_Base = _sueldo;
                cargo = _cargo;
            }
            //Funcion para mostrar en pantalla los empleados
            public override String ToString(){
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("--- Nombre: {0}, Apellido: {1}, Fecha de Nacimiento: {2}, Estado Civil: {3}, Genero: {4},Fecha de Ingreso: {5}, Sueldo Base: ${6},  Cargo: {7}", nombre, apellido, F_Nac, Est_Civil,Genero ,F_Ingreso, sueldo_Base, cargo);
                return (sb.ToString());
            }
  

        }
        enum Trabajo { Auxiliar, Administrativo, Ingeniero, Especialista, Investigador};

        //------------------------------AGREGAR EMPLEADOS
        static void Agregar_Emp(List<Empleados> Personas){
            int contador = 1;
            
            Console.WriteLine("-----Ingrese la cantidad de empleados: ");
            int cant_Per = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < cant_Per; i++)
            {
                Console.WriteLine("-----Ingrese los datos del empleado [" + contador + "]: ");
                //Nombre
                Console.WriteLine("-----Ingrese el nombre: ");
                string n_emp = Convert.ToString(Console.ReadLine());
                //Apellido
                Console.WriteLine("-----Ingrese el apellido: ");
                string a_emp = Convert.ToString(Console.ReadLine());
                //Fecha de Nacimiento
                Console.WriteLine("-----Ingrese la fecha de Nacimiento: ");
                string fn_emp = Convert.ToString(Console.ReadLine());
                //Genero
                string g_emp = Genero();
                //Estado Civil
                string e_emp = Estado_Civil(g_emp);
                //Fecha de Ingreso
                Console.WriteLine("-----Ingrese la fecha de ingreso: ");
                string fi_emp = Convert.ToString(Console.ReadLine());
                //Sueldo
                Console.WriteLine("-----Ingrese el sueldo: ");
                double s_emp = Convert.ToDouble(Console.ReadLine());
                //Cargo
                Console.WriteLine("-----Ingrese el cargo ([0]Auxiliar, [1]Administrativo, [2]Ingeriero, [3]Especialista, [4]Investigador) : ");
                int opcion = Convert.ToInt32(Console.ReadLine());
                Trabajo cargo = (Trabajo)opcion;
                string c_emp = Convert.ToString(cargo);

                Personas.Add(new Empleados() { nombre = n_emp, apellido = a_emp, F_Nac=fn_emp, Est_Civil=e_emp, Genero=g_emp ,F_Ingreso = fi_emp, sueldo_Base = s_emp, cargo = c_emp });//Agrego los datos del empleado
                contador++;
            }
        }
        //------------------------------BUSCAR EMPLEADOS
        static void Buscar_Emp(List<Empleados> Personas) {
            Console.WriteLine("--Escriba el nombre completo: ");
            string nom_bus = Convert.ToString(Console.ReadLine());
            String[] partes_nom = nom_bus.Split(' ');
            //Me fijo que el empleado exista
            while(!Personas.Exists(x => x.nombre == partes_nom[0]) && !Personas.Exists(x => x.apellido == partes_nom[1])){
                Console.WriteLine("--No exite el empleado\nIngrese otro nombre\n--Escriba el nombre completo: ");
                nom_bus = Convert.ToString(Console.ReadLine());
                partes_nom = nom_bus.Split(' ');
            }
            Console.WriteLine(Personas.Where(x => x.nombre == partes_nom[0]).FirstOrDefault()); //Busco el empleado
        }
        //------------------------------ELIMINAR EMPLEADOS
        static void Eliminar_Emp(List<Empleados> Personas)
        {
            Console.WriteLine("--Escriba el nombre completo: ");
            string nom_elim = Convert.ToString(Console.ReadLine());
            String[] partes_nom = nom_elim.Split(' ');
            //Me fijo que el empleado exista
            while (!Personas.Exists(x => x.nombre == partes_nom[0]) && !Personas.Exists(x => x.apellido == partes_nom[1]))
            {
                Console.WriteLine("--No exite el empleado\nIngrese otro nombre\n--Escriba el nombre completo: ");
                nom_elim = Convert.ToString(Console.ReadLine());
                partes_nom = nom_elim.Split(' ');
            }
            Personas.Remove(Personas.Where(x => x.nombre == partes_nom[0]).FirstOrDefault()); //Elimino el empleado
        }
        //Veo el Estado civil
        static string Estado_Civil(string g_emp) {
            Console.WriteLine("-----Ingrese el estado civil: ");
            Char Opcion=Convert.ToChar(Console.ReadLine());
            while (Opcion != 'C' && Opcion != 'c' && Opcion != 'S' && Opcion != 's') {
                Console.WriteLine("---Opcion Incorrecta - Por favor ingrese una opcion valida\n-----Ingrese el estado civil: ");
                Opcion=Convert.ToChar(Console.ReadLine());
            }
            string Estado = "";
            if (g_emp.Contains("Masculino") == true)
            {
                switch (Opcion)
                {
                    case 's':
                    case 'S':
                        Estado = "Soltero";
                        break;
                    case 'c':
                    case 'C':
                        Estado = "Casado";
                        break;
                }
            }
            else {
                switch (Opcion)
                {
                    case 's':
                    case 'S':
                        Estado = "Soltera";
                        break;
                    case 'c':
                    case 'C':
                        Estado = "Casada";
                        break;
                }
            }
            return Estado;
        }
        //Veo el Genero
        static string Genero()
        {
            Console.WriteLine("-----Ingrese el genero: ");
            Char Opcion = Convert.ToChar(Console.ReadLine());
            while (Opcion != 'M' && Opcion != 'm' && Opcion != 'F' && Opcion != 'f')
            {
                Console.WriteLine("---Opcion Incorrecta - Por favor ingrese una opcion valida\n-----Ingrese el estado civil: ");
                Opcion = Convert.ToChar(Console.ReadLine());
            }
            string Genero = "";
            switch (Opcion)
            {
                case 'M':
                case 'm':
                    Genero = "Masculino";
                    break;
                case 'F':
                case 'f':
                    Genero = "Femenino";
                    break;
            }
            return Genero;
        }
        
    }
}
