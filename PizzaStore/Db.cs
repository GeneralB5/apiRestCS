//namespace instancia un contenedor en el cual se va  a producir esto
// si queremos llamar a namespace deberiamos llamarlo desde el nombre completo a menos que tengan el mismo
// se lo puede instanciar desde otro carpeta instanciadolo completo el nombre de la carpeta

namespace PizzaStore.Db; 
//Un registro se declara utilizando la palabra clave record, la cual modifica una declaración de clase o 
 public record Pizza 
 {
   public int Id {get; set;} 
   public string ? Name { get; set; }
   //public string ? noLoVes {get;set;}
 }
// se podria decir que establece la estructura de un objeto inmutable, basicamente tenes que agregar las piezas segun
// lo necesite, por ejemplo el id que se tiene que establecer pero no podrias agregar por ejemplo topings, ya que 
// en la estructura inicial no requiere/tiene toppings, entoces no vas a poder agregarlo



//public hace referencia a que una clase puede ser instanciadad sin ningun proble en otra clase
// si se le da privado a una clase no podra ser accedida desde ningun lado
 public class PizzaDB
 {
    // este seria el constructor, parecido a js como funciona
    // public PizzaDB()
    // {

    // }
   private static List<Pizza> _pizzas = new List<Pizza>()
   {
     new Pizza{ Id=1, Name="Montemagno, Pizza shaped like a great mountain" },
     new Pizza{ Id=2, Name="The Galloway, Pizza shaped like a submarine, silent but deadly"},
     new Pizza{ Id=3, Name="The Noring, Pizza shaped like a Viking helmet, where's the mead"} 
     
   };
// List<Pizza>: Define el tipo de la lista como una lista genérica que almacena objetos de tipo "Pizza". 
// En este caso, se espera que la lista contenga objetos de la clase o estructura "Pizza".

// new List<Pizza>(): Inicializa la lista "_pizzas" como una nueva instancia 
// de la clase List que contendrá objetos de tipo "Pizza". 
// Es una forma de crear una lista vacía al principio.



   public static List<Pizza> GetPizzas() 
   {
     return _pizzas;
   } 

   public static Pizza ? GetPizza(int id) 
   {
     return _pizzas.SingleOrDefault(pizza => pizza.Id == id);
   } 

   public static Pizza CreatePizza(Pizza pizza) 
   {
     _pizzas.Add(pizza);
     return pizza;
   }

   public static Pizza UpdatePizza(Pizza update) 
   {
     _pizzas = _pizzas.Select(pizza =>
     {
       if (pizza.Id == update.Id)
       {
         pizza.Name = update.Name;
       }
       return pizza;
     }).ToList();
     return update;
   }

   public static void RemovePizza(int id)
   {
    
     _pizzas = _pizzas.FindAll(pizza => pizza.Id != id).ToList();
   }
   private static string sayword(string word)
   {
    return "buenas tardes" + word;
   }
 }

// class prueba
// {
//   public static void sayIt()
//   {
//     //me deja llamar a la clase y a la funcion sayword 
//     string devolucion  = PizzaDB();
//     // en cambio si la pongo privada se vuelve unica de la clase en la que se instancio
        
//   }
// }
