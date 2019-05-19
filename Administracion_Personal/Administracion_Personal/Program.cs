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
            int contador = 1;
            for (int i = 0; i < Personas.Count; i++) {
               Console.WriteLine("----Empleado n°"+ contador +": \n");
               Personas[i].Mostrar();
               contador++;
            }
            Console.WriteLine("Cantidad de empleados: "+ Personas.Count);
            Console.WriteLine("Monto total: ", Monto_Total(Personas));
            Menu(Personas);
            
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
                this.nombre = _nom;
                this.apellido = _ape;
                this.F_Nac = _FechN;
                this.Est_Civil = _Est;
                this.Genero = _G;
                this.F_Ingreso = _FechI;
                this.sueldo_Base = _sueldo;
                this.cargo = _cargo;
            }
            //Funcion para mostrar en pantalla los empleados     
            public void Mostrar() {
                Console.WriteLine("--Nombre: {0}", this.nombre);
                Console.WriteLine("--Apellido: {0}", this.apellido);
                Console.WriteLine("--Fecha de Nacimiento: {0}", this.F_Nac);
                Console.WriteLine("--Edad: " + calc_edad());
                Console.WriteLine("--Estado Civil: {0}", this.Est_Civil);
                Console.WriteLine("--Genero: {0}", this.Genero);
                Console.WriteLine("--Fecha de Ingreso: {0}", this.F_Ingreso);
                Console.WriteLine("--Antiguedad: " + antiguedad());
                Console.WriteLine("--Sueldo Base: ${0}", this.sueldo_Base);
                Console.WriteLine("--Cargo: {0}", this.cargo);
                Console.WriteLine("--Salario: $" + salario());
                jubilacion();
            }
            //Calculo la edad
            public int calc_edad() {
                //Fecha de nacimiento
                String[] partes_nac = this.F_Nac.Split('/');
                int dia_nac = Convert.ToInt32(partes_nac[0]);
                int mes_nac = Convert.ToInt32(partes_nac[1]);
                int anio_nac = Convert.ToInt32(partes_nac[2]);
                //Fecha actual
                String F_Act = "20/6/2019";
                Console.WriteLine(F_Act);
                String[] partes_act = F_Act.Split('/');
                int dia_act = Convert.ToInt32(partes_act[0]);
                int mes_act = Convert.ToInt32(partes_act[1]);
                int anio_act = Convert.ToInt32(partes_act[2]);
                int edad=0;

                if (verif_fecha() == true){
                    if (mes_nac == mes_act){
                        if (dia_nac == dia_act){
                            edad = anio_act - anio_nac;
                        }
                        else
                            if (dia_act < dia_nac){
                                edad = anio_act - anio_nac;
                                edad = edad - 1;
                            }
                    }
                    else
                        if (mes_nac < mes_act){
                            edad = anio_act - anio_nac;
                        }
                        else{
                            edad = anio_act - anio_nac;
                            edad = edad - 1;
                        }
                }
                else {
                    Console.WriteLine("No se puede calcular la fecha");
                }
                return edad;
            }

            //Calcular la antiguedad
            public int antiguedad() {
                //Fecha actual
                String F_Act = "20/6/2019";
                Console.WriteLine(F_Act);
                String[] partes_act = F_Act.Split('/');
                int dia_act = Convert.ToInt32(partes_act[0]);
                int mes_act = Convert.ToInt32(partes_act[1]);
                int anio_act = Convert.ToInt32(partes_act[2]);
                //Fecha de ingreso
                String[] partes_ing = this.F_Ingreso.Split('/');
                int dia_ing = Convert.ToInt32(partes_ing[0]);
                int mes_ing = Convert.ToInt32(partes_ing[1]);
                int anio_ing = Convert.ToInt32(partes_ing[2]);
                int edad = 0;

                if (verif_fecha() == true)
                {
                    if (mes_act == mes_ing)
                    {
                        if (dia_act == dia_ing)
                        {
                            edad = anio_act - anio_ing;
                        }
                        else
                            if (dia_act < dia_ing)
                            {
                                edad = anio_act - anio_ing;
                                edad = edad - 1;
                            }
                    }
                    else
                        if (mes_ing < mes_act)
                        {
                            edad = anio_act - anio_ing;
                        }
                        else
                        {
                            edad = anio_act - anio_ing;
                            edad = edad - 1;
                        }
                }
                else{
                    Console.WriteLine("No se puede calcular la fecha");
                }
                return edad;
            }
            //Verifico la fecha
            public bool verif_fecha(){
                //Fecha de nacimiento
                String[] partes_nac = this.F_Nac.Split('/');
                int dia_nac = Convert.ToInt32(partes_nac[0]);
                int mes_nac = Convert.ToInt32(partes_nac[1]);
                int anio_nac = Convert.ToInt32(partes_nac[2]);
                //Fecha de ingreso
                String[] partes_ing = this.F_Ingreso.Split('/');
                int dia_ing = Convert.ToInt32(partes_nac[0]);
                int mes_ing = Convert.ToInt32(partes_nac[1]);
                int anio_ing = Convert.ToInt32(partes_nac[2]);
                //Fecha actual
                String F_Act = "20/6/2019";
                String[] partes_act = F_Act.Split('/');
                int dia_act = Convert.ToInt32(partes_act[0]);
                int mes_act = Convert.ToInt32(partes_act[1]);
                int anio_act = Convert.ToInt32(partes_act[2]);
                //Contadores de verificacion
                int bisiesto_nac = 0, bisiesto_act = 0, bisiesto_ing = 0, verif_act = 0, verif_nac = 0, verif_ing = 0;
                bool verificado;

                if (dia_nac > 0 && dia_act > 0 && dia_ing > 0 && mes_nac > 0 && mes_nac <= 12 && mes_ing > 0 && mes_ing <= 12 && mes_nac > 0 && mes_nac <= 12 && anio_nac > 0 && anio_act > 0 && anio_ing > 0){
                    /*Verifico si los años son bisiestos*/
                    //Año de nacimiento
                    if ((anio_nac % 400) == 0){
                        bisiesto_nac++;
                    }
                    else
                        if ((anio_nac % 4) == 0){
                            bisiesto_nac++;
                        }
                    //Año actual
                    if ((anio_act % 400) == 0){
                        bisiesto_act++;
                    }
                    else
                        if ((anio_act % 4) == 0){
                            bisiesto_act++;
                        }
                    //Año de ingreso
                    if ((anio_ing % 400) == 0){
                        bisiesto_ing++;
                    }
                    else
                        if ((anio_ing % 4) == 0){
                            bisiesto_act++;
                        }

                    /*Verifico la fecha actual*/
                    if (bisiesto_act == 1){
                        switch (mes_act){
                            case 1:
                                if (dia_act < 32) verif_act++; break;
                            case 2:
                                if (dia_act < 29) verif_act++; break;
                            case 3:
                                if (dia_act < 32) verif_act++; break;
                            case 4:
                                if (dia_act < 31) verif_act++; break;
                            case 5:
                                if (dia_act < 32) verif_act++; break;
                            case 6:
                                if (dia_act < 31) verif_act++; break;
                            case 7:
                                if (dia_act < 32) verif_act++; break;
                            case 8:
                                if (dia_act < 32) verif_act++; break;
                            case 9:
                                if (dia_act < 31) verif_act++; break;
                            case 10:
                                if (dia_act < 32) verif_act++; break;
                            case 11:
                                if (dia_act < 31) verif_act++; break;
                            case 12:
                                if (dia_act < 32) verif_act++; break;
                            default: break;
                        }
                    }
                    else{
                        switch (mes_act){
                            case 1:
                                if (dia_act < 32) verif_act++; break;
                            case 2:
                                if (dia_act < 28) verif_act++; break;
                            case 3:
                                if (dia_act < 32) verif_act++; break;
                            case 4:
                                if (dia_act < 31) verif_act++; break;
                            case 5:
                                if (dia_act < 32) verif_act++; break;
                            case 6:
                                if (dia_act < 31) verif_act++; break;
                            case 7:
                                if (dia_act < 32) verif_act++; break;
                            case 8:
                                if (dia_act < 32) verif_act++; break;
                            case 9:
                                if (dia_act < 31) verif_act++; break;
                            case 10:
                                if (dia_act < 32) verif_act++; break;
                            case 11:
                                if (dia_act < 31) verif_act++; break;
                            case 12:
                                if (dia_act < 32) verif_act++; break;
                            default: break;
                        }
                    }
                    /*Verifico la fecha de nacimiento*/
                    if (bisiesto_nac == 1){
                        switch (mes_nac){
                            case 1:
                                if (dia_nac < 32) verif_nac++; break;
                            case 2:
                                if (dia_nac < 29) verif_nac++; break;
                            case 3:
                                if (dia_nac < 32) verif_nac++; break;
                            case 4:
                                if (dia_nac < 31) verif_nac++; break;
                            case 5:
                                if (dia_nac < 32) verif_nac++; break;
                            case 6:
                                if (dia_nac < 31) verif_nac++; break;
                            case 7:
                                if (dia_nac < 32) verif_nac++; break;
                            case 8:
                                if (dia_nac < 32) verif_nac++; break;
                            case 9:
                                if (dia_nac < 31) verif_nac++; break;
                            case 10:
                                if (dia_nac < 32) verif_nac++; break;
                            case 11:
                                if (dia_nac < 31) verif_nac++; break;
                            case 12:
                                if (dia_nac < 32) verif_nac++; break;
                            default: break;
                        }
                    }
                    else{
                        switch (mes_nac){
                            case 1:
                                if (dia_nac < 32) verif_nac++; break;
                            case 2:
                                if (dia_nac < 28) verif_nac++; break;
                            case 3:
                                if (dia_nac < 32) verif_nac++; break;
                            case 4:
                                if (dia_nac < 31) verif_nac++; break;
                            case 5:
                                if (dia_nac < 32) verif_nac++; break;
                            case 6:
                                if (dia_nac < 31) verif_nac++; break;
                            case 7:
                                if (dia_nac < 32) verif_nac++; break;
                            case 8:
                                if (dia_nac < 32) verif_nac++; break;
                            case 9:
                                if (dia_nac < 31) verif_nac++; break;
                            case 10:
                                if (dia_nac < 32) verif_nac++; break;
                            case 11:
                                if (dia_nac < 31) verif_nac++; break;
                            case 12:
                                if (dia_nac < 32) verif_nac++; break;
                            default: break;
                        }
                    }
                    /*Verifico la fecha de nacimiento*/
                    if (bisiesto_ing == 1){
                        switch (mes_ing){
                            case 1:
                                if (dia_ing < 32) verif_ing++; break;
                            case 2:
                                if (dia_ing < 29) verif_ing++; break;
                            case 3:
                                if (dia_ing < 32) verif_ing++; break;
                            case 4:
                                if (dia_ing < 31) verif_ing++; break;
                            case 5:
                                if (dia_ing < 32) verif_ing++; break;
                            case 6:
                                if (dia_ing < 31) verif_ing++; break;
                            case 7:
                                if (dia_ing < 32) verif_ing++; break;
                            case 8:
                                if (dia_ing < 32) verif_ing++; break;
                            case 9:
                                if (dia_ing < 31) verif_ing++; break;
                            case 10:
                                if (dia_ing < 32) verif_ing++; break;
                            case 11:
                                if (dia_ing < 31) verif_ing++; break;
                            case 12:
                                if (dia_ing < 32) verif_ing++; break;
                            default: break;
                        }
                    }
                    else{
                        switch (mes_ing){
                            case 1:
                                if (dia_ing < 32) verif_ing++; break;
                            case 2:
                                if (dia_ing < 28) verif_ing++; break;
                            case 3:
                                if (dia_ing < 32) verif_ing++; break;
                            case 4:
                                if (dia_ing < 31) verif_ing++; break;
                            case 5:
                                if (dia_ing < 32) verif_ing++; break;
                            case 6:
                                if (dia_ing < 31) verif_ing++; break;
                            case 7:
                                if (dia_ing < 32) verif_ing++; break;
                            case 8:
                                if (dia_ing < 32) verif_ing++; break;
                            case 9:
                                if (dia_ing < 31) verif_ing++; break;
                            case 10:
                                if (dia_ing < 32) verif_ing++; break;
                            case 11:
                                if (dia_ing < 31) verif_ing++; break;
                            case 12:
                                if (dia_ing < 32) verif_ing++; break;
                            default: break;
                        }
                    }
                }
                if (verif_nac == 1 && verif_act == 1 && verif_ing == 1){
                    verificado = true;
                }
                else verificado = false;

                return verificado;
            }
            //Verifico la jubilacion
            public void jubilacion() {
                int edad_jub=0;
                int edad = calc_edad();
                int dif = 0;
                if (this.Genero.Contains("Femenino") == true){
                    edad_jub = 60;
                }
                else edad_jub = 65;

                if (edad_jub > edad){
                    dif = edad_jub - edad;
                    Console.WriteLine("--Le faltan " + dif + "anios");
                }
                else Console.WriteLine("--Esta disponible para la jubilacion");
            }
            //Veo el salario
            public double salario() {
                double salario = 0;
                double aux_double = 0;
                double adicional;
                int ant = antiguedad();

                if (ant < 20){
                    for (int i = 0; i < ant; i++){
                        aux_double = sueldo_Base * ((2 / sueldo_Base) * 100);
                    }
                    adicional = aux_double;
                }
                else {
                    for (int i = 0; i < 20; i++){
                        aux_double = sueldo_Base + ((5 / sueldo_Base) * 100);
                    }
                    adicional = aux_double;
                    int aux = ant - 20;
                    for (int i = 0; i < aux; i++ ) {
                        sueldo_Base = sueldo_Base + ((25 / sueldo_Base) * 100);
                    }
                    adicional = aux_double;
                }

                if(cargo.Contains("Ingeniero")==true || cargo.Contains("Especialista")==true){
                    adicional =  adicional * 1.50;
                }
                if (Est_Civil.Contains("Casado") == true || Est_Civil.Contains("Casada") == true) {
                    Console.WriteLine("----Ingrese la cantidad de hijos: ");
                    int cant_hijos= Convert.ToInt32(Console.ReadLine());

                    if (cant_hijos > 2) {
                        adicional = adicional + 5000;
                    }
                }
                salario = sueldo_Base + adicional;

                return salario;
            }

        }
        enum Trabajo { Auxiliar, Administrativo, Ingeniero, Especialista, Investigador};

        //------------------------------AGREGAR EMPLEADOS
        static void Agregar_Emp(List<Empleados> Personas){
            int contador = 1;
            
            Console.WriteLine("-----Ingrese la cantidad de empleados: ");
            int cant_Per = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < cant_Per; i++){
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
            while(!Personas.Exists(x => x.nombre == partes_nom[0]) || !Personas.Exists(y => y.apellido == partes_nom[1])){
                Console.WriteLine("--No exite el empleado\nIngrese otro nombre\n--Escriba el nombre completo: ");
                nom_bus = Convert.ToString(Console.ReadLine());
                partes_nom = nom_bus.Split(' ');
            }
            Console.WriteLine(Personas.Where(x => x.nombre == partes_nom[0]).FirstOrDefault()); //Busco el empleado
        }


        //------------------------------ELIMINAR EMPLEADOS
        static void Eliminar_Emp(List<Empleados> Personas){
            Console.WriteLine("--Escriba el nombre completo: ");
            string nom_elim = Convert.ToString(Console.ReadLine());
            String[] partes_nom = nom_elim.Split(' ');
            //Me fijo que el empleado exista
            while (!Personas.Exists(x => x.nombre == partes_nom[0]) || !Personas.Exists(y => y.apellido == partes_nom[1])){
                Console.WriteLine("--No exite el empleado\nIngrese otro nombre\n--Escriba el nombre completo: ");
                nom_elim = Convert.ToString(Console.ReadLine());
                partes_nom = nom_elim.Split(' ');
            }
            Personas.Remove(Personas.Where(x => x.nombre == partes_nom[0]).FirstOrDefault()); //Elimino el empleado
        }
        //Menu
        static void Menu(List<Empleados> Personas) {
            char continuar = 's';

            do{
                Console.WriteLine("\n\nElija una de estas opciones: ");
                Console.WriteLine("0) Buscar Empleado");
                Console.WriteLine("1) Agregar Empleado");
                Console.WriteLine("2) Eliminar Empleado");
                Console.WriteLine("Ingrese aqui: ");
                int opcion= Convert.ToInt32(Console.ReadLine());

                while (opcion > 2) {
                    Console.WriteLine("--Opcion Incorrecta/Por Favor eliga una opcion valida");
                    Console.WriteLine("\n\nElija una de estas opciones: ");
                    Console.WriteLine("0) Buscar Empleado");
                    Console.WriteLine("1) Agregar Empleado");
                    Console.WriteLine("2) Eliminar Empleado");
                    Console.WriteLine("Ingrese aqui: ");
                    opcion = Convert.ToInt32(Console.ReadLine());
                }

                switch(opcion){
                    case 0:
                        //------------------------------BUSCAR EMPLEADOS
                        Buscar_Emp(Personas);
                        break;
                    case 1:
                        //------------------------------AGREGAR EMPLEADOS
                        Agregar_Emp(Personas);
                        break;
                    case 2:
                        //------------------------------ELIMINAR EMPLEADOS
                        Eliminar_Emp(Personas);
                        break;
                }
                Console.WriteLine("Desea continuar? (S/N): ");
                continuar = Convert.ToChar(Console.ReadLine());
                while (continuar != 's' && continuar != 'S' && continuar != 'n' && continuar != 'N') {
                    Console.WriteLine("--Opcion Incorrecta/Por Favor eliga una opcion valida\nDesea continuar? (S/N): ");
                    continuar = Convert.ToChar(Console.ReadLine());
                }
            }while(continuar == 's' || continuar == 'S');
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
            if (g_emp.Contains("Masculino") == true){
                switch (Opcion){
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
                switch (Opcion){
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
        static string Genero(){
            Console.WriteLine("-----Ingrese el genero: ");
            Char Opcion = Convert.ToChar(Console.ReadLine());
            while (Opcion != 'M' && Opcion != 'm' && Opcion != 'F' && Opcion != 'f'){
                Console.WriteLine("---Opcion Incorrecta - Por favor ingrese una opcion valida\n-----Ingrese el estado civil: ");
                Opcion = Convert.ToChar(Console.ReadLine());
            }
            string Genero = "";
            switch (Opcion){
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

        //Calculo el monto total
        static double Monto_Total(List<Empleados> Personas){
            double total=0;
            double aux=0;
            double sal_Per = 0;
            for (int i = 0; i < Personas.Count; i++) {
                sal_Per = Personas[i].salario();
                aux = aux + sal_Per;
            }
            total = aux;
            return total;
        }
        
    }
}
