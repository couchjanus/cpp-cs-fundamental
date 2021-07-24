#include <iostream>
using std::cout;
using std::endl;

// ref - это ссылка на переданный аргумент, а не копия аргумента
void changeN(int &ref)
{
    ref = 8;
}

struct Something
{
    int value1;
    float value2;
};
 
struct Other
{
    Something something;
    int otherValue;
};



int main() {
     
// Ссылочный тип
// Ссылка — это тип переменной в языке C++, который работает как псевдоним другого объекта или значения. Язык C++ поддерживает 3 типа ссылок:
// - Ссылки на неконстантные значения (обычно их называют просто «ссылки» или «неконстантные ссылки»).
// - Ссылки на константные значения (обычно их называют «константные ссылки»).
// - В C++11 добавлены ссылки r-value.

// Ссылочный тип, иногда называемый псевдонимом, служит для задания объекту дополнительного имени. Ссылка позволяет косвенно манипулировать объектом, точно так же, как это делается с помощью указателя. Однако эта косвенная манипуляция не требует специального синтаксиса, необходимого для указателей. Обычно ссылки употребляются как формальные параметры функций. 

// Ссылка (на неконстантное значение) объявляется с использованием амперсанда (&) между типом данных и именем ссылки:

int value = 7; // обычная переменная
int &ref = value; // ссылка на переменную value корректная ссылка: инициализирована переменной value
// int &invalidRef; // некорректная ссылка: ссылка должна ссылаться на что-либо

// В этом контексте амперсанд не означает «оператор адреса», он означает «ссылка на».

// Ссылки в качестве псевдонимов
// Ссылки обычно ведут себя идентично значениям, на которые они ссылаются. В этом смысле ссылка работает как псевдоним объекта, на который она ссылается:

    // int value = 7; // обычная переменная
    // int &ref = value; // ссылка на переменную value
 
    value = 8; // value теперь 8
    ref = 9; // value теперь 9
 
    std::cout << value << std::endl; // выведется 9
    ++ref;
    std::cout << value << std::endl; // выведется 10
 

 // Инициализация ссылок
// Ссылки должны быть инициализированы при создании:

// int value = 7;

// В отличие от указателей, которые могут содержать нулевое значение, ссылки нулевыми быть не могут.
int ival = 1024;
// правильно: refVal - ссылка на ival
int &refVal = ival;
// ошибка: ссылка должна быть инициализирована
// int &refVal2;

// Ссылка должна быть инициализирована не адресом объекта, а его значением. Таким объектом может быть и указатель: int ival = 1024;

// ошибка: refVal имеет тип int, а не int*
// int &refVal = &ival;
// int *pi = &ival;
// // правильно: ptrVal - ссылка на указатель
// int *&ptrVal2 = pi;

// Ссылки на неконстантные значения могут быть инициализированы только неконстантными l-values. Они не могут быть инициализированы константными l-values или r-values:

int a = 7;
int &ref1 = a; // ок: a - это неконстантное l-value
 
const int b = 8;
int &ref2 = b; // не ок: b - это константное l-value
 
int &ref3 = 4; // не ок: 4 - это r-value

// Обратите внимание, во втором случае вы не можете инициализировать неконстантную ссылку константным объектом. В противном случае, вы бы могли изменить значение константного объекта через ссылку, что уже является нарушением понятия «константа».

// После инициализации изменить объект, на который указывает ссылка — нельзя:

int value1 = 7;
int value2 = 8;
 
int &ref = value1; // ок: ref - теперь псевдоним для value1
ref = value2; // присваиваем 8 (значение переменной value2) переменной value1. Здесь НЕ изменяется объект, на который ссылается ссылка!

// Вместо переприсваивания ref (ссылаться на переменную value2), значение из value2 присваивается переменной value1 (на которое и ссылается ref).

// Определив ссылку, вы уже не сможете изменить ее так, чтобы работать с другим объектом (именно поэтому ссылка должна быть инициализирована в месте своего определения). В следующем примере оператор присваивания не меняет значения refVal, новое значение присваивается переменной ival – ту, которую адресует refVal.

int min_val = 0;
// ival получает значение min_val,
// а не refVal меняет значение на min_val
refVal = min_val;


// Все операции со ссылками реально воздействуют на адресуемые ими объекты. В том числе и операция взятия адреса:

refVal += 2; // прибавляет 2 к ival – переменной, на которую ссылается refVal.
int ii = refVal; // присваивает ii текущее значение,
int *pi = &refVal; // инициализирует pi адресом.

 
// Если мы определяем ссылки в одной инструкции через запятую, перед каждым объектом типа ссылки должен стоять амперсанд (&) – оператор взятия адреса (точно так же, как и для указателей):

// определено два объекта типа int
int ival = 1024, ival2 = 2048;

// определена одна ссылка и один объект
int &rval = ival, rval2 = ival2;

// определен один объект, один указатель и одна ссылка
int inal3 = 1024, *pi = ival3, &ri = ival3;

// определены две ссылки
int &rval3 = ival3, &rval4 = ival2;


// Константная ссылка 
// Константная ссылка может быть инициализирована объектом другого типа (если существует возможность преобразования одного типа в другой), а также безадресной величиной – такой, как литеральная константа:

double dval = 3.14159;

// верно только для константных ссылок
const int &ir = 1024;
const int &ir2 = dval;
const double &dr = dval + 1.0;


// Что касается объектов другого типа, то компилятор преобразует исходный объект в некоторый вспомогательный. Например, если мы пишем:

double dval = 1024;
const int &ri = dval;
// то компилятор преобразует это примерно так:
int temp = dval;
const int &ri = temp;

// Если бы мы могли присвоить новое значение ссылке ri, мы бы реально изменили не dval, а temp. Значение dval осталось бы тем же, что совершенно неочевидно. Поэтому компилятор запрещает такие действия, и единственная возможность проинициализировать ссылку объектом другого типа – объявить ее как const.

// Мы хотим определить ссылку на адрес константного объекта, но наш первый вариант вызывает ошибку компиляции:

const int ival = 1024;
// ошибка: нужна константная ссылка
int *&pi_ref = &ival;
 
// Попытка исправить дело добавлением спецификатора const тоже не проходит:
 
const int ival = 1024;
// все равно ошибка
const int *&pi_ref = &ival;

// pi_ref является ссылкой на константный указатель на объект типа int. А нам нужен неконстантный указатель на константный объект, поэтому правильной будет следующая запись:

const int ival = 1024;
// правильно
int *const &piref = &ival;


// Между ссылкой и указателем существуют два основных отличия. 
// Во-первых, ссылка обязательно должна быть инициализирована в месте своего определения. 
// Во-вторых, всякое изменение ссылки преобразует не ее, а тот объект, на который она ссылается. 

// Если мы пишем:

int *pi = 0;
// мы инициализируем указатель pi нулевым значением, а это значит, что pi не указывает ни на какой объект. 
// В то же время запись
const int &ri = 0;
// означает примерно следующее:
int temp = 0;
const int &ri = temp;

// Что касается операции присваивания, то в следующем примере:

int ival = 1024, ival2 = 2048;
int *pi = &ival, *pi2 = &ival2;
pi = pi2;
// переменная ival, на которую указывает pi, остается неизменной, а pi получает значение адреса переменной ival2. И pi, и pi2 и теперь указывают на один и тот же объект ival2.

// Если же мы работаем со ссылками:
 int &ri = ival, &ri2 = ival2;
 ri = ri2;
 // то само значение ival меняется, но ссылка ri по-прежнему адресует ival.

// В реальных С++ программах ссылки редко используются как самостоятельные объекты, обычно они употребляются в качестве формальных параметров функций:

// пример использования ссылок
// Значение возвращается в параметре next_value
// bool get_next_value( int &next_value );

// перегруженный оператор
// Matrix operator+( const Matrix&, const Matrix& );

// Как соотносятся самостоятельные объекты-ссылки и ссылки-параметры? Если мы пишем:
// int ival;
// while (get_next_value( ival )) ...

// это равносильно следующему определению ссылки внутри функции:
// int &next_value = ival;

// Ссылки в качестве параметров в функциях
// Ссылки чаще всего используются в качестве параметров в функциях. В этом контексте ссылка-параметр работает как псевдоним аргумента, а сам аргумент не копируется при передаче в параметр. Это в свою очередь улучшает производительность, если аргумент слишком большой или затратный для копирования.

// передача аргумента-указателя в функцию позволяет функции при разыменовании этого указателя напрямую изменять значение аргумента.

// Ссылки работают аналогично. Поскольку ссылка-параметр — это псевдоним аргумента, то функция, использующая ссылку-параметр, может изменять аргумент, переданный ей, также напрямую:
 
 
    int x = 7;
 
    std::cout << x << '\n';
 
    changeN(x); // обратите внимание, этот аргумент не обязательно должен быть ссылкой
 
    std::cout << x << '\n';

// Когда аргумент x передается в функцию, то параметр функции ref становится ссылкой на аргумент x. Это позволяет функции изменять значение x непосредственно через ref! Обратите внимание, переменная x не обязательно должна быть ссылкой.

// Передавайте аргументы в функцию через неконстантные ссылки-параметры, если они должны быть изменены функцией в дальнейшем.

// Основным недостатком использования неконстантных ссылок в качестве параметров в функциях является то, что аргумент должен быть неконстантным l-value (т.е. константой или литералом он быть не может). 

// Ссылки как более легкий способ доступа к данным
// Второе (гораздо менее используемое) применение ссылок заключается в более легком способе доступа к вложенным данным. Рассмотрим следующую структуру:

Other other;

// Предположим, что нам нужно работать с полем value1 структуры Something переменной other структуры Other. Обычно, доступ к этому полю осуществлялся бы через other.something.value1.

// если нам нужно неоднократно получать доступ к этому члену, ссылки предоставляют более легкий способ доступа к данным:

int &ref = other.something.value1;
// ref теперь может использоваться вместо other.something.value1
// Таким образом, следующие два стейтмента идентичны:
other.something.value1 = 7;
ref = 7;

// Ссылки позволяют сделать ваш код более чистым и понятным.
// Ссылка — это тот же указатель, который неявно разыменовывается при доступе к значению, на которое он указывает (ссылки реализованы с помощью указателей). Таким образом, в следующем коде:

int value = 7;
int *const ptr = &value;
int &ref = value;
// *ptr и ref обрабатываются одинаково. Т.е. это одно и то же:

*ptr = 7;
ref = 7;

// Поскольку ссылки должны быть инициализированы корректными объектами (они не могут быть нулевыми) и не могут быть изменены позже, то они, как правило, безопаснее указателей (так как риск разыменования нулевого указателя отпадает). Однако они немного ограничены в функциональности по сравнению с указателями.

// Если определенное задание может быть решено с помощью как ссылок, так и указателей, то лучше использовать ссылки. Указатели следует использовать только в тех ситуациях, когда ссылки являются недостаточно эффективными (например, при динамическом выделении памяти).

// Ссылки на указатели
// Так как ссылка не является объектом, то нельзя определить указатель на ссылку, однако можно определить ссылку на указатель. Через подобную ссылку можно изменять значение, на которое указывает указатель или изменять адрес самого указателя:

    int a = 10;
    int b = 6;
     
    int *p = 0;     // указатель
    int *&pRef = p;     // ссылка на указатель
    pRef = &a;          // через ссылку указателю p присваивается адрес переменной a
    std::cout << "p value=" << *p << std::endl;   // 10
    *pRef = 70;         // изменяем значение по адресу, на который указывает указатель
    std::cout << "a value=" << a << std::endl;    // 70
     
    pRef = &b;          // изменяем адрес, на который указывает указатель
    std::cout << "p value=" << *p << std::endl;   // 6
     
   return 0;

}
