using System;

namespace cs
{
// Индексы необязательно должны представлять тип int. 
// мы можем рассматривать объект как хранилище свойств и передавать имя атрибута объекта в виде строки:

class User
{
    string name;
    string email;
    string phone;
 
    public string this[string propname]
    {
        get
        {
            switch (propname)
            {
                case "name": return "Mr/Ms. " + name;
                case "email": return email;
                case "phone": return phone;
                default: return null;
            }
        }
        set
        {
            switch (propname)
            {
                case "name":
                    name = value;
                    break;
                case "email":
                    email = value;
                    break;
                case "phone":
                    phone = value;
                    break;
            }
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        User janus = new User();
        janus["name"] = "Janus";
        janus["email"] = "couchjanus@gmail.com";
 
        Console.WriteLine(janus["name"]); // Mr/Ms. Janus
 
        Console.ReadKey();
    }
}
}
