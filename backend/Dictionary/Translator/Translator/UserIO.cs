namespace InputOutput;
public class UserIO
{
    public void InputCommand()
    {
        Console.WriteLine( "Введите код команды:\n (1)Добавить перевод\n (2)Удалить перевод\n (3)Изменить перевод\n (4)Перевести слово\n (5)Выйти" );
    }
    public void InputWordAndTranslate()
    {
        Console.WriteLine( "Введите слово и его перевод через запятую:" );
    }
    public void IncorrectData()
    {
        Console.WriteLine( "Введены некорректные данные!" );
    }
    public void DeleteWord()
    {
        Console.WriteLine( "Введите слово для удаления:" );
    }
    public void ChangedTranslate()
    {
        Console.WriteLine( "Введите слово и новый перевод через запятую:" );
    }
    public void WordToTranslate()
    {
        Console.WriteLine( "Введите слово для перевода:" );
    }
    public void TranslationOfWord()
    {
        Console.Write( "Введите перевод слова: " );
    }
    public void WantToTranslate()
    {
        Console.WriteLine( "Хотите добавить перевод? (да/нет)" );
    }
    public void UnknowCommand()
    {
        Console.WriteLine( "Неизвестная команда" );
    }
    public void NoWord()
    {
        Console.WriteLine( "Слова нет в словаре!" );
    }
    public void TranslationAvaliable( string word )
    {
        Console.WriteLine( $"Перевод данного слова {word} уже существует!" );
    }
}
