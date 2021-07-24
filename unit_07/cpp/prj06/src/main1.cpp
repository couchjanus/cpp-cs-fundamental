#include <iostream>
using std::cout;
using std::endl;

// Указатели в параметрах функции
// Параметры функции в C++ могут представлять указатели. 
// Указатели передаются в функцию по значению, то есть функция получает копию указателя. 
// В то же время копия указателя будет в качестве значения иметь тот же адрес, что оригинальный указатель. 
// Поэтому используя в качестве параметров указатели, мы можем получить доступ к значению аргумента и изменить его.

// Например, пусть у нас будет простейшая функция, которая увеличивает число на единицу:
     
    void increment(int);
 
    void increment(int x)
    {
        x++;
        std::cout << "increment function: " <<  x << std::endl;
    }

   // Теперь изменим функцию increment, использовав в качестве параметра указатель:
     
    void increment1(int*);

    void increment1(int *x)
    {
        (*x)++;
        std::cout << "increment function: " <<  *x << std::endl;
    }

    void increment2(int*);

    void increment2(int *x)
    {
        int z = 6;
        x = &z;     // переустанавливаем адрес указателя x
        std::cout << "increment function: " <<  *x << std::endl;
    }

    // Если функция принимает в качестве параметра массив, то фактически в эту функцию передается указатель на первый элемент массива. 
    // То есть как и в случае с указателями нам доступен адрес, по которому мы можем менять значения. 

    // Поэтому следующие объявления функции будут по сути равноценны:
    
    void print1(int numbers[]);
    void print2(int *numbers);
     
    void print1(int numbers[])
    {
        std::cout << "First number: " <<  numbers[0] << std::endl;
    }
    // В данном случае функция print выводит на консоль первый элемент массива.
    
    void print2(int *numbers)
    {
        std::cout << "First number: " <<  *numbers << std::endl;
    }
    // Здесь также в функцию передается массив, однако параметр представляет указатель на первый элемент массива

    // Поскольку параметр, определенный как массив, рассматривается именно как указатель на первый элемент, 
    // то мы не сможем корректно получить длину массива следующим образом:
    
    void print3(int numbers[])
    {
        int size = sizeof(numbers) / sizeof(numbers[0]);
        std::cout << size << std::endl;
    }

    // Передача маркера конца массива
    // Чтобы определять конец массив, перебирать элементы массива, необходимо использовать специальный маркер, который бы сигнализировал об окончании массива.


    void print4(char[]);

    void print4(char chars[])
    {
        for (int i = 0; chars[i] != '\0'; i++)
        {
            std::cout << chars[i] << "\t";
        }
    }


    void print5(int[], int);
    void print5(int numbers[], int n)
    {
        for(int i=0; i < n; i++)
        {
            std::cout << numbers[i] << "\t";
        }
    } 
    
    void print6(int*, int*);
     
    void print6(int *begin, int *end)
    {
        for (int *ptr  = begin; ptr != end; ptr++)
        {
            std::cout << *ptr << "\t";
        }
    }

    void print7(const int*, const int*);
    void twice(int*, int*);

    // В данном случае функция print просто выводит значения из массива, поэтому параметры этой функции помечаются как константные.
     
    void print7(const int *begin, const int *end)
    {
        for (const int *ptr  = begin; ptr != end; ptr++)
        {
            std::cout << *ptr << "\t";
        }
    }
    // Функция twice изменяет элементы массива - увеличивает их в два раза, поэтому в этой функции параметры являются неконстантными. Причем поле выполнения функции twice массив nums3 будет изменен.

    void twice(int *begin, int *end)
    {
        for (int *ptr = begin; ptr != end; ptr++)
        {
            *ptr = *ptr * 2;
        }
    }


    void print8(int(*)[3], int); 
    void print8(int (*numbers)[3], int rowsCount)
    {
        // количество столбцов или элементов в каждом подмассиве
        int columnsCount = sizeof(*numbers)/ sizeof(*numbers[0]);
        for(int i =0; i < rowsCount; i++)
        {
            for (int j = 0; j < columnsCount; j++)
            {
                std::cout << numbers[i][j] << "\t";
            }
            std::cout << std::endl;
        }
    }

