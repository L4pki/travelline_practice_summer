using EnRuTranslator;
using InputOutput;
class Programm
{
    static void Main()
    {
        UserIO _userIO = new UserIO();
        Translator translator = new Translator();
        bool isProgrammWorking = true;
        while ( isProgrammWorking )
        {
            _userIO.InputCommand();
            string command = Console.ReadLine();

            switch ( command )
            {
                case "1":
                    translator.AddTranslation();
                    break;
                case "2":
                    translator.RemoveTranslation();
                    break;
                case "3":
                    translator.ChangeTranslation();
                    break;
                case "4":
                    translator.Translate();
                    break;
                case "5":
                    isProgrammWorking = false;
                    break;
                default:
                    _userIO.UnknowCommand();
                    break;
            }
        }
    }
}