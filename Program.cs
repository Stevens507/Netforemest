
// See https://aka.ms/new-console-template for more information

namespace TaskApp
{
    public class Program
    {
    static List<User> users = new List<User>();
    static List<TaskItem> tasks = new List<TaskItem>();
    static User autenticacionUser = null;

public static void Main(string[] args)
{
    int option;
    do
    {
        Console.WriteLine("-----Menu----");
        Console.WriteLine("1. Registar usuario");
        Console.WriteLine("2. Iniciar Session");
        Console.WriteLine("3. Crear Tarea");
        Console.WriteLine("4. Ver todas las tareas");
        Console.WriteLine("5. Eliminar Tarea");
        Console.WriteLine("0. Salir");
        Console.WriteLine("Selecciona una opcion: ");
        option = int.Parse(Console.ReadLine());
        switch (option)
        {
            case 1:
            RegistrarUsuario();
            break;
            case 2:
            Login();
            break;
            case 3:
            CrearTask();
            break;
            case 4:
            ObtenerTask();
            break; 
            case 5:
            Actualizar();
            break;
            case 6:
            Eliminar();
            break;
            case 0:
            Console.WriteLine("Saliendo...");
            break;
            default:
            Console.WriteLine("Opcion no Valida");
            break;

        }
    } while(option!=0);

}
public class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime Duedata { get; set; }
    public int UserId { get; set; }
    
}

public class User
{
    public int Id { get; set;}
    public string Username { get; set; }
    public string Password { get; set; }

}


//registar usuario :
    static void RegistrarUsuario()
    {
        Console.Write("Nombre de Usuario ");
        string username = Console.ReadLine();
        Console.Write("Password: ");
        string password = Console.ReadLine();
        int id = users.Count+1;
        users.Add(new User{ Id = id, Password= password});
        Console.WriteLine("Usuario Registrado con Exito.");

    }

    //login
    static void Login()
    {
        Console.Write("Nombre de Usuario:  ");
        string username = Console.ReadLine();
        Console.Write("Password: ");
        string password = Console.ReadLine();

        autenticacionUser = users.FirstOrDefault(u => u.Username == username && u.Password== password);
        if (autenticacionUser != null)
        {
            Console.WriteLine("Inicio de sesion de manera exitosa");

        }
        else{
            Console.WriteLine("Inicio de Sesion Incorrecta");

        }
    }

    //Crear Task
    static void CrearTask()
    {
        if (autenticacionUser == null)
        {
            Console.WriteLine("Debe iniciar Sesion");
            return;

        } 
        Console.Write("Tarea: ");
        string title = Console.ReadLine();
        Console.Write("Descripcion de la tarea: ");
        string descripcion = Console.ReadLine();
        Console.Write("Fecha de Vencimiento: ");
        DateTime dueDate =DateTime.Parse(Console.ReadLine());

        int taskId = tasks.Count +1;
        tasks.Add(new TaskItem{Id= taskId, Title= title, Description= descripcion, Duedata= dueDate, IsCompleted= false,UserId=autenticacionUser.Id});

        Console.WriteLine("Su tarea Se ha Creado.");
    

    }
    //Obtener Todas las tareas
    static void ObtenerTask()
    {
        if(autenticacionUser == null)
        {
            Console.WriteLine("Debe iniciar sesion primero");
            return;
        
        }

        var userTasks = tasks.Where(t => t.UserId == autenticacionUser.Id).ToList();
        Console.WriteLine("----Tareas----");
        foreach (var task in userTasks)
        {
            Console.WriteLine($"ID: {task.Id}, Titulo: {task.Title}, Descripcion: {task.Description}, Completado: {task.IsCompleted}, Fecha de Vencimiento : {task.Duedata}");

        }
    }

    //actualizar tarea

static void Actualizar()
{
    if (autenticacionUser == null)
    {
        Console.WriteLine("Debe iniciar sesion primero");
            return;

    }
    Console.Write("ID de la tarea a actualizar: ");
    int taskId = int.Parse(Console.ReadLine());
    var task = tasks.FirstOrDefault(t=> t.Id==taskId && t.UserId == autenticacionUser.Id);
    
    if (task!= null )
    {
        Console.WriteLine("Nuevo Titulo: ");
        task.Title = Console.ReadLine();
        Console.Write("Nueva descripcion");
        task.Description = Console.ReadLine();
        Console.Write("Nueva fecha de vencimiento :");
        task.Duedata = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Tarea Actualizada con exito");

    }
    else {
        Console.WriteLine("Tarea no encontrada.");

    }
}
//eliminar
static void Eliminar()
{
   if (autenticacionUser == null)
    {
        Console.WriteLine("Debe iniciar sesion primero");
            return;

    }
    Console.Write("ID de la tarea a eliminar");
    int taskId = int.Parse(Console.ReadLine());
    var task = tasks.FirstOrDefault(t=> t.Id==taskId && t.UserId == autenticacionUser.Id);
    if (task != null)
    {
        tasks.Remove(task);
        Console.WriteLine("Tarea eliminada con exito");


    }
    else{
        Console.WriteLine("Tarea no econtrada");

    }

}
     

    }
 }