using System;
using System.Collections.Generic;
using System.IO;

void IngresarEstudiante(){
    Console.WriteLine("Ingrese la cantidad de estudiantes: ");
    int estudiantes = int.Parse(Console.ReadLine()!);

    //Aqui guardamos los datos del los estudiantes digase nota, nombre, apellido, etc...
    string datos = "";

    //Aqui guardamos los datos de las letras en estas listas.
    List<string> ListaA = new List<string>();
    List<string> ListaB = new List<string>();
    List<string> ListaC = new List<string>();
    List<string> ListaF = new List<string>();

    //Bucle para pedir nombres y datos de estudiantes. y calcular el promedio
    for (int i = 0; i < estudiantes; i++ ){
        
        Console.WriteLine($"\nEscriba el nombre del estudiante {i + 1}: ");
        string nombre = Console.ReadLine()!;

        Console.WriteLine("Escriba el apellido del estudiante: ");
        string apellido = Console.ReadLine()!;

        Console.WriteLine("Digite la nota 1: ");
        int nota1 = int.Parse(Console.ReadLine())!;

        Console.WriteLine("Digite la nota 2: ");
        int nota2 = int.Parse(Console.ReadLine()!);

        Console.WriteLine("Digite la nota 3: ");
        int nota3 = int.Parse(Console.ReadLine()!);

        Console.WriteLine("Digite la nota 4: ");
        int nota4 = int.Parse(Console.ReadLine()!);

        int promedio = (nota1 + nota2 + nota3 + nota4) / 4;

        //Aqui guarda el promedio en letra
        string letra = "";
        if(promedio >= 90 && promedio <= 100){
            letra = "A";
        }
        else if(promedio >= 80 && promedio <= 90){
            letra = "B";
        }
        else if(promedio >= 70 && promedio <= 80){
            letra = "C";
        }
        else{
            letra = "F";
        }
        //========================================================================================

        //Almacena las letras en la lista
        if (letra == "A"){
            ListaA.Add($"{nombre} {apellido}");
        }
        else if(letra == "B"){
            ListaB.Add($"{nombre} {apellido}");
        }
        else if(letra == "C"){
            ListaC.Add($"{nombre} {apellido}");
        }
        else{
            ListaF.Add($"{nombre} {apellido}");
        }
        //=========================================================================================================================

        datos += ($"{nombre, -12} {apellido, -12} {nota1, -8} {nota2, -8} {nota3, -8} {nota4, -8} {promedio, -10} {letra, -14}\n");
       
    }     
        Console.WriteLine($"\n<------------------Menu Promedio Express.------------------>");
        Console.WriteLine("\tCalificaciones del cuatrimestre");
        Console.WriteLine($"============================================================");
        Console.WriteLine($"{"nombre",-12} {"apellido",-12}  {"nota1",-8} {"nota2",-8} {"nota3",-8} {"nota4",-8} {"promedio",-10}  {"calificacion",-14}");
        Console.WriteLine(datos);
        Console.WriteLine($"\nLos estudiantes que sacaron A son: {ListaA.Count}\n {string.Join(", ", ListaA)}.");
        Console.WriteLine($"\nLos estudiantes que sacaron B son: {ListaB.Count}\n {string.Join(", ", ListaB)}.");
        Console.WriteLine($"\nLos estudiantes que sacaron C son: {ListaC.Count}\n {string.Join(", ", ListaC)}.");
        Console.WriteLine($"\nLos estudiantes que reprobaron son: {ListaF.Count}\n {string.Join(", ", ListaF)}.");
        
        
}


