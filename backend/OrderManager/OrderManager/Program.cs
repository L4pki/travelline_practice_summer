while (true)
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
    Console.Write( "Введите название товара: " );
    return Console.ReadLine();
}

static int GetCount()
{
    Console.Write( "Введите количество: " );
    return int.Parse( Console.ReadLine() );
}

static string GetName()
{
    Console.Write( "Введите ваше имя: " );
    return Console.ReadLine();
}

static string GetAddress()
{
    Console.Write( "Введите адрес доставки: " );
    return Console.ReadLine();
}

static bool GetConfirmation( string name, int count, string product, string address )
{
    Console.WriteLine( $"Здравствуйте, {name}, вы заказали {count} {product} на адрес {address}, все верно? (да/нет)" );
    string confirmation = Console.ReadLine();
    return confirmation.ToLower() == "да";
}

static void ProcessOrder( string name, string product, int count, string address )
{
    Console.WriteLine( $"{name}!\nВаш заказ {product} в количестве {count} оформлен!\nОжидайте доставку по адресу {address} к {DateTime.Now.AddDays( 3 ).ToShortDateString()}" );
}
