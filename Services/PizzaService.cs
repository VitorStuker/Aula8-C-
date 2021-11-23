using Laboratorio11.Models;

namespace Laboratorio11.Services;

public static class PizzaService     //garantindo que tudo será *da classe*
{
    private static List<Pizza> Pizzas { get; }
    private static int nextId = 3;

    static PizzaService()  //inicializador -> diferente de construtor pois não cria instâncias de objetos 
    {
        Pizzas = new List<Pizza>
        {
            new Pizza { Id = 1, Name = "Classic Italian", IsGlutenFree = false},
            new Pizza { Id = 2, Name = "Veggie", IsGlutenFree = true},
        };
    }

    public static List<Pizza> GetAll()
    {
        return Pizzas;
    }
    
    public static Pizza? Get(int id)   //posso buscar uma pizza que não existe/null
    {
        return Pizzas.FirstOrDefault(p => p.Id == id);
    }

    public static void Add(Pizza pizza)
    {
        pizza.Id = nextId++;
        Pizzas.Add(pizza);
    }

    public static void Delete(int id)
    {
        var pizza = Get(id);
        if(pizza is null) return;
        Pizzas.Remove(pizza);
    }

    public static void Update(Pizza pizza)
    {
        var index = Pizzas.FindIndex(p => p.Id == pizza.Id); //retorna o indice de onde está a pizza e -1 se não encontrou ela

        if(index == -1) return;

        Pizzas[index] = pizza;
    }
}
