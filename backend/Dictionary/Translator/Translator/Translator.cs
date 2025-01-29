using InputOutput;

namespace EnRuTranslator;

public class Translator
{
    UserIO _userIO = new UserIO();
    private Dictionary<string, string> _translations;
    string fileName = "translations.txt";
    public Translator()
    {
        _translations = new Dictionary<string, string>();
        LoadTranslationsFromFile( fileName );
    }
    public void AddTranslation()
    {
        _userIO.InputWordAndTranslate();
        string input = Console.ReadLine();
        string[] words = input.Split( ',' );
        if ( input.Length < 2 )
        {
            _userIO.IncorrectData();
        }
        else if ( CheckingWordTranslation( words[ 0 ] ) || CheckingWordTranslation( words[ 1 ] ) )
        {
            _userIO.IncorrectData();
        }
        else
        {
            _translations[ words[ 0 ] ] = words[ 1 ];
            _translations[ words[ 1 ] ] = words[ 0 ];
            SaveTranslationsToFile( fileName );
        }
    }
    public void RemoveTranslation()
    {
        _userIO.DeleteWord();
        string wordToRemove = Console.ReadLine();
        if ( _translations.ContainsKey( wordToRemove ) )
        {
            _translations.Remove( _translations[ wordToRemove ] );
            _translations.Remove( wordToRemove );
            SaveTranslationsToFile( fileName );
        }
        else
        {
            _userIO.NoWord();
        }
    }
    public void ChangeTranslation()
    {
        _userIO.ChangedTranslate();
        string[] changeInput = Console.ReadLine().Split( ',' );
        if ( changeInput.Length < 2 )
        {
            _userIO.IncorrectData();
        }
        else if ( CheckingWordTranslation( changeInput[ 1 ] ) )
        {
            _userIO.IncorrectData();
        }
        else if ( _translations.ContainsKey( changeInput[ 0 ] ) )
        {
            _translations.Remove( _translations[ changeInput[ 0 ] ] );
            _translations.Remove( changeInput[ 0 ] );
            _translations[ changeInput[ 0 ] ] = changeInput[ 1 ];
            _translations[ changeInput[ 1 ] ] = changeInput[ 0 ];
            SaveTranslationsToFile( fileName );
        }
        else
        {
            _userIO.NoWord();
        }
    }
    public void Translate()
    {
        _userIO.WordToTranslate();
        string wordToTranslate = Console.ReadLine();
        if ( _translations.ContainsKey( wordToTranslate ) )
        {
            Console.WriteLine( _translations[ wordToTranslate ] );
        }
        else
        {
            _userIO.NoWord();
            _userIO.WantToTranslate();
            if ( string.Equals( Console.ReadLine(), "да", StringComparison.OrdinalIgnoreCase ) )
            {
                AddTranslation();
            }
        }
    }
    private void LoadTranslationsFromFile( string fileName )
    {
        if ( File.Exists( fileName ) )
        {
            string[] lines = File.ReadAllLines( fileName );
            foreach ( var line in lines )
            {
                string[] parts = line.Split( ',' );
                _translations[ parts[ 0 ] ] = parts[ 1 ];
            }
        }
    }
    private void SaveTranslationsToFile( string fileName )
    {
        using ( StreamWriter writer = new StreamWriter( fileName ) )
        {
            foreach ( var pair in _translations )
            {
                writer.WriteLine( $"{pair.Key}, {pair.Value}" );
                ;
            }
        }
    }
    private bool CheckingWordTranslation( string word )
    {
        if ( _translations.ContainsKey( word ) )
        {
            _userIO.TranslationAvaliable( word );
            return true;
        }
        return false;
    }
}