// Также мы могли бы определить параметр функци print непосредственно как двухмерный массив, но в этом случае опять же надо было бы указать явным образом вторую размерность:
    
    void print9(int numbers[][3], int rowsCount)
    {
        // количество столбцов или элементов в каждом подмассиве
        int columnsCount = sizeof(numbers[0])/ sizeof(numbers[0][0]);
        for(int i =0; i < rowsCount; i++)
        {
            for (int j = 0; j < columnsCount; j++)
            {
                std::cout << numbers[i][j] << "\t";
            }
            std::cout << std::endl;
        }
    }

void hello();
void goodbye();

void hello()
{
    std::cout << "Hello, World" << std::endl;
}
void goodbye()
{
    std::cout << "Good Bye, World" << std::endl;
}

int add(int, int);
int subtract(int, int);

int add(int x, int y)
{
    return x+y;
}
int subtract(int x, int y)
{
    return x-y;
}


int main() {
     
    int n = 10;
    // Здесь переменная n передается в качестве аргумента для параметра x. 
    // Передача происходит по значению, поэтому любое изменение параметра x в функции increment 
    // никак не скажется на значении переменной n.
    increment(n);

    // Теперь изменим функцию increment, использовав в качестве параметра указатель:
    // void increment(int*);
     
    // increment1(&n);
    // Для изменения значения параметра применяется операция разыменования с последующим инкрементом: (*x)++. Это изменяет значение, которое находится по адресу, хранимому в указателе x.

    // Поскольку теперь функция в качестве параметра принимает указатель, то при ее вызове необходимо передать адрес переменной: increment(&n);.

    // В итоге изменение параметра x также повлияет на переменную n


    // В то же время поскольку аргумент передается в функцию по значению, то есть функция получает копию адреса, то если внутри функции будет изменен адрес указателя, то это не затронет внешний указатель, который передается в качестве аргумента:
    
    int *ptr = &n;

    // В функцию increment передается указатель ptr. При вызове функция получает копию этого указателя в виде парамета x. В функции изменяется адрес указателя x. Но это никак не затронет указатель ptr, так как он предствляет другую копию. В итоге поле переустановки адреса указатели x и ptr будут хранить разные адреса.

    increment2(ptr);
    
    std::cout << "main function: " <<  n << std::endl;


    // Массивы в параметрах функции

    int nums[] = {1, 2, 3, 4, 5};
    // Передадим в функцию массив:
    print1(nums);

    // Теперь определим параметр как указатель:
    print2(nums);
     
    print3(nums);

    // Передача маркера конца массива
    // Первый подход заключается в том, чтобы один из элементов массива сам сигнализировал о его окончании. 
    // В частности, массив символов может представлять строку - набор символов, который завершается нулевым символом '\0'. Фактически нулевой символ служит признком окончания символьного массива:

    char chars[] = "Hello";
 
    print4(chars);


    // Второй подход заключается в передаче в функцию размера массива:
    int n = sizeof(nums)/sizeof(nums[0]);
    print5(nums, n);
     
    // Третий подход заключается в передаче указателя на конец массива. Можно вручную вычислять вычислять указатель на конец массива. А можно использовать встроенные библиотечные функции std::begin() и std::end():
    
    int *begin = std::begin(nums);      // указатель на начало массива
    int *end = std::end(nums);      // указатель на конец массива
   
    // Причем end возвращает указатель не на последний элемент, а адрес за последним элементом в массиве.
     
    print6(begin, end);

    // Константные массивы
    // Поскольку при передаче массива передается фактически указатель на первый элемент, то используя этот указатель, мы можем изменить элемены массива. Если нет необходимости в изменении массива, то лучше параметр-массив определять как константный:


 
 

    int nums1[] = { 1, 2, 3, 4, 5 };
    int *begin = std::begin(nums1);
    int *end = std::end(nums1);

    print7(begin, end);
    std::cout << std::endl;
 
    int nums2[] = { 1, 2, 3, 4, 5 }; 
    begin = std::begin(nums2);
    end = std::end(nums2);
    twice(begin, end);
    for (int *ptr = begin; ptr != end; ptr++)
    {
        std::cout << *ptr << "\t";
    }
    std::cout << std::endl;

    //  Передача многомерного массива
    // Многомерный массив также передается как указатель наего первый элемент. В то же время поскольку элементами многомерного массива являются другие массивы, то указатель на первый элемент многомерного массива фактически будет представлять указатель на массив.

    // При определении параметра как указателя на массив размер второй размерности (а также всех последующих размерностей) должен быть определен, так как данный размер является частью типа элемента. Пример объявления:
    
    // void print8(int (*numbers)[3])
    
    // Здесь предполагается, что передаваемый массив будет двухмерным, и все его подмассивы будут иметь по 3 элемента. Стоит обратить внимание на скобки вокруг имени параметра, которые и позволяют определить параметр как указатель на массив. И от этой ситуации стоит отличать следующую:
    
    // void print9(int *numbers[3])
    
    // В данном случае параметр определен как массив указателей, а не как указатель на массив.

    // применение указателя на массив:

    // В функции main определяется двухмерных массив - он состоит из трех подмассивов. Каждый подмассив имеет по три элемента.

        int table[3][3] = { {1, 2, 3}, {4, 5, 6}, {7, 8, 9} };
        // количество строк или подмассивов
        int rowsCount = sizeof(table) / sizeof(table[0]);

     // В функцию print вместе с массивом передается и число строк - по сути число подмассивов. В самой функции print получаем количество элементов в каждом подмассиве и с помощью двух циклов перебираем все элементы. С помощью выражения number[0] можно обратиться к первому подмассиву в двухмерном массиве, а с помощью выражения numbers[0][0] - к первому элементу первого подмассива. И таким образом, манипулируя индексами можно перебрать весь двухмерный массив.

        print8(table, rowsCount);
    
// Указатели на функции
// Указатель на функцию (function pointer) хранит адрес функции. По сути указатель на функцию содержит адрес первого байта в памяти, по которому располагается выполняемый код функции.

// Самым распространенным указателем на функцию является ее имя. С помощью имени функции можно вызывать ее и получать результат ее работы.

// Указатель на функцию мы можем определять в виде отдельной переменной с помощью следующего синтаксиса:

// тип (*имя_указателя) (параметры);

// - тип представляет тип возвращаемого функцией значения.
// - имя_указателя представляет произвольно выбранный идентификатор в соответствии с правилами о наименовании переменных.
// - параметры определяют тип и название параметров через запятую при их наличии.

// Например, определим указатель на функцию: void (*message) ();
// В данном случае определен указатель, который имеет имя message. Он может указывать на функции без параметров, которые возвращают тип void (то есть ничего не возвращают).

// Используем указатель на функцию:
  
    void (*message)();
      
    message=hello;
    message();
    message = goodbye;
    message();
      

// Указателю на функцию можно присвоить функцию, которая соответствует указателю по возвращаемому типу и спецификации параметров: message=hello;

// То есть в данном случае указатель message теперь хранит адрес функции hello. И посредством обращения к указателю мы можем вызвать эту функцию: message();

// В качестве альтернативы мы можем обращаться к указателю на функцию следующим образом:(*message)();

// При определении указателя стоит обратить внимание на скобки вокруг имени. 
// Так, использованное выше определение void (*message) ();
// НЕ будет аналогично следующему определению: void *message ();
// определен не указатель на функцию, а прототип функции message, которая возвращает указатель типа void*.

// Рассмотрим еще один указатель на функцию:
 
  
    int a = 10;
    int b = 5;
    int result;
    int (*operation)(int a, int b);
      
    operation=add;
    result = operation(a, b);
    // result = (*operation)(a, b); // альтернативный вариант
    std::cout << "result=" << result << std::endl;     // result=15

// Здесь определен указатель operation, который может указывать на функцию с двумя параметрами типа int, возвращающую также значение типа int. Соответственно мы можем присвоить указателю адреса функций add и subtract и вызвать их, передав при вызове указателю некоторые значения для параметров.
      
    operation = subtract;
    result = operation(a, b);
    std::cout << "result=" << result << std::endl;     // result=5

   
    return 0;

}