void MenuCursos(){

    bool SeguirMenuCursos = true;
    int TotalCursos = 0;
    string CantidadNombresCurso = "";


    while(SeguirMenuCursos){

        Console.WriteLine("\n<------------------Bienvenido al Menu de los cursos!--------------------->");
        Console.WriteLine("Por favor elija una de estas 4 opciones:\n1 - Crear un curso\n2 - Anadir estudiante\n3 - Quitar un estudiante o curso\n4 - Para tirar reporte del curso\n5 - Salir al menu principal");
        int Opcion = int.Parse(Console.ReadLine());


        switch(Opcion){
            case 1:
                Console.WriteLine("\nFavor digite cuanto cursos desea crear");
                int CursosCantidad = int.Parse(Console.ReadLine()!);

                for(int i = 0; i < CursosCantidad; i++){
                    Console.WriteLine($"\nDiga el nombre del curso numero: {i + 1}");
                    string NombreCurso = Console.ReadLine()!;

                    string RutaCrearCurso = $"{NombreCurso}.txt";
                    File.WriteAllText(RutaCrearCurso, "");

                    TotalCursos ++;
                    CantidadNombresCurso += ($"{NombreCurso}");

                    Console.WriteLine($"\nEl curso {NombreCurso} fue creado correctamente!");     
                }
            break;

            case 2:
                if (TotalCursos != 0){
                    Console.WriteLine("<---------------Bienvenido al Menu Anadir estudiantes!--------------->");
                    Console.WriteLine("\tFavor diga en cual curso desea agregar al estudiante");
                    Console.WriteLine($"- {CantidadNombresCurso}\n");
                    string OpcionAnadir = Console.ReadLine().Trim();
                    string rutaArchivo = $"{OpcionAnadir}.txt";

                    if (File.Exists(rutaArchivo)){
                        Console.WriteLine($"<----------Bienvenido al curso {OpcionAnadir}---------->");
                        Console.WriteLine("\tCuantos estudiantes desea agregar?");
                        int CantidadEstudiantes = int.Parse(Console.ReadLine());

                        for(int i = 0; i < CantidadEstudiantes; i++){
                            Console.WriteLine($"\nIngrese el nombre del estudiante numero {i + 1}");
                            string NombreEstudiante = Console.ReadLine();

                            File.AppendAllText(rutaArchivo, NombreEstudiante + "\n");

                            Console.WriteLine($"\nEl estudiante {NombreEstudiante} fue agregado correctamente!");
                        }

                    }
                    else{
                        Console.WriteLine("\nEl curso que escribio no se encuentra!");
                    }

                }
                else{
                    Console.WriteLine("\nNo tiene cursos creados actualmente!");
                }
            break;

            case 3:
                Console.WriteLine("<----------Bienvenido al menu quitar estudiante!---------->");


                string[] RutaMostrarEliminar = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.txt");
                Console.WriteLine("Desea eliminar un curso o un estudiante?");
                Console.WriteLine("\n1 - Eliminar curso\n2 - Eliminar estudiante");
                int OpcionEliminar = int.Parse(Console.ReadLine());

                switch(OpcionEliminar){
                    case 1:
                    
                        if (RutaMostrarEliminar.Length > 0 ){
                            Console.WriteLine("\nFavor escriba el cursos que desea eliminar");
                            for (int i = 0; i < RutaMostrarEliminar.Length; i++){
                                string NombreLimpio2 = Path.GetFileNameWithoutExtension(RutaMostrarEliminar[i]);
                                Console.WriteLine($"{i + 1} - {NombreLimpio2}");
                            }
                            
                            string OpcionEscogerCurso2 = Console.ReadLine().Trim()!;
                            string RutaArchivoEliminar2 = $"{OpcionEscogerCurso2}.txt";
                            
                            if (File.Exists(RutaArchivoEliminar2)){
                                Console.WriteLine($"\nDeseas eliminar el curso {OpcionEscogerCurso2} para siempre? (Si/No)");
                                string respuesta2 = Console.ReadLine()!.Trim();
                                if(respuesta2.ToLower().Trim() == "si"){
                                    File.Delete(RutaArchivoEliminar2);
                                    Console.WriteLine($"\nEl curso {OpcionEscogerCurso2} ha sido eliminado!");
                                }
                                else{
                                    Console.WriteLine("El curso que escribio no existe!");
                                }
                            }
                            
                        }
                    break;


                
                
                    case 2:
                        //string[] RutaMostrarEliminar = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.txt");

                        if (RutaMostrarEliminar.Length > 0 ){

                            Console.WriteLine("\nFavor escriba el cursos que desea visualizar");
                            Console.WriteLine("\nCursos disponibles:\n");

                            for (int i = 0; i < RutaMostrarEliminar.Length; i++){
                                string NombreLimpio = Path.GetFileNameWithoutExtension(RutaMostrarEliminar[i]);
                                Console.WriteLine($"{i + 1} - {NombreLimpio}");
                            }
                
                            string OpcionEscogerCurso = Console.ReadLine().Trim();

                            string RutaArchivoEliminar = $"{OpcionEscogerCurso}.txt";

                
                
                            if(File.Exists(RutaArchivoEliminar)){

                                string[] estudiantes = File.ReadAllLines(RutaArchivoEliminar);

                                if (estudiantes.Length > 0){
                                    Console.WriteLine($"\nAqui esta la lista de los estudiantes del curso: {OpcionEscogerCurso}\n");

                                    for (int i = 0; i < estudiantes.Length; i++){
                                    Console.WriteLine($"{i + 1} - {estudiantes[i]}");

                                    }
                    
                                    Console.WriteLine("\nEscriba el nombre del estudiante que desea eliminar");
                                    string EliminarEstudiante = Console.ReadLine();

                                    List<string>ListaEstudiante = new List<string>(estudiantes);
                                    ListaEstudiante.RemoveAll(e => e.Equals(EliminarEstudiante));
                                    File.WriteAllLines(RutaArchivoEliminar, ListaEstudiante);
                                    Console.WriteLine($"\nEl estudiante {EliminarEstudiante} ha sido eliminado del archivo");
                                }
                                else{
                                    Console.WriteLine("\nEl curso no tiene estudiantes actualmente!");
                                }

                            }
                        }
                        else{
                        Console.WriteLine("\nEl archivo del curso no existe!");
                        }
                        break;
                    }
                break;      
                
                
                
            

                

            case 4:
                Console.WriteLine("<----------Bienvenido al menu reportes---------->");

                string[] ArchivosCursos = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.txt");

                if (ArchivosCursos.Length > 0){
                    Console.WriteLine("\nAqui estan los cursos disponibles!");
                    for(int i = 0; i < ArchivosCursos.Length; i++){
                        string NombreCompletoCurso = Path.GetFileNameWithoutExtension(ArchivosCursos[i]);
                        Console.WriteLine($"{i + 1} - {NombreCompletoCurso}");
                    }

                    Console.WriteLine("\nPor favor, elija el curso al cual quiere tirar el reporte:");
                    string OpcionReportes = Console.ReadLine().Trim();
                    string RutaEstudiantesReporte = $"{OpcionReportes}.txt";

                    if (File.Exists(RutaEstudiantesReporte)){
                        
                        string[] LeerEstudiantes = File.ReadAllLines(RutaEstudiantesReporte);
                        Console.WriteLine($"<========={OpcionReportes.ToUpper()}===========>\nEstudiantes:\n");

                        if (LeerEstudiantes.Length > 0){

                            foreach(string estudiante in LeerEstudiantes){
                                Console.WriteLine($"- {estudiante}");
                            }
                        }
                        else{
                            Console.WriteLine("\nEste curso no tiene estudiantes!");
                        }


                    }
                    else{
                        Console.WriteLine("\nEste curso no existe!");
                    }

                }
                else{
                    Console.WriteLine("\nNo hay cursos creados!");
                }
            break;

            case 5:
                Console.WriteLine("Saliendo del menu de cursos!");
                SeguirMenuCursos = false;
                break;

            default:
                Console.WriteLine("Favor escoja una opcion!");
                break;

        }   

    }
}


Console.WriteLine("<===================Bienvenido al colegio Dios es bueno!=========================>");
Console.WriteLine("Por favor, digite uno de los tres numeros para continuar:\n1 - Calcular promedio express\n2 - Menu de los cursos\n3 - Salir del programa");
int opcion = int.Parse(Console.ReadLine()!);
switch(opcion){
    case 1:
        IngresarEstudiante();
        break;
    case 2:
        MenuCursos();
        break;

    case 3:
        Console.WriteLine("Hasta luego!");
        break;

    default:
        Console.WriteLine("Favor ingrese un numero valido!");
        break;
}