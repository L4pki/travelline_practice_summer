while ( true )
{
    string product = GetProduct();
    int count = GetCount();
    string name = GetName();
    string address = GetAddress();

    bool isConfirmed = GetConfirmation( name, count, product, address );
    if ( isConfirmed )
    {
        ProcessOrder( name, product, count, address );
    }
    else
    {
        Console.WriteLine( "Пожалуйста, введите данные заново." );
    }
}

static string GetProduct()
{
    while ( true )
    {
        Console.Write( "Введите название товара: " );
        string product = Console.ReadLine();
        if ( !string.IsNullOrWhiteSpace( product ) )
        {
            return product;
        }
        Console.WriteLine( "Вы не указали название продукта!" );
    }
}

static int GetCount()
{
    int count;
    bool isValid;

    do
    {
        Console.Write( "Введите количество: " );
        string input = Console.ReadLine();
        isValid = int.TryParse( input, out count );

        if ( !isValid )
        {
            Console.WriteLine( "Введено некорректное значение. Пожалуйста, введите целое число." );
        }
    } while ( !isValid );
    return count;
}

static string GetName()
{
    while ( true )
    {
        Console.Write( "Введите ваше имя: " );
        string name = Console.ReadLine();
        if ( !string.IsNullOrWhiteSpace( name ) )
        {
            return name;
        }
        Console.WriteLine( "Вы не указали имя!" );
    }
}

static string GetAddress()
{
    while ( true )
    {
        Console.Write( "Введите адрес доставки: " );
        string addres = Console.ReadLine();
        if ( !string.IsNullOrWhiteSpace( addres ) )
        {
            return addres;
        }
        Console.WriteLine( "Адрес не может быть пустым!" );
    }
}

static bool GetConfirmation( string name, int count, string product, string address )
{
    Console.WriteLine( $"Здравствуйте, {name}, вы заказали {count} {product} на адрес {address}, все верно? (да/нет)" );
    string confirmation = Console.ReadLine();
    return string.Equals( confirmation, "да", StringComparison.OrdinalIgnoreCase );
}

static void ProcessOrder( string name, string product, int count, string address )
{
    Console.WriteLine( $"{name}!\nВаш заказ {product} в количестве {count} оформлен!\nОжидайте доставку по адресу {address} к {DateTime.Now.AddDays( 3 ).ToShortDateString()}" );
}
